using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autobuses2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();

            MessageBox.Show("Coneccion Exitosa");
            dataGridView1.DataSource = LLenarGrilla();

        }
        
        public DataTable LLenarGrilla()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "Select * From chofer";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable LLenarGrilla2()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "Select * From autobuses";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable LLenarGrilla3()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            String consulta = "Select * From ruta";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        






        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertar = "insert Into chofer(Nombre,Apellido,Fechanacimiento,Cedula) Values (@Nombre,@apellido,\n" +
                "@Fechanacimiento,@Cedula)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Nombre", txtNobre.Text);
            cmd1.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd1.Parameters.AddWithValue("@Fechanacimiento", txtFecha.Text);
            cmd1.Parameters.AddWithValue("@Cedula", txtCedula.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("El contacto fue agendado correctamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            txtNobre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            String actualizar = "Update chofer set Nombre=@Nombre, Apellido=@Apellido, Fechanacimiento=Fechanacimiento,\n" +
                " Cedula=@Cedula Where idchofer=@idchofer";

            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@idchofer", txtid.Text);
            cmd2.Parameters.AddWithValue("@Nombre", txtNobre.Text);
            cmd2.Parameters.AddWithValue("@Apellido", txtApellido.Text);
            cmd2.Parameters.AddWithValue("@Fechanacimiento", txtFecha.Text);
            cmd2.Parameters.AddWithValue("@Cedula", txtCedula.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron modificados exitosamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNobre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtFecha.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtCedula.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch { }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "Delete From chofer where idchofer=@idchofer";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("idchofer", txtid.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminados exitosamente");
            dataGridView1.DataSource = LLenarGrilla();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btNuevoAutobus_Click(object sender, EventArgs e)
        {
            

        }

        private void btAgregarAutobus_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertar = "insert Into autobuses(Marca,Modelo,Placa,Color,Año) Values (@Marca,@Modelo,\n" +
                "@Placa,@Color,@Año)";
            SqlCommand cmd3 = new SqlCommand(insertar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Marca", txtMarca.Text);
            cmd3.Parameters.AddWithValue("@Modelo", txtModelo.Text);
            cmd3.Parameters.AddWithValue("@Placa", txtPlaca.Text);
            cmd3.Parameters.AddWithValue("@Color", txtColor.Text);
            cmd3.Parameters.AddWithValue("@Año", txtAño.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("El contacto fue agendado correctamente");
            dataGridView2.DataSource = LLenarGrilla2();
        }


        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();

            string insertar = "insert Into ruta(nombre_de_ruta) Values (@ruta)";
            SqlCommand cmd3 = new SqlCommand(insertar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@idruta", txtidruta.Text);
            cmd3.Parameters.AddWithValue("@ruta", txtRuta.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("El contacto fue agendado correctamente");
            dataGridView3.DataSource = LLenarGrilla3();
        }

        private void cbxNombreChofer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

