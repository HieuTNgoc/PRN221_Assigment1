using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SalesWPFApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public int UserRole { get; set; }
        public Member User { get; set; }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _CompanyName;
        public string CompanyName { get => _CompanyName; set { _CompanyName = value; OnPropertyChanged(); } }

        private string _City;
        public string City { get => _City; set { _City = value; OnPropertyChanged(); } }

        private string _Country;
        public string Country { get => _Country; set { _Country = value; OnPropertyChanged(); } }

        public ICommand LoadedWindowCommand { get; set; }
        public ICommand AccountCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand OrderCommand { get; set; }


        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null)
                {
                    return;
                }
                p.Hide();
                WindowLogin wd = new WindowLogin(); wd.ShowDialog();
                if (wd.DataContext == null)
                {
                    return;
                }
                var loginVM = wd.DataContext as LoginViewModel;
                if (loginVM.IsLogin)
                {
                    UserRole = loginVM.UserRole;
                    User  = loginVM.member;
                    if (loginVM.member != null)
                    {
                        Email = loginVM.member.Email;
                        City = loginVM.member.City;
                        Country = loginVM.member.Country;
                        CompanyName = loginVM.member.CompanyName;
                    }
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });

            AccountCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ WindowMembers wd = new WindowMembers(User); wd.ShowDialog(); });

            ProductCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>{
                if (UserRole < 2)
                {
                    MessageBox.Show("You do not have permissions!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                WindowProducts wd = new WindowProducts(); wd.ShowDialog();
            });

            OrderCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { WindowOrders wd = new WindowOrders(User); wd.ShowDialog(); });
        }
    }
}
