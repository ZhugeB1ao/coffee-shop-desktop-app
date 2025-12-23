using CoffeeShop.BUS;
using CoffeeShop.DTO;
using CoffeeShop.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    /// <summary>
    /// Inventory/Category Management Form: Allows managing Categories and Products.
    /// </summary>
    public partial class IngredientManagementForm : Form
    {
        CategoryService categoryService = new CategoryService();
        ProductService productService = new ProductService();
        private byte[]? currentImageBytes = null; // Stores the byte array of the currently selected image.

        public IngredientManagementForm()
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);
            
            // Customize colors for the TabControl.
            tabControlIngredient.BackColor = UIHelper.BackColor;
            foreach (TabPage tab in tabControlIngredient.TabPages)
            {
                tab.BackColor = UIHelper.BackColor;
                tab.ForeColor = UIHelper.TextBodyColor;
            }
            textBoxProductImagePath.Enabled = false; // Only display the filename, direct input disabled.
            textBoxCategoryID.Enabled = false;

            LoadCategoryGrid();
            SetCategoryButtonState(false);
            SetProductButtonState(false);
        }

        private void IngredientManagementForm_Load(object sender, EventArgs e)
        {
        }

        // Automatically reload corresponding data when switching between 'Category' and 'Product' tabs.
        private void tabControlIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControlIngredient.SelectedTab;
            if (selectedTab == tabPageProduct)
            {
                LoadProducts();
                LoadCategories(); // Load onto the TreeView.
                LoadCategoryToComboBox(); // Load onto the ComboBox for selection when adding/editing products.
            }
            else
            {
                LoadCategoryGrid();
            }
        }

        // ==========================================
        // QUẢN LÝ DANH MỤC (CATEGORY)
        // ==========================================

        private void LoadCategoryGrid()
        {
            dataGridViewCategory.DataSource = null;
            dataGridViewCategory.DataSource = categoryService.GetAll();

            if (dataGridViewCategory.Columns.Contains("Enable"))
            {
                dataGridViewCategory.Columns["Enable"].Visible = false;
            }
        }

        // Adds a new category.
        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = textBoxCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Tên danh mục không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (categoryService.IsNameExists(categoryName))
            {
                MessageBox.Show("Tên danh mục này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category c = new Category() { Name = categoryName };
            categoryService.Add(c);
            LoadCategoryGrid();
            ClearCategoryForm();
        }

        // Deletes a category (Soft Delete).
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCategoryID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            if (!Confirm("Bạn có chắc chắn muốn xóa danh mục này?"))
                return;

            int id = int.Parse(textBoxCategoryID.Text);
            categoryService.Delete(id);

            LoadCategoryGrid();
            ClearCategoryForm();
            MessageBox.Show("Xóa danh mục thành công!");
        }

        // Updates the category name.
        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCategoryID.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            Category c = new Category()
            {
                Id = int.Parse(textBoxCategoryID.Text),
                Name = textBoxCategoryName.Text
            };

            categoryService.Update(c);
            LoadCategoryGrid();
            ClearCategoryForm();
        }

        // Searches for categories.
        private void buttonFindCategory_Click(object sender, EventArgs e)
        {
            string keyword = textBoxFindCategory.Text.Trim();
            dataGridViewCategory.DataSource = categoryService.FindByName(keyword);
        }

        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewCategory.Rows[e.RowIndex];
            textBoxCategoryID.Text = row.Cells["Id"].Value?.ToString();
            textBoxCategoryName.Text = row.Cells["Name"].Value?.ToString();

            SetCategoryButtonState(true);
        }

        // ==========================================
        // QUẢN LÝ SẢN PHẨM (PRODUCT)
        // ==========================================

        // Displays the product list as a photo gallery in the ListView.
        private void LoadProducts(List<Product> products)
        {
            listViewProduct.Items.Clear();
            listViewProduct.LargeImageList.Images.Clear();

            foreach (var p in products)
            {
                Image img;
                try
                {
                    if (p.Image != null && p.Image.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(p.Image))
                        {
                            img = Image.FromStream(ms);
                        }
                    }
                    else img = Properties.Resources.placeholder;
                }
                catch { img = Properties.Resources.placeholder; }

                listViewProduct.LargeImageList.Images.Add(p.Id.ToString(), img);

                ListViewItem item = new ListViewItem
                {
                    Text = p.Name,
                    ImageKey = p.Id.ToString()
                };
                item.Tag = p.Id;
                listViewProduct.Items.Add(item);
            }
        }

        private void LoadProducts()
        {
            LoadProducts(productService.GetAll());
        }

        // Displays categories in the left TreeView for product filtering.
        private void LoadCategories()
        {
            List<Category> categories = categoryService.GetAll();

            treeViewCategory.Nodes.Clear();
            foreach (var category in categories)
            {
                TreeNode node = new TreeNode(category.Name);
                node.Tag = category.Id;
                treeViewCategory.Nodes.Add(node);
            }
            treeViewCategory.ExpandAll();
        }

        // Filters products when a category is selected from the TreeView.
        private void treeViewCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in treeViewCategory.Nodes)
            {
                node.NodeFont = treeViewCategory.Font;
            }

            e.Node.NodeFont = new Font(treeViewCategory.Font, FontStyle.Bold);
            e.Node.Text = e.Node.Text;

            int categoryId = (int)e.Node.Tag;
            List<Product> products = productService.GetAllByCategoryID(categoryId);
            LoadProducts(products);
            ClearProductForm();
        }

        private void LoadCategoryToComboBox()
        {
            var categories = categoryService.GetAll();
            comboBoxCategoryName.DataSource = categories;
            comboBoxCategoryName.DisplayMember = "Name";
            comboBoxCategoryName.ValueMember = "Id";
        }

        // Displays product information when a ListView item is clicked.
        private void listViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProduct.SelectedItems.Count == 0) return;

            int id = (int)listViewProduct.SelectedItems[0].Tag;
            Product p = productService.GetByID(id);
            if (p == null) return;

            textBoxProductID.Text = p.Id.ToString();
            textBoxProductName.Text = p.Name;
            comboBoxCategoryName.SelectedValue = p.IdCategory;
            numericUpDownProductPrice.Value = p.Price.HasValue ? p.Price.Value : 0;

            currentImageBytes = p.Image;
            if (p.Image != null && p.Image.Length > 0)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(p.Image))
                    {
                        pictureBoxProductImage.Image = Image.FromStream(ms);
                    }
                    textBoxProductImagePath.Text = "[Ảnh từ database]";
                }
                catch
                {
                    pictureBoxProductImage.Image = null;
                    textBoxProductImagePath.Text = "";
                }
            }
            else
            {
                pictureBoxProductImage.Image = null;
                textBoxProductImagePath.Text = "";
            }

            SetProductButtonState(true);
        }

        // Adds a new product along with an image.
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Tên sản phẩm không được trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productService.IsNameExists(productName))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product p = new Product()
            {
                Name = productName,
                IdCategory = (int)comboBoxCategoryName.SelectedValue,
                Price = numericUpDownProductPrice.Value,
                Image = currentImageBytes
            };

            productService.Add(p);
            LoadProducts();
            ClearProductForm();
        }

        // Deletes a product.
        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            if (!Confirm("Bạn có chắc chắn muốn xóa sản phẩm này?"))
                return;

            int id = int.Parse(textBoxProductID.Text);
            productService.Delete(id);

            LoadProducts();
            MessageBox.Show("Xóa sản phẩm thành công!");
        }

        // Updates product information and image.
        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            Product p = new Product()
            {
                Id = int.Parse(textBoxProductID.Text),
                Name = textBoxProductName.Text,
                IdCategory = (int)comboBoxCategoryName.SelectedValue,
                Price = numericUpDownProductPrice.Value,
                Image = currentImageBytes
            };

            productService.Update(p);
            LoadProducts();
            ClearProductForm();
        }

        // Searches for products.
        private void buttonFindProduct_Click(object sender, EventArgs e)
        {
            string keyword = textBoxFindProduct.Text;
            var products = productService.Search(keyword);
            LoadProducts(products);
        }

        // Uploads an image from the computer.
        private void buttonProductUpLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFile.FileName;
                    currentImageBytes = File.ReadAllBytes(filePath);
                    pictureBoxProductImage.Image = Image.FromFile(filePath);
                    textBoxProductImagePath.Text = Path.GetFileName(filePath);
                }
            }
        }

        private bool Confirm(string message)
        {
            return MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void SetCategoryButtonState(bool categorySelected)
        {
            buttonAddCategory.Enabled = !categorySelected;
            buttonDeleteCategory.Enabled = categorySelected;
            buttonUpdateCategory.Enabled = categorySelected;
            buttonClearCategoryInfo.Enabled = categorySelected;
        }

        private void ClearCategoryForm()
        {
            textBoxCategoryID.Clear();
            textBoxCategoryName.Clear();
            SetCategoryButtonState(false);
        }

        private void buttonClearCategoryInfo_Click(object sender, EventArgs e)
        {
            ClearCategoryForm();
        }

        private void SetProductButtonState(bool productSelected)
        {
            buttonAddProduct.Enabled = !productSelected;
            buttonDeleteProduct.Enabled = productSelected;
            buttonUpdateProduct.Enabled = productSelected;
            buttonClearProductInfo.Enabled = productSelected;
        }

        private void ClearProductForm()
        {
            textBoxProductID.Clear();
            textBoxProductName.Clear();
            numericUpDownProductPrice.Value = 0;
            textBoxProductImagePath.Clear();
            pictureBoxProductImage.Image = null;
            currentImageBytes = null;
            if (comboBoxCategoryName.Items.Count > 0)
                comboBoxCategoryName.SelectedIndex = 0;
            SetProductButtonState(false);
        }

        private void buttonClearProductInfo_Click(object sender, EventArgs e)
        {
            ClearProductForm();
        }
    }
    }
}
