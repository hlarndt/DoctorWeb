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
    [Serializable]
    public class controles
    {
        public string nome;
        public int indice;
        public int height;
        public int width;
        public int left;
        public int top;
        public Color backcolor;
        public string text;
        public int maxlength;

        public controles(string a, int b, int c, int d, int e, int f, Color g, string h, int i)
        {
            nome = a;
            indice = b;
            height = c;
            width = d;
            left = e;
            top = f;
            backcolor = g;
            text = h;
            maxlength = i;
        }

    }
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
        public List<controles> controle = new List<controles>();
        public dynamic resultado;

        public Designer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            foreach (controles item in controle)
            {
                switch (item.nome.ToString())
                {
                    case "pan": // anyControl = btn to Add Button
                        {
                            item.left   = panArray[Convert.ToInt32(item.indice)].Left;
                            item.top    = panArray[Convert.ToInt32(item.indice)].Top;
                            item.width  = panArray[Convert.ToInt32(item.indice)].Width;
                            item.height = panArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "btn": // anyControl = btn to Add Button
                        {
                            item.left   = btnArray[Convert.ToInt32(item.indice)].Left;
                            item.top    = btnArray[Convert.ToInt32(item.indice)].Top;
                            item.width  = btnArray[Convert.ToInt32(item.indice)].Width;
                            item.height = btnArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "lbl": // anyControl = lbl to Add Label
                        {
                            item.left = lblArray[Convert.ToInt32(item.indice)].Left;
                            item.top = lblArray[Convert.ToInt32(item.indice)].Top;
                            item.width = lblArray[Convert.ToInt32(item.indice)].Width;
                            item.height = lblArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "txt": // anyControl = txt to Add TextBox
                        {
                            item.left = txtArray[Convert.ToInt32(item.indice)].Left;
                            item.top = txtArray[Convert.ToInt32(item.indice)].Top;
                            item.width = txtArray[Convert.ToInt32(item.indice)].Width;
                            item.height = txtArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "lblpsq": // anyControl = lbl to Add Label
                        {
                            item.left = lblpsqArray[Convert.ToInt32(item.indice)].Left;
                            item.top = lblpsqArray[Convert.ToInt32(item.indice)].Top;
                            item.width = lblpsqArray[Convert.ToInt32(item.indice)].Width;
                            item.height = lblpsqArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "txtpsq": // anyControl = txt to Add TextBox
                        {
                            item.left = txtpsqArray[Convert.ToInt32(item.indice)].Left;
                            item.top = txtpsqArray[Convert.ToInt32(item.indice)].Top;
                            item.width = txtpsqArray[Convert.ToInt32(item.indice)].Width;
                            item.height = txtpsqArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "dtv": // anyControl = txt to Add TextBox
                        {
                            item.left = dtvArray[Convert.ToInt32(item.indice)].Left;
                            item.top = dtvArray[Convert.ToInt32(item.indice)].Top;
                            item.width = dtvArray[Convert.ToInt32(item.indice)].Width;
                            item.height = dtvArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                    case "grb": // anyControl = txt to Add TextBox
                        {
                            item.left = grbArray[Convert.ToInt32(item.indice)].Left;
                            item.top = grbArray[Convert.ToInt32(item.indice)].Top;
                            item.width = grbArray[Convert.ToInt32(item.indice)].Width;
                            item.height = grbArray[Convert.ToInt32(item.indice)].Height;
                            break;
                        }
                }
            }
            resultado = serializer.Serialize(controle);
            controlesTableAdapter1.DeleteQuery(comboBox1.Text.ToString());
            controlesTableAdapter1.InsertQuery(comboBox1.Text.ToString(), "M", resultado);
            MessageBox.Show("Arquivo salvo.","ATENÇÃO");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Designer.ActiveForm.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            controlesTableAdapter1.DeleteQuery(comboBox1.Text.ToString());
            button3_Click(sender, e);
        }
        private void Designer_Load(object sender, EventArgs e)
        {
            OdbcDataReader myReader = funcoesdb.executasql("SELECT tablename FROM pg_catalog.pg_tables where schemaname='public' and tablename not in ('layout','usuario','controles') order by tablename");
            var achou = false;
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

        private void montacontrole(string control,int indice,int top,int left,int width, int height,Color backcolor,int maxlength, string texto)
        {
            controles elemento = new controles(control, indice, height, width, left, top, backcolor, texto,maxlength);
            controle.Add(elemento);
            switch (control)
            {
                case "pan": // anyControl = btn to Add Button
                    {
                        panArray[indice].Left = left;
                        panArray[indice].Top = top;
                        panArray[indice].Width = width;
                        panArray[indice].Height = height;
                        panArray[indice].BackColor = backcolor;
                        grbArray[indice].Controls.Add(panArray[indice]);
                        ControlMoverOrResizer.Init(panArray[indice], grbArray[0]);
                        break;
                    }
                case "btn": // anyControl = btn to Add Button
                    {
                        btnArray[indice].Left = left;
                        btnArray[indice].Top = top;
                        btnArray[indice].Width = width;
                        btnArray[indice].Height = height;
                        btnArray[indice].Text = texto;
                        panel1.Controls.Add(btnArray[indice]);
                        ControlMoverOrResizer.Init(btnArray[indice]);
                        break;
                    }
                case "lbl": // anyControl = lbl to Add Label
                    {
                        lblArray[indice].Left = left;
                        lblArray[indice].Top = top;
                        lblArray[indice].Width = width;
                        lblArray[indice].Text = texto;
                        panel1.Controls.Add(lblArray[indice]);
                        ControlMoverOrResizer.Init(lblArray[indice]);
                        break;
                    }
                case "txt": // anyControl = txt to Add TextBox
                    {
                        txtArray[indice].Left = left;
                        txtArray[indice].Top = top;
                        txtArray[indice].MaxLength = maxlength;
                        txtArray[indice].Width = width;
                        panel1.Controls.Add(txtArray[indice]);
                        ControlMoverOrResizer.Init(txtArray[indice]);
                        break;
                    }
                case "lblpsq": // anyControl = lbl to Add Label
                    {
                        lblpsqArray[indice].Left = left;
                        lblpsqArray[indice].Top = top;
                        lblpsqArray[indice].Width = width;
                        lblpsqArray[indice].Text = texto;
                        panArray[0].Controls.Add(lblpsqArray[indice]);
                        ControlMoverOrResizer.Init(lblpsqArray[indice]);
                        break;
                    }
                case "txtpsq": // anyControl = txt to Add TextBox
                    {
                        txtpsqArray[indice].Left = left;
                        txtpsqArray[indice].Top = top;
                        txtpsqArray[indice].Width = width;
                        txtpsqArray[indice].MaxLength = maxlength;
                        panArray[0].Controls.Add(txtpsqArray[indice]);
                        ControlMoverOrResizer.Init(txtpsqArray[indice]);
                        break;
                    }
                case "dtv": // anyControl = txt to Add TextBox
                    {
                        dtvArray[indice].Left = left;
                        dtvArray[indice].Top = top;
                        dtvArray[indice].Width = width;
                        dtvArray[indice].Height = height;
                        panel1.Controls.Add(dtvArray[indice]);
                        ControlMoverOrResizer.Init(dtvArray[indice]);
                        break;
                    }
                case "grb": // anyControl = txt to Add TextBox
                    {
                        grbArray[indice].Left = left;
                        grbArray[indice].Top = top;
                        grbArray[indice].Width = width;
                        grbArray[indice].Height = height;
                        grbArray[indice].BackColor = backcolor;
                        panel1.Controls.Add(grbArray[indice]);
                        ControlMoverOrResizer.Init(grbArray[indice]);
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var linha = 20;
            var cntPsq = 0;
            var cntDad = 0;
            OdbcDataReader myReader = funcoesdb.executasql("SELECT dados FROM controles where lower(trim(controle))='" + comboBox1.Text + "'");
            while (myReader.Read())
            {
                var serializer = new JavaScriptSerializer();
                dynamic itens = serializer.Deserialize(myReader.GetString(0), typeof(object));
                Dictionary<int, string> items = new Dictionary<int, string>();
                foreach (Dictionary<string, object> item in itens)
                {
                    if (item["nome"].ToString() == "lblpsq")
                    {
                        cntPsq += 1;
                    }
                    if (item["nome"].ToString() == "lbl")
                    {
                        cntDad += 1;
                    }
                }
            }
            if (cntPsq > 0)
            {
                AddControls("grb", 0);
                AddControls("pan", 0);
                AddControls("lblpsq", cntPsq - 1);
                AddControls("txtpsq", cntPsq - 1);
            }
            if (cntDad > 0)
            {
                AddControls("dtv", 0);
                AddControls("lbl", cntDad - 1);
                AddControls("txt", cntDad - 1);
                AddControls("btn", 2);
            }
            OdbcDataReader myReader1 = funcoesdb.executasql("SELECT dados FROM controles where lower(trim(controle))='" + comboBox1.Text + "'");
            while (myReader1.Read())
            {
                panel1.Controls.Clear();
                var serializer = new JavaScriptSerializer();
                dynamic itens = serializer.Deserialize(myReader1.GetString(0), typeof(object));
                Dictionary<int, string> items = new Dictionary<int, string>();
                foreach (Dictionary<string, object> item in itens)
                {
                    montacontrole(item["nome"].ToString(), Convert.ToInt32(item["indice"]), Convert.ToInt32(item["top"]), Convert.ToInt32(item["left"]),
                        Convert.ToInt32(item["width"]), Convert.ToInt32(item["height"]), Color.FromName(item["backcolor"].ToString()), Convert.ToInt32(item["maxlength"]), item["text"].ToString());
                }
                if (cntPsq>0)
                {
                    grbArray[0].BackColor = Color.FromArgb(255, 255, 192);
                    panArray[0].BackColor = Color.FromArgb(255, 255, 192);
                }
                return;
            }
            OdbcDataReader myReader2 = funcoesdb.executasql("SELECT dados FROM layout where lower(trim(tabela))='" + comboBox1.Text + "'");
            cntPsq = 0;
            cntDad = 0;
            while (myReader2.Read())
            {
                var serializer = new JavaScriptSerializer();
                dynamic itens = serializer.Deserialize(myReader2.GetString(0), typeof(object));
                Dictionary<int, string> items = new Dictionary<int, string>();
                foreach (Dictionary<string, object> item in itens)
                {
                    if (item["chave"].ToString() != "0")
                    {
                        cntPsq += 1;
                    }
                    cntDad += 1;
                }
            }
            if (cntPsq>0)
            {
                AddControls("grb", 0);
                AddControls("pan", 0);
                AddControls("lblpsq", cntPsq-1);
                AddControls("txtpsq", cntPsq-1);
            }
            if (cntDad > 0)
            {
                AddControls("dtv", 0);
                AddControls("lbl", cntDad-1);
                AddControls("txt", cntDad-1);
                AddControls("btn", 2);
            }
            OdbcDataReader myReader3 = funcoesdb.executasql("SELECT dados FROM layout where lower(trim(tabela))='" + comboBox1.Text + "'");
            panel1.Controls.Clear();
            ControlMoverOrResizer.WorkType = ControlMoverOrResizer.MoveOrResize.MoveAndResize;
            montacontrole("dtv", 0, linha, 50, 1250, 300, Color.Blue, 0, "");
            linha = linha + 310;
            var linpsq = 20;
            while (myReader3.Read())
            {
                var serializer = new JavaScriptSerializer();
                dynamic itens = serializer.Deserialize(myReader3.GetString(0), typeof(object));
                Dictionary<int, string> items = new Dictionary<int, string>();
                var achou = false;
                var cntpsq = 0;
                foreach (Dictionary<string, object> item in itens)
                {
                    if (item["chave"].ToString() != "0")
                    {
                        if (achou == false)
                        {
                            montacontrole("grb", 0, linha, 50, 1250, 0, Color.FromArgb(255, 255, 192), 0, "");
                            montacontrole("pan", 0, 0, 0, 1250, 0, Color.FromArgb(255, 255, 192), 0, "");
                            achou = true;
                        }
                        montacontrole("lblpsq", cntpsq, linpsq, 10, 70, 0, Color.Blue, 0, item["nome"].ToString() + ":");
                        montacontrole("txtpsq", cntpsq, linpsq, 110, 10 + (Convert.ToInt32(item["tamanho"].ToString()) * 6), 70, Color.Blue, Convert.ToInt32(item["tamanho"].ToString()), "");
                        linpsq = linpsq + 30;
                        grbArray[0].Height = linpsq;
                        panArray[0].Height = linpsq;
                        cntpsq = cntpsq + 1;
                    }
                }
                if (linpsq > 20)
                {
                    linha = linha + linpsq + 10;
                }
                else
                {
                    linha = linha + 10;
                }
                var pos = 0;
                foreach (Dictionary<string, object> item in itens)
                {
                    montacontrole("lbl", pos, linha, 50, 70, 0, Color.Blue, 0, item["nome"].ToString() + ":");
                    montacontrole("txt", pos, linha, 150, 10 + (Convert.ToInt32(item["tamanho"].ToString()) * 6), 0, Color.Blue, Convert.ToInt32(item["tamanho"].ToString()), "");
                    linha = linha + 30;
                    pos = pos + 1;
                }
            }

            montacontrole("btn", 0, linha, 100, 72, 24, Color.Blue, 0, "Incluir");
            montacontrole("btn", 1, linha, 200, 72, 24, Color.Blue, 0, "Salvar");
            montacontrole("btn", 2, linha, 300, 72, 24, Color.Blue, 0, "Sair");
        }
    }
}
