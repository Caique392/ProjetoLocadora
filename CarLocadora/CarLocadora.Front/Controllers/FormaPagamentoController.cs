using CarLocadora.Comum;
using CarLocadora.Comum.Modelo;
using CarLocadora.Modelo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class FormaPagamentoController : Controller
    {
        
        private string mensagem = string.Empty;

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;
        private readonly IApiToken _apiToken;
        public FormaPagamentoController(IOptions<DadosBase> dadosBase, IApiToken apiToken, IHttpClientFactory httpClient)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: FormaPagamentoController
        public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<FormaPagamentoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // GET: FormaPagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormaPagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] FormaPagamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento", model);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                    }
                    else
                    {
                        throw new Exception("Algo deu errado");
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

        // GET: FormaPagamentoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento/ObterDados?Id={id}");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<FormaPagamentoModel>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // POST: FormaPagamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] FormaPagamentoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}FormasDePagamento", model);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
                    else
                        throw new Exception("Algo deu errado");

                }
                else
                {
                    TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algo deu errado " + ex.Message;

                return View();
            }
        }

        //// GET: FormaPagamentoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        HttpClient client = new();
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());

        //        HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}FormaPagamento?Id={id}").Result;

        //        if (response.IsSuccessStatusCode)
        //            return RedirectToAction(nameof(Index), new { mensagem = "Registro deletado!", sucesso = true });
        //        else
        //            throw new Exception("Algo deu errado");

        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["erro"] = " Não foi possível realizar a exlusão" + ex.Message;

        //        return View();
        //    }
        //}

        //// POST: FormaPagamentoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}