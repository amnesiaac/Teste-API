using CarrosConsomeApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarrosConsomeApi.Controllers
{
    public class ConsomeCarrosController : Controller
    {
        // GET: ConsomeCarros
        string uri = "http://localhost:56136/api/CarroApi";
        public async Task<ActionResult> Index()
        {
            List<Carro> carros;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var Json = await response.Content.ReadAsStringAsync();
                        carros = JsonConvert.DeserializeObject<Carro[]>(Json).ToList();
                        return View (carros);
                    }
                }
            }
            return null;
        }
    }
}
    