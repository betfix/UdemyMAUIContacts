using System.Collections.ObjectModel;
using Contacts.MAUI.Models;
using Contacts.UseCases.Interfaces;
using Contacts.Core;
using Contacts.UseCases;

namespace Contacts.MAUI.Views;

public partial class ContactsPage : ContentPage
{
	private readonly IViewContactsUseCase _viewContactsUseCase;
	private readonly IDeleteContactUseCase _deleteContactUseCase;


	public ContactsPage(IViewContactsUseCase viewContactsUseCase, IDeleteContactUseCase deleteContactUseCase)
	{
		_viewContactsUseCase = viewContactsUseCase;
		_deleteContactUseCase = deleteContactUseCase;
		InitializeComponent();
		//AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();
		LoadContacts();
	}


	private async void LoadContacts()
	{
		ContactsList.ItemsSource =
			new ObservableCollection<ContactEntity>(await _viewContactsUseCase.ExecuteAsync());
		Search.Text = "";
	}


	private void ContactsList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if ( e.SelectedItem == null )
			return;
	}


	private void ContactsList_OnItemTapped(object sender, ItemTappedEventArgs e)
	{
		if ( e.Item is not ContactEntity contact )
			return;
		Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.ContactId}");
	}


	private async void AddBtn_OnClicked(object? sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
	}


	private void Item_Delete(object? sender, EventArgs e)
	{
		var menuItem = sender as MenuItem;
		if ( menuItem?.CommandParameter is not ContactEntity contact )
			return;
		_deleteContactUseCase.ExecuteAsync(contact.ContactId);
		LoadContacts();
	}


	private async void Search_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		if ( sender is not SearchBar searchBar )
			return;
		ContactsList.ItemsSource =
			new ObservableCollection<ContactEntity>(await _viewContactsUseCase.ExecuteAsync(searchBar.Text));
	}

	private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		// Log the exception
		Console.WriteLine(e.ExceptionObject);

		// Display an error message to the user
		var message = "An unexpected error occurred. Please try again later.";
		DisplayAlert("Error", message, "OK");

		// Perform other custom actions
		// ...
	}
}