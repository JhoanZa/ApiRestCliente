using ApiRestCliente.Models.MDomicilios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ApiRestCliente.Gestores
{
    public class GestorMunicipios
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";
        public GestorMunicipios()
        {
        }

        public static List<Departamento> ConsultarDepartamento()
        {
            Uri();
            var request = client.GetAsync($"/api/Departamentos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<List<Departamento>>(resultString);
                return Objeto;
            }
            return null;
        }
        public static List<Municipio> ConsultarMunicipios(int idDepartamento)
        {
            Uri();
            var request = client.GetAsync($"/api/Municipios/{idDepartamento}").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<List<Municipio>>(resultString);
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
