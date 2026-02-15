namespace Sistema_Clinica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEtiqueta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAbrirRecibos = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ColCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnalisis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMEDICO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.numEdad = new System.Windows.Forms.NumericUpDown();
            this.txtMedico = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAnalisis = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEtiqueta
            // 
            this.btnEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEtiqueta.Location = new System.Drawing.Point(3, 187);
            this.btnEtiqueta.Name = "btnEtiqueta";
            this.btnEtiqueta.Size = new System.Drawing.Size(111, 37);
            this.btnEtiqueta.TabIndex = 2;
            this.btnEtiqueta.Text = "Etiquetado";
            this.btnEtiqueta.UseVisualStyleBackColor = true;
            this.btnEtiqueta.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(3, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Médicos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbrirRecibos
            // 
            this.btnAbrirRecibos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAbrirRecibos.Location = new System.Drawing.Point(3, 57);
            this.btnAbrirRecibos.Name = "btnAbrirRecibos";
            this.btnAbrirRecibos.Size = new System.Drawing.Size(111, 37);
            this.btnAbrirRecibos.TabIndex = 0;
            this.btnAbrirRecibos.Text = "Recibos";
            this.btnAbrirRecibos.UseVisualStyleBackColor = true;
            this.btnAbrirRecibos.Click += new System.EventHandler(this.btnAbrirRecibos_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(736, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 20);
            this.textBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBox1, "Puede ingresar cualquier dato para encontrar al paciente");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(752, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar Paciente: 🔎";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox7.BackgroundImage")));
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(38, 2);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(26, 26);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 95;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(69, 2);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(26, 26);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 94;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(8, 2);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(26, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 93;
            this.pictureBox5.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.button1);
            this.pnlMenu.Controls.Add(this.pictureBox7);
            this.pnlMenu.Controls.Add(this.pictureBox6);
            this.pnlMenu.Controls.Add(this.btnEtiqueta);
            this.pnlMenu.Controls.Add(this.pictureBox5);
            this.pnlMenu.Controls.Add(this.btnAbrirRecibos);
            this.pnlMenu.Location = new System.Drawing.Point(0, -1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(127, 604);
            this.pnlMenu.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(133, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(899, 86);
            this.panel1.TabIndex = 97;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(232, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ColCorreo
            // 
            this.ColCorreo.HeaderText = "CORREO";
            this.ColCorreo.Name = "ColCorreo";
            // 
            // ColAnalisis
            // 
            this.ColAnalisis.HeaderText = "ANALISIS SOLICITADOS";
            this.ColAnalisis.Name = "ColAnalisis";
            // 
            // ColSexo
            // 
            this.ColSexo.HeaderText = "SEXO";
            this.ColSexo.Name = "ColSexo";
            // 
            // ColEdad
            // 
            this.ColEdad.HeaderText = "EDAD";
            this.ColEdad.Name = "ColEdad";
            // 
            // ColOBSERVACIONES
            // 
            this.ColOBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.ColOBSERVACIONES.Name = "ColOBSERVACIONES";
            // 
            // ColTELEFONO
            // 
            this.ColTELEFONO.HeaderText = "TELEFONO";
            this.ColTELEFONO.Name = "ColTELEFONO";
            // 
            // ColCOSTO
            // 
            this.ColCOSTO.HeaderText = "COSTO";
            this.ColCOSTO.Name = "ColCOSTO";
            // 
            // ColMEDICO
            // 
            this.ColMEDICO.HeaderText = "MEDICO";
            this.ColMEDICO.Name = "ColMEDICO";
            // 
            // ColFECHA
            // 
            this.ColFECHA.HeaderText = "FECHA";
            this.ColFECHA.Name = "ColFECHA";
            // 
            // ColNombre
            // 
            this.ColNombre.HeaderText = "NOMBRE";
            this.ColNombre.Name = "ColNombre";
            // 
            // ColFOLIO
            // 
            this.ColFOLIO.HeaderText = "FOLIO";
            this.ColFOLIO.Name = "ColFOLIO";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPacientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPacientes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFOLIO,
            this.ColNombre,
            this.ColFECHA,
            this.ColMEDICO,
            this.ColCOSTO,
            this.ColTELEFONO,
            this.ColOBSERVACIONES,
            this.ColEdad,
            this.ColSexo,
            this.ColAnalisis,
            this.ColCorreo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPacientes.Location = new System.Drawing.Point(133, 375);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(887, 228);
            this.dgvPacientes.TabIndex = 98;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick_1);
            this.dgvPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.txtCorreo);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.cmbSexo);
            this.groupBox1.Controls.Add(this.numEdad);
            this.groupBox1.Controls.Add(this.txtMedico);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtFolio);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(133, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 278);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro del Cliente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(86, 140);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 137;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(328, 136);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(107, 20);
            this.txtCorreo.TabIndex = 136;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(328, 102);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(107, 20);
            this.txtObservaciones.TabIndex = 134;
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(328, 71);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(107, 21);
            this.cmbSexo.TabIndex = 133;
            // 
            // numEdad
            // 
            this.numEdad.Location = new System.Drawing.Point(328, 40);
            this.numEdad.Name = "numEdad";
            this.numEdad.Size = new System.Drawing.Size(107, 20);
            this.numEdad.TabIndex = 132;
            // 
            // txtMedico
            // 
            this.txtMedico.FormattingEnabled = true;
            this.txtMedico.Items.AddRange(new object[] {
            "A quien corresponda"});
            this.txtMedico.Location = new System.Drawing.Point(153, 179);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.Size = new System.Drawing.Size(105, 21);
            this.txtMedico.TabIndex = 129;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(86, 99);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(100, 20);
            this.dtpFecha.TabIndex = 128;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(86, 62);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 126;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(86, 27);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(100, 20);
            this.txtFolio.TabIndex = 125;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(210, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 124;
            this.label12.Text = "Correo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "Folio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Nombre:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(210, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 123;
            this.label11.Text = "Observaciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "Fecha:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(210, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Sexo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 117;
            this.label5.Text = "Médico que envía:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(210, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Edad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 120;
            this.label8.Text = "Teléfono:";
            // 
            // txtAnalisis
            // 
            this.txtAnalisis.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtAnalisis.FormattingEnabled = true;
            this.txtAnalisis.Location = new System.Drawing.Point(141, 13);
            this.txtAnalisis.Name = "txtAnalisis";
            this.txtAnalisis.Size = new System.Drawing.Size(107, 21);
            this.txtAnalisis.TabIndex = 135;
            this.txtAnalisis.Text = "\"BUSCAR ANÁLISIS...\"";
            this.txtAnalisis.SelectedIndexChanged += new System.EventHandler(this.txtAnalisis_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(330, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 28);
            this.button2.TabIndex = 99;
            this.button2.Text = "Ingresar Orden";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 118;
            this.label6.Text = "Análisis Solicitados:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.txtAnalisis);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(586, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 278);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(387, 251);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 143;
            this.label15.Text = "label15";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(269, 251);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 142;
            this.label14.Text = "Subtotal: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(205, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 141;
            this.label13.Text = "Eliminar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 140;
            this.label7.Text = "Agregar";
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(208, 179);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 50);
            this.button4.TabIndex = 139;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(207, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 50);
            this.button3.TabIndex = 138;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(272, 49);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(156, 189);
            this.dataGridView2.TabIndex = 137;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(175, 215);
            this.dataGridView1.TabIndex = 136;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1032, 604);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Registro de Pacientes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEdad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAbrirRecibos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnEtiqueta;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnalisis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOBSERVACIONES;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCOSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMEDICO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFOLIO;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.ComboBox txtAnalisis;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.NumericUpDown numEdad;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox txtMedico;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

