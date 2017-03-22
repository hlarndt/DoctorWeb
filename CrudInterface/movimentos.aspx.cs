using System;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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
                    Label1.BackColor = System.Drawing.Color.Black;
                    Label1.BorderColor = System.Drawing.Color.Black;
                    Label1.BorderStyle = BorderStyle.Solid;
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

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
