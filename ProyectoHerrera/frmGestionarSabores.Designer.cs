namespace ProyectoHerrera
{
    partial class frmGestionarSabores
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
            this.lblLineaSeleccionada = new System.Windows.Forms.Label();
            this.dgvSabores = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLineaSeleccionada
            // 
            this.lblLineaSeleccionada.AutoSize = true;
            this.lblLineaSeleccionada.Location = new System.Drawing.Point(44, 55);
            this.lblLineaSeleccionada.Name = "lblLineaSeleccionada";
            this.lblLineaSeleccionada.Size = new System.Drawing.Size(36, 13);
            this.lblLineaSeleccionada.TabIndex = 0;
            this.lblLineaSeleccionada.Text = "Linea:";
            // 
            // dgvSabores
            // 
            this.dgvSabores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSabores.Location = new System.Drawing.Point(47, 87);
            this.dgvSabores.Name = "dgvSabores";
            this.dgvSabores.Size = new System.Drawing.Size(475, 247);
            this.dgvSabores.TabIndex = 1;
            this.dgvSabores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSabores_CellContentClick_1);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(574, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Nuevo";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(574, 156);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmGestionarSabores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 428);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvSabores);
            this.Controls.Add(this.lblLineaSeleccionada);
            this.Name = "frmGestionarSabores";
            this.Text = "frmGestionarSabores";
            this.Load += new System.EventHandler(this.frmGestionarSabores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSabores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLineaSeleccionada;
        private System.Windows.Forms.DataGridView dgvSabores;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
    }
}