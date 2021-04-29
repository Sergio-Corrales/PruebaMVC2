using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC2.Models;
using PruebaMVC2.Models.TableViewModels;

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
                            Lst2 = (from x in db.Person
                                    where P.Id_Person == x.Id_Person
                                    select new ProfesorTableViewModel
                                    {
                                        Id = x.Id,
                                        Firstname = x.FirstName,
                                        Lastname = x.LastName,
                                        Mail = x.Mail,
                                        Phone = x.Phone,
                                        State = "Inactivo"
                                    }).ToList();
                        }
                    }
                }

            }
            return View(Lst2);
        }
    }
}