using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;


namespace pplemus.Controllers
{
    public class veterinariaController : Controller
    {
        // GET: veterinaria
        [System.Web.Http.HttpPost]
        public IHttpActionResult Index()
        {
            using (Models.veterinariaEntities db = new Models.veterinariaEntities())
            {
                var masco = new Models.mascotas();

                masco.nombre = "Baki";
                masco.raza = "pitbull";
                masco.edad = "2 años ";
                masco.dueño = "jose miguel guardado quintanilla";
                


                db.mascotas.Add(masco);
                db.SaveChanges();
                
                return ok("la mascota se agrego con exito");

            }
        }

        private IHttpActionResult ok(string v)
        {
            throw new NotImplementedException();
        }
    }
}