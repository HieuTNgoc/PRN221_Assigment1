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
    public class MemberViewModel : BaseViewModel
    {
        public Member User { get; set; }

        private IMemberRepository _MemberRepository = new MemberRepository();
        private IEnumerable<Member> _MemberList;
        public IEnumerable<Member> MemberList { get => _MemberList; set { _MemberList = value; OnPropertyChanged(); } }
        private Member _SelectedMember;
        public Member SelectedMember { get => _SelectedMember; 
            set { 
                _SelectedMember = value; 
                OnPropertyChanged(); 
                if (SelectedMember != null)
                {
                    Email = SelectedMember.Email;
                    CompanyName = SelectedMember.CompanyName;   
                    City = SelectedMember.City;
                    Country = SelectedMember.Country;
                    Password = SelectedMember.Password;
                }
            } 
        }

        private string _Email;
        public string Email { get => _Email; set { _Email = value;OnPropertyChanged(); } }

        private string _CompanyName;
        public string CompanyName { get => _CompanyName; set { _CompanyName = value; OnPropertyChanged(); } }

        private string _City;
        public string City { get => _City; set { _City = value; OnPropertyChanged(); } }

        private string _Country;
        public string Country { get => _Country; set { _Country = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _Key;
        public string Key { get => _Key; set { _Key = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }




        public MemberViewModel(Member user)
        {
            User = user;
            LoadMemberList();

            // Add new item
            AddCommand = new RelayCommand<object>((p) => {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(Password)){return false;}
                var accCount = _MemberRepository.EmailCount(Email);
                if (accCount != 0 || User!=null){return false;}
                return true;
            }, (p) => {
                _MemberRepository.Create(new Member {Email = Email, CompanyName = CompanyName,City = City,Country = Country,Password = Password});
                MessageBox.Show($"Account: {Email} is created successfully", "Add Member");
                LoadMemberList();
            });

            // Edit item
            EditCommand = new RelayCommand<object>((p) => {
                if (SelectedMember==null || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(City) || string.IsNullOrEmpty(Country) || string.IsNullOrEmpty(Password)){ return false;}
                var accCount = _MemberRepository.EmailCount(Email);
                var acc = _MemberRepository.GetById(SelectedMember.MemberId);
                if (accCount != 0 && Email != acc.Email) {return false; }
                return true;
            }, (p) => {
                _MemberRepository.Update(SelectedMember.MemberId, new Member { Email = Email, CompanyName = CompanyName, City = City, Country = Country, Password = Password });
                MessageBox.Show($"Account: {Email} is Updated successfully", "Update Member");
                LoadMemberList();
            });


            // Remove item
            DeleteCommand = new RelayCommand<object>((p) => {
                if (SelectedMember == null || User != null) { return false;}
                return true;
            }, (p) => {
                _MemberRepository.Remove(SelectedMember.MemberId);
                MessageBox.Show($"Account: {Email} is Removed successfully", "Remove Member");
                LoadMemberList();
            });


            // Search item
            SearchCommand = new RelayCommand<object>((p) => {
                if (Key == null || User != null) {return false;}
                return true;
            }, (p) => {
                MemberList = _MemberRepository.ReadKey(Key);
            });
        }
       
        void LoadMemberList()
        {
            if (User == null)
            {
                MemberList = _MemberRepository.ReadAll();
            } else
            {
                List<Member> list = new List<Member>();
                list.Add(_MemberRepository.GetByEmail(User.Email));
                MemberList = list;
            }

        }


    }
}
