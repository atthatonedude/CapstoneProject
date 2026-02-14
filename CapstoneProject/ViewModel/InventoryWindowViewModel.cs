using CapstoneProject.Model;
using CapstoneProject.MVVMBase;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CapstoneProject.ViewModel
{
    public class InventoryWindowViewModel : MVVMBase.ViewModelBase
    {

        private ItemModel itemSearched;

        public ItemModel ItemSearched
        {
            get { return itemSearched; }
            set
            {
                itemSearched = value;
                OnPropertyChanged();

            }
        }

        private ObservableCollection<ItemModel> inventoryItems;

        public ObservableCollection<ItemModel> InventoryItems
        {
            get { return inventoryItems; }
            set
            {
                inventoryItems = value;
                OnPropertyChanged();
            }
        }


        public ICommand GetItemsCommand { get; set; }

        public InventoryWindowViewModel()
        {
            ItemSearched = new ItemModel();

            InventoryItems = new ObservableCollection<ItemModel>();

           
            GetItemsCommand = new RelayCommand(execute: _ => GetItems());
        }

        private async Task GetItems()
        {
            var apiModel = new APIAccessLibrary.Model.ItemModel();
            apiModel.ItemId = ItemSearched.ItemId;


            var response  = await APIAccessLibrary.ApiProcessor.GetItemsAsync(apiModel);

            foreach (var item in response)
            {
                InventoryItems.Add(new ItemModel
                {
                    ItemId = item.ItemId,
                    ItemDescription = item.ItemDescription,
                    ItemQuantity = item.ItemQuantity,
                    ItemPartNumber = item.ItemPartNumber
                });
            }


        }
    }
}
