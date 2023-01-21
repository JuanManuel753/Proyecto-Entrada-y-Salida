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

namespace login_simple
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void btningresar_Click(object sender, EventArgs e)
        {
            //llamo el metodo de logeo en el boton de inicio de sesion.
            logeo(this.txtusuario.Text, this.txtcontraseña.Text);//pide dos parametros usuario y contraseña
        }

    //creo metodo de logeo con roles.
    public void logeo (string cedula, string contraseña )
        {
            //manejo de errores
            try
            {
                conexion.Open(); //abro conexion
                SqlCommand comando = new SqlCommand("SELECT  NOMBRE, ROL FROM Usuarios WHERE  CEDULA = @usuario AND CONTRASEÑA = @contraseña", conexion);
                comando.Parameters.AddWithValue("usuario", cedula); // primer parametro cedula
                comando.Parameters.AddWithValue("contraseña", contraseña);// segundo parametro
                SqlDataAdapter sda = new SqlDataAdapter(comando); //creo objeto sql (sda=Sql Data Adapter)
                DataTable dt = new DataTable();//creo datatable
                sda.Fill(dt);
                //evaluamos si la consulta devuelve filas. para saber si hay algun usuario que coincida
                if (dt.Rows.Count == 1)//si encontro filas 
                {
                    ClaseVariablesPublicas.Usuario = dt.Rows[0][0].ToString();
                    //validar que tipo de usuario esta ingresando, si es vigilante o administrador
                    if (dt.Rows[0][1].ToString() == "Administrador") // señalo la primeras columnas de la consulta sql (nombre, rol) y lo convierto string, y finalizo colocando su respectivo rol.
                    {
                        this.Hide();
                        ClaseVariablesPublicas.Rol = "Administrador";
                        FrmMenu f = new FrmMenu();
                        f.ShowDialog();
                    } 

                    if (dt.Rows[0][1].ToString() == "Vigilante")
                    {
                        this.Hide();
                        ClaseVariablesPublicas.Rol = "Vigilante";
                        FrmMenuVigilante f = new FrmMenuVigilante();
                        f.ShowDialog();
                    }
                }
                else // no encontro filas
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

		private void BtnSalir_Click(object sender, EventArgs e)
		{
            Application.Exit();
		}

		private void FrmLogin_Load(object sender, EventArgs e)
		{

		}

		private void PbxSalir_Click(object sender, EventArgs e)
		{
            Application.Exit();
		}

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
