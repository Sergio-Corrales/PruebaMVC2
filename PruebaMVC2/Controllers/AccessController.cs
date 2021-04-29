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

        //Metodo para realizar login
        public ActionResult Enter(string User, string Pass)
        {
            try
            {
                //Cargo la bd en db
                using (ChallengeEntities db = new ChallengeEntities())
                {
                    //creo lista con linq verificando el usuario y la contraseña
                    var lst = from x in db.User
                              where x.User_Name == User && x.Pass == Pass
                              select x;
                    //Si retorna un usuario inicio la sesion
                    if (lst.Count() > 0)
                    {
                        User oUser = lst.First();
                        Session["User"] = oUser;

                        //Chequeo que tipo de usuario es (Admin o Student)
                        //using (ChallengeEntities db2 = new ChallengeEntities())
                        //{
                            //Verifico si es un administrador
                            var lst2 = from x in db.Admin
                                       where x.Id_User == oUser.Id_User
                                       select x;
                            //si retorna un administrador retorno valor "2"
                        if (lst2.Count() > 0)
                        {
                            return Content("2");
                        }
                        else
                        {
                            var lst3 = from x in db.Student
                                       where x.Id_User == oUser.Id_User
                                       select x;
                            if (lst3.Count() > 0)
                            {
                                return Content("3");
                            }
                        }

                        //}
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