using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace DoctorWeb
{
    public partial class Visoes : Form
    {
        public bool achoutabela;
        public bool achouarquivo;
        public int id;
        public dynamic resultado;
        [Serializable]
        public class estrutura
        {
            public string nome;
            public string campo;
            public int tamanho;
            public int chave;

            public estrutura(string a, string b, int c, int d)
            {
                nome = a;
                campo = b;
                tamanho = c;
                chave = d;
            }

        }
        public Visoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(ExcelSelector.ShowDialog() == DialogResult.OK)
            {
                var _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", ExcelSelector.FileName);
                try
                {
                    var _olecon = new OleDbConnection(_StringConexao);
                    var firstplan = "";
                    _olecon.Open();
                    var _oleCmd = new OleDbCommand();
                    _oleCmd.Connection = _olecon;
                    _oleCmd.CommandType = CommandType.Text;
                    DataTable dt = _olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    //Cria o objeto dataset para receber o conteúdo do arquivo Excel
                    DataSet output = new DataSet();
                    //Add each table name to the combo box
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        comboBox1.Items.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            if (firstplan.Length == 0)
                            {
                                firstplan = row["TABLE_NAME"].ToString();
                            }
                            comboBox1.Items.Add(row["TABLE_NAME"].ToString());
                        }
                        comboBox1.Text = firstplan;
                        populaplanilha();
                    }
                }
                    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                populaplanilha();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Visoes_SizeChanged(object sender, EventArgs e)
        {
            Redimensiona();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text=="Gerar Dados")
            {
                achouarquivo = false;
                achoutabela = false;
                id = 0;

                this.dataGridView2.Columns.Clear();
                this.dataGridView2.Rows.Clear();
                this.dataGridView2.Columns.Add("Campo", "Campo");
                DataGridViewComboBoxColumn tipos = new DataGridViewComboBoxColumn();
                var tiposlst = new List<string>() { "Caracter", "Data", "Moeda", "Numero" };
                tipos.DataSource = tiposlst;
                tipos.HeaderText = "Tipo";
                tipos.DataPropertyName = "Tipo";
                this.dataGridView2.Columns.Add(tipos);
                this.dataGridView2.Columns.Add("Tamanho", "Tamanho");
                this.dataGridView2.Columns.Add("Chave", "Chave");

                if (ExcelSelector.FileName.Length == 0 || comboBox1.Text.Length == 0)
                {
                    MessageBox.Show("Por favor, selecione algum arquivo\ne depois selecione a planilha ativa.");
                    return;
                }

                foreach (DataGridViewColumn coluna in dataGridView1.Columns)
                {
                    this.dataGridView2.Rows.Add(coluna.HeaderText, "Caracter", 100, 0);
                }

                var table = layoutTableAdapter1.GetData();
                // Print column 0 of each returned row.
                foreach (DataRow linha in table)
                {
                    if (linha[1].ToString() == comboBox1.Text.Replace("$", ""))
                    {
                        id = Convert.ToInt32(linha[0].ToString());
                        achoutabela = true;
                    }
                    if (linha[3].ToString() == ExcelSelector.FileName.ToString())
                    {
                        id = Convert.ToInt32(linha[0].ToString());
                        achouarquivo = true;
                    }

                }

                button2.Text = "Salvar Dados";
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                comboBox1.Visible = false;
                button1.Visible = false;

            }

            else
            {

                button2.Text = "Gerar Dados";
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                comboBox1.Visible = true;
                button1.Visible = true;

                JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

                List<estrutura> ls = new List<estrutura>();

                var Campos = "";
                string[] SQLTipo = new string[dataGridView2.Rows.Count];
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    estrutura estrut = new estrutura(dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString(),
                        dataGridView2.Rows[i].Cells[1].EditedFormattedValue.ToString(), 
                        Convert.ToInt32(dataGridView2.Rows[i].Cells[2].EditedFormattedValue.ToString()),
                        Convert.ToInt32(dataGridView2.Rows[i].Cells[3].EditedFormattedValue.ToString()));
                    ls.Add(estrut);
                    Campos = Campos + '"' + dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString() + '"';
                    var Tipo = "";
                    switch (dataGridView2.Rows[i].Cells[1].EditedFormattedValue.ToString())
                    {
                        case "Caracter":
                            Tipo = " char(" + Convert.ToInt32(dataGridView2.Rows[i].Cells[2].EditedFormattedValue.ToString()) + ")";
                            SQLTipo[i] = "C";
                            break;
                        case "Data":
                            Tipo = " date";
                            SQLTipo[i] = "D";
                            break;
                        case "Moeda":
                            Tipo = " money";
                            SQLTipo[i] = "N";
                            break;
                        case "Numero":
                            Tipo = " bigint";
                            SQLTipo[i] = "N";
                            break;
                    }
                    Campos = Campos + Tipo;
                    if (i < dataGridView2.Rows.Count - 1)
                    {
                        Campos = Campos + ",";
                    }
                }

                resultado = serializer.Serialize(ls);
                var table = layoutTableAdapter1.GetData();
                var grava = false;

                if (achouarquivo == true && achoutabela == true)
                {
                    DialogResult Opcao = MessageBox.Show("Planiha já existe.Deseja regravar?", "ATENÇÃO", MessageBoxButtons.YesNo);
                    if (Opcao == DialogResult.No)
                    {
                        grava = false;
                    }
                    else
                    {
                        layoutTableAdapter1.UpdateQuery(comboBox1.Text.Replace("$", ""), resultado, ExcelSelector.FileName.ToString(), id);
                        d12rnams4f6a7nDataSet1.AcceptChanges();
                        grava = true;
                    }
                }
                else
                {
                    layoutTableAdapter1.InsertQuery(comboBox1.Text.Replace("$", ""), resultado, ExcelSelector.FileName.ToString());
                    d12rnams4f6a7nDataSet1.AcceptChanges();
                    grava = true;
                }

                if (grava==true)
                {
                    string connectionString = DoctorWeb.Properties.Settings.Default.DoctorMed;
                    using (OdbcConnection con = new OdbcConnection(connectionString))
                    {
                        try
                        {
                            con.Open();
                            try
                            {
                                using (OdbcCommand command = new OdbcCommand("Drop Table " + comboBox1.Text.Replace("$", ""), con))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            catch
                            {
                            }
                            using (OdbcCommand command = new OdbcCommand("Create Table " + comboBox1.Text.Replace("$", "") + "(" + Campos + ")", con))
                            {
                                command.ExecuteNonQuery();
                            }
                            for (int i = 1; i < dataGridView1.Rows.Count; i++)
                            {
                                var Valores = "";
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    if (SQLTipo[j]=="C")
                                    {
                                        Valores += "'" + dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() + "'";
                                    }
                                    else if (SQLTipo[j]=="D")
                                    {
                                        if(dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString().Trim().Length==0)
                                            Valores += "'01/01/1901'";
                                        else
                                            Valores += "TO_DATE('" + dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() + "','MM/DD/YYYY')";
                                    }
                                    else if (SQLTipo[j]=="N")
                                    {
                                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString().Trim().Length == 0)
                                            Valores += "0";
                                        else
                                            Valores += dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString();
                                    }
                                    else
                                    {
                                        if (dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString().Trim().Length == 0)
                                            Valores += "'00:00:00'";
                                        else
                                            Valores += "'" + dataGridView1.Rows[i].Cells[j].EditedFormattedValue.ToString() + "'" ;
                                    }
                                    if (j < dataGridView1.Columns.Count - 1)
                                    {
                                        Valores += ",";
                                    }
                                }
                                using (OdbcCommand command = new OdbcCommand("Insert Into " + comboBox1.Text.Replace("$", "") + " Values (" + Valores + ")", con))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

        }

        private void populaplanilha()
        {
            var _StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", ExcelSelector.FileName);
            var _olecon = new OleDbConnection(_StringConexao);
            _olecon.Open();
            var _oleCmd = new OleDbCommand();
            _oleCmd.Connection = _olecon;
            _oleCmd.CommandType = CommandType.Text;
            DataTable dt = _olecon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Cria o objeto dataset para receber o conteúdo do arquivo Excel
            DataSet output = new DataSet();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + comboBox1.Text + "]", _olecon);
            string sheet = comboBox1.Text;
            DataTable outputTable = new DataTable(sheet);
            output.Tables.Add(outputTable);
            new OleDbDataAdapter(cmd).Fill(outputTable);
            cmd.CommandType = CommandType.Text;
            // copia os dados da planilha para o datatable
            dataGridView1.DataSource = output.Tables[0];
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
        }

        private void Redimensiona()
        {
            try
            {
                if (Visoes.ActiveForm.WindowState == FormWindowState.Maximized || Visoes.ActiveForm.WindowState == FormWindowState.Normal)
                {
                    dataGridView1.Width = Visoes.ActiveForm.Width - 50;
                    dataGridView1.Height = Visoes.ActiveForm.Height - 166;
                    dataGridView2.Width = Visoes.ActiveForm.Width - 50;
                    dataGridView2.Height = Visoes.ActiveForm.Height - 120;
                    comboBox1.Width = Visoes.ActiveForm.Width - 250;
                    button2.Left = Visoes.ActiveForm.Width - 133;
                    button2.Top = Visoes.ActiveForm.Height - 85;
                }
            }
            catch
            {

            }
        }

        private void Visoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex==2 || e.ColumnIndex==3)
            {
                var numero = 0;
                if (int.TryParse(e.FormattedValue.ToString(), out numero)==false)
                {
                    MessageBox.Show("Valor não é numérico", "ATENÇÃO!");
                    e.Cancel = true;
                }
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Designer Designer = new Designer(0,1);
            Designer.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Designer Designer = new Designer(1, 1);
            Designer.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Usuario Usuario = new Usuario();
            Usuario.Show();
        }

    }
}
