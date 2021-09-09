using System;
using System.Net.Http;

namespace ApiRestCliente.Gestores
{
    public class GestorDomicilios
    {
        private static readonly HttpClient client = new();
        private static readonly String url = "https://localhost:44324/";

    }
}
