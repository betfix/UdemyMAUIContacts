namespace UdemyMAUIContacts.Models;

public class Contact
{
	public int ContactId { get; set; }
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public string? Address { get; set; }


	/*
	public void Deconstruct(out int contactId, out string name, out string email, out string phone, out string address)
	{
		contactId = this.ContactId;
		name = this.Name;
		email = this.Email;
		phone = this.Phone;
		address = this.Address;
	}*/
}