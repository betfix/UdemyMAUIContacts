using Contacts.Core;

namespace Contacts.UseCases.Interfaces;

public interface IAddContactUseCase
{
		Task ExecuteAsync(ContactEntity contact);
}