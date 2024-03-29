﻿using ApiRestCliente.Models.MDomicilios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ApiRestCliente.Gestores
{
    public class GestorDomicilios
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";

        public GestorDomicilios()
        {
        }


        public static List<Domicilio> ConsultarDomicilio(String correo)
        {
            Uri();
            var request = client.GetAsync($"/api/Domicilios/{correo}").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var Objeto = JsonConvert.DeserializeObject<List<Domicilio>>(resultString);
                return Objeto;
            }
            return null;
        }

        public static bool ModificarDomicilio(Domicilio domicilio)
        {
            if (VerificarDomicilio(domicilio.CorreoAsociado))
            {
                _ = client.PutAsync($"api/Domicilios/{domicilio.Id}", domicilio, new JsonMediaTypeFormatter()).Result;
                return true;
            }
            return false;
        }

        private static bool VerificarDomicilio(String correo)
        {
            List<Domicilio> c = ConsultarDomicilio(correo);
            if (c.Count == 0)
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

        public static bool RegistrarDomicilio(Domicilio domicilio)
        {
            if (!VerificarDomicilio(domicilio.CorreoAsociado))
            {
                _ = client.PostAsync("api/Domicilios/", domicilio, new JsonMediaTypeFormatter()).Result;
                return true;
            }

            return false;
        }
    }
}
