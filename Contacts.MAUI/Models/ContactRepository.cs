#pragma warning disable IDE0046

namespace Contacts.MAUI.Models
{
	public static class ContactRepository
	{
		public static List<Contact> Contacts { get; } = new()
		{
			new Contact
			{
				ContactId = 1, Name = "John Doe", Email = "", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new Contact
			{
				ContactId = 2, Name = "Jane Doe", Email = "janedoe@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new Contact
			{
				ContactId = 3, Name = "John Smith", Email = "johnsmith@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			},
			new Contact
			{
				ContactId = 4, Name = "Jane Smith", Email = "janesmith@gmail.com", Phone = "11--555-6666",
				Address = "Avenue du Parc 34, Brussels"
			}
		};

		public static void UpdateContact(int contactId, Contact contact)
		{
			if ( contactId != contact.ContactId )
				throw new ArgumentException("Contact ID mismatch.");
			var contactToUpdate = Contacts.FirstOrDefault(c => c.ContactId == contactId);
			if ( contactToUpdate == null )
				return;

			contactToUpdate.Name = contact.Name;
			contactToUpdate.Email = contact.Email;
			contactToUpdate.Phone = contact.Phone;
			contactToUpdate.Address = contact.Address;
		}

		public static void AddContact(Contact contact)
		{
			var maxId = Contacts.Max(c => c.ContactId);
			contact.ContactId = maxId + 1;
			Contacts.Add(contact);
		}

		public static void DeleteContact(int contactId)
		{
			var contactToDelete = Contacts.FirstOrDefault(c => c.ContactId == contactId);
			if ( contactToDelete == null )
				return;
			Contacts.Remove(contactToDelete);
		}

		public static Contact? GetContactById(int contactId)
		{
			var contact = Contacts.FirstOrDefault(c => c.ContactId == contactId);
			if ( contact == null )
				return null;
			return new Contact
			{
				ContactId = contact.ContactId, Name = contact.Name, Email = contact.Email,
				Phone = contact.Phone, Address = contact.Address
			};
		}

		public static IEnumerable<Contact> SearchContacts(string searchBarText)
		{
			var contacts = Contacts
				.Where(c => c.Name?.StartsWith(searchBarText, StringComparison.OrdinalIgnoreCase)??false)
				.ToList();

			
			if ( contacts.Any() )
				return contacts;

			contacts = Contacts
				.Where(c => c.Email?.StartsWith(searchBarText, StringComparison.OrdinalIgnoreCase)??false)
				.ToList();

			if ( contacts.Any() )
				return contacts;

			contacts = Contacts
				.Where(c => c.Phone?.StartsWith(searchBarText, StringComparison.OrdinalIgnoreCase)??false)
				.ToList();

			if ( contacts.Any() )
				return contacts;

			contacts = Contacts
				.Where(c => c.Address?.StartsWith(searchBarText, StringComparison.OrdinalIgnoreCase)??false)
				.ToList();

			return contacts;

		}
	}
}

