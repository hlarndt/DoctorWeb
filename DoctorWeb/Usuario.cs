using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DoctorWeb
{
    public partial class Usuario : Form
    {
        public dynamic resultado;

        public object itens { get; private set; }

        [Serializable]
        public class estrutura
        {
            public string nome;
            public bool inc;
            public bool alt;
            public bool con;
            public bool rel;
            public bool gra;
            public bool inc1;
            public bool alt1;
            public bool con1;
            public bool rel1;
            public bool gra1;

            public estrutura(string a, bool b, bool c, bool d, bool e, bool f, bool g, bool h, bool i, bool j, bool k)
            {
                nome = a;
                inc = b;
                alt = c;
                con = d;
                rel = e;
                gra = f;
                inc1 = g;
                alt1 = h;
                con1 = i;
                rel1 = j;
                gra1 = k;
            }

        }
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'd12rnams4f6a7nDataSet.usuario' table. You can move, or remove it, as needed.
            this.usuarioTableAdapter.Fill(this.d12rnams4f6a7nDataSet.usuario);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja excluir esse usuario?", "ATENÇÃO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                usuarioTableAdapter.DeleteQuery(Convert.ToInt32(textBox4.Text));
                this.usuarioTableAdapter.Fill(this.d12rnams4f6a7nDataSet.usuario);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarioTableAdapter.InsertQuery();
            this.usuarioTableAdapter.Fill(this.d12rnams4f6a7nDataSet.usuario);
            usuarioBindingSource.MoveLast();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<estrutura> ls = new List<estrutura>();

            string[] SQLTipo = new string[dataGridView2.Rows.Count];
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                estrutura estrut = new estrutura(dataGridView2.Rows[i].Cells[0].EditedFormattedValue.ToString(),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[1].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[2].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[3].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[4].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[5].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[6].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[7].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[8].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[9].EditedFormattedValue.ToString()),
                    Convert.ToBoolean(dataGridView2.Rows[i].Cells[10].EditedFormattedValue.ToString()));
                ls.Add(estrut);
            }

            resultado = serializer.Serialize(ls);
            usuarioTableAdapter.UpdateQuery(textBox1.Text, textBox2.Text, textBox3.Text, resultado, Convert.ToInt32(textBox4.Text));
            this.usuarioTableAdapter.Fill(this.d12rnams4f6a7nDataSet.usuario);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
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
                    try
                    {
                        using (OdbcCommand command = new OdbcCommand("SELECT acessos FROM usuario where id="+textBox4.Text, con))
                        {
                            OdbcDataReader myReader1 = command.ExecuteReader();
                            try
                            {
                                while (myReader1.Read())
                                {
                                    var serializer = new JavaScriptSerializer();
                                    dynamic itens = serializer.Deserialize(myReader1.GetString(0),typeof(object));
                                    Dictionary<int, string> items = new Dictionary<int, string>();
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        foreach(Dictionary<string, object> item in itens)
                                        {
                                            if(item["nome"].ToString()== row["Tabela"].ToString())
                                            {
                                                row["inc"] = item["inc"];
                                                row["alt"] = item["alt"];
                                                row["con"] = item["con"];
                                                row["rel"] = item["rel"];
                                                row["gra"] = item["gra"];
                                                row["inc1"]= item["inc1"];
                                                row["alt1"]= item["alt1"];
                                                row["con1"]= item["con1"];
                                                row["rel1"]= item["rel1"];
                                                row["gra1"]= item["gra1"];
                                            }
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                myReader1.Close();
                            }
                        }
                    }
                    catch
                    {
                    }
                    con.Close();
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns["Tabela"].ReadOnly = true;
                    dataGridView2.Columns["Inc"].Width = 20;
                    dataGridView2.Columns["Alt"].Width = 20;
                    dataGridView2.Columns["Con"].Width = 20;
                    dataGridView2.Columns["Rel"].Width = 20;
                    dataGridView2.Columns["Gra"].Width = 20;
                    dataGridView2.Columns["Inc"].HeaderText = "I";
                    dataGridView2.Columns["Alt"].HeaderText = "A";
                    dataGridView2.Columns["Con"].HeaderText = "C";
                    dataGridView2.Columns["Rel"].HeaderText = "R";
                    dataGridView2.Columns["Gra"].HeaderText = "G";
                    dataGridView2.Columns["Inc1"].Width = 20;
                    dataGridView2.Columns["Alt1"].Width = 20;
                    dataGridView2.Columns["Con1"].Width = 20;
                    dataGridView2.Columns["Rel1"].Width = 20;
                    dataGridView2.Columns["Gra1"].Width = 20;
                    dataGridView2.Columns["Inc1"].HeaderText = "I";
                    dataGridView2.Columns["Alt1"].HeaderText = "A";
                    dataGridView2.Columns["Con1"].HeaderText = "C";
                    dataGridView2.Columns["Rel1"].HeaderText = "R";
                    dataGridView2.Columns["Gra1"].HeaderText = "G";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
