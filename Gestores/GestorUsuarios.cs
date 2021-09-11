using ApiRestCliente.Models.MUsuarios;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ApiRestCliente.Gestores
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
            var request = client.GetAsync($"/api/Usuarios/{correo}").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<Usuario>(resultString);
                return Objeto;
            }
            return null;
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            if (VerificarUsuario(usuario.Correo))
            {
                _ = client.PutAsync($"api/Usuarios/{usuario.Correo}", usuario, new JsonMediaTypeFormatter()).Result;
                return true;
            }
            return false;
        }

        private static bool VerificarUsuario(String correo)
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
