using Newtonsoft.Json;
using System;

namespace ApiRestCliente.Models.MUsuarios
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(int tipoUsuario, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
            DateTime fechaNacimiento, int edad, string correo, string contrasena)
        {
            TipoUsuario = tipoUsuario;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Edad = edad;
            Correo = correo;
            Contrasena = contrasena;
        }

        [JsonProperty(PropertyName = "tipoUsuario")]
        public int TipoUsuario { get; set; }

        [JsonProperty(PropertyName = "primerNombre")]
        public String PrimerNombre { get; set; }

        [JsonProperty(PropertyName = "segundoNombre")]
        public String SegundoNombre { get; set; }

        [JsonProperty(PropertyName = "primerApellido")]
        public String PrimerApellido { get; set; }

        [JsonProperty(PropertyName = "segundoApellido")]
        public String SegundoApellido { get; set; }

        [JsonProperty(PropertyName = "fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonProperty(PropertyName = "edad")]
        public int Edad { get; set; }

        [JsonProperty(PropertyName = "correo")]
        public String Correo { get; set; }

        [JsonProperty(PropertyName = "contrasena")]
        public String Contrasena { get; set; }

    }
}
