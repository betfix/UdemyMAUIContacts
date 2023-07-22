using Contacts.UseCases.PluginInterfaces;
using Contacts.UseCases.Interfaces;

namespace Contacts.UseCases;
public class DeleteContactUseCase : IDeleteContactUseCase
{
	private readonly IContactRepository _repo;


	public DeleteContactUseCase(IContactRepository repo)
	{
		_repo = repo;
	}


	public async Task ExecuteAsync(int id)
	{
		await _repo.DeleteAsync(id);
	}
}
