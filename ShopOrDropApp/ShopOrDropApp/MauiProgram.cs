using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

using ShopOrDropApp.Services;
using ShopOrDropApp.Views;

namespace ShopOrDropApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<IShopOrDropService, ShopOrDropService>();

        builder.Services.AddSingleton<PurchaseListPage>();
        builder.Services.AddTransient<PurchaseItemPage>();
        builder.Services.AddTransient<SatisfactionPredPage>();

        return builder.Build();
	}
}
