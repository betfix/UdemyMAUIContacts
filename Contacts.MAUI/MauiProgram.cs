using CommunityToolkit.Maui;
using Contacts.MAUI.Views;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;

namespace Contacts.MAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IContactRepository, ContactInMemoryRepository>();
		builder.Services.AddTransient<IViewContactsUseCase, ViewContactsUseCase>();
		builder.Services.AddTransient<IViewContactUseCase, ViewContactUseCase>();
		builder.Services.AddTransient<IEditContactUseCase, EditContactUseCase>();
		builder.Services.AddTransient<IAddContactUseCase, AddContactUseCase>();
		builder.Services.AddTransient<IDeleteContactUseCase, DeleteContactUseCase>();
		builder.Services.AddSingleton<ContactsPage>();
		builder.Services.AddTransient<EditContactPage>();
		builder.Services.AddTransient<AddContactPage>();

		var app = builder.Build();

		return app;
	}
}