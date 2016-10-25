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
                            comboBox1.Items.Add(row["TABLE_NAME"].ToString());
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        // obtem o noma da planilha corrente
                        comboBox1.Text = row["TABLE_NAME"].ToString();
                        string sheet = row["TABLE_NAME"].ToString();
                        // obtem todos as linhas da planilha corrente
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", _olecon);
                        cmd.CommandType = CommandType.Text;
                        // copia os dados da planilha para o datatable
                        DataTable outputTable = new DataTable(sheet);
                        output.Tables.Add(outputTable);
                        new OleDbDataAdapter(cmd).Fill(outputTable);
                    }
                    dataGridView1.DataSource = output.Tables[0];
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                    // Neste momento, o conteúdo de todas as planilhas presentes no arquivo Excel foi copiado para os DataTables consolidados no Dataset "output".
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Visoes_SizeChanged(object sender, EventArgs e)
        {
            dataGridView1.Width = Visoes.ActiveForm.Width - 50;
            dataGridView1.Height = Visoes.ActiveForm.Height - 120;
            comboBox1.Width = Visoes.ActiveForm.Width - 250;   
        }
    }
}
