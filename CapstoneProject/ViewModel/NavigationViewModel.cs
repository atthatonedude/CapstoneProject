using CapstoneProject.Model;
using CapstoneProject.MVVMBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CapstoneProject.ViewModel
{
    internal class NavigationViewModel : MVVMBase.ViewModelBase
    {
        private object view;

        public object View
        {
            get { return view; } 
            set { view = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; set; }

        private void LoginView(object obj) => View = new UserLogin();

        public NavigationViewModel()
        {
            LoginCommand = new RelayCommand(LoginView);
            
        }
    }
}
