using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DoctorWeb
{
    public partial class Designer1 : Form
    {
        public Int32 tp;

        public Designer1(Int32 tipo)
        {
            tp = tipo;
            InitializeComponent();
        }

        private void Designer1_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            if (tp == 1)
            {
                List<string> lstCampos = new List<string>();
                List<string> lstFiltos = new List<string>();
                IDictionary<string,List<string>> Resultado = new Dictionary<string, List<string>>();
                foreach (Object item in listBox1.SelectedItems)
                {
                    lstCampos.Add(item.ToString());
                }
                foreach (Object item in listBox3.SelectedItems)
                {
                    lstFiltos.Add(item.ToString());
                }
                Resultado.Add("Campos", lstCampos);
                Resultado.Add("Filtros", lstFiltos);
                var campo = serializer.Serialize(Resultado);
                controlesTableAdapter1.DeleteQuery(comboBox1.Text.ToString(), "3");
                controlesTableAdapter1.InsertQuery(comboBox1.Text.ToString(), "3", campo);
                MessageBox.Show("Consulta Salva.", "Atenção");
            }
            else
            {
                List<string> lstCampos = new List<string>();
                List<string> lstFiltos = new List<string>();
                List<string> lstQuebra = new List<string>();
                List<string> lstOrdena = new List<string>();
                IDictionary<string, List<string>> Resultado = new Dictionary<string, List<string>>();
                foreach (Object item in listBox1.SelectedItems)
                {
                    lstCampos.Add(item.ToString());
                }
                foreach (Object item in listBox3.SelectedItems)
                {
                    lstFiltos.Add(item.ToString());
                }
                foreach (Object item in listBox5.SelectedItems)
                {
                    lstQuebra.Add(item.ToString());
                }
                foreach (Object item in listBox7.SelectedItems)
                {
                    lstOrdena.Add(item.ToString());
                }
                Resultado.Add("Campos", lstCampos);
                Resultado.Add("Filtros", lstFiltos);
                Resultado.Add("Quebra", lstQuebra);
                Resultado.Add("Ordena", lstOrdena);
                var campo = serializer.Serialize(Resultado);
                controlesTableAdapter1.DeleteQuery(comboBox1.Text.ToString(), "4");
                controlesTableAdapter1.InsertQuery(comboBox1.Text.ToString(), "4", campo);
                MessageBox.Show("Relatório Salvo.", "Atenção");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Designer1.ActiveForm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
            if (tp==1)
            {
                OdbcDataReader myReader = funcoesdb.executasql("SELECT dados FROM controles where lower(trim(controle))='" + comboBox1.Text + "' and trim(tipo)='3'");
                while (myReader.Read())
                {
                    var serializer = new JavaScriptSerializer();
                    dynamic itens = serializer.Deserialize(myReader.GetString(0), typeof(Dictionary<string, List<string>>));
                    foreach (string key in itens.Keys)
                    {
                        foreach(string list in itens[key])
                        {
                            if (key.ToString() == "Campos")
                            {
                                int index = listBox1.FindString(list.ToString());
                                if (index != -1)
                                    listBox1.SetSelected(index, true);
                            }
                            if (key.ToString() == "Filtros")
                            {
                                int index = listBox3.FindString(list.ToString());
                                if (index != -1)
                                    listBox3.SetSelected(index, true);
                            }
                        }
                    }
                }
            }
            else
            {
                OdbcDataReader myReader = funcoesdb.executasql("SELECT dados FROM controles where lower(trim(controle))='" + comboBox1.Text + "' and trim(tipo)='4'");
                while (myReader.Read())
                {
                    var serializer = new JavaScriptSerializer();
                    dynamic itens = serializer.Deserialize(myReader.GetString(0), typeof(Dictionary<string, List<string>>));
                    foreach (string key in itens.Keys)
                    {
                        foreach (string list in itens[key])
                        {
                            if (key.ToString() == "Campos")
                            {
                                int index = listBox1.FindString(list.ToString());
                                if (index != -1)
                                    listBox1.SetSelected(index, true);
                            }
                            if (key.ToString() == "Filtros")
                            {
                                int index = listBox3.FindString(list.ToString());
                                if (index != -1)
                                    listBox3.SetSelected(index, true);
                            }
                            if (key.ToString() == "Quebra")
                            {
                                int index = listBox5.FindString(list.ToString());
                                if (index != -1)
                                    listBox5.SetSelected(index, true);
                            }
                            if (key.ToString() == "Ordena")
                            {
                                int index = listBox7.FindString(list.ToString());
                                if (index != -1)
                                    listBox7.SetSelected(index, true);
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            listBox5.Items.Clear();
            listBox7.Items.Clear();
            OdbcDataReader myReader2 = funcoesdb.executasql("SELECT dados FROM layout where lower(trim(tabela))='" + comboBox1.Text + "'");
            while (myReader2.Read())
            {
                var serializer = new JavaScriptSerializer();
                dynamic itens = serializer.Deserialize(myReader2.GetString(0), typeof(object));
                Dictionary<int, string> items = new Dictionary<int, string>();
                foreach (Dictionary<string, object> item in itens)
                {
                    listBox1.Items.Add(item["nome"].ToString());
                    if (item["chave"].ToString() != "0")
                    {
                        listBox3.Items.Add(item["nome"].ToString());
                    }
                    if (tp == 2)
                    {
                        listBox5.Items.Add(item["nome"].ToString());
                        listBox7.Items.Add(item["nome"].ToString());
                    }
                }
            }
            if (tp == 1)
            {
                label1.Left = 50;
                label1.Top = 50;
                label1.Text = "Colunas";
                label2.Left = 50;
                label2.Top = 350;
                label2.Text = "Filtros";
                listBox1.Left = 50;
                listBox1.Top = 100;
                listBox1.Width = 300;
                listBox1.Height = 210;
                listBox3.Left = 50;
                listBox3.Top = 400;
                listBox3.Width = 300;
                listBox3.Height = 210;
            }
            else
            {
                label1.Left = 50;
                label1.Top = 50;
                label1.Text = "Colunas";
                label2.Left = 50;
                label2.Top = 350;
                label2.Text = "Filtros";
                label3.Left = 450;
                label3.Top = 50;
                label3.Text = "Quebra";
                label4.Left = 450;
                label4.Top = 350;
                label4.Text = "Ordenacao";
                listBox1.Left = 50;
                listBox1.Top = 100;
                listBox1.Width = 300;
                listBox1.Height = 210;
                listBox3.Left = 50;
                listBox3.Top = 400;
                listBox3.Width = 300;
                listBox3.Height = 210;
                listBox5.Left = 450;
                listBox5.Top = 100;
                listBox5.Width = 300;
                listBox5.Height = 210;
                listBox7.Left = 450;
                listBox7.Top = 400;
                listBox7.Width = 300;
                listBox7.Height = 210;
            }
        }

    }
}