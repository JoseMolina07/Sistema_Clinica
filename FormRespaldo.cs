using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Clinica
{
    public partial class FormRespaldo : Form
    {
        string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        public FormRespaldo()
        {
            InitializeComponent();
        }

        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            string nombreArchivo = $"Respaldo_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
            string rutaCompleta = Path.Combine(carpetaDescargas, nombreArchivo);

            string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe";

            try
            {
                // El comando de respaldo
                ProcessStartInfo psi = new ProcessStartInfo(mysqldumpPath, $"-u root \"db_laboratorio_pio\" -r \"{rutaCompleta}\"")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process proc = Process.Start(psi))
                {
                    if (proc.WaitForExit(15000) && proc.ExitCode == 0)
                    {
                        CargarHistorial(); // Refrescamos la lista automáticamente
                        MessageBox.Show("Respaldo guardado con éxito en Descargas.");
                    }
                    else
                    {
                        MessageBox.Show("Error al respaldar. Verifica que XAMPP esté iniciado.");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error crítico: " + ex.Message); }
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ventanaInicio = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (ventanaInicio != null)
            {
                ventanaInicio.Show();
                ventanaInicio.BringToFront();
            }
            else
            {
                Form1 nuevoInicio = new Form1();
                nuevoInicio.Show();
            }
            this.Close();
        }

        private void FormRespaldo_Load(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            dgvRespaldos.Rows.Clear();
            try
            {
                DirectoryInfo info = new DirectoryInfo(carpetaDescargas);
                // Filtramos solo los archivos que empiezan con "Respaldo_"
                FileInfo[] archivos = info.GetFiles("Respaldo_*.sql");

                // Ordenamos del más nuevo al más viejo
                foreach (FileInfo archivo in archivos.OrderByDescending(f => f.CreationTime))
                {
                    dgvRespaldos.Rows.Add(
                        archivo.CreationTime.ToString("dd/MM/yyyy"),
                        archivo.CreationTime.ToString("HH:mm:ss"),
                        "Admin",
                        archivo.Name
                    );
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar historial: " + ex.Message); }
        }
        private void dgvRespaldos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnConecNube_Click(object sender, EventArgs e)
        {
            // Esta es la URL de Google Drive (donde se suben los respaldos)
            // También puedes usar: "https://console.cloud.google.com/"
            string urlGoogleDrive = "https://drive.google.com/drive/my-drive";
            try
            {
                Process.Start(new ProcessStartInfo(urlGoogleDrive) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el navegador: " + ex.Message);
            }
        }
    }
}
