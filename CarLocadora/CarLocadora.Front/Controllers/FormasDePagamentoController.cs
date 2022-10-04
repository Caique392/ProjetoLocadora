using CarLocadora.Comum;
using CarLocadora.Comum.Modelo;
using CarLocadora.Front.Models;
using CarLocadora.Modelo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class FormasDePagamentoController : Controller
    {
        private string? mensagem = string.Empty;

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;


        public FormasDePagamentoController(IOptions<DadosBase> dadosBase, IHttpClientFactory httpClient)
        {
            _dadosBase = dadosBase;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: FormasDePagamentoController
        public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<FormaPagamentoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }

        // GET: FormasDePagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormasDePagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormasDePagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] FormaPagamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Deu Zica");
                    }

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;

                return View();
            }
        }

        // GET: FormasDePagamentoController/Edit/5
        public ActionResult Edit(int id)
        {


            HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento/ObterDados?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FormaPagamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("Deu Zica");
            }
        }

        // POST: FormasDePagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] FormaPagamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento", model);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
                    else
                        throw new Exception("Deu Zica");

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;

                return View();
            }
        }

        // GET: FormasDePagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FormasDePagamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
