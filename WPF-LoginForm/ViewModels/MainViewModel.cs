using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;
using WPF_LoginForm.Views;
using WPF_LoginForm.Core;

namespace WPF_LoginForm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand StoreViewCommand {  get; set; }

        public RelayCommand DiscountViewCommand { get; set; }

        public RelayCommand LibraryViewCommand { get; set; }

        public LibraryViewModel LibraryVM { get; set; }

        public DiscountsViewModel DiscountVM { get; set; }

        public StoreViewModel StoreVM { get; set; }

        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;
        private object _currentView;
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }
        public object CurrentView 
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            StoreVM = new StoreViewModel();
            CurrentView = StoreVM;
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
            StoreViewCommand = new RelayCommand(o =>
            {
                StoreVM = new StoreViewModel();
                CurrentView = StoreVM;
            });
            LibraryViewCommand = new RelayCommand(o =>
            {
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
                LibraryVM = new LibraryViewModel(user.Username);
                CurrentView = LibraryVM;
            });
            DiscountViewCommand = new RelayCommand(o =>
            {
                DiscountVM = new DiscountsViewModel();
                CurrentView = DiscountVM;
            });
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $" {user.Username} ";
                CurrentUserAccount.ProfilePicture = null;               
            }
            else
            {
                CurrentUserAccount.DisplayName="Invalid user, not logged in";
            }
        }
    }
}
