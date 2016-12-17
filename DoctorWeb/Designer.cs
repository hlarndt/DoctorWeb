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
using ControlManager;
using System.Web.Script.Serialization;

namespace DoctorWeb
{
    public partial class Designer : Form
    {
        private System.Windows.Forms.Label[] lblArray;
        private System.Windows.Forms.TextBox[] txtArray;
        private System.Windows.Forms.Button[] btnArray;
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
                    var achou = false;
                    using (OdbcCommand command = new OdbcCommand("SELECT tablename FROM pg_catalog.pg_tables where schemaname='public' and tablename not in ('layout','usuario') order by tablename", con))
                    {
                        OdbcDataReader myReader = command.ExecuteReader();
                        try
                        {
                            while (myReader.Read())
                            {
                                comboBox1.Items.Add(myReader.GetString(0));
                                if (achou == false)
                                {
                                    achou = true;
                                    comboBox1.Text = myReader.GetString(0);
                                }
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
        private void AddControls(string anyControl, int cNumber)
        {
            switch (anyControl)
            {
                case "btn": // anyControl = btn to Add Button
                    {
                        // assign number of controls 
                        btnArray = new System.Windows.Forms.Button[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            btnArray[i] = new System.Windows.Forms.Button();
                        }
                        break;
                    }
                case "lbl": // anyControl = lbl to Add Label
                    {
                        // assign number of controls 
                        lblArray = new System.Windows.Forms.Label[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            lblArray[i] = new System.Windows.Forms.Label();
                        }
                        break;
                    }
                case "txt": // anyControl = txt to Add TextBox
                    {
                        // assign number of controls 
                        txtArray = new System.Windows.Forms.TextBox[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            txtArray[i] = new System.Windows.Forms.TextBox();
                        }
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var linha = 50;
            string connectionString = DoctorWeb.Properties.Settings.Default.DoctorMed;
            using (OdbcConnection con = new OdbcConnection(connectionString))
            {
                panel1.Controls.Clear();
                con.Open();
                try
                {
                    using (OdbcCommand command = new OdbcCommand("SELECT dados FROM layout where lower(trim(tabela))='"+comboBox1.Text+"'", con))
                    {
                        OdbcDataReader myReader = command.ExecuteReader();
                        try
                        {
                            while (myReader.Read())
                            {
                                var serializer = new JavaScriptSerializer();
                                dynamic itens = serializer.Deserialize(myReader.GetString(0), typeof(object));
                                Dictionary<int, string> items = new Dictionary<int, string>();
                                AddControls("lbl", Enumerable.Count(itens)-1);
                                AddControls("txt", Enumerable.Count(itens)-1);
                                var pos = 0;
                                foreach (Dictionary<string, object> item in itens)
                                {
                                    lblArray[pos].Left = 100;
                                    lblArray[pos].Top = linha;
                                    lblArray[pos].Width = 70;
                                    lblArray[pos].Text = item["nome"].ToString()+":";
                                    panel1.Controls.Add(lblArray[pos]);
                                    ControlMoverOrResizer.Init(lblArray[pos]);
                                    txtArray[pos].Left = 200;
                                    txtArray[pos].Top = linha;
                                    txtArray[pos].Width = 100;
                                    panel1.Controls.Add(txtArray[pos]);
                                    ControlMoverOrResizer.Init(txtArray[pos]);
                                    linha = linha + 30;
                                    pos = pos + 1;
                                }
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

            AddControls("btn", 2);

            btnArray[0].Left = 100;
            btnArray[0].Top = linha;
            btnArray[0].Width = 72;
            btnArray[0].Height = 24;
            btnArray[0].Text = "Incluir";
            panel1.Controls.Add(btnArray[0]);
            ControlMoverOrResizer.Init(btnArray[0]);

            btnArray[1].Left = 200;
            btnArray[1].Top = linha;
            btnArray[1].Width = 72;
            btnArray[1].Height = 24;
            btnArray[1].Text = "Salvar";
            panel1.Controls.Add(btnArray[1]);
            ControlMoverOrResizer.Init(btnArray[1]);

            btnArray[2].Left = 300;
            btnArray[2].Top = linha;
            btnArray[2].Width = 72;
            btnArray[2].Height = 24;
            btnArray[2].Text = "Sair";
            panel1.Controls.Add(btnArray[2]);
            ControlMoverOrResizer.Init(btnArray[2]);

        }
    }
}
