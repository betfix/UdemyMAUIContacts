namespace Contacts.Core;

// All the code in this file is included in all platforms.
public class ContactEntity
{
	public int ContactId { get; set; }
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Phone { get; set; }
	public string? Address { get; set; }
}
