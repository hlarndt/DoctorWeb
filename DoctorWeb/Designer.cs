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
        private System.Windows.Forms.Panel[] panArray;
        private System.Windows.Forms.Label[] lblpsqArray;
        private System.Windows.Forms.TextBox[] txtpsqArray;
        private System.Windows.Forms.Label[] lblArray;
        private System.Windows.Forms.TextBox[] txtArray;
        private System.Windows.Forms.Button[] btnArray;
        private System.Windows.Forms.DataGrid[] dtvArray;
        private System.Windows.Forms.GroupBox[] grbArray;
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
                case "pan": // anyControl = btn to Add Button
                    {
                        // assign number of controls 
                        panArray = new System.Windows.Forms.Panel[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            panArray[i] = new System.Windows.Forms.Panel();
                        }
                        break;
                    }
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
                case "lblpsq": // anyControl = lbl to Add Label
                    {
                        // assign number of controls 
                        lblpsqArray = new System.Windows.Forms.Label[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            lblpsqArray[i] = new System.Windows.Forms.Label();
                        }
                        break;
                    }
                case "txtpsq": // anyControl = txt to Add TextBox
                    {
                        // assign number of controls 
                        txtpsqArray = new System.Windows.Forms.TextBox[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            txtpsqArray[i] = new System.Windows.Forms.TextBox();
                        }
                        break;
                    }
                case "dtv": // anyControl = txt to Add TextBox
                    {
                        // assign number of controls 
                        dtvArray = new System.Windows.Forms.DataGrid[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            dtvArray[i] = new System.Windows.Forms.DataGrid();
                        }
                        break;
                    }
                case "grb": // anyControl = txt to Add TextBox
                    {
                        // assign number of controls 
                        grbArray = new System.Windows.Forms.GroupBox[cNumber + 1];
                        for (int i = 0; i < cNumber + 1; i++)
                        {
                            // Initialize one variable
                            grbArray[i] = new System.Windows.Forms.GroupBox();
                        }
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var linha = 20;
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
                            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;
                            AddControls("dtv", 0);
                            dtvArray[0].Left = 50;
                            dtvArray[0].Top = linha;
                            dtvArray[0].Width = 1250;
                            dtvArray[0].Height = 300;
                            linha = linha + 310;
                            panel1.Controls.Add(dtvArray[0]);
                            ControlMoverOrResizer.Init(dtvArray[0]);
                            var linpsq = 20;
                            while (myReader.Read())
                            {
                                var serializer = new JavaScriptSerializer();
                                dynamic itens = serializer.Deserialize(myReader.GetString(0), typeof(object));
                                Dictionary<int, string> items = new Dictionary<int, string>();
                                var achou = false;
                                var cntpsq = 0;
                                foreach (Dictionary<string, object> item in itens)
                                {
                                    AddControls("lblpsq", cntpsq);
                                    AddControls("txtpsq", cntpsq);
                                    if (item["chave"].ToString() != "0")
                                    {
                                        if (achou == false)
                                        {
                                            AddControls("grb", 0);
                                            grbArray[0].Left = 50;
                                            grbArray[0].Top = linha;
                                            grbArray[0].Width = 1250;
                                            grbArray[0].BackColor = Color.FromArgb(255, 255, 192);
                                            panel1.Controls.Add(grbArray[0]);
                                            ControlMoverOrResizer.Init(grbArray[0]);
                                            AddControls("pan", 0);
                                            panArray[0].Left = 0;
                                            panArray[0].Top = 0;
                                            panArray[0].Width = 1250;
                                            panArray[0].BackColor = Color.FromArgb(255, 255, 192);
                                            grbArray[0].Controls.Add(panArray[0]);
                                            ControlMoverOrResizer.Init(panArray[0],grbArray[0]);
                                            achou = true;
                                        }
                                        lblpsqArray[cntpsq].Left = 10;
                                        lblpsqArray[cntpsq].Top = linpsq;
                                        lblpsqArray[cntpsq].Width = 70;
                                        lblpsqArray[cntpsq].Text = item["nome"].ToString() + ":";
                                        panArray[0].Controls.Add(lblpsqArray[cntpsq]);
                                        ControlMoverOrResizer.Init(lblpsqArray[cntpsq]);
                                        txtpsqArray[cntpsq].Left = 110;
                                        txtpsqArray[cntpsq].Top = linpsq;
                                        txtpsqArray[cntpsq].Width = 10 + (Convert.ToInt32(item["tamanho"].ToString()) * 6);
                                        txtpsqArray[cntpsq].MaxLength = Convert.ToInt32(item["tamanho"].ToString());
                                        panArray[0].Controls.Add(txtpsqArray[cntpsq]);
                                        ControlMoverOrResizer.Init(txtpsqArray[cntpsq]);
                                        linpsq = linpsq + 30;
                                        grbArray[0].Height = linpsq;
                                        panArray[0].Height = linpsq;
                                        linha = linha + linpsq;
                                        cntpsq = cntpsq + 1;
                                    }
                                }
                                linha = linha + 10;
                                AddControls("lbl", Enumerable.Count(itens)-1);
                                AddControls("txt", Enumerable.Count(itens)-1);
                                var pos = 0;
                                foreach (Dictionary<string, object> item in itens)
                                {
                                    lblArray[pos].Left = 50;
                                    lblArray[pos].Top = linha;
                                    lblArray[pos].Width = 70;
                                    lblArray[pos].Text = item["nome"].ToString()+":";
                                    panel1.Controls.Add(lblArray[pos]);
                                    ControlMoverOrResizer.Init(lblArray[pos]);
                                    txtArray[pos].Left = 150;
                                    txtArray[pos].Top = linha;
                                    txtArray[pos].MaxLength = Convert.ToInt32(item["tamanho"].ToString());
                                    txtArray[pos].Width = 10 + (Convert.ToInt32(item["tamanho"].ToString()) * 6);
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
