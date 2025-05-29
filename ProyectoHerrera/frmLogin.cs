using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProyectoHerrera
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnIngresas; // Establecer el botón de inicio de sesión como el botón predeterminado
        }

       

        private void btnIngresas_Click(object sender, EventArgs e)
        {
            if (txtUsuario .Text == "admin" && txtContraseña.Text == "123" )
            {
                frmInicio frminicio = new frmInicio();
                frminicio.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Los datos ingresados son incorrectos.");
                // Limpiar los campos de texto
                txtUsuario.Clear();
                txtContraseña.Clear();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ShowPassword = false; //variable de control para mostrar y ocultar la conraseña
        private void pbContraseña_Click(object sender, EventArgs e)
        {
            ShowPassword = !ShowPassword;
            if (ShowPassword)
            {
                txtContraseña.PasswordChar = '\0';
                pbContraseña.Image = ProyectoHerrera.Properties.Resources.hide;

            }
            else
            {
                txtContraseña.PasswordChar = '*';
                pbContraseña.Image = ProyectoHerrera.Properties.Resources.show;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GraphicsPath hex = CrearHexagonoRedondeado(LoginPanel.ClientRectangle, 10); // ajustá el 'radio'
            LoginPanel.Region = new Region(hex);

        }

        private GraphicsPath CrearHexagonoRedondeado(Rectangle bounds, int radio)
        {
            PointF[] puntos = new PointF[6];

            float ancho = bounds.Width;
            float alto = bounds.Height;
            float mitadAncho = ancho / 2;
            float cuartoAlto = alto / 4;

            // Coordenadas para los 6 vértices del hexágono
            puntos[0] = new PointF(mitadAncho, 0);
            puntos[1] = new PointF(ancho, cuartoAlto);
            puntos[2] = new PointF(ancho, 3 * cuartoAlto);
            puntos[3] = new PointF(mitadAncho, alto);
            puntos[4] = new PointF(0, 3 * cuartoAlto);
            puntos[5] = new PointF(0, cuartoAlto);

            GraphicsPath path = new GraphicsPath();

            for (int i = 0; i < 6; i++)
            {
                PointF actual = puntos[i];
                PointF siguiente = puntos[(i + 1) % 6];

                // Línea recta con curva en el vértice
                path.AddLine(actual, siguiente);
            }

            path.CloseFigure();
            return path;
        }



    }
}
