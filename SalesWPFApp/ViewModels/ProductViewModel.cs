using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SalesWPFApp.ViewModels;
using DataAccess.Repository;
using System.Windows;

namespace SalesWPFApp.ViewModels
{
    public class ProductViewModel:BaseViewModel
    {
        private IProductRepository _ProductRepository = new ProductRepository();
        private IEnumerable<Product> _ProductList;
        public IEnumerable<Product> ProductList { get=> _ProductList; set { _ProductList = value; OnPropertyChanged(); } }

        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct;
            set
            {
                _SelectedProduct = value;
                OnPropertyChanged();
                if (SelectedProduct != null)
                {
                    ProductName = SelectedProduct.ProductName;
                    CategoryId = SelectedProduct.CategoryId;
                    Weight = SelectedProduct.Weight;
                    UnitPrice = SelectedProduct.UnitPrice;
                    UnitStock = SelectedProduct.UnitStock;
                }
            }
        }

        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private int _CategoryId;
        public int CategoryId { get => _CategoryId; set { _CategoryId = value; OnPropertyChanged(); } }

        private string _Weight;
        public string Weight { get => _Weight; set { _Weight = value; OnPropertyChanged(); } }

        private decimal _UnitPrice;
        public decimal UnitPrice { get => _UnitPrice; set { _UnitPrice = value; OnPropertyChanged(); } }

        private int _UnitStock;
        public int UnitStock { get => _UnitStock; set { _UnitStock = value; OnPropertyChanged(); } }

        private string _Key;
        public string Key { get => _Key; set { _Key = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }



        public ProductViewModel()
        {
            LoadProductList();

            // Add item
            AddCommand = new RelayCommand<object>((p) => {
                if (string.IsNullOrEmpty(ProductName) || CategoryId == null || string.IsNullOrEmpty(Weight) || UnitPrice == null || UnitStock == null)
                {
                    //MessageBox.Show("Please complete all field data!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                var productCount = _ProductRepository.ProductCount(ProductName);
                if (productCount > 0)
                {
                    //MessageBox.Show("Product already exists, please try again!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }, (p) => {
                _ProductRepository.Create(new Product { ProductName = ProductName, CategoryId = CategoryId, Weight=Weight,UnitPrice = UnitPrice, UnitStock = UnitStock});
                MessageBox.Show($"Product: {ProductName} is created successfully", "Add Product");
                LoadProductList();
            });


            // Edit item
            EditCommand = new RelayCommand<object>((p) => {
                if (SelectedProduct == null || string.IsNullOrEmpty(ProductName) || CategoryId == null || string.IsNullOrEmpty(Weight) || UnitPrice == null || UnitStock == null)
                {
                    //MessageBox.Show("Please complete all field data!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;

            }, (p) => {
                _ProductRepository.Update(SelectedProduct.ProductId, (new Product { ProductName = ProductName, CategoryId = CategoryId, Weight = Weight, UnitPrice = UnitPrice, UnitStock = UnitStock }));
                MessageBox.Show($"Product: {ProductName} is Updated successfully", "Update Product");
                LoadProductList();
            });

            // Remove Item
            DeleteCommand = new RelayCommand<object>((p) => {
                if (SelectedProduct == null)
                {
                    return false;
                }
                return true;
            }, (p) => {
                _ProductRepository.Remove(SelectedProduct.ProductId);
                MessageBox.Show($"Account: {ProductName} is Removed successfully", "Remove Member");
                LoadProductList();
            });

            // Search item
            SearchCommand = new RelayCommand<object>((p) => {
                if (Key == null)
                {
                    return false;
                }
                return true;
            }, (p) => {
                ProductList = _ProductRepository.ReadKey(Key);
            });
        }

        void LoadProductList()
        {
           ProductList = _ProductRepository.ReadAll();
        }

    }
}
