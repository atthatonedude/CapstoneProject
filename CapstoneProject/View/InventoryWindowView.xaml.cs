using CapstoneProject.ViewModel;
using System.Windows.Controls;

namespace CapstoneProject.View
{
    /// <summary>
    /// Interaction logic for InventoryWindowView.xaml
    /// </summary>
    public partial class InventoryWindowView : UserControl

    {
        public InventoryWindowView()
        {
            InitializeComponent();
            InventoryWindowViewModel vm = new InventoryWindowViewModel();
            DataContext = vm;
        }
    }
}
