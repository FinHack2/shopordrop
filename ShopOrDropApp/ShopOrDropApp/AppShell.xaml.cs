using ShopOrDropApp.Views;

namespace ShopOrDropApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(PurchaseItemPage), typeof(PurchaseItemPage));
        Routing.RegisterRoute(nameof(PurchaseListPage), typeof(PurchaseListPage));
    }
}
