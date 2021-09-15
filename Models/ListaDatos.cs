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
            Producto = new Producto();
        }
        public void EliminarUsuario()
        {
            Usuario = new Usuario();
            Domicilio = new Domicilio();
            Producto = new Producto();
        }


        //Datos de domicilio
        public Domicilio Domicilio { get; set; }

        public void CrearDomicilio(Domicilio domicilio)
        {
            if (domicilio != null)
            {
                Domicilio = domicilio;
            }
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

        //Datos de producto

        public Producto Producto { get; set; }

        public void AsignarProducto(int? IdProducto)
        {
            Producto = new Producto();
            foreach (Producto p in Productos)
            {
                if (p.IdProducto == IdProducto)
                {
                    Producto = p;
                    break;
                }
            }
        }   
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
                    Producto.Categoria = c.Text;
                    break;
                }
            }
        }
    }
}
