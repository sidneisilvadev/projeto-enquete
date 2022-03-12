using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Pages
{
	[Route("/Enquete")]
    public partial class EnquetePage
    {
        [Inject]
        private Repositorio Repositorio { get; set; }

        private void NotifyChange() { }
    }
}