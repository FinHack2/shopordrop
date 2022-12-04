using ShopOrDropApp.Models;
using ShopOrDropApp.Services;

namespace ShopOrDropApp.Views
{
    [QueryProperty(nameof(PurchaseItem), "PurchaseItem")]
    public partial class PurchaseItemPage : ContentPage
    {
        IShopOrDropService _shopOrDropService;
        PurchaseItem _purchaseItem;
        bool _isNewItem;

        public PurchaseItem PurchaseItem
        {
            get => _purchaseItem;
            set
            {
                //_isNewItem = IsNewItem(value);
                _purchaseItem = value;
                OnPropertyChanged();
            }
        }

        //bool IsNewItem(PurchaseItem purchaseItem)
        //{
        //    if (string.IsNullOrWhiteSpace(purchaseItem.ItemName) 
        //        && string.IsNullOrWhiteSpace(purchaseItem.Category)
        //        && purchaseItem.ID == "")
        //        return true;
        //    return false;
        //}

        public PurchaseItemPage(IShopOrDropService service)
        {
            InitializeComponent();
            _shopOrDropService = service;
            BindingContext = this;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //await _shopOrDropService.SaveTaskAsync(PurchaseItem, _isNewItem);
            await _shopOrDropService.SaveTaskAsync(PurchaseItem);
            await Shell.Current.GoToAsync("..");
        }

        //async void OnDeleteButtonClicked(object sender, EventArgs e)
        //{
        //    await _shopOrDropService.DeleteTaskAsync(PurchaseItem);
        //    await Shell.Current.GoToAsync("..");
        //}


        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
