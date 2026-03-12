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
using MySql.Data.MySqlClient;
using System.Globalization;
using Zen.Barcode;

namespace Sistema_Clinica
{
    public partial class FormRecibos : Form
    {
        public FormRecibos()
        {
            InitializeComponent();
        }

        //este pedazo de codigo me hace un recibo estetico pero como hace captura de pantalla sale borroso

        /*private void GuardarPdfDirecto()
        {
            try
            {
                // Obtener ruta de la carpeta Descargas
                string pathDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string nombreArchivo = $"Recibo_{txtBusquedaFolio.Text.Trim()}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(pathDescargas, nombreArchivo);

                // Captura del GroupBox (igual que en tu btnImprimir)
                groupBox1.PerformLayout();
                Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
                groupBox1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height));
                bmp.MakeTransparent(Color.White);

                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    iTextSharp.text.Rectangle mediaCarta = new iTextSharp.text.Rectangle(Utilities.MillimetersToPoints(139.7f), Utilities.MillimetersToPoints(215.9f));
                    Document pdfDoc = new Document(mediaCarta, 10f, 10f, 10f, 10f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                    iTextSharp.text.Image imgRecibo = iTextSharp.text.Image.GetInstance(bmp, ImageFormat.Png);
                    imgRecibo.ScaleToFit(mediaCarta.Width - 20f, mediaCarta.Height - 20f);
                    imgRecibo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    pdfDoc.Add(imgRecibo);

                    pdfDoc.Close();
                }

                // Feedback discreto (puedes quitarlo si prefieres que sea silencioso)
                // MessageBox.Show("PDF guardado en Descargas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar PDF: " + ex.Message);
            }
        }*/
        private void GuardarPdfDirecto()
        {
            try
            {
                string pathDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                string nombreArchivo = $"Recibo_{txtBusquedaFolio.Text.Trim()}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string rutaCompleta = Path.Combine(pathDescargas, nombreArchivo);

                // Configuración de Media Carta (396 x 612 puntos)
                iTextSharp.text.Rectangle mediaCarta = new iTextSharp.text.Rectangle(396f, 612f);

                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create))
                {
                    Document pdfDoc = new Document(mediaCarta, 20f, 20f, 20f, 20f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                    pdfDoc.Open();

                 
                    if (pictureBox3.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox3.Image.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                            logo.ScaleToFit(200f, 200f);
                            float x = (mediaCarta.Width - logo.ScaledWidth) / 2;
                            float y = (mediaCarta.Height - logo.ScaledHeight) / 2;
                            logo.SetAbsolutePosition(x, y);
                            PdfGState gstate = new PdfGState { FillOpacity = 0.1f };
                            writer.DirectContentUnder.SetGState(gstate);
                            writer.DirectContentUnder.AddImage(logo);
                        }
                    }

                    var fBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9);
                    var fNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    var fTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
    
                    PdfPTable headerTable = new PdfPTable(2);
                    headerTable.WidthPercentage = 100;
                    headerTable.SetWidths(new float[] { 2f, 1f });
                    headerTable.DefaultCell.Border = 0;

                    if (pictureBox2.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                            imgLogo.ScaleToFit(120f, 80f);
                            headerTable.AddCell(new PdfPCell(imgLogo) { Border = 0 });
                        }
                    }
                    else { headerTable.AddCell(new PdfPCell(new Phrase(" ")) { Border = 0 }); }

                    PdfPCell cellDer = new PdfPCell();
                    cellDer.Border = 0;
                    cellDer.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    if (picCodigoBarras.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            picCodigoBarras.Image.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image imgBar = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                            imgBar.ScaleToFit(80f, 25f);
                            cellDer.AddElement(imgBar);
                        }
                    }
                    cellDer.AddElement(new Paragraph("Folio: " + txtBusquedaFolio.Text, fBold));
                    headerTable.AddCell(cellDer);
                    pdfDoc.Add(headerTable);

                    pdfDoc.Add(new Paragraph("LABORATORIO DE ANÁLISIS CLÍNICOS", fBold));
                    pdfDoc.Add(new Paragraph("C 20 de Noviembre S/N Col. Pueblo Nuevo. Tacotalpa, Tab.", fNormal));
                    pdfDoc.Add(new Paragraph("-----------------------------------------------------------------------------------------"));

                    //datos de los pacientes
                    PdfPTable datos = new PdfPTable(2);
                    datos.WidthPercentage = 100;
                    datos.AddCell(new PdfPCell(new Phrase("Nombre: " + lblNombre.Text, fNormal)) { Border = 0 });
                    datos.AddCell(new PdfPCell(new Phrase("Fecha: " + c.Text, fNormal)) { Border = 0 });
                    datos.AddCell(new PdfPCell(new Phrase("Edad: " + lblEdad.Text + " | Sexo: " + lblSexo.Text, fNormal)) { Border = 0 });
                    datos.AddCell(new PdfPCell(new Phrase("Médico: " + lblMedic.Text, fNormal)) { Border = 0 });
                    datos.AddCell(new PdfPCell(new Phrase("Correo: " + label19.Text, fNormal)) { Border = 0 });
                    datos.AddCell(new PdfPCell(new Phrase("Quién Paga: " + label27.Text, fBold)) { Border = 0 }); // ✅ Nuevo
                    pdfDoc.Add(datos);
                    pdfDoc.Add(new Paragraph(" "));

                    PdfPTable tabla = new PdfPTable(4);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 1f, 4f, 1.5f, 1.5f });
                    foreach (string h in new string[] { "Cant.", "Estudio", "P.U.", "Importe" })
                        tabla.AddCell(new PdfPCell(new Phrase(h, fBold)) { Border = iTextSharp.text.Rectangle.BOTTOM_BORDER });

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells[0].Value?.ToString(), fNormal)) { Border = 0 });
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells[1].Value?.ToString(), fNormal)) { Border = 0 });
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells[2].Value?.ToString(), fNormal)) { Border = 0 });
                        tabla.AddCell(new PdfPCell(new Phrase(row.Cells[3].Value?.ToString(), fNormal)) { Border = 0 });
                    }
                    pdfDoc.Add(tabla);

                    pdfDoc.Add(new Paragraph(" "));
                    pdfDoc.Add(new Paragraph("Total: " + lblTotalNumero.Text, fBold));
                    pdfDoc.Add(new Paragraph("Recibido: " + txtRecibido.Text + " | Cambio: " + label20.Text, fNormal));
                    pdfDoc.Add(new Paragraph("SON: " + label16.Text, fNormal));

                    string obs = richTextBox1.Text.Trim();
                    pdfDoc.Add(new Paragraph("Observaciones: " + obs, fNormal));

                    if (pictureBox1.Image != null)
                    {
                        PdfPTable footer = new PdfPTable(2);
                        footer.WidthPercentage = 35;
                        footer.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        footer.DefaultCell.Border = 0;
                        footer.SetWidths(new float[] { 1f, 4f });
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox1.Image.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image icon = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                            icon.ScaleToFit(12f, 12f);
                            footer.AddCell(new PdfPCell(icon) { Border = 0, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE, HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                            footer.AddCell(new PdfPCell(new Phrase("932 106 6122", fBold)) { Border = 0, VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE });
                        }
                        pdfDoc.Add(new Paragraph(" "));
                        pdfDoc.Add(footer);
                    }
                    pdfDoc.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al generar PDF: " + ex.Message); }
        }

        private void GenerarCodigoBarras(string folio)
        {
            if (picCodigoBarras != null)
            {
                Code128BarcodeDraw barcode = BarcodeDrawFactory.Code128WithChecksum;

                // 2. Parámetros del Draw: (Texto, Altura, Factor de escala/ancho)
                // El segundo parámetro (100) es la ALTURA
                // El tercer parámetro (3) es el ANCHO (escala de los módulos)
                picCodigoBarras.Image = barcode.Draw(folio, 150, 20 );
                picCodigoBarras.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }



        private void CargarReciboPorFolio(string folio)
        {
            if (string.IsNullOrWhiteSpace(folio))
            {
                MessageBox.Show("Ingresa un folio.");
                return;
            }

            CConexion objetoConexion = new CConexion();

            try
            {
                string query = @"SELECT folio_curp, nombre, edad, sexo, telefono, correo, fecha, medico, costo, analisis_clinicos, quien_paga 
                         FROM pacientes 
                         WHERE folio_curp = @fol 
                         LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, objetoConexion.establecerconexion()))
                {
                    cmd.Parameters.AddWithValue("@fol", folio);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (!dr.Read())
                        {
                            MessageBox.Show("No se encontró ese folio.");
                            return;
                        }

                        c.Text = dr["fecha"]?.ToString() ?? "";
                        lblNombre.Text = dr["nombre"]?.ToString() ?? "";
                        lblMedic.Text = dr["medico"]?.ToString() ?? "";
                        label19.Text = dr["correo"]?.ToString() ?? "";
                        lblTelefono.Text = dr["telefono"]?.ToString() ?? "";
                        lblSexo.Text = dr["sexo"]?.ToString() ?? "";
                        lblEdad.Text = dr["edad"]?.ToString() ?? "";
                        label27.Text = dr["quien_paga"]?.ToString() ?? "N/A";

                        string fechaStr = dr["fecha"]?.ToString() ?? "";
                        DateTime fecha;
                        if (!string.IsNullOrWhiteSpace(fechaStr) && DateTime.TryParse(fechaStr, new CultureInfo("es-MX"), DateTimeStyles.None, out fecha))
                        {
                            c.Text = fecha.ToString("dd/MM/yyyy");
                        }
                        else { c.Text = fechaStr; }

                        string estudiosRaw = dr["analisis_clinicos"]?.ToString() ?? "";
                        dataGridView1.Rows.Clear();
                        txtRecibido.Text = "0";

                        if (!string.IsNullOrWhiteSpace(estudiosRaw))
                        {
                            string[] lineas = estudiosRaw.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string l in lineas)
                            {
                                if (!l.Contains("|")) continue;
                                string[] partes = l.Split('|');
                                if (partes.Length < 2) continue;

                                string estudio = partes[0].Trim();
                                string precioTxt = partes[1].Trim();
                                decimal precio = 0;
                                decimal.TryParse(precioTxt.Replace("$", "").Replace(",", "").Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);

                                dataGridView1.Rows.Add(1, estudio, precio.ToString("0.00"), precio.ToString("0.00"));
                            }
                        }
                        RecalcularTotales();
                        GenerarCodigoBarras(folio);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar folio: " + ex.Message);
            }
            finally
            {
                objetoConexion.cerrarconexion();
            }
        }

        private string NumeroALetras(decimal numero)
        {
            long parteEntera = (long)Math.Floor(numero);
            int centavos = (int)Math.Round((numero - parteEntera) * 100);

            string letras = EnteroALetras(parteEntera);
            return $"{letras} PESOS {centavos:00}/100 M.N.";
        }

        private string EnteroALetras(long numero)
        {
            if (numero == 0) return "CERO";
            if (numero < 0) return "MENOS " + EnteroALetras(Math.Abs(numero));

            string[] unidades = { "", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE",
                          "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISÉIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE" };

            string[] decenas = { "", "", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA" };

            string[] centenas = { "", "CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS",
                          "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS" };

            if (numero == 100) return "CIEN";

            string resultado = "";

            if (numero >= 1000000)
            {
                long millones = numero / 1000000;
                resultado += (millones == 1 ? "UN MILLÓN" : EnteroALetras(millones) + " MILLONES");
                numero %= 1000000;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 1000)
            {
                long miles = numero / 1000;
                resultado += (miles == 1 ? "MIL" : EnteroALetras(miles) + " MIL");
                numero %= 1000;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 100)
            {
                long c = numero / 100;
                resultado += centenas[c];
                numero %= 100;
                if (numero > 0) resultado += " ";
            }

            if (numero >= 20)
            {
                long d = numero / 10;
                if (d == 2 && (numero % 10) != 0)
                {
                    resultado += "VEINTI" + EnteroALetras(numero % 10).ToLower();
                }
                else
                {
                    resultado += decenas[d];
                    long u = numero % 10;
                    if (u > 0) resultado += " Y " + unidades[u];
                }
            }
            else if (numero > 0)
            {
                resultado += unidades[numero];
            }
            resultado = resultado.Replace("UNO", "UN");
            return resultado.Trim();
        }

        private decimal ObtenerTotalDesdeGrid()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string importeTxt = row.Cells[3].Value?.ToString() ?? "0";
                importeTxt = importeTxt.Replace("$", "").Replace(",", "").Trim();

                if (decimal.TryParse(importeTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal importe))
                    total += importe;
            }

            return total;
        }

        private decimal LeerRecibido()
        {
            string recibidoTxt = txtRecibido.Text ?? "0";
            recibidoTxt = recibidoTxt.Replace("$", "").Replace(",", "").Trim();

            if (decimal.TryParse(recibidoTxt, NumberStyles.Any, new CultureInfo("es-MX"), out decimal recibido))
                return recibido;

            if (decimal.TryParse(recibidoTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out recibido))
                return recibido;

            return 0;
        }

        private void RecalcularTotales()
        {
            decimal total = ObtenerTotalDesdeGrid();
            decimal recibido = LeerRecibido();

            lblTotalNumero.Text = total.ToString("C2", new CultureInfo("es-MX"));

            label16.Text = NumeroALetras(total);

            decimal cambio = recibido - total;

            if (cambio < 0)
            {
                label20.Text = "FALTAN " + Math.Abs(cambio).ToString("C2", new CultureInfo("es-MX"));
                label20.ForeColor = Color.Red;
            }
            else
            {
                label20.Text = cambio.ToString("C2", new CultureInfo("es-MX"));
                label20.ForeColor = Color.Green;
            }
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
            RecalcularTotales();

            float margen = 40;

            System.Drawing.RectangleF area =
                new System.Drawing.RectangleF(
                    margen,
                    margen,
                    e.PageBounds.Width - (margen * 2),
                    e.PageBounds.Height - (margen * 2)
                );

            if (pictureBox3.Image != null)
            {
                float logoAncho = area.Width * 0.4f;
                float logoAlto = logoAncho;

                float xLogo = area.X + (area.Width - logoAncho) / 2;
                float yLogo = area.Y + (area.Height - logoAlto) / 2;

                using (var ia = new System.Drawing.Imaging.ImageAttributes())
                {
                    var cm = new System.Drawing.Imaging.ColorMatrix();
                    cm.Matrix33 = 0.15f;
                    ia.SetColorMatrix(cm);

                    System.Drawing.Rectangle destino = new System.Drawing.Rectangle(
                        (int)xLogo,
                        (int)yLogo,
                        (int)logoAncho,
                        (int)logoAlto
                    );

                    e.Graphics.DrawImage(
                        pictureBox3.Image,
                        destino,
                        0,
                        0,
                        pictureBox3.Image.Width,
                        pictureBox3.Image.Height,
                        System.Drawing.GraphicsUnit.Pixel,
                        ia
                    );
                }
            }

            Bitmap bmp = new Bitmap(groupBox1.Width, groupBox1.Height);
            groupBox1.DrawToBitmap(
                bmp,
                new System.Drawing.Rectangle(0, 0, groupBox1.Width, groupBox1.Height)
            );

            bmp.MakeTransparent(System.Drawing.Color.White);

            float escalaX = area.Width / bmp.Width;
            float escalaY = area.Height / bmp.Height;
            float escalaFinal = Math.Min(escalaX, escalaY);

            float nuevoAncho = bmp.Width * escalaFinal;
            float nuevoAlto = bmp.Height * escalaFinal;

            float x = area.X + (area.Width - nuevoAncho) / 2;
            float y = area.Y + (area.Height - nuevoAlto) / 2;

            e.Graphics.DrawImage(bmp, x, y, nuevoAncho, nuevoAlto);

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void FormRecibos_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBusquedaFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                CargarReciboPorFolio(txtBusquedaFolio.Text.Trim());
                Application.DoEvents();
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            
            RecalcularTotales();
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        { 
            char sep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != sep)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == sep && txtRecibido.Text.Contains(sep))
            {
                e.Handled = true;
                return;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtBusquedaFolio_TextChanged(object sender, EventArgs e)
        {

        }

        private void picCodigoBarras_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusquedaFolio.Text))
            {
                MessageBox.Show("Por favor, ingresa un folio.");
                return;
            }
            RecalcularTotales();
            GuardarPdfDirecto();
            MessageBox.Show("PDF generado correctamente en Descargas.");
        }
        private string rutaArchivoSeleccionado = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Todos los archivos (*.*)|*.*|Archivos SQL (*.sql)|*.sql";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoSeleccionado = ofd.FileName;
                MessageBox.Show("Archivo cargado: " + Path.GetFileName(rutaArchivoSeleccionado));
            }
        }
    }
}
