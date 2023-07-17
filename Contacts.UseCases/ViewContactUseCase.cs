using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contacts.Core;

namespace Contacts.UseCases;
public class ViewContactUseCase : IViewContactUseCase
{
	private readonly IContactRepository _repo;


	public ViewContactUseCase(IContactRepository repo)
	{
		_repo = repo;
	}

	public async Task<ContactEntity>? ExecuteAsync(int id)
	{
		return await _repo.GetByIdAsync(id);
	}
}
