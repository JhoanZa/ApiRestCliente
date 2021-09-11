using ApiRestCliente.Models.MDomicilios;
using ApiRestCliente.Models.MUsuarios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiRestCliente.Models
{
    public class ListaDatos
    {
        public ListaDatos()
        {
            TipoUsuario = 1;
            PrimerNombre = "Visitante";
            SegundoNombre = "";
            PrimerApellido = "";
            SegundoNombre = "";
        }

        [JsonProperty(PropertyName = "tipoUsuario")]
        public int TipoUsuario { get; set; }

        [Required(ErrorMessage = "El campo --Primer nombre-- es requerido.")]
        [Display(Name = "Primer nombre:")]
        [JsonProperty(PropertyName = "primerNombre")]
        public String PrimerNombre { get; set; }

        [Display(Name = "Segundo nombre:")]
        [JsonProperty(PropertyName = "segundoNombre")]
        public String SegundoNombre { get; set; }

        [Required(ErrorMessage = "El campo --Primer apellido-- es requerido.")]
        [Display(Name = "Primer apellido:")]
        [JsonProperty(PropertyName = "primerApellido")]
        public String PrimerApellido { get; set; }

        [Display(Name = "Segundo apellido:")]
        [JsonProperty(PropertyName = "segundoApellido")]
        public String SegundoApellido { get; set; }

        [Required(ErrorMessage = "El campo --Fecha de nacimiento-- es requerido")]
        [Display(Name = "Fecha de nacimiento:")]
        [JsonProperty(PropertyName = "fechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo --Edad- es requerido.")]
        [Display(Name = "Edad:")]
        [JsonProperty(PropertyName = "edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo --Correo-- es requerido.")]
        [Display(Name = "Correo:")]
        [JsonProperty(PropertyName = "correo")]
        public String Correo { get; set; }

        [Required(ErrorMessage = "El campo --contraseña-- es requerido.")]
        [Display(Name = "Contraseña:")]
        [JsonProperty(PropertyName = "contrasena")]
        public String Contrasena { get; set; }


        public void CrearUsuario(Usuario usuario)
        {
            TipoUsuario = usuario.TipoUsuario;
            PrimerNombre = usuario.PrimerNombre;
            SegundoNombre = usuario.SegundoNombre;
            PrimerApellido = usuario.PrimerApellido;
            SegundoApellido = usuario.SegundoApellido;
            FechaNacimiento = usuario.FechaNacimiento;
            Edad = usuario.Edad;
            Correo = usuario.Correo;
            Contrasena = usuario.Contrasena;
        }
        public Usuario GenerarUsuario()
        {
            Usuario usuario = new Usuario(TipoUsuario, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, FechaNacimiento, Edad, Correo, Contrasena);
            return usuario;
        }
        public void EliminarUsuario()
        {
            TipoUsuario = 1;
            PrimerNombre = "Visitante";
            SegundoNombre = "";
            PrimerApellido = "";
            SegundoApellido = "";
            FechaNacimiento = new DateTime().AddDays(0).AddMonths(0).AddYears(0);
            Edad = 0;
            Correo = "";
            Contrasena = "";
        }

        public List<SelectListItem> Departamentos { get; set; }
        public void AgregarDepartamento(List<Departamento> departamento)
        {
            if (Departamentos == null)
            {
                Departamentos = new List<SelectListItem>();
                Municipios = new List<SelectListItem>();
                Departamentos.Add(new SelectListItem("----------","10000"));
                Municipios.Add(new SelectListItem("----------", "10000"));
            }
            if (Departamentos.Count == 1)
            {
                foreach (Departamento d in departamento)
                {
                    Departamentos.Add(new SelectListItem(d.Nombre, String.Concat(d.IdDepartamento)));
                }
            }
        }
        public void AsignarDepartamento(int IdDepartamento)
        {
            foreach (SelectListItem d in Departamentos)
            {
                if (d.Value.Equals(String.Concat(IdDepartamento)))
                {
                    NombreDepartamento = d.Text;
                    break;
                }
            }
        }
        //Datos de los municipios
        public List<SelectListItem> Municipios { get; set; }
        public void AgregarMunicipios(List<Municipio> municipios) 
        {
            if (Municipios.Count > 1)
            {
                Municipios = new List<SelectListItem>();
                Municipios.Add(new SelectListItem("----------", "10000"));
            }
            foreach (Municipio m in municipios)
            {
                Municipios.Add(new SelectListItem(m.NombreMunicipio, String.Concat(m.Id)));
            }
        }

        //Datos de domicilio

        public String NombreDepartamento { get; set; }
        public String NombreMunicipio { get; set; }
    }
}
