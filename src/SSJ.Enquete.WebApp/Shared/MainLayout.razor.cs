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