using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autobuses2
{
    public class Conexion
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Data Source= DESKTOP-GDS6LOP; Initial Catalog=control; Integrated Security=true");

            cn.Open();
            return cn;
        }
    }
}