using MySql.Data.MySqlClient;
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
        //mi tabla temporal para hacer la orden tipo carrito de ocmpra
        DataTable tablaOrden = new DataTable();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            dgvPacientes.DataBindingComplete += dgvPacientes_DataBindingComplete;
            
            CargarEstudios();
 
            if (tablaOrden.Columns.Count == 0)
            {
                tablaOrden.Columns.Add("Análisis");
                tablaOrden.Columns.Add("Precio Base");
            }
            dataGridView2.DataSource = tablaOrden;
        }

        private void EstilizarTabla()
        {
            dgvPacientes.ReadOnly = true;
            dgvPacientes.AllowUserToAddRows = false;
            dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Color de fila alterno para mejorar la lectura
            dgvPacientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);

            dgvPacientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Ajusta la altura de la fila automáticamente según el contenido
            dgvPacientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            
            // Muestra todas las líneas de la cuadrícula como en el ticket de Chontalpa
            dgvPacientes.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPacientes.GridColor = Color.Gray;

        }

        private void LlenarCategorias()
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                string query = "SELECT id_categoria, nombre_categoria FROM categorias";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                txtAnalisis.DataSource = dt;
                txtAnalisis.DisplayMember = "nombre_categoria";
                txtAnalisis.ValueMember = "id_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        public void FiltrarPorCategoria(string id)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // Filtramos usando el ID de la categoría
                string query = "SELECT nombre_estudio AS 'Análisis', precio_base AS 'Precio Base' " +
                               "FROM estudios WHERE id_categoria = " + id;

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
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
            CargarEstudios();
        }

        public void CargarEstudios()
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                string query = "SELECT nombre_estudio AS 'Análisis', precio_base AS 'Precio Base' FROM estudios";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudios: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
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
                return; 

            foreach (DataGridViewColumn col in dgvPacientes.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            SetColumnWidth("ColFolio", 90);
            SetColumnWidth("ColNombre", 200);
            SetColumnWidth("ColObservaciones", 230);

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
        //esto lu use cuando el datagrid del Form1 era el princiapl para registrar datos, no se que pasa si se borra
        //lo dejo por cualquier cosa

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

        private void button2_Click_1(object sender, EventArgs e)
        {
          
        }

        private void dgvPacientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void btnAgregar_Click(object sender, EventArgs e)
        {
            dgvPacientes.Rows.Add(
         txtFolio.Text,
         txtNombre.Text,
         dtpFecha.Value.ToShortDateString(), 
         txtMedico.Text,
         txtCosto.Text,
         txtTelefono.Text,
         txtObservaciones.Text,
         numEdad.Value.ToString(),           
         cmbSexo.Text,                       
         txtAnalisis.Text,
         txtCorreo.Text
     );
            dgvPacientes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);//aqui ocurre el autoajuste de 
            //las celdas si el texto es muy largo

            // Limpiamos los campos para el siguiente registro
            LimpiarCampos();
        }
*/
        private void LimpiarCampos()
        {
            this.txtNombre.Text = "";
            this.txtMedico.Text = ""; 
            this.txtTelefono.Text = "";
            this.txtObservaciones.Text = "";
            this.txtAnalisis.Text = "";
            this.txtCorreo.Text = "";
            this.numEdad.Value = 0;
            this.cmbSexo.SelectedIndex = -1;
            this.txtNombre.Focus();
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];

                txtFolio.Text = fila.Cells[0].Value?.ToString();
                txtNombre.Text = fila.Cells[1].Value?.ToString();

                if (DateTime.TryParse(fila.Cells[2].Value?.ToString(), out DateTime fecha))
                    dtpFecha.Value = fecha;

                txtMedico.Text = fila.Cells[3].Value?.ToString();
                txtTelefono.Text = fila.Cells[5].Value?.ToString();
                txtObservaciones.Text = fila.Cells[6].Value?.ToString();

                decimal.TryParse(fila.Cells[7].Value?.ToString(), out decimal edad);
                numEdad.Value = edad;

                cmbSexo.Text = fila.Cells[8].Value?.ToString(); // Para el ComboBox
                txtAnalisis.Text = fila.Cells[9].Value?.ToString();
                txtCorreo.Text = fila.Cells[10].Value?.ToString();

                dgvPacientes.Rows.RemoveAt(e.RowIndex);

                MessageBox.Show("Datos cargados para modificar.", "Laboratorios Pío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                MessageBox.Show("Por favor, ingresa un número de Folio.", "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow fila in dgvPacientes.Rows)
            {
                
                if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == txtFolio.Text)
                {
                    MessageBox.Show("Este número de Folio ya está registrado. Verifica los datos.",
                                    "Registro Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }
            }

            // 3. Si el código llega aquí, significa que no encontró duplicados y procede a agregar
            dgvPacientes.Rows.Add(
                txtFolio.Text,
                txtNombre.Text,
                dtpFecha.Value.ToShortDateString(), // Para el DateTimePicker
                txtMedico.Text,
                txtTelefono.Text,
                txtObservaciones.Text,
                numEdad.Value.ToString(),            
                cmbSexo.Text,                     
                txtAnalisis.Text,
                txtCorreo.Text
            );
            dgvPacientes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            LimpiarCampos();

            MessageBox.Show("Paciente registrado correctamente.", "Laboratorios Pío", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar que haya una fila seleccionada en el catálogo
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener datos de la fila seleccionada
                string nombre = dataGridView1.CurrentRow.Cells["Análisis"].Value.ToString();
                string precio = dataGridView1.CurrentRow.Cells["Precio Base"].Value.ToString();

                // Agregar a nuestra tabla de la orden
                tablaOrden.Rows.Add(nombre, precio);

                // Actualizar el total automáticamente (opcional para tu Form1)
                CalcularTotalOrden();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un análisis del catálogo primero.");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Eliminar la fila seleccionada de la tabla temporal
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);

                // Recalcular el total tras eliminar
                CalcularTotalOrden();
            }
        }
        private void CalcularTotalOrden()
        {
            decimal total = 0;
            foreach (DataRow fila in tablaOrden.Rows)
            {
                // Sumamos los precios base extraídos del catálogo
                total += Convert.ToDecimal(fila["Precio Base"]);
            }

            // Mostramos el resultado en el label15 con formato de moneda
            label15.Text = total.ToString("C2");
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtAnalisis_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Este código filtra los 197 estudios que ya están cargados en el Grid
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    // Filtra la columna 'Análisis' buscando lo que el usuario escribe
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Análisis LIKE '%{0}%'", txtAnalisis.Text);
                }
            }
            catch (Exception)
            {
               
            }
        }
    }
}