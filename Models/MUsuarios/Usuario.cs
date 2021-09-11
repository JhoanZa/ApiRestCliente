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

        public int TipoUsuario { get; set; }

        public String PrimerNombre { get; set; }

        public String SegundoNombre { get; set; }

        public String PrimerApellido { get; set; }

        public String SegundoApellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad { get; set; }

        public String Correo { get; set; }

        public String Contrasena { get; set; }

    }
}
