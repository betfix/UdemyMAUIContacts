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
	private string? _filterText;

	public ObservableCollection<ContactEntity> Contacts { get; set; }

	//TODO: Use Command to filter the SearchBar once this issue is resolved: https://github.com/dotnet/maui/issues/8994
	public string? FilterText
	{
		get => _filterText;
		set
		{
			_filterText = value;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
						LoadContactsAsync(value);
#pragma warning restore CS4014 
				}
	}


	public ContactsViewModel(
	IViewContactsUseCase viewContactsUseCase,
	IDeleteContactUseCase deleteContactUseCase)
	{
		_viewContactsUseCase = viewContactsUseCase;
		_deleteContactUseCase = deleteContactUseCase;

		Contacts = new ObservableCollection<ContactEntity>();
	}


	public async Task LoadContactsAsync(string? filterText = "")
	{
		Contacts.Clear();
		var contacts = await _viewContactsUseCase.ExecuteAsync(filterText);
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
