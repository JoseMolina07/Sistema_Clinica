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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAbrirRecibos = new System.Windows.Forms.Button();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.ColFOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMEDICO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCOSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTELEFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColOBSERVACIONES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAnalisis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CMI_LABORATORIO";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAbrirRecibos);
            this.panel1.Location = new System.Drawing.Point(1, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 56);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "btn2";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAbrirRecibos
            // 
            this.btnAbrirRecibos.Location = new System.Drawing.Point(11, 3);
            this.btnAbrirRecibos.Name = "btnAbrirRecibos";
            this.btnAbrirRecibos.Size = new System.Drawing.Size(83, 37);
            this.btnAbrirRecibos.TabIndex = 0;
            this.btnAbrirRecibos.Text = "Recibos";
            this.btnAbrirRecibos.UseVisualStyleBackColor = true;
            this.btnAbrirRecibos.Click += new System.EventHandler(this.btnAbrirRecibos_Click);
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.ColAnalisis});
            this.dgvPacientes.Location = new System.Drawing.Point(10, 12);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPacientes.Size = new System.Drawing.Size(999, 437);
            this.dgvPacientes.TabIndex = 0;
            this.dgvPacientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellClick);
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            // 
            // ColFOLIO
            // 
            this.ColFOLIO.HeaderText = "FOLIO";
            this.ColFOLIO.Name = "ColFOLIO";
            // 
            // ColNombre
            // 
            this.ColNombre.HeaderText = "NOMBRE";
            this.ColNombre.Name = "ColNombre";
            // 
            // ColFECHA
            // 
            this.ColFECHA.HeaderText = "FECHA";
            this.ColFECHA.Name = "ColFECHA";
            // 
            // ColMEDICO
            // 
            this.ColMEDICO.HeaderText = "MEDICO";
            this.ColMEDICO.Name = "ColMEDICO";
            // 
            // ColCOSTO
            // 
            this.ColCOSTO.HeaderText = "COSTO";
            this.ColCOSTO.Name = "ColCOSTO";
            // 
            // ColTELEFONO
            // 
            this.ColTELEFONO.HeaderText = "TELEFONO";
            this.ColTELEFONO.Name = "ColTELEFONO";
            // 
            // ColOBSERVACIONES
            // 
            this.ColOBSERVACIONES.HeaderText = "OBSERVACIONES";
            this.ColOBSERVACIONES.Name = "ColOBSERVACIONES";
            // 
            // ColEdad
            // 
            this.ColEdad.HeaderText = "EDAD";
            this.ColEdad.Name = "ColEdad";
            // 
            // ColSexo
            // 
            this.ColSexo.HeaderText = "SEXO";
            this.ColSexo.Name = "ColSexo";
            // 
            // ColAnalisis
            // 
            this.ColAnalisis.HeaderText = "ANALISIS SOLICITADOS";
            this.ColAnalisis.Name = "ColAnalisis";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPacientes);
            this.groupBox1.Location = new System.Drawing.Point(1, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 455);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Pacientes";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 571);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMEDICO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCOSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTELEFONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOBSERVACIONES;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAnalisis;
        private System.Windows.Forms.Button btnAbrirRecibos;
        private System.Windows.Forms.Button button1;
    }
}

