using Contacts.Core;
using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;

namespace Contacts.UseCases;

public class EditContactUseCase : IEditContactUseCase
{
	private readonly IContactRepository _repo;


	public EditContactUseCase(IContactRepository repo)
	{
		_repo = repo;
	}

	public async Task ExecuteAsync(int contactId, ContactEntity contact)
	{
		await _repo.UpdateAsync(contactId, contact);
	}
}
