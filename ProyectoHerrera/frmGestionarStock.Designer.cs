﻿namespace ProyectoHerrera
{
    partial class frmGestionarStock
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnEliminarStock = new System.Windows.Forms.Button();
            this.btnAgregarStock = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStockNuevo = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductoSeleccionado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(394, 258);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 19;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnEliminarStock
            // 
            this.btnEliminarStock.Location = new System.Drawing.Point(354, 183);
            this.btnEliminarStock.Name = "btnEliminarStock";
            this.btnEliminarStock.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarStock.TabIndex = 18;
            this.btnEliminarStock.Text = "Eliminar";
            this.btnEliminarStock.UseVisualStyleBackColor = true;
            this.btnEliminarStock.Click += new System.EventHandler(this.btnEliminarStock_Click_1);
            // 
            // btnAgregarStock
            // 
            this.btnAgregarStock.Location = new System.Drawing.Point(273, 183);
            this.btnAgregarStock.Name = "btnAgregarStock";
            this.btnAgregarStock.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarStock.TabIndex = 17;
            this.btnAgregarStock.Text = "Agregar";
            this.btnAgregarStock.UseVisualStyleBackColor = true;
            this.btnAgregarStock.Click += new System.EventHandler(this.btnAgregarStock_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Stock nuevo: ";
            // 
            // txtStockNuevo
            // 
            this.txtStockNuevo.Location = new System.Drawing.Point(154, 234);
            this.txtStockNuevo.Name = "txtStockNuevo";
            this.txtStockNuevo.Size = new System.Drawing.Size(100, 20);
            this.txtStockNuevo.TabIndex = 15;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(154, 183);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 14;
            // 
            // txtStockActual
            // 
            this.txtStockActual.Location = new System.Drawing.Point(154, 149);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(100, 20);
            this.txtStockActual.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Stock actual:";
            // 
            // txtProductoSeleccionado
            // 
            this.txtProductoSeleccionado.Location = new System.Drawing.Point(167, 82);
            this.txtProductoSeleccionado.Name = "txtProductoSeleccionado";
            this.txtProductoSeleccionado.Size = new System.Drawing.Size(302, 20);
            this.txtProductoSeleccionado.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nombre del producto: ";
            // 
            // frmGestionarStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(536, 354);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnEliminarStock);
            this.Controls.Add(this.btnAgregarStock);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProductoSeleccionado);
            this.Controls.Add(this.txtStockNuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtStockActual);
            this.Name = "frmGestionarStock";
            this.Text = "Agregar Stock";
            this.Load += new System.EventHandler(this.frmGestionarStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStockNuevo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductoSeleccionado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEliminarStock;
        private System.Windows.Forms.Button btnAgregarStock;
        private System.Windows.Forms.Button btnAceptar;
    }
}