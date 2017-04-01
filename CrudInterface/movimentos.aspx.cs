using System;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using System.IO;
using System.Web.Mvc;
using System.Text;

namespace CrudInterface
{
    public partial class movimentos : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Data") + "\\" + fn;
                try
                {
                    FileUpload1.PostedFile.SaveAs(SaveLocation);
                    Label1.Font.Bold = true;
                    Label1.Font.Size = System.Web.UI.WebControls.FontUnit.Medium;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Height = 24;
                    Label1.Text = "Arquivo " + FileUpload1.PostedFile.FileName.ToString() + " foi recebido.";
                    if (File.Exists(SaveLocation))
                    {
                        var _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", SaveLocation);
                        var _olecon = new OleDbConnection(_StringConexao);
                        _olecon.Open();
                        var _oleCmd = new OleDbCommand();
                        _oleCmd.Connection = _olecon;
                        _oleCmd.CommandType = CommandType.Text;
                        DataTable dt = _olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        //Cria o objeto dataset para receber o conteúdo do arquivo Excel
                        DataSet output = new DataSet();
                        string firstplan = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                Debug.WriteLine(row["TABLE_NAME"].ToString());
                                if (firstplan.Length == 0)
                                {
                                    firstplan = row["TABLE_NAME"].ToString();
                                }
                            }
                        }
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + firstplan + "]", _olecon);
                        string sheet = firstplan;
                        DataTable outputTable = new DataTable(sheet);
                        output.Tables.Add(outputTable);
                        new OleDbDataAdapter(cmd).Fill(outputTable);
                        cmd.CommandType = CommandType.Text;
                        GridView1.DataSource = output.Tables[0];
                        GridView1.AutoGenerateColumns = true;
                        GridView1.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Label1.BackColor = System.Drawing.Color.Black;
                    Label1.BorderColor = System.Drawing.Color.Black;
                    Label1.BorderStyle = BorderStyle.Solid;
                    Label1.Font.Bold = true;
                    Label1.Font.Size = System.Web.UI.WebControls.FontUnit.Medium;
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Height = 24;
                    Label1.Text = "Erro: " + ex.Message;
                }
            }
            else
            {
                Label1.BackColor = System.Drawing.Color.Black;
                Label1.BorderColor = System.Drawing.Color.Black;
                Label1.BorderStyle = BorderStyle.Solid;
                Label1.Font.Bold = true;
                Label1.Font.Size = System.Web.UI.WebControls.FontUnit.Medium;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Height = 24;
                Label1.Text = "Por favor, selecione um arquivo.";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.BackColor = System.Drawing.Color.Black;
            Label1.BorderColor = System.Drawing.Color.Black;
            Label1.BorderStyle = BorderStyle.Solid;
            Label1.Font.Bold = true;
            Label1.Font.Size = System.Web.UI.WebControls.FontUnit.Medium;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Height = 24;
            if (GridView1.Rows.Count > 0)
            {
                Label1.Text = "O arquivo foi validado com sucesso.";
            }
            else
            {
                Label1.Text = "Favor selecione um arquivo.";
                return;
            }
            Label1.Text = "O arquivo foi validado com sucesso.";
            int cnterros = 0;
            foreach (System.Web.UI.WebControls.GridViewRow linha in GridView1.Rows)
            {
                int cnt = 0;
                string data = "";
                string paciente = "";
                string procedimento = "";
                string convenio = "";
                double vlproced = 0;
                double vlmed = 0;
                int qtde = 0;
                string medicoatend = "";
                string medicoproced = "";
                string equipemulti = "";
                foreach (TableCell coluna in linha.Cells)
                {
                    string nome = HttpUtility.HtmlDecode(GridView1.HeaderRow.Cells[cnt].Text.ToString().Trim());
                    if (nome == "Dt Proced")
                    {
                        data = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Paciente")
                    {
                        paciente = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Convênio")
                    {
                        convenio = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Proced")
                    {
                        procedimento = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Qt")
                    {
                        try
                        {
                            qtde = Convert.ToInt32(HttpUtility.HtmlDecode(coluna.Text.ToString().Trim()));
                        }
                        catch
                        {
                            qtde = 0;
                        }
                    }
                    if (nome == "Vl Proced")
                    {
                        try
                        {
                            vlproced = Convert.ToDouble(HttpUtility.HtmlDecode(coluna.Text.ToString().Trim()));
                        }
                        catch
                        {
                            vlproced = 0;
                        }
                    }
                    if (nome == "Vl Med")
                    {
                        try
                        {
                            vlmed = Convert.ToDouble(HttpUtility.HtmlDecode(coluna.Text.ToString().Trim()));
                        }
                        catch
                        {
                            vlmed = 0;
                        }
                    }
                    if (nome == "Méd Atend")
                    {
                        medicoatend = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Méd Proced")
                    {
                        medicoproced = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    if (nome == "Equipe Multi")
                    {
                        equipemulti = HttpUtility.HtmlDecode(coluna.Text.ToString().Trim());
                    }
                    cnt++;
                }
                cnt = 0;
                foreach (TableCell coluna in linha.Cells)
                {
                    string nome = HttpUtility.HtmlDecode(GridView1.HeaderRow.Cells[cnt].Text.ToString().Trim());
                    if (procedimento.ToString().Contains("Total"))
                    {
                        break;
                    }
                    if (nome == "Dt Proced")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && data.ToString().Trim().Length == 0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Paciente")
                    {
                        if (procedimento.ToString().Trim().Length>0 && paciente.ToString().Trim().Length ==0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Convênio")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && convenio.ToString().Trim().Length == 0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Qt")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && qtde == 0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Vl Proced")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && vlproced == 0 && vlmed == 0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Vl Med")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && vlproced == 0 && vlmed == 0)
                        {
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Méd Atend")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && medicoatend.Trim().ToString().Trim().Length == 0 && medicoproced.ToString().Trim().Length == 0 && equipemulti.ToString().Trim().Length == 0)
                        {
                            cnterros++;
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Méd Proced")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && medicoatend.ToString().Trim().Length == 0 && medicoproced.ToString().Trim().Length == 0 && equipemulti.ToString().Trim().Length == 0)
                        {
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    if (nome == "Equipe Multi")
                    {
                        if (procedimento.ToString().Trim().Length > 0 && medicoatend.ToString().Trim().Length == 0 && medicoproced.ToString().Trim().Length == 0 && equipemulti.ToString().Trim().Length == 0)
                        {
                            coluna.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    cnt++;
                }
                if (cnterros>0)
                {
                    Label1.Text = "O arquivo possui " + cnterros.ToString() + " erros.";
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Label1.Text.Contains("erros"))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('O arquivo possui erros. Não será possível gravar.')</script>");
            }
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alerta", "<script>alert('Favor selecionar algum arquivo.')</script>");
            }
        }

        protected void form1_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Server.Transfer("logoff.aspx", true);
            }
        }
    }
}
