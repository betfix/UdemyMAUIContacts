using System.Collections.ObjectModel;
using Contacts.Core;
using Contacts.UseCases.Interfaces;

namespace Contacts.MAUI.ViewModels;
public class ContactsViewModel
{
	private readonly IViewContactsUseCase _viewContactsUseCase;
	public ObservableCollection<ContactEntity> Contacts { get; set; }


	public ContactsViewModel(IViewContactsUseCase viewContactsUseCase)
	{
		_viewContactsUseCase = viewContactsUseCase;
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
}
