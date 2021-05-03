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
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            List<Profesor> Lst = new List<Profesor>();
            List<ProfesorTableViewModel> Lst2=new List<ProfesorTableViewModel>();
            ProfesorTableViewModel PTVM;

            using(ChallengeEntities db=new ChallengeEntities())
            {
                Lst = (from x in db.Profesor
                      where x.State == 1 || x.State == 0
                      select x).ToList();

                if (Lst.Count() > 0)
                {
                    foreach ( Profesor P in Lst)
                    {
                        if (P.State == 1)
                        {
                            PTVM = (from x in db.Person
                                     where P.Id_Person == x.Id_Person
                                     select new ProfesorTableViewModel
                                     {
                                         Id = x.Id,
                                         Firstname = x.FirstName,
                                         Lastname = x.LastName,
                                         Mail = x.Mail,
                                         Phone = x.Phone,
                                         State = "Activo"
                                     }).Single();
                            Lst2.Add(PTVM);
                        }
                        else
                        {
                            PTVM = (from x in db.Person
                                    where P.Id_Person == x.Id_Person
                                    select new ProfesorTableViewModel
                                    {
                                        Id = x.Id,
                                        Firstname = x.FirstName,
                                        Lastname = x.LastName,
                                        Mail = x.Mail,
                                        Phone = x.Phone,
                                        State = "Inactivo"
                                    }).Single();
                            Lst2.Add(PTVM);
                        }
                    }
                }

            }
            return View(Lst2);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProfesorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ChallengeEntities())
            {
                Person oPerson = new Person();

                oPerson.Id = model.Id;
                oPerson.FirstName = model.FirstName;
                oPerson.LastName = model.LastName;
                oPerson.Mail = model.Email;
                oPerson.Phone = model.Phone;

                db.Person.Add(oPerson);
                db.SaveChanges();

                var lst = (from x in db.Person
                          where x.Id == model.Id
                          select x).ToList();

                if (lst.Count() > 0)
                {
                    foreach(var P in lst)
                    {
                        if (P.Id == model.Id)
                        {
                            Profesor oProfesor = new Profesor();
                            oProfesor.Id_Person = P.Id_Person;
                            oProfesor.State = 1;

                            db.Profesor.Add(oProfesor);
                            db.SaveChanges();
                        }
                    }
                }
            }

            return Redirect(Url.Content("~/Profesor/Index"));
        }
    }

    
}