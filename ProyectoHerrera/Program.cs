using DataLayer.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHerrera
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmIniciarSesion());
        }

        public static class SesionUsuario
        {
            public static Usuario UsuarioActual { get; set; }  // ✅ Usuario logueado accesible en toda la app
        }




    }
}
