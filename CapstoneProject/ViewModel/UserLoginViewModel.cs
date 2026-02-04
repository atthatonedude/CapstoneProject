using CapstoneProject.MVVMBase;
using CapstoneProject;
using CapstoneProject.Model;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CapstoneProject.ViewModel
{
    public class UserLoginViewModel : MVVMBase.ViewModelBase
    {
        private UserLoginModal model;

        public UserLoginModal Model {
        

            get { return model; }
            set { model = value;
                OnPropertyChanged();
            }

        }


        
        
        public ICommand LoginCommand {  get; set; }

        public UserLoginViewModel()
        {   
            Model = new UserLoginModal();
            
            
      
            LoginCommand = new RelayCommand(execute: _ => OnClickLogin());

        }

        

       

        private async Task<bool> OnClickLogin()
        {
            var apiModel = new APIAccessLibrary.Model.UserLoginModal();
            apiModel.UserName = model.UserName;
            apiModel.UserPassword = model.UserPassword;

            if (apiModel != null) {

               await APIAccessLibrary.ApiProcessor.CreateUserAsync(apiModel);
                return true;
            }
            else {
                
                MessageBox.Show($"User not created.\nTry again.");
                
                return false; 

            }
            
        }

        




    }
}
