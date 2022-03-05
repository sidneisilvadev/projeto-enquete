using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Components
{
    public partial class CandidatoCard
    {
        [Parameter]
        public Candidato Candidato { get; set; }
    }
}