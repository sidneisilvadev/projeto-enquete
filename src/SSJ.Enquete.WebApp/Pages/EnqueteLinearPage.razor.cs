using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Pages
{
	[Route("/EnqueteLinear")]
    public partial class EnqueteLinearPage
    {
        [Inject]
        private Repositorio Repositorio { get; set; }

        private void NotifyChange() { }
    }
}