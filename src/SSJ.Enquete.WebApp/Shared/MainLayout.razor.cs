using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Shared
{
	public partial class MainLayout
	{
		private bool collapseNavMenu = false;

		private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

		public void ToggleNavMenu()
		{
			collapseNavMenu = !collapseNavMenu;
		}
	}
}