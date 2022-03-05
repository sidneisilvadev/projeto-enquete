using SSJ.Enquete.WebApp.Classes;
using Microsoft.AspNetCore.Components;

namespace SSJ.Enquete.WebApp.Pages
{
    [Route("/Enquete")]
    public partial class EnquetePage
    {
        [Inject]
        private Repositorio Repositorio { get; set; }

    }
}