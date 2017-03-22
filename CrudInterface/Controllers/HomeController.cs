using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
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
        public ActionResult Login(Usuario u)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                string connectionString = "Data Source=DESKTOP-UISGS37\\SQLEXPRESS;Initial Catalog=DoctorWeb;User ID=heinrich;Password=hla060174";
                using ( SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmdAcesso = new SqlCommand("select id,usuario,tipo,usuarioinc,usuarioman,usuariodel," +
                        "pacienteinc,pacienteman,pacientedel,convenioinc,convenioman,conveniodel," +
                        "movimentoinc,movimentoman,movimentodel,relatorio,grafico,medicoinc,medicoman,medicodel,procedimentoinc,procedimentoman,procedimentodel,enfermeiroinc,enfermeiroman,enfermeirodel,fichainc,fichadel,fichaman " +
                        " from dbo.usuario where usuario='" +u.NomeUsuario+"' and senha='"+u.Senha+"'", con))
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
                        SqlDataReader drsretorno = cmdAcesso.ExecuteReader();
                        // esta action trata o post (login)
                        if (drsretorno.HasRows)
                        {
                            while (drsretorno.Read())
                            {
                                Session["usuarioLogadoID"] = u.NomeUsuario;
                                Session["acessos"] = Convert.ToInt16(drsretorno.GetBoolean(3)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(4)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(5)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(6)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(7)).ToString() +
                                                     Convert.ToInt16(drsretorno.GetBoolean(8)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(9)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(10)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(11)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(12)).ToString() +
                                                     Convert.ToInt16(drsretorno.GetBoolean(13)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(14)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(15)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(16)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(17)).ToString() +
                                                     Convert.ToInt16(drsretorno.GetBoolean(18)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(19)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(20)) + Convert.ToInt16(drsretorno.GetBoolean(21)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(22)).ToString() +
                                                     Convert.ToInt16(drsretorno.GetBoolean(23)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(24)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(25)) + Convert.ToInt16(drsretorno.GetBoolean(26)).ToString() + Convert.ToInt16(drsretorno.GetBoolean(27)).ToString() +
                                                     Convert.ToInt16(drsretorno.GetBoolean(28)).ToString();
                            }
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