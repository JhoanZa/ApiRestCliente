using ApiRestCliente.Models.MProductos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ApiRestCliente.Gestores
{
    public class GestorProductos
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";

        public GestorProductos()
        {
        }

        public static Producto ConsultarProducto(int id)
        {
            Uri();
            var request = client.GetAsync($"/api/Productos/{id}").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<Producto>(resultString);
                return Objeto;
            }
            return null;
        }
        public static List<Producto> ConsultarProductos()
        {
            Uri();
            var request = client.GetAsync($"/api/Productos/").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<List<Producto>>(resultString);
                return Objeto;
            }
            return null;
        }

        public static bool ModificarProducto(Producto producto)
        {
            if (VerificarProducto(producto.IdProducto))
            {
                _ = client.PutAsync($"api/Productos/{producto.IdProducto}", producto, new JsonMediaTypeFormatter()).Result;
                return true;
            }
            return false;
        }

        private static bool VerificarProducto(int id)
        {
            Producto c = ConsultarProducto(id);
            if (c == null)
            {
                return false;
            }
            return true;
        }

        private static void Uri()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(url);
            }
        }

        public static bool RegistrarProducto(Producto producto)
        {
            if (!VerificarProducto(producto.IdProducto))
            {
                _ = client.PostAsync("api/Productos/", producto, new JsonMediaTypeFormatter()).Result;
                return true;
            }

            return false;
        }
    }
}
