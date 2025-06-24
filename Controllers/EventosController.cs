using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EComunidadeMVC.Models;
using Newtonsoft.Json;
using System.Text;


namespace EComunidadeMVC.Controllers
{
    public class EventosController : Controller
    {
        public string uriBase = "http://ecomunidade.somee.com/ecomunidadeapi/eventos";
   public async Task<IActionResult> Index()
        {
            List<EventoViewModel> eventos = new();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uriBase);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    eventos = JsonConvert.DeserializeObject<List<EventoViewModel>>(content);
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao buscar eventos.";
                }
            }

            return View(eventos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventoViewModel evento)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(evento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(uriBase, content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["MensagemSucesso"] = "Evento criado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["MensagemErro"] = "Erro ao criar evento.";
                return View(evento);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            EventoViewModel evento;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{uriBase}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    TempData["MensagemErro"] = "Evento não encontrado.";
                    return RedirectToAction(nameof(Index));
                }

                evento = JsonConvert.DeserializeObject<EventoViewModel>(content);
            }

            return View(evento);
        }
    }
}