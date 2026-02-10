using CapstoneProject.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CapstoneProject.View
{
    public partial class UserLoginView : UserControl
    {
        public UserLoginView()
        {
            InitializeComponent();
            UserLoginViewModel vm = new UserLoginViewModel();
            DataContext = vm;



        }
    }
}
