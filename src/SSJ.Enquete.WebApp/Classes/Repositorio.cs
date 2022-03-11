using System;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Repositorio
	{
		public Enquete Enquete { get; }

		public Repositorio(IServiceProvider serviceProvider)
		{
			Enquete = new Enquete(serviceProvider);
		}
	}
}