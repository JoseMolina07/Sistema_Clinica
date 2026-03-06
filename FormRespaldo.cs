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
            // 1. Abrir diálogo para elegir dónde guardar
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo SQL (*.sql)|*.sql";
                sfd.FileName = $"Respaldo_Clinica_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string rutaCompleta = sfd.FileName;
                    string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe";
                    string dbName = "db_laboratorio_pio";
                    string dbUser = "root";
                    string dbPass = "";

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = mysqldumpPath;
                        psi.Arguments = $"-u{dbUser} -p{dbPass} {dbName} -r \"{rutaCompleta}\"";
                        psi.WindowStyle = ProcessWindowStyle.Hidden;
                        psi.UseShellExecute = false;
                        psi.CreateNoWindow = true;

                        using (Process proc = Process.Start(psi))
                        {
                            proc.WaitForExit();

                            if (proc.ExitCode == 0)
                            {
                                string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                                string hora = DateTime.Now.ToString("HH:mm:ss");
                                string quien = "N/A"; 

                                dgvRespaldos.Rows.Add(fecha, hora, quien, rutaCompleta);

                                MessageBox.Show("Respaldo realizado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Error al realizar el respaldo. Revisa usuario/contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
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
    }
}
