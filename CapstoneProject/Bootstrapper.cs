using Caliburn.Micro;
using System.Windows;
using CapstoneProject.ViewModel;
using System.Threading.Tasks;

namespace CapstoneProject
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
           await DisplayRootViewForAsync<UserLoginViewModel>();
        }
    }
}
