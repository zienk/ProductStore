using DataAccessLayer.Models;
using Services.Implements;
using Services.Interfaces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public MainWindow()
        {
            InitializeComponent();
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        public void LoadCategoryList()
        {
            try
            {
                var listCategories = _categoryService.GetCategories();
                cboCategory.ItemsSource = listCategories;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var listProducts = _productService.GetProducts();
                dgData.ItemsSource = listProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");
            }
            finally
            {
                ResetInput();
            }
        }

        private void ResetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = txtProductName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                product.CategoryId = int.Parse(cboCategory.SelectedValue.ToString());

                _productService.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on create product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = int.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = int.Parse(cboCategory.SelectedValue.ToString());

                    _productService.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on update product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = int.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = int.Parse(cboCategory.SelectedValue.ToString());

                    _productService.DeleteProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on delete product");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            
            // Kiểm tra xem có item nào được chọn không
            if (dataGrid.SelectedItem == null)
                return;
            
            // Sử dụng SelectedItem thay vì SelectedIndex
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            
            // Kiểm tra row có null không
            if (row == null)
                return;
            
            var cellContent = dataGrid.Columns[0].GetCellContent(row);
            if (cellContent == null)
                return;
                
            DataGridCell rowColumn = cellContent.Parent as DataGridCell;
            if (rowColumn == null)
                return;
                
            string id = ((TextBlock)rowColumn.Content).Text;
            Product product = _productService.GetProductById(int.Parse(id));
            
            txtProductID.Text = product.ProductId.ToString();
            txtProductName.Text = product.ProductName;
            txtPrice.Text = product.UnitPrice.ToString();
            txtUnitsInStock.Text = product.UnitsInStock.ToString();
            cboCategory.SelectedValue = product.CategoryId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        //Cách 2
        //private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DataGrid dataGrid = sender as DataGrid;

        //    // Sử dụng trực tiếp SelectedItem
        //    if (dataGrid.SelectedItem is Product selectedProduct)
        //    {
        //        txtProductID.Text = selectedProduct.ProductId.ToString();
        //        txtProductName.Text = selectedProduct.ProductName;
        //        txtPrice.Text = selectedProduct.UnitPrice.ToString();
        //        txtUnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
        //        cboCategory.SelectedValue = selectedProduct.CategoryId;
        //    }
        //}

    }
}