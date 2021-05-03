using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC2.Models;
using PruebaMVC2.Models.TableViewModels;

namespace PruebaMVC2.Controllers
{
    public class SubjectStudentController : Controller
    {
        // GET: SubjectStudent
        public ActionResult Index()
        {
            List<SubjectTableViewModel> Lst = new List<SubjectTableViewModel>();
            using (ChallengeEntities db = new ChallengeEntities())
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

        public ActionResult Inscripcion(string Name)
        {
            using (ChallengeEntities db = new ChallengeEntities())
            {
                Subject oSubject = new Subject();

                var IdSubjAux = (from x in db.Subject
                                where Name == x.Name
                                select x.Id_Subject).FirstOrDefault();
                

                User oUser = new User();
                oUser = (User)Session["User"];

                var IdStudAux = (from x in db.Student
                                where oUser.Id_User == x.Id_User
                                select x.Id_Student).FirstOrDefault();

                if (IdStudAux != 0 && IdSubjAux != 0)
                {
                    Subject_Student SS = new Subject_Student();
                    SS.Id_Student = IdStudAux;
                    SS.Id_Subject = IdSubjAux;

                    db.Subject_Student.Add(SS);
                    db.SaveChanges();

                }
                               
            }
            return View();
        }
    }
}