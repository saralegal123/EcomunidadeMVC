using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EComunidadeMVC.Models;
using Newtonsoft.Json;
using System.Text;
<<<<<<< HEAD
=======

>>>>>>> 06e3c146928f8296d0ca2cdde73da3c29b471e8d

namespace EComunidadeMVC.Controllers
{
    public class EventosController : Controller
    {
<<<<<<< HEAD
        public string uriBase = "http://ecomunidade.somee.com/EComunidadeApi/eventos";

        public async Task<IActionResult> Index()
=======
        public string uriBase = "http://ecomunidade.somee.com/ecomunidadeapi/eventos";
   public async Task<IActionResult> Index()
>>>>>>> 06e3c146928f8296d0ca2cdde73da3c29b471e8d
        {
            List<EventoViewModel> eventos = new();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uriBase);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
<<<<<<< HEAD
                    eventos = JsonConvert.DeserializeObject<List<EventoViewModel>>(content) ?? new();
=======
                    eventos = JsonConvert.DeserializeObject<List<EventoViewModel>>(content);
>>>>>>> 06e3c146928f8296d0ca2cdde73da3c29b471e8d
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
<<<<<<< HEAD
=======
            EventoViewModel evento;

>>>>>>> 06e3c146928f8296d0ca2cdde73da3c29b471e8d
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{uriBase}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    TempData["MensagemErro"] = "Evento não encontrado.";
                    return RedirectToAction(nameof(Index));
                }

<<<<<<< HEAD
                var evento = JsonConvert.DeserializeObject<EventoViewModel>(content);
                if (evento == null)
                {
                    TempData["MensagemErro"] = "Erro ao processar os dados do evento.";
                    return RedirectToAction(nameof(Index));
                }

                return View(evento);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{uriBase}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    TempData["MensagemErro"] = "Evento não encontrado.";
                    return RedirectToAction(nameof(Index));
                }

                var evento = JsonConvert.DeserializeObject<EventoViewModel>(content);
                if (evento == null)
                {
                    TempData["MensagemErro"] = "Erro ao processar os dados do evento.";
                    return RedirectToAction(nameof(Index));
                }

                return View(evento);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EventoViewModel evento)
        {
            if (id != evento.IdEvento)
            {
                TempData["MensagemErro"] = "ID do evento não corresponde.";
                return View(evento);
            }

            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(evento);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"{uriBase}/update/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["MensagemSucesso"] = "Evento atualizado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                TempData["MensagemErro"] = "Erro ao atualizar evento.";
                return View(evento);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"{uriBase}/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    TempData["MensagemErro"] = "Evento não encontrado.";
                    return RedirectToAction(nameof(Index));
                }

                var evento = JsonConvert.DeserializeObject<EventoViewModel>(content);
                if (evento == null)
                {
                    TempData["MensagemErro"] = "Erro ao processar os dados do evento.";
                    return RedirectToAction(nameof(Index));
                }

                return View(evento);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"{uriBase}/delete/{id}");

                if (response.IsSuccessStatusCode)
                {
                    TempData["MensagemSucesso"] = "Evento excluído com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir evento.";
                }

                return RedirectToAction(nameof(Index));
            }
=======
                evento = JsonConvert.DeserializeObject<EventoViewModel>(content);
            }

            return View(evento);
>>>>>>> 06e3c146928f8296d0ca2cdde73da3c29b471e8d
        }
    }
}
