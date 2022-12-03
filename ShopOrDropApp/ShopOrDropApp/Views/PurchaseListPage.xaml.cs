using ShopOrDropApp.Models;
using ShopOrDropApp.Services;

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

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { nameof(PurchaseItem), e.CurrentSelection.FirstOrDefault() as PurchaseItem }
            };
            await Shell.Current.GoToAsync(nameof(PurchaseItemPage), navigationParameter);
        }
    }
}
