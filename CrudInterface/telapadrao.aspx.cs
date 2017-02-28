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
                CommandField lbtn = DetailsView5.Fields[2] as CommandField;
                if (Session["acessos"].ToString().Substring(1, 18) == "0")
                {
                    lbtn.ShowEditButton = false;
                }
                else
                {
                    lbtn.ShowEditButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 17) == "0")
                {
                    lbtn.ShowInsertButton = false;
                }
                else
                {
                    lbtn.ShowInsertButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 19) == "0")
                {
                    lbtn.ShowDeleteButton = false;
                }
                else
                {
                    lbtn.ShowDeleteButton = true;
                }
            }

            if (Request.QueryString["menu"] == "4")
            {
                CommandField lbtn = DetailsView2.Fields[1] as CommandField;
                if (Session["acessos"].ToString().Substring(1, 15) == "0")
                {
                    lbtn.ShowEditButton = false;
                }
                else
                {
                    lbtn.ShowEditButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 14) == "0")
                {
                    lbtn.ShowInsertButton = false;
                }
                else
                {
                    lbtn.ShowInsertButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 16) == "0")
                {
                    lbtn.ShowDeleteButton = false;
                }
                else
                {
                    lbtn.ShowDeleteButton = true;
                }
            }

            if (Request.QueryString["menu"] == "3")
            {
                CommandField lbtn = DetailsView1.Fields[1] as CommandField;
                if (Session["acessos"].ToString().Substring(1, 21) == "0")
                {
                    lbtn.ShowEditButton = false;
                }
                else
                {
                    lbtn.ShowEditButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 20) == "0")
                {
                    lbtn.ShowInsertButton = false;
                }
                else
                {
                    lbtn.ShowInsertButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 22) == "0")
                {
                    lbtn.ShowDeleteButton = false;
                }
                else
                {
                    lbtn.ShowDeleteButton = true;
                }
            }
            if (Request.QueryString["menu"] == "2")
            {
                CommandField lbtn = DetailsView3.Fields[1] as CommandField;
                if (Session["acessos"].ToString().Substring(1, 7) == "0")
                {
                    lbtn.ShowEditButton = false;
                }
                else
                {
                    lbtn.ShowEditButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 6) == "0")
                {
                    lbtn.ShowInsertButton = false;
                }
                else
                {
                    lbtn.ShowInsertButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 8) == "0")
                {
                    lbtn.ShowDeleteButton = false;
                }
                else
                {
                    lbtn.ShowDeleteButton = true;
                }
            }

            if (Request.QueryString["menu"] == "1")
            {
                CommandField lbtn = DetailsView4.Fields[3] as CommandField;
                if (Session["acessos"].ToString().Substring(1, 4) == "0")
                {
                    lbtn.ShowEditButton = false;
                }
                else
                {
                    lbtn.ShowEditButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 3) == "0")
                {
                    lbtn.ShowInsertButton = false;
                }
                else
                {
                    lbtn.ShowInsertButton = true;
                }
                if (Session["acessos"].ToString().Substring(1, 5) == "0")
                {
                    lbtn.ShowDeleteButton = false;
                }
                else
                {
                    lbtn.ShowDeleteButton = true;
                }
            }

        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                string connectionString = ConfigurationManager.ConnectionStrings[3].ToString();
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
                        strMsg = "Usuario";
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
                            Response.Write("<script>alert('Erro na conexão do banco de dados.');</script>");
                        }
                        SqlDataReader drsretorno = cmdAcesso.ExecuteReader();
                        // esta action trata o post (login)
                        if (drsretorno.HasRows)
                        {
                            Response.Write("<script>alert('" + strMsg + " já cadastrado.');</script>");
                            e.Cancel = true;
                        }
                    }

                }
            }

        }

    }
}