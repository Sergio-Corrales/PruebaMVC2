using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC2.Models;

namespace PruebaMVC2.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string User, string Pass)
        {
            try
            {
                using (ChallengeEntities db = new ChallengeEntities())
                {
                    var lst = from x in db.User
                              where x.User_Name == User && x.Pass == Pass
                              select x;
                    if (lst.Count() > 0)
                    {
                        User oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        throw new Exception ("Usuario o Contraseña INCORRECTO!!!");
                    }
                }            
            }

            catch (Exception ex)
            {
                return Content("Error!!! " + ex.Message);
            }
        }
    }
}