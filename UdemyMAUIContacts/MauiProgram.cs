﻿using CommunityToolkit.Maui;
using Contacts.Plugins.DataStore.InMemory;
using Contacts.UseCases;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Microsoft.Extensions.Logging;
using UdemyMAUIContacts.Views;

namespace UdemyMAUIContacts;

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
		builder.Services.AddTransient<ContactsPage>();
		builder.Services.AddTransient<EditContactPage>();
		builder.Services.AddTransient<AddContactPage>();
		return builder.Build();
	}

}