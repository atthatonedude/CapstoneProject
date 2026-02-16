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

        private ItemModel itemMaximumBuildable;

        public ItemModel ItemMaximumBuildable
        {
            get { return itemMaximumBuildable; }
            set
            {
                itemMaximumBuildable = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetItemsCommand { get; set; }


        //Constructor
        public InventoryWindowViewModel()
        {
            ItemSearched = new ItemModel();

            InventoryItems = new ObservableCollection<ItemModel>();

           
            GetItemsCommand = new RelayCommand(execute: _ => GetItems());
        }

        private async Task GetItems()
        {
            var apiModel = new APIAccessLibrary.Model.ItemModel();
            // Use the part number the user entered/bound in the UI
            apiModel.ItemPartNumber = itemSearched.ItemPartNumber;

            var response = await APIAccessLibrary.ApiProcessor.GetItemsAsync(apiModel);

            InventoryItems.Clear();
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
            ShowMaximumBuildable();
            
        }

        private async Task ShowMaximumBuildable()
        {
            var apiModelPartNumber = itemSearched.ItemPartNumber;

            
            

            var response = await APIAccessLibrary.ApiProcessor.GetBuildableItemsAsync(apiModelPartNumber);




            ItemMaximumBuildable = new ItemModel
            {


                ItemQuantity = response

            };


        }
    }
}
