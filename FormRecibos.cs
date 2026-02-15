using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace Sistema_Clinica
{
    public partial class FormRecibos : Form
    {
        public FormRecibos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // 1. Capturamos el diseño tal cual está en tu GroupBox
            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(
                bmp,
                new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height)
            );

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Files|*.pdf";
            saveFile.FileName = "Recibo_Laboratorio_Pio.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    // ======= TAMAÑO REAL MEDIA CARTA (5.5 x 8.5 pulgadas) =======
                    var mediaCarta = new iTextSharp.text.Rectangle(
                        Utilities.MillimetersToPoints(139.7f), // 5.5 pulgadas
                        Utilities.MillimetersToPoints(215.9f)  // 8.5 pulgadas
                    );

                    Document pdfDoc = new Document(mediaCarta, 10f, 10f, 10f, 10f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    // ======= MARCA DE AGUA (LOGO CENTRADO EN MEDIA CARTA) =======
                    if (pictureBox3.Image != null)
                    {
                        iTextSharp.text.Image marcaAgua =
                            iTextSharp.text.Image.GetInstance(pictureBox3.Image, ImageFormat.Png);

                        // Reducimos un poco el logo para que no invada el recibo
                        marcaAgua.ScaleToFit(
                            mediaCarta.Width * 0.6f,
                            mediaCarta.Height * 0.6f
                        );

                        // Centramos el logo en MEDIA CARTA (no en LETTER)
                        marcaAgua.SetAbsolutePosition(
                            (mediaCarta.Width - marcaAgua.ScaledWidth) / 2,
                            (mediaCarta.Height - marcaAgua.ScaledHeight) / 2
                        );

                        pdfDoc.Add(marcaAgua);
                    }

                    // ======= RECIBO (TU GROUPBOX) ENCIMA DEL LOGO =======
                    iTextSharp.text.Image imgRecibo =
                        iTextSharp.text.Image.GetInstance(bmp, ImageFormat.Png);

                    // Ajustamos el recibo para que ocupe casi toda la hoja
                    imgRecibo.ScaleToFit(
                        mediaCarta.Width - 20f,
                        mediaCarta.Height - 20f
                    );

                    imgRecibo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                    pdfDoc.Add(imgRecibo);
                    pdfDoc.Close();
                }

                MessageBox.Show(
                    "Recibo generado con éxito (Media Carta)",
                    "Laboratorios Pío",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize =
            new System.Drawing.Printing.PaperSize("Media Carta", 550, 850);
            PrintPreviewDialog vista = new PrintPreviewDialog();
            vista.Document = printDocument1;
            vista.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /* 1. Resolvemos la ambigüedad del Rectangle
            System.Drawing.Rectangle areaImpresion = new System.Drawing.Rectangle(25, 25, 500, (500 * groupBox1.Height / groupBox1.Width));

            // 2. DIBUJAR EL LOGO PRIMERO (Marca de agua)
            // Lo ponemos justo en el centro del área donde irá el recibo
            if (pictureBox3.Image != null)
            {
                int anchoLogo = 300;
                int altoLogo = 300;
                int xLogo = areaImpresion.X + (areaImpresion.Width - anchoLogo) / 2;
                int yLogo = areaImpresion.Y + (areaImpresion.Height - altoLogo) / 2;

                e.Graphics.DrawImage(pictureBox3.Image, xLogo, yLogo, anchoLogo, altoLogo);
            }

            // 3. CAPTURAR EL GROUPBOX SIN FONDO
            // Para que el blanco del GroupBox no tape el logo, usamos este truco:
            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height));

            // Hacemos que el color blanco de la captura sea transparente para que se vea el logo de atrás
            bmp.MakeTransparent(System.Drawing.Color.White);

            // 4. DIBUJAR EL RECIBO ENCIMA
            e.Graphics.DrawImage(bmp, areaImpresion);*/
            // ======= 1. DEFINIMOS EL ÁREA DE IMPRESIÓN (AQUÍ FALTABA) =======
            float margen = 40;

            System.Drawing.RectangleF areaImpresion =
                new System.Drawing.RectangleF(
                    margen,
                    margen,
                    e.PageBounds.Width - (margen * 2),
                    e.PageBounds.Height - (margen * 2)
                );

            // ======= 2. CAPTURAMOS TU GROUPBOX =======
            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(bmp,
                new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height));

            // ======= 3. DIBUJAMOS LOGO COMO MARCA DE AGUA (CENTRADO) =======
            if (pictureBox3.Image != null)
            {
                float logoAncho = areaImpresion.Width * 0.35f; // 35% del ancho
                float logoAlto = logoAncho;

                float xLogo = areaImpresion.X + (areaImpresion.Width - logoAncho) / 2;
                float yLogo = areaImpresion.Y + (areaImpresion.Height - logoAlto) / 2;

                e.Graphics.DrawImage(
                    pictureBox3.Image,
                    xLogo,
                    yLogo,
                    logoAncho,
                    logoAlto
                );
            }

            // ======= 4. DIBUJAR RECIBO ENCIMA (ESCALADO PROPORCIONAL) =======
            float escalaX = areaImpresion.Width / bmp.Width;
            float escalaY = areaImpresion.Height / bmp.Height;
            float escalaFinal = Math.Min(escalaX, escalaY);

            float nuevoAncho = bmp.Width * escalaFinal;
            float nuevoAlto = bmp.Height * escalaFinal;

            float x = areaImpresion.X + (areaImpresion.Width - nuevoAncho) / 2;
            float y = areaImpresion.Y + (areaImpresion.Height - nuevoAlto) / 2;

            e.Graphics.DrawImage(bmp, x, y, nuevoAncho, nuevoAlto);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void FormRecibos_Load(object sender, EventArgs e)
        {
            // Quita todas las líneas de la cuadrícula (verticales y horizontales)
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Quita el borde externo del control
            dataGridView1.BorderStyle = BorderStyle.None;

            // Asegura que el fondo de las celdas sea blanco para que no se vea gris en el papel
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            // Asegura que los encabezados sean visibles
            dataGridView1.ColumnHeadersVisible = true;

            // Opcional: Si quieres que el encabezado tenga una línea abajo para separar
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
