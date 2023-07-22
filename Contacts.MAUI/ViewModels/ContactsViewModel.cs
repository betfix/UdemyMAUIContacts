using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Contacts.Core;
using Contacts.MAUI.Views_MVVM;
using Contacts.UseCases.Interfaces;

namespace Contacts.MAUI.ViewModels;
public partial class ContactsViewModel : ObservableObject
{
	private readonly IViewContactsUseCase _viewContactsUseCase;
	private readonly IDeleteContactUseCase _deleteContactUseCase;

	public ObservableCollection<ContactEntity> Contacts { get; set; }


	public ContactsViewModel(
		IViewContactsUseCase viewContactsUseCase,
		IDeleteContactUseCase deleteContactUseCase)
	{
		_viewContactsUseCase = viewContactsUseCase;
		_deleteContactUseCase = deleteContactUseCase;

		Contacts = new ObservableCollection<ContactEntity>();
	}


	public async Task LoadContactsAsync()
	{
		Contacts.Clear();
		var contacts = await _viewContactsUseCase.ExecuteAsync();
		foreach ( var contact in contacts )
		{
			Contacts.Add(contact);
		}
	}

	[RelayCommand]
	public async Task DeleteContactAsync(int contactId)
	{
		await _deleteContactUseCase.ExecuteAsync(contactId);
		await LoadContactsAsync();
	}

	[RelayCommand]
	public async Task GoToEditContactAsync(int contactId)
	{
		await Shell.Current.GoToAsync($"{nameof(EditContact_MVVM_Page)}?ContactId={contactId}");
	}

	[RelayCommand]
	public async Task GoToAddContact1Async()
	{
		await Shell.Current.GoToAsync(nameof(AddContact_MVVM_Page));
	}
}
