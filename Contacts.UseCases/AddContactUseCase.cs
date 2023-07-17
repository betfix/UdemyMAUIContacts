using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contacts.Core;

namespace Contacts.UseCases;
public class AddContactUseCase : IAddContactUseCase
{
	private readonly IContactRepository _repo;

	public AddContactUseCase(IContactRepository repo)
	{
		_repo = repo;
	}

	public async Task ExecuteAsync(ContactEntity contact)
	{
		await _repo.AddAsync(contact);
	}
}
