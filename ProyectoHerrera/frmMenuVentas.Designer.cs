namespace ProyectoHerrera
{
    partial class frmMenuVentas
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
            this.barraSuperior1 = new ProyectoHerrera.BarraSuperior();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistorialVentas = new Guna.UI2.WinForms.Guna2Button();
            this.btnNuevaVenta = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(1364, 53);
            this.barraSuperior1.TabIndex = 0;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.btnHistorialVentas);
            this.guna2GradientPanel1.Controls.Add(this.btnNuevaVenta);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.PeachPuff;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.MistyRose;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(72, 113);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1214, 555);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(824, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Historial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(291, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nueva venta";
            // 
            // btnHistorialVentas
            // 
            this.btnHistorialVentas.BackColor = System.Drawing.Color.Transparent;
            this.btnHistorialVentas.BorderRadius = 30;
            this.btnHistorialVentas.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistorialVentas.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistorialVentas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistorialVentas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistorialVentas.FillColor = System.Drawing.Color.LightCoral;
            this.btnHistorialVentas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHistorialVentas.ForeColor = System.Drawing.Color.White;
            this.btnHistorialVentas.Image = global::ProyectoHerrera.Properties.Resources.historial_de_transacciones;
            this.btnHistorialVentas.ImageSize = new System.Drawing.Size(128, 128);
            this.btnHistorialVentas.Location = new System.Drawing.Point(732, 106);
            this.btnHistorialVentas.Name = "btnHistorialVentas";
            this.btnHistorialVentas.Size = new System.Drawing.Size(262, 273);
            this.btnHistorialVentas.TabIndex = 1;
            this.btnHistorialVentas.UseTransparentBackground = true;
            this.btnHistorialVentas.Click += new System.EventHandler(this.btnHistorialVentas_Click);
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevaVenta.BorderRadius = 30;
            this.btnNuevaVenta.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevaVenta.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNuevaVenta.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNuevaVenta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNuevaVenta.FillColor = System.Drawing.Color.SkyBlue;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Image = global::ProyectoHerrera.Properties.Resources.Nuevaventa;
            this.btnNuevaVenta.ImageSize = new System.Drawing.Size(128, 128);
            this.btnNuevaVenta.Location = new System.Drawing.Point(230, 106);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(262, 273);
            this.btnNuevaVenta.TabIndex = 0;
            this.btnNuevaVenta.UseTransparentBackground = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // frmMenuVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.barraSuperior1);
            this.Name = "frmMenuVentas";
            this.Text = "frmMenuVentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BarraSuperior barraSuperior1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnHistorialVentas;
        private Guna.UI2.WinForms.Guna2Button btnNuevaVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}