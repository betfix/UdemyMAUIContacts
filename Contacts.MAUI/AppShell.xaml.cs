using Contacts.MAUI.Views;
using Contacts.MAUI.Views_MVVM;

namespace Contacts.MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
		Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
		Routing.RegisterRoute(nameof(EditContact_MVVM_Page), typeof(EditContact_MVVM_Page));
		Routing.RegisterRoute(nameof(AddContact_MVVM_Page), typeof(AddContact_MVVM_Page));
		Routing.RegisterRoute(nameof(Contacts_MVVM_Page), typeof(Contacts_MVVM_Page));
	}
}
