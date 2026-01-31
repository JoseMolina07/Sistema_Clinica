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
            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height));

          
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "PDF Files|*.pdf";
            saveFile.FileName = "Recibo_Laboratorio_Pio.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    
                    Document pdfDoc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                   
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bmp, ImageFormat.Png);

                    
                    img.ScaleToFit(PageSize.LETTER.Width - 20f, PageSize.LETTER.Height - 20f);
                    img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                    pdfDoc.Add(img);
                    pdfDoc.Close();
                }

                MessageBox.Show("Recibo generado con éxito", "Laboratorios Pío", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
