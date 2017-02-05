using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Odbc;
using System.Web.Mvc;
using CrudInterface.Models;

namespace CrudInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                string connectionString = "Driver={PostgreSQL UNICODE};Server=127.0.0.1;Port=5432;Database=DoctorWeb;Uid=postgres;Pwd=p;";
                using (OdbcConnection con = new OdbcConnection(connectionString))
                {
                    using (OdbcCommand cmdAcesso = new OdbcCommand("select id,usuario,tipo,usuarioinc,usuarioman,usuariodel," +
                        "pacienteinc,pacienteman,pacientedel,convenioinc,convenioman,conveniodel," +
                        "movimentoinc,movimentoman,movimentodel,relatorio,grafico,medicoinc,medicoman,medicodel,procedimentoinc,procedimentoman,procedimentodel,enfermeiroinc,enfermeiroman,enfermeirodel,fichainc,fichadel,fichaman " +
                        " from usuario where usuario='" +u.NomeUsuario+"' and senha='"+u.Senha+"'", con))
                    {
                        con.Open();
                        try
                        {
                            cmdAcesso.ExecuteNonQuery();
                        }
                        catch
                        {
                            ViewBag.Message = "Erro na conexão do Banco de Dados.";
                            return View();
                        }
                        OdbcDataReader drsretorno = cmdAcesso.ExecuteReader();
                        // esta action trata o post (login)
                        if (drsretorno.HasRows)
                        {
                            Session["usuarioLogadoID"] = u.NomeUsuario;
                            Session["acessos"] = drsretorno.GetString(3) + drsretorno.GetString(4) + drsretorno.GetString(5) + drsretorno.GetString(6) + drsretorno.GetString(7) +
                                                 drsretorno.GetString(8) + drsretorno.GetString(9) + drsretorno.GetString(10)+ drsretorno.GetString(11)+ drsretorno.GetString(12)+
                                                 drsretorno.GetString(13)+ drsretorno.GetString(14)+ drsretorno.GetString(15)+ drsretorno.GetString(16) + drsretorno.GetString(17) +
                                                 drsretorno.GetString(18) + drsretorno.GetString(19) + drsretorno.GetString(20) + drsretorno.GetString(21) + drsretorno.GetString(22) +
                                                 drsretorno.GetString(23) + drsretorno.GetString(24) + drsretorno.GetString(25) + drsretorno.GetString(26) + drsretorno.GetString(27) +
                                                 drsretorno.GetString(28);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Message = "Acesso não autorizado.";
                            return View();
                        }
                    }
                }
            }
            return View(u);
            throw new NotImplementedException();
        }

    }
}