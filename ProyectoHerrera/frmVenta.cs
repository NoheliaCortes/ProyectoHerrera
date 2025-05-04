using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoHerrera
{
    public partial class frmVenta : Form
    {
        public frmVenta()
        {
            InitializeComponent();
            this.Load += frmVenta_Load;
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {

            //txtFactura.Text = ObtenerSiguienteFactura().ToString();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
            txtFactura.Text = ObtenerSiguienteFactura().ToString();

        }

        private int ObtenerSiguienteFactura()
        {
            const string sql = @"

            SELECT ISNULL(MAX(id_venta), 0) + 1
            FROM Venta;
        ";

            using (var cn = new SqlConnection(miCadena))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                 
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private readonly string miCadena = //pone tu cadena de conexion
    @"Server=DESKTOP-VSK4022\SQLEXPRESS01;Database=ProyectoHerrera;Trusted_Connection=True;"; 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
