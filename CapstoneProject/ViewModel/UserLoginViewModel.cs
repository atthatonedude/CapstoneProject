using CapstoneProject.MVVMBase;
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
            set { model = value;
                OnPropertyChanged();
            }

        }

        
        public ICommand CreateUserCommand {  get; set; }
        public ICommand LoginUserCommand {  get; set; }

        //Constructor
        public UserLoginViewModel()
        {
            Model = new UserLoginModal();
            
            
      
            CreateUserCommand = new RelayCommand(execute: _ => OnClickCreateUser());

            LoginUserCommand = new RelayCommand(execute: _ => OnClickUserLogin());

        }


        public  void CloseWindow()
        {
             TryCloseAsync();
             
                

        }
        
        private async Task<bool> OnClickCreateUser()
        {
            var apiModel = new APIAccessLibrary.Model.UserLoginModal();
            apiModel.UserName = model.UserName;
            apiModel.UserPassword = model.UserPassword;            
            
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
        
        private async Task<bool> OnClickUserLogin()
        {
            var apiModel = new APIAccessLibrary.Model.UserLoginModal();
            apiModel.UserName = model.UserName;
            apiModel.UserPassword = model.UserPassword;

            if (apiModel != null)
            {

                var response = await APIAccessLibrary.ApiProcessor.LoginUserAsync(apiModel);

                if (response != true)
                {

                    MessageBox.Show($"User or password could not be verified\nTry again");

                    return false;

                }
                
                MessageBox.Show("User Verified");



            }

            
            // Ask the existing Shell (the Parent) to open the inventory view
            if (this.Parent is ShellViewModel shell)
            {
                await shell.OpenNewInventoryWindow();
                await TryCloseAsync(); // close the login screen if that's desired
            }
            else
            {
                // Fallback: if Parent is null, create a shell and activate (less ideal)
                var tempShell = new ShellViewModel();
                await tempShell.OpenNewInventoryWindow();
            }

            return true;
            

        }
        

    }
}
