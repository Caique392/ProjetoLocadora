using CarLocadora.Comum;
using CarLocadora.Comum.Modelo;
using CarLocadora.Modelo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarLocadora.Front.Controllers
{
    public class VeiculoController : Controller
    {
        private string mensagem = string.Empty;

        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;
        private readonly IApiToken _apiToken;
        public VeiculoController(IOptions<DadosBase> dadosBase, IApiToken apiToken, IHttpClientFactory httpClient)
        {
            _dadosBase = dadosBase;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: VeiculoController
        public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
        {
            if (sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<List<VeiculoModel>>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: VeiculoController/Create
        public ActionResult Create()
        {
            ViewBag.CategoriasDeVeiculos = CarregarCategoriasDeVeiculos();

            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] VeiculoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", model);

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
                TempData["erro"] = "Algo deu errado " + ex.Message;

                return View();
            }
        }

        // GET: VeiculoController/Edit/5
        public async Task<IActionResult> Edit(string placa)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo/ObterDados?placa={placa}").Result;

            if (response.IsSuccessStatusCode)
            {
                string conteudo = response.Content.ReadAsStringAsync().Result;
                return View(JsonConvert.DeserializeObject<VeiculoModel>(conteudo));
            }
            else
            {
                throw new Exception("Algo deu errado");
            }
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] VeiculoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo", model);

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

        public async Task<List<SelectListItem>> CarregarCategoriasDeVeiculos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());

            HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Categoria");

            if (response.IsSuccessStatusCode)
            {
                string conteudo = await response.Content.ReadAsStringAsync();
                List<CategoriaModel> categorias = JsonConvert.DeserializeObject<List<CategoriaModel>>(conteudo);

                foreach (var linha in categorias)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.Id.ToString(),
                        Text = linha.Descricao,
                        Selected = false,
                    });
                }
                return lista;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
        //// GET: VeiculoController/Delete/5
        //public ActionResult Delete(string placa)
        //{
        //    try
        //    {
        //        HttpClient client = new();
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken.Obter());


        //        HttpResponseMessage response = client.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Veiculo?Placa={placa}").Result;

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

        //// POST: VeiculoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(string veiculo, IFormCollection collection)
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
