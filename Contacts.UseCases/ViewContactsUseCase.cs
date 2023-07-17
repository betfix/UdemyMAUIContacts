using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contacts.Core;

namespace Contacts.UseCases;

// All the code in this file is included in all platforms.
public class ViewContactsUseCase : IViewContactsUseCase
{
	private readonly IContactRepository _repo;


	public ViewContactsUseCase(IContactRepository repo)
	{
		_repo = repo;
	}


	public async Task<List<ContactEntity>> ExecuteAsync(string? filterText = null)
	{
		return await _repo.GetAllAsync(filterText);
		
	}
}
