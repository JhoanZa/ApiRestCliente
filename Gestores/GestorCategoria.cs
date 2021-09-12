using ApiRestCliente.Models.MProductos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiRestCliente.Gestores
{
    public class GestorCategoria
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";

        public GestorCategoria()
        {
        }
        public static List<Categoria> ConsultarCategorias()
        {
            Uri();
            var request = client.GetAsync($"/api/Categorias").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<List<Categoria>>(resultString);
                return Objeto;
            }
            return null;
        }

        private static void Uri()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(url);
            }
        }
    }
}
