using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.CRUDAJAX.NET.Models;

namespace WEB.CRUDAJAX.NET.Controllers
{
    public class HomeController : Controller
    {
        BDPRUEBASEntities ctx = new BDPRUEBASEntities();

        public ActionResult EliminarCliente(int id)
        {
            Customer eliminar = (from e in ctx.Customers where e.CustomerId == id select e).FirstOrDefault();

            ctx.Customers.Remove(eliminar);
            ctx.SaveChanges();
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult EditarCliente(Customer cliente)
        {
            Customer actualizar = (from c in ctx.Customers where c.CustomerId == cliente.CustomerId select c).FirstOrDefault();

            actualizar.Country = cliente.Country;
            actualizar.Name = cliente.Name;
            ctx.SaveChanges();

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult CrearCliente(Customer cliente)
        {
            ctx.Customers.Add(cliente);
            ctx.SaveChanges();

            return Json(cliente);
        }





        public ActionResult Index()
        {
            return View(ctx.Customers);
        }     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}