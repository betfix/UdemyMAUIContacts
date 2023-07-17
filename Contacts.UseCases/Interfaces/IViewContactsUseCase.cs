using Contacts.Core;

namespace Contacts.UseCases.Interfaces;

public interface IViewContactsUseCase
{
		Task<List<ContactEntity>> ExecuteAsync(string? filterText = null);
}