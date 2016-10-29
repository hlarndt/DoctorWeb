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

namespace DoctorWeb
{
    public partial class Visoes : Form
    {
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
            if (ExcelSelector.FileName.Length==0 || comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Por favor, selecione algum arquivo\ne depois selecione a planilha ativa.");
                return;
            }
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<string> ls = new List<string>();

            foreach (DataGridViewColumn coluna in dataGridView1.Columns)
            {
                ls.Add(coluna.HeaderText);                
            }

            dynamic resultado = serializer.Serialize(ls);

            layoutTableAdapter1.Insert("{"+comboBox1.Text.Replace("$","")+"}",resultado);
            d12rnams4f6a7nDataSet1.AcceptChanges();

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
            if (Visoes.ActiveForm.WindowState==FormWindowState.Maximized||Visoes.ActiveForm.WindowState==FormWindowState.Normal)
            {
                dataGridView1.Width = Visoes.ActiveForm.Width - 50;
                dataGridView1.Height = Visoes.ActiveForm.Height - 160;
                comboBox1.Width = Visoes.ActiveForm.Width - 250;
                button2.Left = Visoes.ActiveForm.Width - 133;
                button2.Top = Visoes.ActiveForm.Height - 85;
            }
        }

        private void Visoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
