using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Clinica
{
    public partial class FormMedicos : Form
    {
        public FormMedicos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 registroExistente = (Form1)Application.OpenForms["Form1"];

            if (registroExistente != null)
            {
                registroExistente.Show();
                registroExistente.BringToFront();
            }
            else
            {
                Form1 nuevoRegistro = new Form1();
                nuevoRegistro.Show();
            }
        }
    }
}
