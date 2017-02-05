using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace CrudInterface
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Focus();
            this.DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
        }

        protected void DetailsView1_ModeChanged(object sender, EventArgs e)
        {
            DetailsView1.Focus();
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            GridView1.DataBind();
        }

        protected void DetailsView1_Load(object sender, EventArgs e)
        {
            if (Session.Count==0)
            {
                Server.Transfer("logoff.aspx", true);
            }

            if (Session["acessos"].ToString().Substring(0, 1) == "1")
            {
                if (DetailsView1.DataItemCount == 0 & DetailsView1.CurrentMode == DetailsViewMode.ReadOnly)
                {
                    this.DetailsView1.ChangeMode(DetailsViewMode.Insert);
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        e.Row.Cells[i].ToolTip = "";
                        break;
                    case 1:
                        e.Row.Cells[i].ToolTip = "Inclusao - Usuário";
                        break;
                    case 2:
                        e.Row.Cells[i].ToolTip = "Alteração - Usuário";
                        break;
                    case 3:
                        e.Row.Cells[i].ToolTip = "Exclusão - Usuário";
                        break;
                    case 4:
                        e.Row.Cells[i].ToolTip = "Inclusão - Paciente";
                        break;
                    case 5:
                        e.Row.Cells[i].ToolTip = "Alteração - Paciente";
                        break;
                    case 6:
                        e.Row.Cells[i].ToolTip = "Exclusão - Paciente";
                        break;
                    case 7:
                        e.Row.Cells[i].ToolTip = "Inclusão - Convênio";
                        break;
                    case 8:
                        e.Row.Cells[i].ToolTip = "Alteração - Convênio";
                        break;
                    case 9:
                        e.Row.Cells[i].ToolTip = "Exclusão - Convênio";
                        break;
                    case 10:
                        e.Row.Cells[i].ToolTip = "Inclusão - Movimento";
                        break;
                    case 11:
                        e.Row.Cells[i].ToolTip = "Alteração - Movimento";
                        break;
                    case 12:
                        e.Row.Cells[i].ToolTip = "Exclusão - Movimento";
                        break;
                    case 13:
                        e.Row.Cells[i].ToolTip = "Inclusão - Ficha do Paciente";
                        break;
                    case 14:
                        e.Row.Cells[i].ToolTip = "Alteração - Ficha do Paciente";
                        break;
                    case 15:
                        e.Row.Cells[i].ToolTip = "Exclusão - Ficha do Paciente";
                        break;
                    case 16:
                        e.Row.Cells[i].ToolTip = "Inclusão - Médico";
                        break;
                    case 17:
                        e.Row.Cells[i].ToolTip = "Alteração - Médico";
                        break;
                    case 18:
                        e.Row.Cells[i].ToolTip = "Exclusão - Médico";
                        break;
                    case 19:
                        e.Row.Cells[i].ToolTip = "Inclusão - Enfermeiro";
                        break;
                    case 20:
                        e.Row.Cells[i].ToolTip = "Alteração - Enfermeiro";
                        break;
                    case 21:
                        e.Row.Cells[i].ToolTip = "Exclusão - Enfermeiro";
                        break;
                    case 22:
                        e.Row.Cells[i].ToolTip = "Inclusão - Procedimento";
                        break;
                    case 23:
                        e.Row.Cells[i].ToolTip = "Alteração - Procedimento";
                        break;
                    case 24:
                        e.Row.Cells[i].ToolTip = "Exclusão - Procedimento";
                        break;
                    case 25:
                        e.Row.Cells[i].ToolTip = "Relatórios";
                        break;
                    case 26:
                        e.Row.Cells[i].ToolTip = "Gráficos";
                        break;
                }
            }
        }

        protected void GridView2_DataBinding(object sender, EventArgs e)
        {
            if (Session["acessos"].ToString().Substring(1, 1) == "0")
            {
                GridView2.Columns[0].Visible = false;
            }
            else
            {
                GridView2.Columns[0].Visible = true;
            }
        }

        protected void DetailsView1_DataBinding(object sender, EventArgs e)
        {
            CommandField lbtn = DetailsView1.Fields[3] as CommandField;
            if (Session["acessos"].ToString().Substring(1, 1) == "0")
            {
                lbtn.ShowEditButton = false;
            }
            else
            {
                lbtn.ShowEditButton = true;
            }
            if (Session["acessos"].ToString().Substring(1, 0) == "0")
            {
                lbtn.ShowInsertButton = false;
            }
            else
            {
                lbtn.ShowInsertButton = true;
            }
            if (Session["acessos"].ToString().Substring(1, 2) == "0")
            {
                lbtn.ShowDeleteButton = false;
            }
            else
            {
                lbtn.ShowDeleteButton = true;
            }
        }
    }
}