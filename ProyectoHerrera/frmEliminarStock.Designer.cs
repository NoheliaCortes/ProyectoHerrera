namespace ProyectoHerrera
{
    partial class frmEliminarStock
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMotivoMovimiento = new System.Windows.Forms.ComboBox();
            this.btnConfirmarEliminacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motivo de eliminación:";
            // 
            // cmbMotivoMovimiento
            // 
            this.cmbMotivoMovimiento.FormattingEnabled = true;
            this.cmbMotivoMovimiento.Location = new System.Drawing.Point(141, 59);
            this.cmbMotivoMovimiento.Name = "cmbMotivoMovimiento";
            this.cmbMotivoMovimiento.Size = new System.Drawing.Size(181, 21);
            this.cmbMotivoMovimiento.TabIndex = 1;
            // 
            // btnConfirmarEliminacion
            // 
            this.btnConfirmarEliminacion.Location = new System.Drawing.Point(254, 109);
            this.btnConfirmarEliminacion.Name = "btnConfirmarEliminacion";
            this.btnConfirmarEliminacion.Size = new System.Drawing.Size(68, 26);
            this.btnConfirmarEliminacion.TabIndex = 2;
            this.btnConfirmarEliminacion.Text = "Eliminar";
            this.btnConfirmarEliminacion.UseVisualStyleBackColor = true;
            this.btnConfirmarEliminacion.Click += new System.EventHandler(this.btnConfirmarEliminacion_Click);
            // 
            // frmEliminarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(374, 187);
            this.Controls.Add(this.btnConfirmarEliminacion);
            this.Controls.Add(this.cmbMotivoMovimiento);
            this.Controls.Add(this.label1);
            this.Name = "frmEliminarStock";
            this.Text = "frmEliminarStock";
            this.Load += new System.EventHandler(this.frmEliminarStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMotivoMovimiento;
        private System.Windows.Forms.Button btnConfirmarEliminacion;
    }
}