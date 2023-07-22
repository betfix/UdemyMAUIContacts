using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Contacts.Core;
using Contacts.MAUI.Views_MVVM;
using Contacts.UseCases.Interfaces;

namespace Contacts.MAUI.ViewModels;

public partial class ContactViewModel : ObservableObject
{
	private readonly IViewContactUseCase _viewContactUseCase;
	private readonly IEditContactUseCase _editContactUseCase;
	private readonly IAddContactUseCase _addContactUseCase;
	private ContactEntity _contact = new();

	public ContactEntity Contact { get => _contact; set => SetProperty(ref _contact, value); }
	public bool IsAddNewVisible { get; set; }
	public bool IsUpdateVisible { get; set; }


	public ContactViewModel(
	IViewContactUseCase viewContactUseCase,
	IEditContactUseCase editContactUseCase,
	IAddContactUseCase addContactUseCase)
	{
		_viewContactUseCase = viewContactUseCase;
		_editContactUseCase = editContactUseCase;
		_addContactUseCase = addContactUseCase;
	}

	public async Task LoadContactAsync(int contactId)
	{
		var contact = await _viewContactUseCase.ExecuteAsync(contactId);
		Contact = contact ?? new ContactEntity();
	}

	[RelayCommand]
	public async Task UpdateContactAsync()
	{
		if ( Contact is null )
			return;
		await _editContactUseCase.ExecuteAsync(Contact.ContactId, Contact);
		await Shell.Current.GoToAsync(nameof(Contacts_MVVM_Page));
	}

	[RelayCommand]
	public async Task AddContactAsync()
	{
		if ( Contact is null )
			return;
		await _addContactUseCase.ExecuteAsync(Contact);
		await Shell.Current.GoToAsync(nameof(Contacts_MVVM_Page));
	}

	[RelayCommand]
	public async Task BackToContactsAsync()
	{
		await Shell.Current.GoToAsync(nameof(Contacts_MVVM_Page));
	}
}
