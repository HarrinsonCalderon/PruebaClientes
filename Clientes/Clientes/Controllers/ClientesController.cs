using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clientes.Models.DTO;
using Clientes.Models;

namespace Clientes.Controllers
{
    public class ClientesController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            var clientesDTOS = new List<ClientesDTO>();
            using (GestionClientesDBEntities db=new GestionClientesDBEntities())
            {
                clientesDTOS = (from a in db.Clientes 
                                select new ClientesDTO
                                {
                                    CodigoCliente=a.CodigoCliente,
                                    NombreCliente=a.NombreCliente,
                                    CiudadCliente=a.CiudadCliente,
                                    Direccion=a.Direccion,
                                    Telefono=a.Telefono
                                }
                                ).ToList();
            }
            
                return View(clientesDTOS);
        }

        
        public ActionResult Create()
        {
           
            return View();
        }



        [HttpPost]
        public ActionResult Create(ClientesDTO model)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    using (GestionClientesDBEntities bd = new GestionClientesDBEntities())
                    {
                        Clientes.Models.Clientes tabla = new Clientes.Models.Clientes();
                        //tabla.CodigoCliente = model.CodigoCliente;
                        tabla.NombreCliente = model.NombreCliente;
                        tabla.CiudadCliente = model.CiudadCliente;
                        tabla.Direccion = model.Direccion;
                        tabla.Telefono = model.Telefono;
                        bd.Clientes.Add(tabla);
                        bd.SaveChanges();
                    }
                }
                return Redirect("~/Clientes/Index");

            }
            catch (Exception ea)
            {

            }
            return View(model);
        }

        public ActionResult Editar(int id)
        {
            var clientesDTOS = new ClientesDTO();
            using (GestionClientesDBEntities db = new GestionClientesDBEntities())
            {
                clientesDTOS = (from a in db.Clientes where a.CodigoCliente == id
                                select new ClientesDTO
                                {
                                    CodigoCliente = a.CodigoCliente,
                                    NombreCliente = a.NombreCliente,
                                    CiudadCliente = a.CiudadCliente,
                                    Direccion = a.Direccion,
                                    Telefono = a.Telefono
                                } 
                                ).FirstOrDefault();
            }

            return View(clientesDTOS);
  
        }
        [HttpPost]
        public ActionResult Editar(ClientesDTO model)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    using (GestionClientesDBEntities bd = new GestionClientesDBEntities())
                    {
                        Clientes.Models.Clientes tabla = new Clientes.Models.Clientes();
                        tabla.CodigoCliente = model.CodigoCliente;
                        tabla.NombreCliente = model.NombreCliente;
                        tabla.CiudadCliente = model.CiudadCliente;
                        tabla.Direccion = model.Direccion;
                        tabla.Telefono = model.Telefono;
                        
                        bd.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        bd.SaveChanges();
                    }
                }
                return Redirect("~/Clientes/Index");

            }
            catch (Exception ea)
            {

            }
            return View(model);

        }

        public ActionResult Eliminar(int id)
        {
            try
            {


              
                    using (GestionClientesDBEntities bd = new GestionClientesDBEntities())
                    {
                    var tabla = new  Clientes.Models.Clientes();
                    tabla = bd.Clientes.Find(id);
                    bd.Clientes.Remove(tabla);
                    bd.SaveChanges();
                }
                
                return Redirect("~/Clientes/Index");

            }
            catch (Exception ea)
            {

            }
            return View();
        }
    }
}