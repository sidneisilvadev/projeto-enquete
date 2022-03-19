﻿using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using SSJ.Enquete.WebApp.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Pages
{
	[Route("/")]
	public partial class IndexPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		[Inject]
		private JavaScriptProxy JavaScriptProxy { get; set; }

		private string Recurso { get; set; }

		private async void List()
		{
			Repositorio.Enquete.RemoverTodos();
			await Repositorio.List(OnNotifyChange, Recurso);
		}

		private void Add() => Repositorio.Enquete.Adicionar(new Candidato());

		private void RemoveAll() => Repositorio.Enquete.RemoverTodos();

		private void CandidatoView_DoRemove(Candidato candidato) => Repositorio.Enquete.Remover(candidato);

		private EventCallback OnNotifyChange => EventCallback.Factory.Create(this, () => { });

		public async Task Download()
		{
			var candidatos = Repositorio.Enquete.Candidatos.OrderByDescending(c => c.Votos).ThenBy(c => c.Nome);
			await JavaScriptProxy.BlazorDownloadFile(candidatos, "application/json", (Recurso ?? Repositorio?.Config?.Recurso)?.Replace("/", ";"));
		}
	}
}