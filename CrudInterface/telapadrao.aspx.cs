using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace CrudInterface
{
    public partial class telapadrao : System.Web.UI.Page
    {
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                DetailsView5.Focus();
                this.DetailsView5.ChangeMode(DetailsViewMode.ReadOnly);
            }
            if (Request.QueryString["menu"] == "4")
            {
                DetailsView2.Focus();
                this.DetailsView2.ChangeMode(DetailsViewMode.ReadOnly);
            }
            if (Request.QueryString["menu"] == "3")
            {
                DetailsView1.Focus();
                this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            }
            if (Request.QueryString["menu"] == "2")
            {
                DetailsView3.Focus();
                this.DetailsView3.ChangeMode(DetailsViewMode.ReadOnly);
            }
            if (Request.QueryString["menu"] == "1")
            {
                DetailsView4.Focus();
                this.DetailsView4.ChangeMode(DetailsViewMode.ReadOnly);
            }
        }

        protected void DetailsView1_ModeChanged(object sender, EventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                DetailsView5.Focus();
            }
            if (Request.QueryString["menu"] == "4")
            {
                DetailsView2.Focus();
            }
            if (Request.QueryString["menu"] == "3")
            {
                DetailsView1.Focus();
            }
            if (Request.QueryString["menu"] == "2")
            {
                DetailsView3.Focus();
            }
            if (Request.QueryString["menu"] == "1")
            {
                DetailsView4.Focus();
            }
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                GridView5.DataBind();
            }
            if (Request.QueryString["menu"] == "4")
            {
                GridView2.DataBind();
            }
            if (Request.QueryString["menu"] == "3")
            {
                GridView1.DataBind();
            }
            if (Request.QueryString["menu"] == "2")
            {
                GridView3.DataBind();
            }
            if (Request.QueryString["menu"] == "1")
            {
                GridView4.DataBind();
            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                GridView5.DataBind();
            }
            if (Request.QueryString["menu"] == "4")
            {
                GridView2.DataBind();
            }
            if (Request.QueryString["menu"] == "3")
            {
                GridView1.DataBind();
            }
            if (Request.QueryString["menu"] == "2")
            {
                GridView3.DataBind();
            }
            if (Request.QueryString["menu"] == "1")
            {
                GridView4.DataBind();
            }
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                GridView5.DataBind();
            }
            if (Request.QueryString["menu"] == "4")
            {
                GridView2.DataBind();
            }
            if (Request.QueryString["menu"] == "3")
            {
                GridView1.DataBind();
            }
            if (Request.QueryString["menu"] == "2")
            {
                GridView3.DataBind();
            }
            if (Request.QueryString["menu"] == "1")
            {
                GridView4.DataBind();
            }
        }

        protected void DetailsView1_Load(object sender, EventArgs e)
        {
            if (Session.Count==0)
            {
                Server.Transfer("logoff.aspx", true);
            }

            if (Request.QueryString["menu"] == "5")
            {
                if (Session["acessos"].ToString().Substring(17, 1) == "1")
                {
                    if (DetailsView5.DataItemCount == 0 & DetailsView5.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        this.DetailsView5.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
            if (Request.QueryString["menu"] == "4")
            {
                if (Session["acessos"].ToString().Substring(14, 1) == "1")
                {
                    if (DetailsView2.DataItemCount == 0 & DetailsView2.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        this.DetailsView2.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
            if (Request.QueryString["menu"] == "3")
            {
                if (Session["acessos"].ToString().Substring(20, 1) == "1")
                {
                    if (DetailsView1.DataItemCount == 0 & DetailsView1.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        this.DetailsView1.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
            if (Request.QueryString["menu"] == "2")
            {
                if (Session["acessos"].ToString().Substring(6, 1) == "1")
                {
                    if (DetailsView3.DataItemCount == 0 & DetailsView3.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        this.DetailsView3.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
            if (Request.QueryString["menu"] == "1")
            {
                if (Session["acessos"].ToString().Substring(3, 1) == "1")
                {
                    if (DetailsView4.DataItemCount == 0 & DetailsView4.CurrentMode == DetailsViewMode.ReadOnly)
                    {
                        this.DetailsView4.ChangeMode(DetailsViewMode.Insert);
                    }
                }
            }
        }

        protected void DetailsView1_DataBinding(object sender, EventArgs e)
        {
            if (Request.QueryString["menu"] == "5")
            {
                TemplateField lbtn = DetailsView5.Fields[2] as TemplateField;
                if (Session["acessos"].ToString().Substring(17, 1) == "0")
                {
                    lbtn.InsertVisible = false;
                }
                else
                {
                    lbtn.InsertVisible = true;
                }
            }

            if (Request.QueryString["menu"] == "4")
            {
                TemplateField lbtn = DetailsView2.Fields[1] as TemplateField;
                if (Session["acessos"].ToString().Substring(14, 1) == "0")
                {
                    lbtn.InsertVisible = false;
                }
                else
                {
                    lbtn.InsertVisible = true;
                }
            }

            if (Request.QueryString["menu"] == "3")
            {
                TemplateField lbtn = DetailsView1.Fields[1] as TemplateField;
                if (Session["acessos"].ToString().Substring(20, 1) == "0")
                {
                    lbtn.InsertVisible = false;
                }
                else
                {
                    lbtn.InsertVisible = true;
                }
            }
            if (Request.QueryString["menu"] == "2")
            {
                TemplateField lbtn = DetailsView3.Fields[1] as TemplateField;
                if (Session["acessos"].ToString().Substring(6, 1) == "0")
                {
                    lbtn.InsertVisible = false;
                }
                else
                {
                    lbtn.InsertVisible = true;
                }
            }
            if (Request.QueryString["menu"] == "1")
            {
                TemplateField lbtn = DetailsView4.Fields[3] as TemplateField;
                if (Session["acessos"].ToString().Substring(3, 1) == "0")
                {
                    lbtn.InsertVisible = false;
                }
                else
                {
                    lbtn.InsertVisible = true;
                }
            }
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DoctorWebConnectionString"].ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    String strSql = "";
                    String strMsg = "";
                    if (Request.QueryString["menu"] == "5")
                    {
                        strSql = "select * from dbo.procedimento where descricao='" + e.Values[0].ToString() + "'";
                        strMsg = "Procedimento";
                    }
                    if (Request.QueryString["menu"] == "4")
                    {
                        strSql = "select * from dbo.medico where nome='" + e.Values[0].ToString() + "'";
                        strMsg = "Médico";
                    }
                    if (Request.QueryString["menu"] == "3")
                    {
                        strSql = "select * from dbo.enfermeiro where nome='" + e.Values[0].ToString() + "'";
                        strMsg = "Enfermeiro";
                    }
                    if (Request.QueryString["menu"] == "2")
                    {
                        strSql = "select * from dbo.convenio where nome='" + e.Values[0].ToString() + "'";
                        strMsg = "Convênio";
                    }
                    if (Request.QueryString["menu"] == "1")
                    {
                        strSql = "select * from dbo.paciente where nome='" + e.Values[0].ToString() + "'";
                        strMsg = "Paciente";
                    }
                    using (SqlCommand cmdAcesso = new SqlCommand(strSql, con))
                    {
                        con.Open();
                        try
                        {
                            cmdAcesso.ExecuteNonQuery();
                        }
                        catch
                        {
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('Erro na conexão do banco de dados.')</script>");
                        }
                        SqlDataReader drsretorno = cmdAcesso.ExecuteReader();
                        // esta action trata o post (login)
                        if (drsretorno.HasRows)
                        {
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('" + strMsg + " já cadastrado.')</script>");
                            e.Cancel = true;
                        }
                    }

                }
            }
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DoctorWebConnectionString"].ToString();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    String strSql = "";
                    String strMsg = "";
                    if (Request.QueryString["menu"] == "5")
                    {
                        strSql = "select * from dbo.procedimento where id<>" + e.Keys[0].ToString() + " and descricao='" + e.NewValues[0].ToString() + "'";
                        strMsg = "Procedimento";
                    }
                    if (Request.QueryString["menu"] == "4")
                    {
                        strSql = "select * from dbo.medico where id<>" + e.Keys[0].ToString() + " and nome='" + e.NewValues[0].ToString() + "'";
                        strMsg = "Médico";
                    }
                    if (Request.QueryString["menu"] == "3")
                    {
                        strSql = "select * from dbo.enfermeiro where id<>" + e.Keys[0].ToString() + " and nome='" + e.NewValues[0].ToString() + "'";
                        strMsg = "Enfermeiro";
                    }
                    if (Request.QueryString["menu"] == "2")
                    {
                        strSql = "select * from dbo.convenio where id<>" + e.Keys[0].ToString() + " and nome='" + e.NewValues[0].ToString() + "'";
                        strMsg = "Convênio";
                    }
                    if (Request.QueryString["menu"] == "1")
                    {
                        strSql = "select * from dbo.paciente where id<>" + e.Keys[0].ToString() + " and nome='" + e.NewValues[0].ToString() + "'";
                        strMsg = "Paciente";
                    }
                    using (SqlCommand cmdAcesso = new SqlCommand(strSql, con))
                    {
                        con.Open();
                        try
                        {
                            cmdAcesso.ExecuteNonQuery();
                        }
                        catch
                        {
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('Erro na conexão do banco de dados.')</script>");
                        }
                        SqlDataReader drsretorno = cmdAcesso.ExecuteReader();
                        // esta action trata o post (login)
                        if (drsretorno.HasRows)
                        {
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('" + strMsg + " já cadastrado.')</script>");
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        protected void Button1_Init(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(17, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init1(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(18, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button2_Init(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(17, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button3_Init(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(19, 1) == "0")
            { 
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init3(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(14, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init4(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(15, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button2_Init1(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(14, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button3_Init1(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(16, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init2(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(20, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button2_Init2(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(21, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button3_Init2(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(22, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init5(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(6, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init6(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(7, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button3_Init3(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(8, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init7(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(3, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button1_Init8(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(4, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }

        protected void Button3_Init4(object sender, EventArgs e)
        {
            Button acao = sender as Button;
            if (Session["acessos"].ToString().Substring(5, 1) == "0")
            {
                acao.Visible = false;
            }
            else
            {
                acao.Visible = true;
            }
        }
    }
}