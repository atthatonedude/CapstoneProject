using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneProject.ViewModel
{
    internal class ShellViewModel : Conductor<object>
    {   public readonly UserLoginViewModel userLoginViewModel;
        public ShellViewModel(UserLoginViewModel model)
        {


            userLoginViewModel = new UserLoginViewModel();

            ActivateItemAsync(userLoginViewModel);
             
        }
    }
}
