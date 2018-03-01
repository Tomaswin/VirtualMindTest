using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirtualTest.Models;
using VirtualTest.Data;

namespace VirtualTest.Controllers
{
    public class MonedaController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return Json(new {
                Request = "GET"
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(string name)
        {
            List<Money> Lista = new List<Money>();

            Money e = new Money();
            e.Nombre = "Euro";
            e.cotizacion = "17.56";
            Lista.Add(e);

            Money d = new Money();
            d.Nombre = "Dolar";
            d.cotizacion = traerdolar();
            Lista.Add(d);

            Money l = new Money();
            l.Nombre = "Libra";
            l.cotizacion = "28.56";
            Lista.Add(l);

            if (name.Equals("Dolar") == true)
            {
                Money m = new Money();
                m.Nombre = Lista[1].Nombre;
                m.cotizacion = Lista[1].cotizacion;
                return Json(m);
            }
            else
            {
                return Json("Error 401");
            }


        }

        public string traerdolar()
        {
            var uri = String.Format("https://www.bancoprovincia.com.ar/Principal/Dolar", 500);

            WebClient client = new WebClient();
            client.UseDefaultCredentials = true;
            var data = client.DownloadString(uri);

            var result = Convert.ToString(data);
            
            string sinraros = result.Replace("[", "");
            string sinraros2 = sinraros.Replace("\"", "");

            return sinraros2;
        }



        //Solo pude hacer que se muestre mediante PostMan, ya que devuelve un json
        public ActionResult GetUser()
        {
            List<Users> list = UsuariosData.ObtenerUsuarios();
            for (int i = 0; i <= list.Count; i++)
            {
                Users u = new Users();
                u.nombre = list[i].nombre;
                u.apellido = list[i].apellido;
                u.email = list[i].email;
                u.contraseña = list[i].contraseña;

                return Json(u);
            }

            return null;
        }

        public ActionResult AddUser(string Nombre, string Apellido, string Email, string Password)
        {
            Users ouser = new Users();
            ouser.nombre = Nombre;
            ouser.apellido = Apellido;
            ouser.email = Email;
            ouser.contraseña = Password;

            UsuariosData.InsertarUsuario(ouser);

            return Json("Hecho"); ;
        }

        public ActionResult DeleteUser(int Id)
        {
            UsuariosData.Delete(Id);

            return Json("Hecho");
        }

        public ActionResult UpdateUser(int id, string Nombre, string Apellido, string Email, string Password)
        {
            Users ouser = new Users();
            ouser.id = id;
            ouser.nombre = Nombre;
            ouser.apellido = Apellido;
            ouser.email = Email;
            ouser.contraseña = Password;

            UsuariosData.Update(ouser);

            return Json("Hecho");
        }
    }
}
