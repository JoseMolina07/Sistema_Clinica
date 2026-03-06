using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Clinica
{
    public partial class FormRespaldo : Form
    {
        public FormRespaldo()
        {
            InitializeComponent();
        }

        private void btnRespaldar_Click(object sender, EventArgs e)
        {
            // 1. Elegir ruta donde guardar
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo SQL (*.sql)|*.sql";
            sfd.FileName = $"Respaldo_Clinica_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string rutaCompleta = sfd.FileName;

                // 2. Configuración de XAMPP (Asegúrate de que esta ruta sea real)
                string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe";
                string dbName = "db_laboratorio_pio";
                string dbUser = "root";

                // 3. Ejecución segura
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = mysqldumpPath;

                    // IMPORTANTE: Si NO tienes contraseña en XAMPP, no incluyas -p.
                    // Si el comando te da error de "Access denied", entonces usa: $"-u{dbUser} -p \"{dbName}\"..."
                    psi.Arguments = $"-u{dbUser} \"{dbName}\" -r \"{rutaCompleta}\"";

                    psi.UseShellExecute = false;
                    psi.CreateNoWindow = true;

                    using (Process proc = Process.Start(psi))
                    {
                        // Espera máxima de 15 segundos para evitar que se congele
                        if (proc.WaitForExit(15000))
                        {
                            if (proc.ExitCode == 0)
                            {
                                // Agregar al DataGridView
                                dgvRespaldos.Rows.Add(DateTime.Now.ToString("dd/MM/yyyy"),
                                                     DateTime.Now.ToString("HH:mm:ss"),
                                                     "N/A",
                                                     rutaCompleta);

                                MessageBox.Show("Respaldo completado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al respaldar. El proceso terminó con código: " + proc.ExitCode);
                            }
                        }
                        else
                        {
                            proc.Kill(); // Mata el proceso si se quedó bloqueado
                            MessageBox.Show("El respaldo tomó demasiado tiempo y fue cancelado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error crítico: " + ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
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

        }
    }
}
