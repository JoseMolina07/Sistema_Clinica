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
    public partial class FormMedicos : Form
    {
        public FormMedicos()
        {
            InitializeComponent();
            ConfigurarGridMedicos();
            CargarReporteMensual();
        }

        private void ConfigurarGridMedicos()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void ResaltarMedicosEstrella(int maxPacientes)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Total Pacientes"].Value) == maxPacientes)
                {
                    row.DefaultCellStyle.BackColor = Color.Gold;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                }
            }
        }

        public void CargarReporteMensual()
        {
            CConexion objetoConexion = new CConexion();
            try
            {
                // Consulta que junta Nombre y Análisis de cada paciente
                // Usamos REPLACE para que el '|' se vea como ':' en el reporte
                string query = @"
            SELECT 
                medico AS 'Médico', 
                COUNT(*) AS 'Total Pacientes',
                GROUP_CONCAT(CONCAT(nombre, ' (', REPLACE(analisis_clinicos, '|', ': '), ')') SEPARATOR ' / ') AS 'Pacientes y Estudios'
            FROM pacientes 
            GROUP BY medico
            ORDER BY COUNT(*) DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerconexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[2].Width = 500;

                    // 1. Obtener la cantidad máxima de pacientes (la primera fila porque está ordenado)
                    int maxPacientes = Convert.ToInt32(dt.Rows[0]["Total Pacientes"]);

                    // 2. Buscar a todos los médicos que tengan esa misma cantidad (empate)
                    var doctoresLideres = dt.AsEnumerable()
                        .Where(row => Convert.ToInt32(row["Total Pacientes"]) == maxPacientes)
                        .Select(row => row["Médico"].ToString());

                    // 3. Unir los nombres si hay más de uno
                    lblNombreDoctor.Text = string.Join(" | ", doctoresLideres);
                    lblCantidad.Text = maxPacientes.ToString();

                    // 4. Resaltar TODOS los que empataron
                    ResaltarMedicosEstrella(maxPacientes);
                }
                else
                {
                    lblNombreDoctor.Text = "Médico Líder: ---";
                    lblCantidad.Text = "Total: 0";
                    MessageBox.Show("No hay pacientes registrados aún.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de SQL: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblCantidad_Click(object sender, EventArgs e)
        {

        }

        private void FormMedicos_Load(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
