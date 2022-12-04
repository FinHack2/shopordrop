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
                { nameof(PurchaseItem), new PurchaseItem { ID = Guid.NewGuid().ToString() } }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }

        async void OnPredictPageClicked(object sender, EventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PurchaseItem), new PurchaseItem { ID = Guid.NewGuid().ToString() } }
            };
            await Shell.Current.GoToAsync(nameof(SatisfactionPredPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var purchaseItem = e.CurrentSelection.FirstOrDefault() as PurchaseItem;
            Debug.WriteLine(@"\Selection:" + purchaseItem.ItemName);

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PurchaseItem), e.CurrentSelection.FirstOrDefault() as PurchaseItem }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }

        async void OnImageButtonClicked(object sender, EventArgs e)
        {
            var purchaseItem = (sender as ImageButton).BindingContext as PurchaseItem;
            Debug.WriteLine(@"\ImageButton:" + purchaseItem.ItemName);

            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PurchaseItem), purchaseItem }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }
    }
}
