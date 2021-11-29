using CRUD_Alumnos.Models;
using CRUD_Alumnos.Models.TablesViewsModels;
using CRUD_Alumnos.Models.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Alumnos.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            List<AlumnosTableViewModel> listAlumnos = null;

            using (AlumnosContext db = new AlumnosContext())
            {
                listAlumnos = db.ALUMNOS.Where(a => a.Edad > 18).Select(x => new AlumnosTableViewModel
                {
                    Nombres = x.Nombres,
                    Apellidos = x.Apellidos,
                    Edad = x.Edad,
                    Sexo = x.Sexo,
                    Fecha_Registro = x.Fecha_Registro
                }).ToList();
            }

            return View(listAlumnos);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AlumnosViewModel alumnosViewModel)
        {
            if (!ModelState.IsValid)
                return View(alumnosViewModel);

            try
            {
                using (AlumnosContext db = new AlumnosContext())
                {
                    ALUMNOS alumnosObj = new ALUMNOS();
                    alumnosObj.Nombres = alumnosViewModel.Nombres;
                    alumnosObj.Apellidos = alumnosViewModel.Apellidos;
                    alumnosObj.Edad = alumnosViewModel.Edad;
                    alumnosObj.Sexo = alumnosViewModel.Sexo;
                    alumnosObj.Fecha_Registro = Convert.ToDateTime(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));

                    db.ALUMNOS.Add(alumnosObj);
                    db.SaveChanges();
                }

                return Redirect(Url.Content("~/Alumnos/"));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar el Alumno: ", ex);
                return View(alumnosViewModel);
            }
        }
    }
}