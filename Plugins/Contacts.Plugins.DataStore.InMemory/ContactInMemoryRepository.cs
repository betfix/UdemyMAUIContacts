using Contacts.UseCases.PluginInterfaces;
using Contacts.Core;

namespace Contacts.Plugins.DataStore.InMemory;

// All the code in this file is included in all platforms.
public class ContactInMemoryRepository: IContactRepository
{
	public static List<ContactEntity> Contacts { get; set; }

	public ContactInMemoryRepository()
	{
		Contacts = new List<ContactEntity>
		{
			new()
			{
				ContactId = 1, Name = "John Doe", Email = "", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new()
			{
				ContactId = 2, Name = "Jane Doe", Email = "janedoe@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new()
			{
				ContactId = 3, Name = "John Smith", Email = "johnsmith@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new()
			{
				ContactId = 4, Name = "Jane Smith", Email = "janesmith@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			}
		};
	}


	public Task DeleteAsync(int id)
	{
		var contact = Contacts.FirstOrDefault(c => c.ContactId == id);
		if ( contact == null )
			return Task.CompletedTask;

		Contacts.Remove(contact);
		return Task.CompletedTask;
	}

	public Task<List<ContactEntity>> GetAllAsync(string filterText = null)
	{
		if ( string.IsNullOrWhiteSpace(filterText) )
			return Task.FromResult(Contacts);

		var contacts = Contacts
			.Where(c => c.Name?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)??false)
			.ToList();
			
		if ( contacts.Any() )
			return Task.FromResult(contacts);

		contacts = Contacts
			.Where(c => c.Email?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)??false)
			.ToList();

		if ( contacts.Any() )
			return Task.FromResult(contacts);

		contacts = Contacts
			.Where(c => c.Phone?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)??false)
			.ToList();

		if ( contacts.Any() )
			return Task.FromResult(contacts);

		contacts = Contacts
			.Where(c => c.Address?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)??false)
			.ToList();

		return Task.FromResult(contacts);
	}

	public Task<ContactEntity> GetByIdAsync(int id)
	{
		var contact = Contacts.FirstOrDefault(c => c.ContactId == id);
		return contact == null ? null : Task.FromResult(DuplicateContact(contact));
	}

	public Task UpdateAsync(int contactId, ContactEntity contact)
	{
		if ( contactId != contact.ContactId )
			return Task.CompletedTask;

		var contactToUpdate = Contacts.FirstOrDefault(c => c.ContactId == contactId);
		if ( contactToUpdate == null )
			return Task.CompletedTask;

		contactToUpdate.Name = contact.Name;
		contactToUpdate.Email = contact.Email;
		contactToUpdate.Phone = contact.Phone;
		contactToUpdate.Address = contact.Address;

		return Task.CompletedTask;
	}


	public Task AddAsync(ContactEntity contact)
	{
		var maxId = Contacts.Max(c => c.ContactId);
		contact.ContactId = maxId + 1;
		Contacts.Add(contact);
		return Task.CompletedTask;
	}


	private static ContactEntity DuplicateContact(ContactEntity contact)
	{
		return new ContactEntity
		{
			ContactId = contact.ContactId,
			Name = contact.Name,
			Email = contact.Email,
			Phone = contact.Phone,
			Address = contact.Address
		};
	}
}
