using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDMVC.Models;
using CRUDMVC.Models.ViewModels;
using System.Data;

namespace CRUDMVC.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (CrudEntities db = new CrudEntities())
            {
                lst = (from d in db.Tabla
                       select new ListTablaViewModel
                       {
                           Id = d.id,
                           Nombre = d.nombre,
                           Correo = d.correo,

                       }).ToList();
            }

            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new Tabla();
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.fecha_Nacimiento;
                        oTabla.nombre = model.Nombre;

                        db.Tabla.Add(oTabla);
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.Tabla.Find(Id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.fecha_Nacimiento = oTabla.fecha_nacimiento;
                model.Id = oTabla.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = db.Tabla.Find(model.Id);
                        oTabla.correo = model.Correo;
                        oTabla.fecha_nacimiento = model.fecha_Nacimiento;
                        oTabla.nombre = model.Nombre;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntities db = new CrudEntities())
            {

                var oTabla = db.Tabla.Find(Id);
                db.Tabla.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");

        }

    }
}