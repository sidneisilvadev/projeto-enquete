﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Config
	{
		public List<Arquivo> Arquivos { get; set; }

		[JsonIgnore]
		public string Recurso => Arquivos?.FirstOrDefault()?.Recurso;
	}

	public class Arquivo
	{
		public string Path { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public string Recurso => $"{Path}/{Name}";
	}
}