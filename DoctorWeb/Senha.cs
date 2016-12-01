using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorWeb
{
    public partial class Senha : Form
    {
        public Senha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Use the Select method to find all rows matching the filter.
            var table = usuarioTableAdapter1.GetData();

            var achouusuario = false;
            var achousenha = false;
            // Print column 0 of each returned row.
            foreach (DataRow linha in table)
            {
                if (linha[1].ToString() == textBox1.Text)
                {
                    achouusuario = true;
                }
                if (linha[2].ToString() == textBox2.Text)
                {
                    achousenha = true;
                }
            }
            if (achouusuario==false)
            {
                MessageBox.Show("Usuario não existente.","ERRO");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            if (achousenha == false)
            {
                MessageBox.Show("Senha não confere.", "ERRO");
                textBox2.Text = "";
                textBox2.Focus();
                return;
            }
            if (achouusuario==true&&achousenha==true)
            {
                try
                {
                    Senha.ActiveForm.Hide();
                    Visoes Visoes = new Visoes();
                    Visoes.Show();
                }
                catch
                {
                }
            }
        }

        private void Senha_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
