using Contacts.Core;

namespace Contacts.UseCases.Interfaces;

public interface IViewContactUseCase
{
		Task<ContactEntity>? ExecuteAsync(int id);
}