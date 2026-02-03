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

            ViewLocator.AddSubNamespaceMapping("CapstoneProject.ViewModel", "CapstoneProject.View");
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<UserLoginViewModel>();
        }
    }
}
