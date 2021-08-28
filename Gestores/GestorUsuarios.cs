using ApiRestCliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Gestores
{
    class GestorUsuarios
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";

        public  GestorUsuarios()
        {
        }

        public static Usuario ConsultarUsuario(String correo)
        {
            Uri();
            var request = client.GetAsync($"api/Usuarios/{correo}").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<Usuario>(resultString);
                return Objeto;
            }
            return null;
        }

        public static bool VerificarUsuario(String correo)
        {
           Usuario c = ConsultarUsuario(correo);
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

        public static bool RegistrarUsuario(Usuario usuario)
        {
            if (!VerificarUsuario(usuario.Correo))
            {
                _ = client.PostAsync("api/Usuarios/", usuario, new JsonMediaTypeFormatter()).Result;
                return true;
            }

            return false;
        }
    }
}
