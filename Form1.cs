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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EstilizarTabla()
        {
            //Aqui le doy estilo a los encabezados y filas de la tabla, doy estilo y tamaño a las letras,
            //tambien se agrega las flechitas tipo excel para el filtro
            dgvPacientes.EnableHeadersVisualStyles = false;
            dgvPacientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(68, 114, 196);
            dgvPacientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPacientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPacientes.ColumnHeadersHeight = 35;
            dgvPacientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(217, 225, 242);
            dgvPacientes.RowsDefaultCellStyle.BackColor = Color.White;

            
            dgvPacientes.RowHeadersVisible = false; 
            dgvPacientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPacientes.GridColor = Color.FromArgb(210, 210, 210); 

           
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

           
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPacientes.MultiSelect = false; 
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en el triangulito del datagridview para eliminar filas enteras
            // El índice de columna para el encabezado siempre es -1
            if (e.ColumnIndex == -1 && e.RowIndex >= 0)
            {
                string nombrePaciente = dgvPacientes.Rows[e.RowIndex].Cells[1].Value?.ToString();
                DialogResult resultado = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar toda la fila?: {nombrePaciente}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    dgvPacientes.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FormRecibos_Click(object sender, EventArgs e)
        {

        }

        private void btnAbrirRecibos_Click(object sender, EventArgs e)
        {
            FormRecibos registroExistente = (FormRecibos)Application.OpenForms["FormRecibos"];
            if (registroExistente != null)
            {
                registroExistente.Show();
                registroExistente.BringToFront();
            }
            else
            {
                FormRecibos nuevoRecibo = new FormRecibos();
                nuevoRecibo.Show();
            }
        }
    }
}
