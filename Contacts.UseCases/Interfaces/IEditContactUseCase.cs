using Contacts.Core;

namespace Contacts.UseCases.Interfaces;

public interface IEditContactUseCase
{
		Task ExecuteAsync(int contactId, ContactEntity contact);
}