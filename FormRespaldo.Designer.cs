namespace Sistema_Clinica
{
    partial class FormRespaldo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRespaldo));
            this.btnRespaldar = new System.Windows.Forms.Button();
            this.dgvRespaldos = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespaldos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRespaldar
            // 
            this.btnRespaldar.Location = new System.Drawing.Point(152, 100);
            this.btnRespaldar.Name = "btnRespaldar";
            this.btnRespaldar.Size = new System.Drawing.Size(75, 45);
            this.btnRespaldar.TabIndex = 0;
            this.btnRespaldar.Text = "button1";
            this.btnRespaldar.UseVisualStyleBackColor = true;
            this.btnRespaldar.Click += new System.EventHandler(this.btnRespaldar_Click);
            // 
            // dgvRespaldos
            // 
            this.dgvRespaldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRespaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRespaldos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colHora,
            this.colQuien,
            this.colRuta});
            this.dgvRespaldos.Location = new System.Drawing.Point(307, 100);
            this.dgvRespaldos.Name = "dgvRespaldos";
            this.dgvRespaldos.Size = new System.Drawing.Size(707, 150);
            this.dgvRespaldos.TabIndex = 1;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "FECHA";
            this.colFecha.Name = "colFecha";
            // 
            // colHora
            // 
            this.colHora.HeaderText = "HORA";
            this.colHora.Name = "colHora";
            // 
            // colQuien
            // 
            this.colQuien.HeaderText = "QUIEN REALIZA";
            this.colQuien.Name = "colQuien";
            // 
            // colRuta
            // 
            this.colRuta.HeaderText = "RUTA";
            this.colRuta.Name = "colRuta";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 42);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRespaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 548);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRespaldos);
            this.Controls.Add(this.btnRespaldar);
            this.Name = "FormRespaldo";
            this.Text = "FormRespaldo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRespaldos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRespaldar;
        private System.Windows.Forms.DataGridView dgvRespaldos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuta;
        private System.Windows.Forms.Button button1;
    }
}