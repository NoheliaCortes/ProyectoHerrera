using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHerrera
{
    public partial class frmInicio : Form
    {

        

        public frmInicio()
        {
            InitializeComponent();
        }

        


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

       

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmMenuVentas nuevoFormulario = new frmMenuVentas(); 
            nuevoFormulario.Show(); 
             
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmInventario nuevoFormulario = new frmInventario();
            nuevoFormulario.Show();
      

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

          



            RedondearBoton(btnVentas, 20);
            RedondearBoton(btnClientes, 20);
            RedondearBoton(btnCompras, 20);
            RedondearBoton(btnProductos, 20);
            RedondearBoton(btnInsumos, 20);
            RedondearBoton(btnUsuarios, 20);
            RedondearBoton(btnReportes, 20);
            RedondearBoton(btnProveedores, 20);
           
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            frmInsumos frm = new frmInsumos();
            frm.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
             frmClientes frm = new frmClientes();
            frm.ShowDialog();
        }

      

        private void RedondearBoton(Button boton, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(boton.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(boton.Width - radio, boton.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, boton.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            boton.Region = new Region(path);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmMenuReportes frm = new frmMenuReportes();
            frm.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            frmCompra frm = new frmCompra();
            frm.ShowDialog();
        }
    }
}
