namespace UdemyMAUIContacts.Views.Controls;

public partial class ContactControl : ContentView
{
	public event EventHandler<string>? OnError;
	public event EventHandler<EventArgs>? OnSave;
	public event EventHandler<EventArgs>? OnCancel;

	private int _contactId;

	public int ContactId
	{
		get => _contactId;
		set
		{
			_contactId = value;
			ContactIdLabel.Text = value.ToString();
		}
	}

	public string? Name
	{
		get => NameEntry.Text;
		set => NameEntry.Text = value;
	}

	public string? Email
	{
		get => EmailEntry.Text;
		set => EmailEntry.Text = value;
	}

	public string? Phone
	{
		get => PhoneEntry.Text;
		set => PhoneEntry.Text = value;
	}

	public string? Address
	{
		get => AddressEntry.Text; 
		set => AddressEntry.Text = value;
	}


	public ContactControl()
	{
		InitializeComponent();
	}


	private void CancelButton_OnClicked(object? sender, EventArgs e)
	{
		OnCancel?.Invoke(sender, e);
	}


	private void SaveButton_OnClicked(object? sender, EventArgs e)
	{
		if ( NameValidator.IsNotValid )
		{
			OnError?.Invoke(sender, "Name is required");
			return;
		}

		if ( EmailValidator.IsNotValid )
		{
			foreach ( var error in EmailValidator.Errors! )
			{
					OnError?.Invoke(sender, error?.ToString()??"");
			}

			return;
		}

		OnSave?.Invoke(sender, e);
	}
}