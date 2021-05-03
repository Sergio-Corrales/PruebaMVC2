using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC2.Models;
using PruebaMVC2.Models.TableViewModels;
using PruebaMVC2.Models.ViewModels;

namespace PruebaMVC2.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            List<SubjectTableViewModel> Lst = new List<SubjectTableViewModel>();
            using(ChallengeEntities db = new ChallengeEntities())
            {
                Lst = (from x in db.Subject
                       select new SubjectTableViewModel
                       {
                           Name = x.Name,
                           Description = x.Description,
                           Capacity = x.Capacity,
                           Availability = x.Availability,
                           TimeTable = x.TimeTable
                       }).ToList();
            }

            return View(Lst);
        }

        //Metodo para agregar materias
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SubjectViewModel model)
        {

            //Si el ingreso no es valido retorna a la vista de agregar materia
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ChallengeEntities())
            {
                Subject oSubject = new Subject();
                oSubject.Name = model.Name;
                oSubject.Description = model.Description;
                oSubject.Capacity = model.Capacity;
                oSubject.TimeTable = model.TimeTable;

                db.Subject.Add(oSubject);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Subject/Index"));

        }
    }
}