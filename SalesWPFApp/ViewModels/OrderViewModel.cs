﻿using BusinessObject;

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
    public class OrderViewModel:BaseViewModel
    {
        public Member User { get; set; }

        private IProductRepository _ProductRepository = new ProductRepository();
        private IEnumerable<Product> _ProductList;
        public IEnumerable<Product> ProductList { get => _ProductList; set { _ProductList = value; OnPropertyChanged(); } }
        private string _PProductName;
        public string PProductName { get => _PProductName; set { _PProductName = value; OnPropertyChanged(); } }

        private decimal _PUnitPrice;
        public decimal PUnitPrice { get => _PUnitPrice; set { _PUnitPrice = value; OnPropertyChanged(); } }

        private int _PQuantity;
        public int PQuantity { get => _PQuantity; set { _PQuantity = value; OnPropertyChanged(); } }
        private int _PDiscount;
        public int PDiscount { get => _PDiscount; set { _PDiscount = value; OnPropertyChanged(); } }

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
                    PProductName = SelectedProduct.ProductName;
                    PUnitPrice = SelectedProduct.UnitPrice;
                    PQuantity = SelectedProduct.UnitStock;
                    PDiscount = 0;
                }
            }
        }


        private IOrderRepository _OrderRepository = new OrderRepository();

        private IEnumerable<Order> _OrderList;
        public IEnumerable<Order> OrderList { get => _OrderList; set { _OrderList = value; OnPropertyChanged(); } }

        private int _MemberId;
        public int MemberId { get => _MemberId; set { _MemberId = value; OnPropertyChanged(); } }

        private DateTime _OrderDate;
        public DateTime OrderDate { get => _OrderDate; set { _OrderDate = value; OnPropertyChanged(); } }

        private DateTime _RequireDate;
        public DateTime RequireDate { get => _RequireDate; set { _RequireDate = value; OnPropertyChanged(); } }

        private DateTime _ShippedDate;
        public DateTime ShippedDate { get => _ShippedDate; set { _ShippedDate = value; OnPropertyChanged(); } }

        private decimal _Freight;
        public decimal Freight { get => _Freight; set { _Freight = value; OnPropertyChanged(); } }

        private Order _SelectedOrder;
        public Order SelectedOrder
        {
            get => _SelectedOrder;
            set
            {
                _SelectedOrder = value;
                OnPropertyChanged();
                if (SelectedOrder != null)
                {
                    MemberId = SelectedOrder.MemberId;
                    OrderDate = SelectedOrder.OrderDate;
                    RequireDate = (DateTime) SelectedOrder.RequireDate;
                    ShippedDate = (DateTime) SelectedOrder.ShippedDate;
                    Freight = (Decimal) SelectedOrder.Freight;
                }
            }
        }

        private IOrderDetailRepository _OrderDetailRepository = new OrderDetailRepository();

        private IEnumerable<OrderDetail> _OrderDetailList;
        public IEnumerable<OrderDetail> OrderDetailList { get => _OrderDetailList; set { _OrderDetailList = value; OnPropertyChanged(); } }
        private int _OrderId;
        public int OrderId { get => _OrderId; set { _OrderId = value; OnPropertyChanged(); } }

        private string _ProductName;
        public string ProductName { get => _ProductName; set { _ProductName = value; OnPropertyChanged(); } }

        private decimal _UnitPrice;
        public decimal UnitPrice { get => _UnitPrice; set { _UnitPrice = value; OnPropertyChanged(); } }

        private int _Quantity;
        public int Quantity { get => _Quantity; set { _Quantity = value; OnPropertyChanged(); } }

        private double _Discount;
        public double Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }

        private OrderDetail _SelectedOrderDetail;
        public OrderDetail SelectedOrderDetail
        {
            get => _SelectedOrderDetail;
            set
            {
                _SelectedOrderDetail = value;
                OnPropertyChanged();
                if (SelectedOrderDetail != null)
                {
                    OrderId = SelectedOrderDetail.OrderId;
                    ProductName = SelectedOrderDetail.Product.ProductName;
                    UnitPrice = SelectedOrderDetail.UnitPrice;
                    Quantity = SelectedOrderDetail.Quantity;
                    Discount = SelectedOrderDetail.Discount;
                }
            }
        }

        public ICommand AddOrderCommand { get; set; }
        public ICommand EditOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand AddOrderDetailCommand { get; set; }
        public ICommand EditOrderDetailCommand { get; set; }
        public ICommand DeleteOrderDetailCommand { get; set; }

        public OrderViewModel(Member user)
        {
            User = user; 
            LoadListData();
            OrderCommand();
            OrderDetailCommand();
        }

        void LoadListData()
        {
            //if (User != null)
            //{
                //OrderList = _OrderRepository.ReadByMember(User.MemberId);
            OrderDetailList = _OrderDetailRepository.ReadAll();
            //ProductList = _ProductRepository.ReadAll();
        OrderList = _OrderRepository.ReadAll();
            //OrderDetailList = _OrderDetailRepository.ReadAll();
            ProductList = _ProductRepository.ReadAll();
        }

        void OrderCommand()
        {
            // Add item
            AddOrderCommand = new RelayCommand<object>((p) => {
                if (OrderDate == null || RequireDate == null || ShippedDate == null || Freight == null){return false;}
                //if (User == null){return false;}
                return true;
            }, (p) => {
                Order order = new Order { MemberId = User.MemberId, OrderDate = OrderDate, RequireDate = RequireDate, ShippedDate = ShippedDate, Freight = Freight };
                _OrderRepository.Create(order);
                MessageBox.Show($"Order of: {User.Email} is created successfully", "Add Order");
                OrderList = _OrderRepository.ReadByMember(User.MemberId);
            });


            // Edit item
            EditOrderCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedOrder == null || OrderDate == null || RequireDate == null || ShippedDate == null || Freight == null){return false; }
                return true;
            }, (p) =>
            {
                _OrderRepository.Update(SelectedOrder.OrderId, new Order { MemberId = SelectedOrder.MemberId, OrderDate = OrderDate, RequireDate = RequireDate, ShippedDate = ShippedDate, Freight = Freight });
                MessageBox.Show($"Order is edited successfully", "Edit Order");
                LoadListData();
            });

            // Remove Item
            DeleteOrderCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedOrder == null){return false;}
                return true;
            }, (p) =>
            {
                _OrderRepository.Delete(SelectedOrder.OrderId);
                MessageBox.Show($"Ordr is Removed successfully", "Remove Order");
                LoadListData();
            });

        }

        void OrderDetailCommand()
        {

        }
    }
}