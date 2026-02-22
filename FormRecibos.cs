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

namespace Sistema_Clinica
{
    public partial class FormRecibos : Form
    {
        public FormRecibos()
        {
            InitializeComponent();
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
                string query = @"SELECT folio_curp, nombre, edad, sexo, telefono, correo, fecha, medico, costo, analisis_clinicos
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

                        // ====== AJUSTA AQUÍ LOS NOMBRES DE TUS CONTROLES DEL RECIBO ======
                        // (Estos nombres son ejemplo, cámbialos por los Name reales del diseñador)

                        c.Text = dr["fecha"]?.ToString() ?? "";
                        lblNombre.Text = dr["nombre"]?.ToString() ?? "";
                        lblMedic.Text = dr["medico"]?.ToString() ?? "";
                        label19.Text = dr["correo"]?.ToString() ?? "";
                        lblTelefono.Text = dr["telefono"]?.ToString() ?? "";
                        lblSexo.Text = dr["sexo"]?.ToString() ?? "";
                        lblEdad.Text = dr["edad"]?.ToString() ?? "";
                        

                        // Fecha (parse seguro)
                        string fechaStr = dr["fecha"]?.ToString() ?? "";
                        DateTime fecha;

                        if (!string.IsNullOrWhiteSpace(fechaStr) &&
                            DateTime.TryParse(fechaStr, new CultureInfo("es-MX"), DateTimeStyles.None, out fecha))
                        {
                            c.Text = fecha.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            c.Text = fechaStr; // lo deja tal cual si no parsea
                        }

                        // ====== ESTUDIOS AL GRID ======
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

                                // limpia precio por si viene con $ o comas
                                decimal precio = 0;
                                decimal.TryParse(precioTxt.Replace("$", "").Replace(",", "").Trim(),
                                                 NumberStyles.Any,
                                                 CultureInfo.InvariantCulture,
                                                 out precio);

                                int cantidad = 1;
                                decimal importe = cantidad * precio;

                                // Tu grid debe tener estas 4 columnas en este orden:
                                // CANTIDAD | ESTUDIO REALIZADO | P.U | IMPORTE
                                dataGridView1.Rows.Add(cantidad, estudio, precio.ToString("0.00"), importe.ToString("0.00"));
                                
                            }
                        }
                        RecalcularTotales();
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

            // Para dinero: UN en vez de UNO
            resultado = resultado.Replace("UNO", "UN");
            return resultado.Trim();
        }

        private decimal ObtenerTotalDesdeGrid()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Importe está en la columna 3
                string importeTxt = row.Cells[3].Value?.ToString() ?? "0";
                importeTxt = importeTxt.Replace("$", "").Replace(",", "").Trim();

                if (decimal.TryParse(importeTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal importe))
                    total += importe;
            }

            return total;
        }

        private decimal LeerRecibido()
        {
            // Lee lo que escriben en el TextBox
            string recibidoTxt = txtRecibido.Text ?? "0";
            recibidoTxt = recibidoTxt.Replace("$", "").Replace(",", "").Trim();

            // Intento con es-MX y fallback
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

            // ✅ TOTAL EN NÚMERO (nuevo label)
            lblTotalNumero.Text = total.ToString("C2", new CultureInfo("es-MX"));

            // ✅ TOTAL EN LETRAS
            label16.Text = NumeroALetras(total);

            // ✅ CAMBIO
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
            dataGridView1.AllowUserToAddRows = false;

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

        private void txtBusquedaFolio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // quita el beep
                CargarReciboPorFolio(txtBusquedaFolio.Text.Trim());
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            
            RecalcularTotales();
        }

        private void txtRecibido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite teclas de control (Backspace), números y separador decimal
            char sep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != sep)
            {
                e.Handled = true;
                return;
            }

            // Solo permitir 1 separador decimal
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
    }
}
