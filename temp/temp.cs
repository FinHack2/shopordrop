using ShopOrDropApp.Models;
using ShopOrDropApp.Services;
using System.Diagnostics;

namespace ShopOrDropApp.Views
{
    public partial class PurchaseListPage : ContentPage
    {
        IShopOrDropService _shopOrDropService;

        public PurchaseListPage(IShopOrDropService service)
        {
            InitializeComponent();
            _shopOrDropService = service;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _shopOrDropService.GetTasksAsync();
        }

        async void OnAddItemClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                //{ nameof(PurchaseItem), new PurchaseItem { ID = Guid.NewGuid().ToString() } }
                { nameof(PurchaseItem), new PurchaseItem {  } }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var purchaseItem = e.CurrentSelection.FirstOrDefault() as PurchaseItem;
            Debug.WriteLine(@"\Selection:" + purchaseItem.ItemName);
            var navigationParameter = new Dictionary<string, object>
            {
                { purchaseItem.ItemName, e.CurrentSelection.FirstOrDefault() as PurchaseItem }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }
    }
}
