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
    public partial class Designer : Form
    {
        public Designer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Designer.ActiveForm.Close();
        }

        private void Designer_Load(object sender, EventArgs e)
        {
            string connectionString = DoctorWeb.Properties.Settings.Default.DoctorMed;
            using (OdbcConnection con = new OdbcConnection(connectionString))
            {
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
                                comboBox1.Items.Add(myReader.GetString(0));
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
            }
            
        }
    }
}
