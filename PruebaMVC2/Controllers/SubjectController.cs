using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC2.Models;
using PruebaMVC2.Models.TableViewModels;

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
    }
}