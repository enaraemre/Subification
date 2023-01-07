
using SUBIFICATION.Views;

namespace SUBIFICATION;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(UpdatePage), typeof(UpdatePage));
    }
}
