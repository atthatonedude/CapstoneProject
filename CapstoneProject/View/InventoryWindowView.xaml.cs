using CapstoneProject.ViewModel;
using System.Windows.Controls;

namespace CapstoneProject.View
{
    
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
