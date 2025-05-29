namespace ProyectoHerrera
{
    partial class frmInventario
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
            this.cmbMedida = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPeso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.cmbSabor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLinea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelSabores = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGestionarSabores = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvLineas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.PanelInventario = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.barraSuperior1 = new ProyectoHerrera.BarraSuperior();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.PanelSabores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).BeginInit();
            this.PanelInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMedida
            // 
            this.cmbMedida.FormattingEnabled = true;
            this.cmbMedida.Location = new System.Drawing.Point(564, 82);
            this.cmbMedida.Name = "cmbMedida";
            this.cmbMedida.Size = new System.Drawing.Size(63, 21);
            this.cmbMedida.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(500, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Medida:";
            // 
            // cmbPeso
            // 
            this.cmbPeso.FormattingEnabled = true;
            this.cmbPeso.Location = new System.Drawing.Point(435, 82);
            this.cmbPeso.Name = "cmbPeso";
            this.cmbPeso.Size = new System.Drawing.Size(59, 21);
            this.cmbPeso.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Peso:";
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(60, 118);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.Size = new System.Drawing.Size(691, 357);
            this.dgvInventario.TabIndex = 10;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // cmbSabor
            // 
            this.cmbSabor.FormattingEnabled = true;
            this.cmbSabor.Location = new System.Drawing.Point(263, 82);
            this.cmbSabor.Name = "cmbSabor";
            this.cmbSabor.Size = new System.Drawing.Size(121, 21);
            this.cmbSabor.TabIndex = 8;
            this.cmbSabor.SelectedIndexChanged += new System.EventHandler(this.cmbSabor_SelectedIndexChanged);
            this.cmbSabor.Click += new System.EventHandler(this.cmbSabor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sabor:";
            // 
            // cmbLinea
            // 
            this.cmbLinea.FormattingEnabled = true;
            this.cmbLinea.Location = new System.Drawing.Point(69, 82);
            this.cmbLinea.Name = "cmbLinea";
            this.cmbLinea.Size = new System.Drawing.Size(121, 21);
            this.cmbLinea.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Línea: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inventario";
            // 
            // PanelSabores
            // 
            this.PanelSabores.BackColor = System.Drawing.Color.AliceBlue;
            this.PanelSabores.Controls.Add(this.label8);
            this.PanelSabores.Controls.Add(this.btnGestionarSabores);
            this.PanelSabores.Controls.Add(this.btnEliminar);
            this.PanelSabores.Controls.Add(this.btnEditar);
            this.PanelSabores.Controls.Add(this.btnAgregar);
            this.PanelSabores.Controls.Add(this.dgvLineas);
            this.PanelSabores.Controls.Add(this.label6);
            this.PanelSabores.Location = new System.Drawing.Point(839, 115);
            this.PanelSabores.Name = "PanelSabores";
            this.PanelSabores.Size = new System.Drawing.Size(498, 569);
            this.PanelSabores.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(-3, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(500, 2);
            this.label8.TabIndex = 17;
            // 
            // btnGestionarSabores
            // 
            this.btnGestionarSabores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarSabores.Location = new System.Drawing.Point(353, 210);
            this.btnGestionarSabores.Name = "btnGestionarSabores";
            this.btnGestionarSabores.Size = new System.Drawing.Size(75, 38);
            this.btnGestionarSabores.TabIndex = 5;
            this.btnGestionarSabores.Text = "Gestionar Sabores";
            this.btnGestionarSabores.UseVisualStyleBackColor = true;
            this.btnGestionarSabores.Click += new System.EventHandler(this.btnGestionarSabores_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(353, 171);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 33);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(353, 136);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 29);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(353, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 34);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Nueva linea";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvLineas
            // 
            this.dgvLineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineas.Location = new System.Drawing.Point(57, 96);
            this.dgvLineas.Name = "dgvLineas";
            this.dgvLineas.Size = new System.Drawing.Size(252, 152);
            this.dgvLineas.TabIndex = 1;
            this.dgvLineas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineas_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "Administrar lineas";
            // 
            // PanelInventario
            // 
            this.PanelInventario.BackColor = System.Drawing.Color.Bisque;
            this.PanelInventario.Controls.Add(this.btnCancelar);
            this.PanelInventario.Controls.Add(this.btnStock);
            this.PanelInventario.Controls.Add(this.btnEliminarProducto);
            this.PanelInventario.Controls.Add(this.btnActualizar);
            this.PanelInventario.Controls.Add(this.btnNuevo);
            this.PanelInventario.Controls.Add(this.label7);
            this.PanelInventario.Controls.Add(this.dgvInventario);
            this.PanelInventario.Controls.Add(this.cmbMedida);
            this.PanelInventario.Controls.Add(this.btnBuscar);
            this.PanelInventario.Controls.Add(this.label5);
            this.PanelInventario.Controls.Add(this.label3);
            this.PanelInventario.Controls.Add(this.cmbSabor);
            this.PanelInventario.Controls.Add(this.cmbPeso);
            this.PanelInventario.Controls.Add(this.cmbLinea);
            this.PanelInventario.Controls.Add(this.label2);
            this.PanelInventario.Controls.Add(this.label4);
            this.PanelInventario.Controls.Add(this.label1);
            this.PanelInventario.Location = new System.Drawing.Point(54, 115);
            this.PanelInventario.Name = "PanelInventario";
            this.PanelInventario.Size = new System.Drawing.Size(770, 569);
            this.PanelInventario.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Bisque;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Image = global::ProyectoHerrera.Properties.Resources.cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(697, 74);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(44, 40);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(575, 482);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(101, 23);
            this.btnStock.TabIndex = 20;
            this.btnStock.Text = "Gestionar Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click_1);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Location = new System.Drawing.Point(483, 482);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarProducto.TabIndex = 19;
            this.btnEliminarProducto.Text = "Eliminar";
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click_1);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(393, 481);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_1);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(297, 482);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(2, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(768, 2);
            this.label7.TabIndex = 16;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Bisque;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBuscar.Image = global::ProyectoHerrera.Properties.Resources.lupa;
            this.btnBuscar.Location = new System.Drawing.Point(645, 74);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 42);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(1364, 53);
            this.barraSuperior1.TabIndex = 17;
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.barraSuperior1);
            this.Controls.Add(this.PanelInventario);
            this.Controls.Add(this.PanelSabores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInventario";
            this.Text = "+";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.PanelSabores.ResumeLayout(false);
            this.PanelSabores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineas)).EndInit();
            this.PanelInventario.ResumeLayout(false);
            this.PanelInventario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLinea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbSabor;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPeso;
        private System.Windows.Forms.ComboBox cmbMedida;
        private System.Windows.Forms.Panel PanelSabores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLineas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnGestionarSabores;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel PanelInventario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Button btnCancelar;
        private BarraSuperior barraSuperior1;
    }
}