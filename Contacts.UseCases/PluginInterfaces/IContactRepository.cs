using Contacts.Core;

namespace Contacts.UseCases.PluginInterfaces;
public interface IContactRepository
{
	Task<List<ContactEntity>> GetAllAsync(string? filterText = null);
	Task<ContactEntity> GetByIdAsync(int id);
	Task UpdateAsync(int contactId, ContactEntity contact);
	Task AddAsync(ContactEntity contact);
	Task DeleteAsync(int id);
}
