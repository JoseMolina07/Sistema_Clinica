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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Clinica
{
    public partial class Form1 : Form
    {
        //mi tabla temporal para hacer la orden tipo carrito de ocmpra
        DataTable tablaOrden = new DataTable();
        public Form1()
        {
            InitializeComponent();
            dgvPacientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPacientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.DoubleBuffered = true;
            dgvPacientes.DataBindingComplete += dgvPacientes_DataBindingComplete;
            RefrescarTablaPacientes();
            CargarEstudios();
 
            if (tablaOrden.Columns.Count == 0)
            {
                tablaOrden.Columns.Add("Análisis");
                tablaOrden.Columns.Add("Precio Base");
            }
            dataGridView2.DataSource = tablaOrden;
            CargarCategorias();
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

            // Activa el ajuste de texto en todo el grid
            dgvPacientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Hace que la fila ajuste su altura automáticamente según el contenido
            dgvPacientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Opcional: Dale un ancho fijo a la columna de análisis para que el texto salte
            if (dgvPacientes.Columns.Count > 9)
            {
                dgvPacientes.Columns[9].Width = 250;

            }
        }

        private void GuardarCompletoEnBD(string estudios)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // 1. Definimos la consulta con los 11 campos que deben existir en tu tabla 'pacientes'
                string query = "INSERT INTO pacientes (folio_curp, nombre, edad, sexo, telefono, correo, fecha, medico, costo, sucursal, analisis_clinicos) " +
                               "VALUES (@fol, @nom, @eda, @sex, @tel, @cor, @fec, @med, @cos, @suc, @ana)";

                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());

                // 2. Limpieza del costo: Quitamos el '$' y las comas para que MySQL lo acepte como número/texto limpio
                string costoLimpio = label15.Text.Replace("$", "").Replace(",", "").Trim();

                // 3. Pasamos los parámetros uno por uno
                cmd.Parameters.AddWithValue("@fol", txtFolio.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@eda", numEdad.Value);
                cmd.Parameters.AddWithValue("@sex", cmbSexo.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@cor", txtCorreo.Text);

                // CORRECCIÓN DE FECHA: Se envía como string corto para que XAMPP no reciba NULL
                cmd.Parameters.AddWithValue("@fec", dtpFecha.Value.ToShortDateString());

                cmd.Parameters.AddWithValue("@med", txtMedico.Text);
                cmd.Parameters.AddWithValue("@cos", costoLimpio);
                cmd.Parameters.AddWithValue("@suc", txtsucursal.Text);
                cmd.Parameters.AddWithValue("@ana", estudios);

                // 4. Ejecutamos la orden en XAMPP
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Si aquí te sale error, es porque algún nombre de columna en el INSERT no existe en tu phpMyAdmin
                MessageBox.Show("Error crítico al guardar en Base de Datos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        private decimal ObtenerPrecioDeBase(string nombre)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // Consultamos el precio_base usando el nombre exacto del estudio
                string query = "SELECT precio_base FROM estudios WHERE nombre_estudio = @nom";
                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());
                cmd.Parameters.AddWithValue("@nom", nombre);

                object resultado = cmd.ExecuteScalar();
                return resultado != null ? Convert.ToDecimal(resultado) : 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        private bool ExisteFolio(string folio)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // Consultamos si el folio_curp ya existe en la tabla pacientes
                string query = "SELECT COUNT(*) FROM pacientes WHERE folio_curp = @fol";
                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());
                cmd.Parameters.AddWithValue("@fol", folio);

                int conteo = Convert.ToInt32(cmd.ExecuteScalar());
                return conteo > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar integridad: " + ex.Message);
                return false;
            }
            finally
            {
                objetoConexion.cerrarconexion();
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

        private void EliminarPacienteBD(string folio)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // Usamos folio_curp que es tu llave primaria
                string query = "DELETE FROM pacientes WHERE folio_curp = @fol";
                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());
                cmd.Parameters.AddWithValue("@fol", folio);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar en BD: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        public void RefrescarTablaPacientes()
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                string query = "SELECT * FROM pacientes";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvPacientes.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int n = dgvPacientes.Rows.Add();

                    // ASIGNACIÓN DIRECTA POR NOMBRE DE COLUMNA (NAME)
                    dgvPacientes.Rows[n].Cells["ColFOLIO"].Value = row["folio_curp"].ToString();
                    dgvPacientes.Rows[n].Cells["ColNombre"].Value = row["nombre"].ToString();
                    dgvPacientes.Rows[n].Cells["ColEdad"].Value = row["edad"].ToString();
                    dgvPacientes.Rows[n].Cells["ColSexo"].Value = row["sexo"].ToString();
                    dgvPacientes.Rows[n].Cells["colCORREO"].Value = row["correo"].ToString();
                    dgvPacientes.Rows[n].Cells["ColTelefono"].Value = row["telefono"].ToString();

                    // AQUÍ ESTABA EL FALLO: Estas son las columnas que "desaparecían"
                    dgvPacientes.Rows[n].Cells["ColFecha"].Value = row["fecha"]?.ToString() ?? "";
                    dgvPacientes.Rows[n].Cells["ColMEDICO"].Value = row["medico"]?.ToString() ?? "";
                    dgvPacientes.Rows[n].Cells["ColSucursal"].Value = row["sucursal"]?.ToString() ?? "";
                    dgvPacientes.Rows[n].Cells["ColAnalisis"].Value = row["analisis_clinicos"]?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        private void GuardarEnBaseDeDatos(string estudios)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                string query = "INSERT INTO pacientes (folio_curp, nombre, edad, sexo, telefono, correo, fecha, medico, costo, sucursal, analisis_clinicos) " +
                               "VALUES (@fol, @nom, @eda, @sex, @tel, @cor, @fec, @med, @cos, @suc, @ana)";

                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());
                cmd.Parameters.AddWithValue("@fol", txtFolio.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@eda", numEdad.Value.ToString());
                cmd.Parameters.AddWithValue("@sex", cmbSexo.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@cor", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@fec", dtpFecha.Text);
                cmd.Parameters.AddWithValue("@med", txtMedico.Text);
                cmd.Parameters.AddWithValue("@cos", label15.Text);
                cmd.Parameters.AddWithValue("@suc", txtsucursal.Text);
                cmd.Parameters.AddWithValue("@ana", estudios); // Aquí se guardan los análisis

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }


        public void CargarCategorias()
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // 1. Establecemos la conexión una sola vez
                MySqlConnection conexion = objetoConexion.establecerconexion();

                string query = "SELECT id_categoria, nombre_categoria FROM categorias";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 2. Validamos que la tabla no venga vacía
                if (dt.Rows.Count > 0)
                {
                    // OJO: Si cambiaste el nombre del control en el diseño, cámbialo aquí también
                    // 'nombre_categoria' es lo que ve la ingeniera, 'id_categoria' es el número interno
                    txtAnalisis.DataSource = dt;
                    txtAnalisis.DisplayMember = "nombre_categoria";
                    txtAnalisis.ValueMember = "id_categoria";

                    // Esto evita que se seleccione la primera categoría por defecto al abrir
                    txtAnalisis.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías de XAMPP: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
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
            if (e.Control is System.Windows.Forms.TextBox txt)
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
            this.txtAnalisis.Text = "";
            this.txtCorreo.Text = "";
            this.numEdad.Value = 0;
            this.cmbSexo.SelectedIndex = -1;
            this.txtNombre.Focus();
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Solo si hace clic en una fila válida (no encabezados)
            if (e.RowIndex >= 0)
            {
                string nombreP = dgvPacientes.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string folioBorrar = dgvPacientes.Rows[e.RowIndex].Cells[0].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    $"¿Deseas ELIMINAR permanentemente a: {nombreP}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop);

                if (result == DialogResult.Yes)
                {
                    // Borramos de la pantalla
                    dgvPacientes.Rows.RemoveAt(e.RowIndex);

                    // Borramos de la BD usando el folio_curp
                    EliminarPacienteBD(folioBorrar);
                }
            }
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                MessageBox.Show("Por favor, ingresa el Folio.");
                return;
            }
            if (ExisteFolio(txtFolio.Text))
            {
                MessageBox.Show("¡ERROR! Este folio ya existe en la base de datos.", "Integridad");
                return; // Aquí se detiene y no guarda nada duplicado
            }

            // BLOQUEO DE DUPLICADOS
            if (ExisteFolio(txtFolio.Text))
            {
                MessageBox.Show("El Folio ya existe. No se puede duplicar el registro.", "Error de Integridad");
                return;
            }

            string analisisJuntos = "";
            foreach (DataRow r in tablaOrden.Rows)
            {
                analisisJuntos += r["Análisis"].ToString() + Environment.NewLine;
            }

            int n = dgvPacientes.Rows.Add();
            dgvPacientes.Rows[n].Cells[0].Value = txtFolio.Text;
            dgvPacientes.Rows[n].Cells[1].Value = txtNombre.Text;
            dgvPacientes.Rows[n].Cells[2].Value = dtpFecha.Text;
            dgvPacientes.Rows[n].Cells[3].Value = txtMedico.Text;
            dgvPacientes.Rows[n].Cells[4].Value = txtCorreo.Text;
            dgvPacientes.Rows[n].Cells[5].Value = label15.Text;
            dgvPacientes.Rows[n].Cells[6].Value = txtsucursal.Text;
            dgvPacientes.Rows[n].Cells[7].Value = numEdad.Value;
            dgvPacientes.Rows[n].Cells[8].Value = cmbSexo.Text;
            dgvPacientes.Rows[n].Cells[9].Value = analisisJuntos;

            GuardarEnBaseDeDatos(analisisJuntos);
            LimpiarCampos();
            tablaOrden.Clear();
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
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                CalcularTotalOrden();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtAnalisis_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya una categoría seleccionada
            if (txtAnalisis.SelectedValue != null && txtAnalisis.ValueMember != "")
            {
                string idCat = txtAnalisis.SelectedValue.ToString();

                CConexion objetoConexion = new CConexion();
                try
                {
                    // Consulta para filtrar estudios por la categoría de XAMPP
                    string query = "SELECT nombre_estudio AS 'Análisis', precio_base AS 'Precio Base' " +
                                   "FROM estudios WHERE id_categoria = " + idCat;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Refrescamos el primer DataGrid
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
        }

        private void txtAnalisis_Enter(object sender, EventArgs e)
        {
            if (txtAnalisis.Text == "BUSCAR ANÁLISIS...")
            {
                txtAnalisis.Text = "";
                txtAnalisis.ForeColor = Color.Black; 
            }
        }

        private void txtAnalisis_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnalisis.Text))
            {
                txtAnalisis.Text = "BUSCAR ANÁLISIS...";
                txtAnalisis.ForeColor = Color.Gray; 
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        /*private void dgvPacientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPacientes.Rows[e.RowIndex].Cells["ColFOLIO"].Value != null)
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];

                // Usamos exactamente los nombres que me diste
                txtFolio.Text = fila.Cells["ColFOLIO"].Value?.ToString();
                txtNombre.Text = fila.Cells["ColNombre"].Value?.ToString();
                txtMedico.Text = fila.Cells["ColMEDICO"].Value?.ToString();
                txtTelefono.Text = fila.Cells["ColTelefono"].Value?.ToString();
                txtCorreo.Text = fila.Cells["colCORREO"].Value?.ToString();

                if (fila.Cells["ColEdad"].Value != null)
                    numEdad.Value = Convert.ToDecimal(fila.Cells["ColEdad"].Value);

                cmbSexo.Text = fila.Cells["ColSexo"].Value?.ToString();

                if (MessageBox.Show("¿Cargar datos para modificar?", "SISTEMA", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dgvPacientes.Rows.RemoveAt(e.RowIndex);
                    txtNombre.Focus();
                }
            }
        }
        */
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPacientes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos el nombre de la fila para confirmar
                string nombreP = dgvPacientes.Rows[e.RowIndex].Cells["ColNombre"].Value?.ToString() ?? "Paciente sin nombre";
                string folio = dgvPacientes.Rows[e.RowIndex].Cells["ColFOLIO"].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    $"¿Deseas ELIMINAR permanentemente a: {nombreP}?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Borramos de la pantalla
                    dgvPacientes.Rows.RemoveAt(e.RowIndex);

                    // Borramos de la BD si hay un folio válido
                    if (!string.IsNullOrEmpty(folio))
                    {
                        EliminarPacienteBD(folio);
                    }
                }
            }
        }

        private void dgvPacientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];

                // Pasamos del Grid a los TextBoxes
                txtFolio.Text = fila.Cells["ColFOLIO"].Value?.ToString();
                txtNombre.Text = fila.Cells["ColNombre"].Value?.ToString();
                dtpFecha.Text = fila.Cells["ColFecha"].Value?.ToString();
                txtMedico.Text = fila.Cells["ColMEDICO"].Value?.ToString();
                txtsucursal.Text = fila.Cells["ColSucursal"].Value?.ToString();
                txtCorreo.Text = fila.Cells["colCORREO"].Value?.ToString();
                txtTelefono.Text = fila.Cells["ColTelefono"].Value?.ToString();
                cmbSexo.Text = fila.Cells["ColSexo"].Value?.ToString();

                // Manejo de la Edad para que no truene si es nulo
                decimal edadD;
                if (decimal.TryParse(fila.Cells["ColEdad"].Value?.ToString(), out edadD)) numEdad.Value = edadD;

                // Regresamos los estudios al carrito (dataGridView2)
                tablaOrden.Rows.Clear();
                string estudios = fila.Cells["ColAnalisis"].Value?.ToString();
                if (!string.IsNullOrEmpty(estudios))
                {
                    string[] lista = estudios.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in lista) { tablaOrden.Rows.Add(s, 0); }
                }
                CalcularTotalOrden();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // UPDATE no crea, solo modifica lo que ya está ahí por su folio_curp
                string query = "UPDATE pacientes SET nombre=@nom, edad=@eda, sexo=@sex, telefono=@tel, correo=@cor, " +
                               "fecha=@fec, medico=@med, sucursal=@suc, analisis_clinicos=@ana WHERE folio_curp=@fol";

                MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion());

                // El folio es la llave, no se cambia, se usa para buscar
                cmd.Parameters.AddWithValue("@fol", txtFolio.Text);
                cmd.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmd.Parameters.AddWithValue("@eda", numEdad.Value.ToString());
                cmd.Parameters.AddWithValue("@sex", cmbSexo.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@cor", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@fec", dtpFecha.Text);
                cmd.Parameters.AddWithValue("@med", txtMedico.Text);
                cmd.Parameters.AddWithValue("@suc", txtsucursal.Text);

                // Juntamos lo que hay en el carrito (dataGridView2) ahora mismo
                string estudiosEditados = "";
                foreach (DataRow r in tablaOrden.Rows)
                {
                    estudiosEditados += r["Análisis"].ToString() + Environment.NewLine;
                }
                cmd.Parameters.AddWithValue("@ana", estudiosEditados);

                cmd.ExecuteNonQuery();
                MessageBox.Show("¡Cambios guardados con éxito!");

                RefrescarTablaPacientes(); // Esto actualiza la tabla principal al momento
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        private void dgvPacientes_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}