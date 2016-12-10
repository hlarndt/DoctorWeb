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
            try
            {
                this.Validate();
                this.usuarioBindingSource.EndEdit();
                this.usuarioTableAdapter.Update(this.d12rnams4f6a7nDataSet.usuario);
                this.d12rnams4f6a7nDataSet.AcceptChanges();
            }
            catch
            {
            }
        }

    }
}
