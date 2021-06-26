using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCcrud.Models;
using MVCcrud.Models.ViewModel;

namespace MVCcrud.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<ListPersonaViewModel> lista;
            using (CRUDEntities db = new CRUDEntities() )
            {
                     lista = (from d in db.PERSONA 
                             orderby d.Id_Persona
                             select new ListPersonaViewModel 
                             {
                                 Id_Persona = d.Id_Persona,
                                 Nombre = d.Nombre,
                                 Correo = d.Correo,
                                 Fecha_Nacimiento = d.Fecha_Nacimiento                                        
                             }).ToList();
                
                
            }
            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using(CRUDEntities db = new CRUDEntities())
                    {
                        var oPersona = new PERSONA();
                        oPersona.Nombre = model.Nombre;
                        oPersona.Correo = model.Correo;
                        oPersona.Fecha_Nacimiento = model.Fecha_Nacimiento;

                        db.PERSONA.Add(oPersona);
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Editar(int Id)
        {
            PersonaViewModel model = new PersonaViewModel();
            using(CRUDEntities db = new CRUDEntities())
            {
                var oPersona = db.PERSONA.Find(Id);
                model.Nombre = oPersona.Nombre;
                model.Correo = oPersona.Correo;
                model.Fecha_Nacimiento = oPersona.Fecha_Nacimiento;
                model.Id_Persona = oPersona.Id_Persona;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CRUDEntities db = new CRUDEntities())
                    {
                        var oPersona = db.PERSONA.Find(model.Id_Persona);
                        oPersona.Nombre = model.Nombre;
                        oPersona.Correo = model.Correo;
                        oPersona.Fecha_Nacimiento = model.Fecha_Nacimiento;

                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified; 
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Eliminar(int Id)
        {            
            using (CRUDEntities db = new CRUDEntities())
            {
                var oPersona = db.PERSONA.Find(Id);
                db.PERSONA.Remove(oPersona);
                db.SaveChanges();
            }
            return Redirect("~/Persona/");
        }

    }
}