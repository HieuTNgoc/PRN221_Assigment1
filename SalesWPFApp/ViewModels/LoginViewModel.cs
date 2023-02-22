using DataAccess;
using DataAccess.Repository;
using SalesWPFApp;
using SalesWPFApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessObject;

namespace SalesWPFApp.ViewModels 
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        public int UserRole { get; set; }
        public Member member { get; set; }

        private IMemberRepository _MemberRepository = new MemberRepository();
        private string _Email;
        public string Email { get => _Email; set{ _Email = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand LoginCommand { get; set; }
        public ICommand CancleCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            IsLogin = false;
            UserRole = 0;

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CancleCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Cancle(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login (Window p)
        {
            if (p == null)
            {
                    return;
            }

            //Validate data
            //ex: MessageBox.Show(DataProvider.Ins.DB.Members.First().Email);
            //var accCount = DataProvider.Ins.DB.Members.Where(x => x.Email == Email && x.Password == Password).Count();
            var accCount = _MemberRepository.Login(Email, Password);
            if (accCount == -1)
            {
                IsLogin = true;
                UserRole = 2;
                MessageBox.Show("Welcome App Admin", "Success!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                p.Close();
            }
            else if (accCount >0)
            {
                member = _MemberRepository.GetByEmail(Email);
                IsLogin = true;
                UserRole = 1;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Wrong Account, try again!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        void Cancle(Window p)
        {
            if (p == null)
            {
                return;
            }
            p.Close();
        }
    }
}
