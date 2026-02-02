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
            this.DoubleBuffered = true;
            dgvPacientes.DataBindingComplete += dgvPacientes_DataBindingComplete;
        }

        private void EstilizarTabla()
        {
            // Aqui le doy estilo a los encabezados y filas de la tabla, doy estilo y tamaño a las letras,
            dgvPacientes.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dgvPacientes.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            dgvPacientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 204, 0);
            dgvPacientes.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvPacientes.CurrentCell = null;

            dgvPacientes.CellEnter += (s, e) =>
            {
                dgvPacientes[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromArgb(255, 204, 0);
            };

            dgvPacientes.CellLeave += (s, e) =>
            {
                dgvPacientes[e.ColumnIndex, e.RowIndex].Style.BackColor = dgvPacientes.RowsDefaultCellStyle.BackColor;
            };

            dgvPacientes.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPacientes.SelectionMode = DataGridViewSelectionMode.CellSelect;
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
                    try
                    {
                        dgvPacientes.Rows.RemoveAt(e.RowIndex);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puede eliminar la primera fila");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EstilizarTabla();

            dgvPacientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPacientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvPacientes.RowTemplate.MinimumHeight = 22;
            dgvPacientes.RowTemplate.Height = 22;

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

        private void button2_Click(object sender, EventArgs e)
        {
            // btnEtiqueta por si no jala se usa button2
            FormEtiquetas registroExistente = (FormEtiquetas)Application.OpenForms["FormEtiquetas"];
            if (registroExistente != null)
            {
                registroExistente.Show();
                registroExistente.BringToFront();
            }
            else
            {
                FormEtiquetas nuevoRecibo = new FormEtiquetas();
                nuevoRecibo.Show();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void dgvPacientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Detecta clic en el asterisco (columna -1) para eliminar
            if (e.ColumnIndex == -1 && e.RowIndex >= 0)
            {
                // Obtenemos el nombre del paciente (asumiendo que está en la celda índice 1)
                string nombrePaciente = dgvPacientes.Rows[e.RowIndex].Cells[1].Value?.ToString();

                DialogResult resultado = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar toda la fila?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        dgvPacientes.Rows.RemoveAt(e.RowIndex);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se puede eliminar esta fila.");
                    }
                }
            }
        }

        private void dgvPacientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvPacientes.AutoResizeRows();
        }

        private void dgvPacientes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvPacientes.AutoResizeRows();
        }

        private void dgvPacientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPacientes.Columns.Count == 0)
                return; // por seguridad

            // ======== CONFIGURACIÓN GENERAL DE COLUMNAS ========
            foreach (DataGridViewColumn col in dgvPacientes.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            // ======== ANCHOS (USANDO LOS NOMBRES REALES DE DISEÑO) ========
            SetColumnWidth("ColFolio", 90);
            SetColumnWidth("ColNombre", 200);
            SetColumnWidth("ColObservaciones", 230);

            // ======== AJUSTE FINAL DE FILAS ========
            dgvPacientes.AutoResizeRows();

        }

        private void SetColumnWidth(string columnName, int width)
        {
            if (dgvPacientes.Columns.Contains(columnName))
                dgvPacientes.Columns[columnName].Width = width;
        }


        private void dgvPacientes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox txt)
            {
                txt.Multiline = true;
                txt.AcceptsReturn = true;
                txt.AcceptsTab = true;
                txt.ScrollBars = ScrollBars.None;

                txt.TextChanged -= Txt_TextChanged;
                txt.TextChanged += Txt_TextChanged;
            }
        }

        private async void Txt_TextChanged(object sender, EventArgs e)
        {
            await Task.Delay(10); //esto me evita el bug de la celda que se pone negra

            if (dgvPacientes.CurrentCell != null)
            {
                int fila = dgvPacientes.CurrentCell.RowIndex;
                dgvPacientes.AutoResizeRow(fila, DataGridViewAutoSizeRowMode.AllCells);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMedicos registroExistente = (FormMedicos)Application.OpenForms["FormMedicos"];
            if (registroExistente != null)
            {
                registroExistente.Show();
                registroExistente.BringToFront();
            }
            else
            {
                FormMedicos nuevoRecibo = new FormMedicos();
                nuevoRecibo.Show();
            }
        }
    }
}