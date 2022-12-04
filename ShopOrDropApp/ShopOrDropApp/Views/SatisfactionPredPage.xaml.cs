using ShopOrDropApp.Models;
using ShopOrDropApp.Services;
using System.Diagnostics;

namespace ShopOrDropApp.Views
{
    [QueryProperty(nameof(PurchaseItem), "PurchaseItem")]
    public partial class SatisfactionPredPage : ContentPage
    {
        IShopOrDropService _shopOrDropService;
        PurchaseItem _purchaseItem;
        public float satisfactionValue = 0f;

        public PurchaseItem PurchaseItem
        {
            get => _purchaseItem;
            set
            {
                _purchaseItem = value;
                OnPropertyChanged();
            }
        }

        public SatisfactionPredPage(IShopOrDropService service)
        {
            InitializeComponent();
            _shopOrDropService = service;
            BindingContext = this;
        }

        //public SatisfactionPredPage()
        //{
        //    InitializeComponent();
        //    PurchaseItem = new PurchaseItem { ID = Guid.NewGuid().ToString() };
        //    _purchaseItem = new PurchaseItem { ID = Guid.NewGuid().ToString() };
        //}

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(PurchaseListPage));
        }

        async void OnPredictButtonClicked(object sender, EventArgs e)
        {
            var temp = await _shopOrDropService.GetPrediction(PurchaseItem);
            Debug.WriteLine("Final {0}", temp);
            satisfactionValue = temp;
            PredictTxt.Text = $"Predicted Value: {temp}";
            PurchaseItem.Satisfaction = temp;

        }
    }
}