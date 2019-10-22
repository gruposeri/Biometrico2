using Biometrico2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Biometrico2.QPws;

namespace Biometrico2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            InsertaUsuarioDao usu = new InsertaUsuarioDao();
            UsuarioBean      Bean = new UsuarioBean();

            try{
                Bean = usu.sp_Biometrico_Insert_Nuevo_Empleado();
            }catch (Exception e){
                Console.Write(e);
            }

            return Json(Bean);
        }

        [HttpPost]
        public JsonResult Update(int empresa, int nomina)
        {
            InsertaUsuarioDao usu = new InsertaUsuarioDao();
            UsuarioBean Bean = new UsuarioBean();

            Bean = usu.sp_Biometrico_Update_Empleado(empresa, nomina);

            return Json(Bean);
        }
    }
}