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
            apiModel.FirstName = "dd";
            apiModel.LastName = "cc";
            apiModel.UserEmail = "df";
            

            if (apiModel != null) {

               var response = await APIAccessLibrary.ApiProcessor.CreateUserAsync(apiModel);

                if (response != true)
                {
                    

                        MessageBox.Show($"User not created.\nTry again.");

                        return false;

                    
                }


                MessageBox.Show($"User Created");
                
                
            }
            return true;


        }

        




    }
}
