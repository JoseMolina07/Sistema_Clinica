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
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. Aumentamos la visibilidad poco a poco cuando se completa
            //detengo el reloj y se manda la señal de listo al program.cs
            //despues se cierra el logo y entra al sistema  
            if (this.Opacity < 1)
            {
                this.Opacity += 0.76;
            }
            else
            {
                timer1.Stop(); 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
