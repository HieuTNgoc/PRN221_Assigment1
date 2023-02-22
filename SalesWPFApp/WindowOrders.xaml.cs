using BusinessObject;
using SalesWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        public WindowOrders(Member user)
        {
            InitializeComponent();
            this.DataContext = new OrderViewModel(user);
        }
    }
}
