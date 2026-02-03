using CapstoneProject.MVVMBase;
using CapstoneProject;
using CapstoneProject.Model;
using System.Windows;
using System.Windows.Input;

namespace CapstoneProject.ViewModel
{
    public class UserLoginViewModel : MVVMBase.ViewModelBase
    {
        private UserLoginModal model;

        public UserLoginModal Model {
        

            get { return model; }
            set { model = value;OnPropertyChanged(); }

        }


        
        
        public ICommand LoginCommand {  get; set; }

        public UserLoginViewModel()
        {   
            Model = new UserLoginModal();
            
            
      
            LoginCommand = new RelayCommand(execute: _ => OnClickLogin());
            
        }

        

       

        private void OnClickLogin()
        {
            
        }




    }
}
