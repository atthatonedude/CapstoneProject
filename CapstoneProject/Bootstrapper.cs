using Caliburn.Micro;
using CapstoneProject.ViewModel;
using System.Diagnostics;
using System.Windows;

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
            DisplayRootViewForAsync<ShellViewModel>();
        }
    }
}