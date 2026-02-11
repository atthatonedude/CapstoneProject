using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using CapstoneProject.ViewModel;

namespace CapstoneProject.ViewModel
{
    public  class ShellViewModel : Conductor<object>
    {   
        public ShellViewModel()
        {
            

            ActivateItemAsync(new UserLoginViewModel());
        }

        public async Task OpenNewInventoryWindow()
        {
            
            await ActivateItemAsync(new InventoryWindowViewModel());
            
            
        }


    }
}
