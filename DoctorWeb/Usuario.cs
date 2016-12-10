using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorWeb
{
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'd12rnams4f6a7nDataSet.usuario' table. You can move, or remove it, as needed.
            this.usuarioTableAdapter.Fill(this.d12rnams4f6a7nDataSet.usuario);

            string connectionString = DoctorWeb.Properties.Settings.Default.DoctorMed;
            using (OdbcConnection con = new OdbcConnection(connectionString))
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Tabela", typeof(String)));
                    dt.Columns.Add(new DataColumn("Inc", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Alt", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Con", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Rel", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Gra", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Inc1", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Alt1", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Con1", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Rel1", typeof(bool)));
                    dt.Columns.Add(new DataColumn("Gra1", typeof(bool)));
                    con.Open();
                    try
                    {
                        using (OdbcCommand command = new OdbcCommand("SELECT tablename FROM pg_catalog.pg_tables where schemaname='public' and tablename not in ('layout','usuario') order by tablename", con))
                        {
                            OdbcDataReader myReader = command.ExecuteReader();
                            try
                            {
                                while (myReader.Read())
                                {
                                    dt.Rows.Add(myReader.GetString(0));
                                }
                            }
                            finally
                            {
                                myReader.Close();
                            }
                        }
                    }
                    catch
                    {
                    }
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns["Tabela"].ReadOnly = true;
                    dataGridView2.Columns["Inc"].Width=20;
                    dataGridView2.Columns["Alt"].Width=20;
                    dataGridView2.Columns["Con"].Width=20;
                    dataGridView2.Columns["Rel"].Width=20;
                    dataGridView2.Columns["Gra"].Width=20;
                    dataGridView2.Columns["Inc"].HeaderText = "I";
                    dataGridView2.Columns["Alt"].HeaderText = "A";
                    dataGridView2.Columns["Con"].HeaderText = "C";
                    dataGridView2.Columns["Rel"].HeaderText = "R";
                    dataGridView2.Columns["Gra"].HeaderText = "G";
                    dataGridView2.Columns["Inc1"].Width=20;
                    dataGridView2.Columns["Alt1"].Width=20;
                    dataGridView2.Columns["Con1"].Width=20;
                    dataGridView2.Columns["Rel1"].Width=20;
                    dataGridView2.Columns["Gra1"].Width=20;
                    dataGridView2.Columns["Inc1"].HeaderText="I";
                    dataGridView2.Columns["Alt1"].HeaderText="A";
                    dataGridView2.Columns["Con1"].HeaderText="C";
                    dataGridView2.Columns["Rel1"].HeaderText="R";
                    dataGridView2.Columns["Gra1"].HeaderText="G";
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario.ActiveForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.AddNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usuarioBindingSource.EndEdit();
            this.usuarioTableAdapter.Update(this.d12rnams4f6a7nDataSet.usuario);
            this.d12rnams4f6a7nDataSet.AcceptChanges();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void Usuario_Enter(object sender, EventArgs e)
        {

        }
    }
}
