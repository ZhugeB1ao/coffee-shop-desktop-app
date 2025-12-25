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
        // ---------------------------------------------------------
        // Fields and Dependencies
        // ---------------------------------------------------------
        private CategoryService categoryService = new CategoryService();
        private ProductService productService = new ProductService();

        // Stores the byte array of the currently selected product image.
        private byte[]? currentImageBytes = null;

        // ---------------------------------------------------------
        // Initialization
        // ---------------------------------------------------------
        public IngredientManagementForm()
        {
            InitializeComponent();
            UIHelper.ApplyModernStyle(this);

            // Apply theme colors to the TabControl.
            tabControlIngredient.BackColor = UIHelper.BackColor;
            foreach (TabPage tab in tabControlIngredient.TabPages)
            {
                tab.BackColor = UIHelper.BackColor;
                tab.ForeColor = UIHelper.TextBodyColor;
            }

            // Configure control basic properties.
            textBoxProductImagePath.Enabled = false; // Path is shown for notification only.
            textBoxCategoryID.Enabled = false;       // ID is system-generated.

            // Initial data load for Category tab.
            LoadCategoryGrid();
            SetCategoryButtonState(false);
            SetProductButtonState(false);
        }

        private void IngredientManagementForm_Load(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------
        // Core Tab Logic
        // ---------------------------------------------------------

        // Automatically reloads relevant data when switching between 'Category' and 'Product' tabs.
        private void tabControlIngredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControlIngredient.SelectedTab;
            if (selectedTab == tabPageProduct)
            {
                LoadProducts();           // Load product list for display in ListView.
                LoadCategories();         // Update Category tree filter.
                LoadCategoryToComboBox(); // Refresh selection list in Product edit form.
            }
            else
            {
                LoadCategoryGrid();       // Refresh category list in GridView.
            }
        }

        // =========================================================
        // CATEGORY MANAGEMENT
        // =========================================================

        // ---------------------------------------------------------
        // Category Data Loading
        // ---------------------------------------------------------

        // Fetches categories and displays them in the DataGridView.
        private void LoadCategoryGrid()
        {
            dataGridViewCategory.DataSource = null;
            dataGridViewCategory.DataSource = categoryService.GetAll();

            if (dataGridViewCategory.Columns.Contains("Enable"))
            {
                dataGridViewCategory.Columns["Enable"].Visible = false;
            }
        }

        // Populates the category selector ComboBox in the Product tab.
        private void LoadCategoryToComboBox()
        {
            var categories = categoryService.GetAll();
            comboBoxCategoryName.DataSource = categories;
            comboBoxCategoryName.DisplayMember = "Name";
            comboBoxCategoryName.ValueMember = "Id";
        }

        // ---------------------------------------------------------
        // Category UI Event Handlers
        // ---------------------------------------------------------

        // Adds a new product category after validating naming rules.
        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = textBoxCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category name cannot be empty!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (categoryService.IsNameExists(categoryName))
            {
                MessageBox.Show("This category name already exists!", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category c = new Category() { Name = categoryName };
            categoryService.Add(c);
            LoadCategoryGrid();
            ClearCategoryForm();
        }

        // Performs a logical deletion of the selected category.
        private void buttonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCategoryID.Text))
            {
                MessageBox.Show("Please select a category first!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Confirm("Are you sure you want to delete this category?"))
                return;

            int id = int.Parse(textBoxCategoryID.Text);
            categoryService.Delete(id);

            LoadCategoryGrid();
            ClearCategoryForm();
        }

        // Updates the properties of an existing category.
        private void buttonUpdateCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCategoryID.Text))
            {
                MessageBox.Show("Please select a category to update!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Filters categories based on the search keyword.
        private void buttonFindCategory_Click(object sender, EventArgs e)
        {
            string keyword = textBoxFindCategory.Text.Trim();
            dataGridViewCategory.DataSource = categoryService.FindByName(keyword);
        }

        // Populates category fields when a row is selected in the grid.
        private void dataGridViewCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewCategory.Rows[e.RowIndex];
            textBoxCategoryID.Text = row.Cells["Id"].Value?.ToString();
            textBoxCategoryName.Text = row.Cells["Name"].Value?.ToString();

            SetCategoryButtonState(true);
        }

        // Resets category input fields.
        private void buttonClearCategoryInfo_Click(object sender, EventArgs e)
        {
            ClearCategoryForm();
        }

        // =========================================================
        // PRODUCT MANAGEMENT
        // =========================================================

        // ---------------------------------------------------------
        // Product Data Loading (ListView / Gallery)
        // ---------------------------------------------------------

        // Renders a specific list of products as a gallery in the ListView.
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

        // Reloads the entire product library.
        private void LoadProducts()
        {
            LoadProducts(productService.GetAll());
        }

        // Populates the filtering TreeView with current categories.
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

        // ---------------------------------------------------------
        // Product UI Event Handlers
        // ---------------------------------------------------------

        // Filters the product gallery based on the category selected in the TreeView.
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

        // Displays full product details when an item is selected in the gallery.
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
                    textBoxProductImagePath.Text = "[Database Image]";
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

        // Validates and adds a new product to the library.
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product name cannot be empty!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (productService.IsNameExists(productName))
            {
                MessageBox.Show("A product with this name already exists!", "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Removes the selected product from the inventory.
        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductID.Text))
            {
                MessageBox.Show("Please select a product to delete!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Confirm("Are you sure you want to delete this product?"))
                return;

            int id = int.Parse(textBoxProductID.Text);
            productService.Delete(id);

            LoadProducts();
            ClearProductForm();
            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Commits changes to product properties or its associated image.
        private void buttonUpdateProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductID.Text))
            {
                MessageBox.Show("Please select a product to update!", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // Filters the product list based on a text string.
        private void buttonFindProduct_Click(object sender, EventArgs e)
        {
            string keyword = textBoxFindProduct.Text;
            var products = productService.Search(keyword);
            LoadProducts(products);
        }

        // Launches a file dialog to choose a local image for the product.
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

        // Resets product input fields.
        private void buttonClearProductInfo_Click(object sender, EventArgs e)
        {
            ClearProductForm();
        }

        // ---------------------------------------------------------
        // Helper Methods
        // ---------------------------------------------------------

        // Displays a standard confirmation prompt.
        private bool Confirm(string message)
        {
            return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // Switches button availability based on category selection.
        private void SetCategoryButtonState(bool categorySelected)
        {
            buttonAddCategory.Enabled = !categorySelected;
            buttonDeleteCategory.Enabled = categorySelected;
            buttonUpdateCategory.Enabled = categorySelected;
            buttonClearCategoryInfo.Enabled = categorySelected;
        }

        // Internal method to clear category fields.
        private void ClearCategoryForm()
        {
            textBoxCategoryID.Clear();
            textBoxCategoryName.Clear();
            SetCategoryButtonState(false);
        }

        // Switches button availability based on product selection.
        private void SetProductButtonState(bool productSelected)
        {
            buttonAddProduct.Enabled = !productSelected;
            buttonDeleteProduct.Enabled = productSelected;
            buttonUpdateProduct.Enabled = productSelected;
            buttonClearProductInfo.Enabled = productSelected;
        }

        // Internal method to reset product form state.
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

        private void textBoxFindProduct_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
