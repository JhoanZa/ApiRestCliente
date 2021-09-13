using ApiRestCliente.Models.MDomicilios;
using ApiRestCliente.Models.MProductos;
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
        //Datos de usuario y metodos para su respectiva gestion
        public Usuario Usuario { get; set; }

        public void IniciarUsuario()
        {
            Usuario = new Usuario();
            Domicilio = new Domicilio();
        }
        public void EliminarUsuario()
        {
            Usuario = new Usuario();
            Domicilio = new Domicilio();
        }

        //Datos relacionados con los departamentos
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
                    Domicilio.NombreDepartamento = d.Text;
                    break;
                }
            }
        }
        
        //Datos relacionados con los municipios
        public void AsignarMunicipio(int IdMunicipio)
        {
            foreach (SelectListItem d in Municipios)
            {
                if (d.Value.Equals(String.Concat(IdMunicipio)))
                {
                    Domicilio.NombreMunicipio = d.Text;
                    break;
                }
            }
        }
        public List<SelectListItem> Municipios { get; set; }
        public void AgregarMunicipios(List<Municipio> municipios) 
        {
            if (Municipios.Count < 1)
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

        public Domicilio Domicilio { get; set; }

        public int IdDomicilio { get; set; }

        public void CrearDomicilio(Domicilio domicilio)
        {
            if (domicilio != null)
            {
                Domicilio = domicilio;
            }
        }

        //Datos de producto

        public List<Producto> Productos { get; set; }

        public void CargarProductos(List<Producto> productos)
        {
            Productos = new List<Producto>();
            if (Usuario.Correo == null || Usuario.Correo.Equals(""))
            {
                Productos.Add(new Producto());
            }
            else
            {
                foreach (Producto p1 in productos)
                {

                    Productos.Add(p1);
                }
            }
            
        }
        [JsonProperty(PropertyName = "idProducto")]
        public int IdProducto { get; set; }

        [Required]
        [Display(Name = "Correo del vendedor:")]
        [JsonProperty(PropertyName = "correoVendedor")]
        public String CorreoVendedor { get; set; }

        [Required]
        [Display(Name = "Categoría:")]
        [JsonProperty(PropertyName = "categoria")]
        public String NombreCategoria { get; set; }

        [Required]
        [Display(Name = "Nombre del producto:")]
        [JsonProperty(PropertyName = "nombre")]
        public String NombreProducto { get; set; }

        [Required]
        [Display(Name = "Descripción:")]
        [JsonProperty(PropertyName = "descripcion")]
        public String Descripcion { get; set; }

        [Required]
        [Display(Name = "Cantidad disponible:")]
        [JsonProperty(PropertyName = "cantidadDisponible")]
        public int CantidadDisponible { get; set; }

        [Required]
        [Display(Name = "Costo del producto:")]
        [JsonProperty(PropertyName = "valorVenta")]
        public decimal ValorVenta { get; set; }


        //Datos de las categorias
        public List<SelectListItem> Categorias { get; set; }
        public void AgregarCategorias(List<Categoria> categorias)
        {    
            Categorias = new List<SelectListItem>();
            if (Categorias.Count < 1)
            {
                Categorias.Add(new SelectListItem("----------", "10000"));
            }
            foreach (Categoria c in categorias)
            {
                Categorias.Add(new SelectListItem(c.Nombre, String.Concat(c.IdCategoria)));
            }
        }

        public void AsignarCategoria(int IdCategoria)
        {
            foreach (SelectListItem c in Categorias)
            {
                if (c.Value.Equals(String.Concat(IdCategoria)))
                {
                    NombreCategoria = c.Text;
                    break;
                }
            }
        }
    }
}
