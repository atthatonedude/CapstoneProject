using CapstoneProject.MVVMBase;
using CapstoneProject.View;


using System.Windows;
using CapstoneProject.Model;

namespace CapstoneProject.ViewModel
{
    internal class UserLoginViewModel : ViewModelBase
    {   private readonly 
        public RelayCommand LoginCommand => new RelayCommand(execute => { }, canExecute => { return true; });

        public UserLoginViewModel() {
            
        }

        private void UserTbFill(object sender, EventArgs e)
        {
            
            
        }
    }
}
