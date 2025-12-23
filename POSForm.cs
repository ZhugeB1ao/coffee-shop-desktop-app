using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.BUS;
using CoffeeShop.DAO;
using CoffeeShop.DTO;
using CoffeeShop.Helper;

namespace CoffeeShop
{
    /// <summary>
    /// Sales Form (POS): Main screen for ordering, switching tables, and payment.
    /// </summary>
    public partial class POSForm : Form
    {
        TableService tableService = new TableService();
        BillService billService = new BillService();
        BillInfoService billInfoService = new BillInfoService();
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        CouponService couponService = new CouponService();

        private int currentTableId = 0; // ID of the currently selected table
        private int currentBillId = 0;  // ID of the table's current bill
        private Button? currentSelectedButton = null; // The UI button for the currently selected table

        public POSForm()
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            LoadTable();       // Load the list of tables
            LoadCategories();  // Load product categories
            LoadEmptyTable();  // Load free tables (for table switching)
            LoadCoupons();     // Load discount coupons
        }

        private void POSForm_Load(object sender, EventArgs e)
        {

        }

        // Create table buttons based on database data.
        private void LoadTable()
        {
            var tables = tableService.GetAll();
            flowLayoutPanelTable.Controls.Clear();
            foreach (var table in tables)
            {
                Button btn = new Button()
                {
                    Width = 150,
                    Height = 150,
                    Text = table.Name + Environment.NewLine + table.Status,
                    BackColor = table.Status.ToLower() == "free" ? Color.FromArgb(200, 190, 180) : Color.FromArgb(120, 60, 20),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = table
                };
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(80, 40, 0);
                btn.Click += Btn_Click;
                flowLayoutPanelTable.Controls.Add(btn);

                // If this is the currently selected table, highlight it (used on reload).
                if (table.Id == currentTableId)
                {
                    btn.BackColor = UIHelper.SecondaryColor;
                    btn.FlatAppearance.BorderSize = 2;
                    currentSelectedButton = btn;
                }
            }
        }

        // Load categories into the ComboBox.
        private void LoadCategories()
        {
            var categories = categoryService.GetAll();
            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Name";
        }

        // Load products based on the selected category.
        private void LoadProduct()
        {
            if (comboBoxCategory.SelectedItem == null) return;
            var selectedCategory = comboBoxCategory.SelectedItem as Category;
            var products = productService.GetAllByCategoryID(selectedCategory.Id);
            comboBoxProduct.DataSource = products;
            comboBoxProduct.DisplayMember = "Name";
        }

        // Load the list of free tables for the switching feature.
        private void LoadEmptyTable()
        {
            var emptyTables = tableService.GetAllFree();
            comboBoxSwitchTable.DataSource = emptyTables;
            comboBoxSwitchTable.DisplayMember = "Name";
        }

        // Handles the table button click event.
        private void Btn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            Table table = btn.Tag as Table;
            if (table == null) return;

            // Reset the previous button's color.
            if (currentSelectedButton != null && currentSelectedButton != btn)
            {
                Table prevTable = currentSelectedButton.Tag as Table;
                if (prevTable != null)
                {
                    currentSelectedButton.BackColor = prevTable.Status.ToLower() == "free" ? Color.FromArgb(200, 190, 180) : Color.FromArgb(120, 60, 20);
                    currentSelectedButton.FlatAppearance.BorderSize = 1;
                }
            }

            // Highlight the newly selected table.
            btn.BackColor = UIHelper.SecondaryColor;
            btn.FlatAppearance.BorderSize = 2;
            currentSelectedButton = btn;

            currentTableId = table.Id;

            // Check if this table has an unpaid bill.
            var bill = billService.GetBillByTableId(currentTableId);

            if (bill != null)
                currentBillId = bill.Id;
            else
                currentBillId = 0;

            // Display the bill's item details.
            LoadBillInfoIntoListView(currentBillId);
            CountToTal();
        }

        // Reload products when the category changes.
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct();
            if (comboBoxProduct.Items.Count > 0)
                comboBoxProduct.SelectedIndex = 0;
            else
                comboBoxProduct.DataSource = null;
        }

        // Display bill details in the ListView.
        private void LoadBillInfoIntoListView(int billId)
        {
            listViewBillInfo.Items.Clear();
            imageListProduct.Images.Clear();

            var billInfos = billInfoService.GetByBillId(billId);

            foreach (var billInfo in billInfos)
            {
                var product = productService.GetByID(billInfo.IdProduct);
                if (product == null) continue;

                // Process product image display (with placeholder fallback).
                Image img;
                try
                {
                    if (product.Image != null && product.Image.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(product.Image))
                        {
                            img = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        img = Properties.Resources.placeholder;
                    }
                }
                catch
                {
                    img = Properties.Resources.placeholder;
                }

                imageListProduct.Images.Add(product.Id.ToString(), img);

                // Format prices in USD (synced with sample data).
                string priceUSD = product.Price.Value.ToString("C", new System.Globalization.CultureInfo("en-US"));
                decimal totalItemPrice = product.Price.Value * billInfo.Count;
                string totalItemUSD = totalItemPrice.ToString("C", new System.Globalization.CultureInfo("en-US"));

                ListViewItem item = new ListViewItem(product.Name);
                item.ImageKey = product.Id.ToString();
                item.SubItems.Add(priceUSD);
                item.SubItems.Add(billInfo.Count.ToString());
                item.SubItems.Add(totalItemUSD);

                listViewBillInfo.Items.Add(item);
            }
        }

        // Calculate totals and apply discounts.
        private void CountToTal()
        {
            decimal subtotal = 0;
            foreach (ListViewItem item in listViewBillInfo.Items)
            {
                string priceText = item.SubItems[1].Text;
                int count = int.Parse(item.SubItems[2].Text);
                decimal price = decimal.Parse(priceText, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"));
                subtotal += price * count;
            }

            decimal discount = 0;
            if (comboBoxCoupon.SelectedItem is Coupon selectedCoupon)
            {
                discount = selectedCoupon.DiscountValue;
            }

            decimal finalTotal = subtotal - discount;
            if (finalTotal < 0) finalTotal = 0;

            textBoxCost.Text = subtotal.ToString("C", new System.Globalization.CultureInfo("en-US"));
            textBoxDiscount.Text = discount.ToString("C", new System.Globalization.CultureInfo("en-US"));
            textBoxTotal.Text = finalTotal.ToString("C", new System.Globalization.CultureInfo("en-US"));
        }

        // Adds an item to a table.
        private void buttonAddCoffee_Click(object sender, EventArgs e)
        {
            if (comboBoxProduct.SelectedItem == null) return;
            if (currentTableId == 0) return;

            int addQty = (int)numericUpDownAdd.Value;
            if (addQty == 0) return;

            var selectedProduct = comboBoxProduct.SelectedItem as Product;
            if (selectedProduct == null) return;

            // If the table has no bill, create a new one and set status to 'Occupied'.
            if (currentBillId == 0)
            {
                if (addQty > 0)
                {
                    billService.CreateBill(currentTableId);
                    var bill = billService.GetBillByTableId(currentTableId);
                    currentBillId = bill.Id;
                    
                    tableService.SetStatus(currentTableId, "Occupied");
                    
                    LoadTable();
                    LoadEmptyTable();
                }
                else return;
            }

            // Update bill info: Add new item or update quantity.
            var existingBillInfo = billInfoService.GetByBillIdAndProductId(currentBillId, selectedProduct.Id);

            if (existingBillInfo != null)
            {
                existingBillInfo.Count += addQty;
                if (existingBillInfo.Count <= 0)
                    billInfoService.Delete(existingBillInfo.Id);
                else
                    billInfoService.Update(existingBillInfo);
            }
            else
            {
                if (addQty > 0)
                {
                    BillInfo newBillInfo = new BillInfo
                    {
                        IdBill = currentBillId,
                        IdProduct = selectedProduct.Id,
                        Count = addQty
                    };
                    billInfoService.Add(newBillInfo);
                }
            }

            LoadBillInfoIntoListView(currentBillId);
            CountToTal();
        }

        // Process bill payment.
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            if (currentBillId == 0) return;

            decimal finalTotal = 0;
            if (!decimal.TryParse(textBoxTotal.Text, System.Globalization.NumberStyles.Currency, new System.Globalization.CultureInfo("en-US"), out finalTotal))
            {
                MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string finalTotalUSD = finalTotal.ToString("C", new System.Globalization.CultureInfo("en-US"));

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn thanh toán {finalTotalUSD} cho bàn này?",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                billService.PayBill(currentBillId, (float)finalTotal);
                // After payment, automatically update table status to 'Free'.
                tableService.UpdateStatusBasedOnBill(currentTableId, billService);

                listViewBillInfo.Items.Clear();
                textBoxCost.Text = "$0.00";
                textBoxDiscount.Text = "$0.00";
                textBoxTotal.Text = "$0.00";
                
                if (comboBoxCoupon.Items.Count > 0)
                    comboBoxCoupon.SelectedIndex = 0;

                LoadTable();
                LoadEmptyTable();
            }
        }

        // Table switch: Move all items from the old table to the new one.
        private void buttonSwitchTable_Click(object sender, EventArgs e)
        {
            if (currentBillId == 0) return;
            if (comboBoxSwitchTable.SelectedItem == null) return;

            var newTable = comboBoxSwitchTable.SelectedItem as Table;
            if (newTable == null) return;

            var bill = billService.GetById(currentBillId);
            if (bill != null)
            {
                int oldTableId = bill.IdTable;

                bill.IdTable = newTable.Id;
                billService.Update(bill);

                // Update both tables' statuses (Old to Free, New to Occupied).
                tableService.UpdateStatusBasedOnBill(oldTableId, billService);
                tableService.UpdateStatusBasedOnBill(newTable.Id, billService);

                currentTableId = newTable.Id;

                LoadTable();
                LoadBillInfoIntoListView(currentBillId);
                CountToTal();
                LoadEmptyTable();
            }
        }

        // Recalculate total when the coupon changes.
        private void comboBoxCoupon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountToTal();
        }

        // Load discount coupons.
        private void LoadCoupons()
        {
            var coupons = couponService.GetAll();
            var couponList = new List<Coupon>();
            couponList.Add(new Coupon { Id = 0, Code = "-- Không chọn --", DiscountValue = 0 });
            couponList.AddRange(coupons);

            comboBoxCoupon.DataSource = couponList;
            comboBoxCoupon.DisplayMember = "Code";
            comboBoxCoupon.SelectedIndex = 0;
        }
    }
}
