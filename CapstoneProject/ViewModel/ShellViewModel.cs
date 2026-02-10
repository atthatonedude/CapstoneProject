using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using CapstoneProject.ViewModel;

namespace CapstoneProject.ViewModel
{
    internal class ShellViewModel : Conductor<object>
    {   
        public ShellViewModel(object model)
        {
            

            ActivateItemAsync(new UserLoginViewModel());
        }

        public void ShowInventoryWindow()
        {
            ActivateItemAsync(new InventoryWindowViewModel());
        }

    }
}
