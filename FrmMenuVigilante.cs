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

    public partial class FrmMenuVigilante : Form
    {
        public static int id = 0;
        public static long idpropietario = 0;

        public FrmMenuVigilante()
        {
            InitializeComponent();
        }

        private void BtnControlES_Click(object sender, EventArgs e)
        {
            Dgv.Visible = true;
            ClaseVariablesPublicas.modulo = BtnControlES.Text;
            System.Data.SqlClient.SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            {
                //Abrir conexión
                conexion.Open();
                //Crear una instancia de la clase SqlCommand
                SqlCommand cmd = new SqlCommand("Pa_Tabla_Registros", conexion);

                //ejecutar un procediento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                //No se agregan parametros ya que la consulta sql no las necesita

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                //Rellenar el objeto DataTable con el resultado de la consulta sql
                da.Fill(dt);
                //Vincular una fuenta de datos con el objeto DataGridView
                Dgv.DataSource = dt;
            }
        }

        private void PbxSalir_Click(object sender, EventArgs e)
        {
            DialogResult rpta = new DialogResult();
            rpta = MessageBox.Show("¿Desea Cerrar Sesion?", "¡Cerrando Sesion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (rpta == DialogResult.OK)
            {
                this.Hide();
                FrmLogin f = new FrmLogin();
                f.ShowDialog();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistros_Click(object sender, EventArgs e)
        {
            Dgv.Visible = false;

        }

        private void TxtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (TxtEntrada.Text != "")
                    {

                        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        //Abrir conexión
                        conexion.Open();
                        //Crear una instancia de la clase SqlCommand
                        SqlCommand cmd = new SqlCommand("Pa_Select_IdBien", conexion);

                        //ejecutar un procediento almacenado
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@CODIGO", TxtEntrada.Text);

                        SqlDataAdapter adap = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        //Rellenar el objeto DataTable con el resultado de la consulta sql
                        adap.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            int idmaximo = 0;
                            id = Convert.ToInt32(dt.Rows[0][0].ToString());
                            //Crear una instancia de la clase SqlCommand
                            SqlCommand cmd1 = new SqlCommand("Pa_IdMax", conexion);

                            //ejecutar un procediento almacenado
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.AddWithValue("@ID_BIENES", id);

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            //Rellenar el objeto DataTable con el resultado de la consulta sql
                            da1.Fill(dt1);
                            if (dt1.Rows[0][0]!=DBNull.Value)
                            {

                                idmaximo = Convert.ToInt32(dt1.Rows[0][0]);
                            }
		

                            //Crear una instancia de la clase SqlCommand
                            SqlCommand cmdpropietario = new SqlCommand("Pa_Select_Codigo_Barras", conexion);

                            //ejecutar un procediento almacenado
                            cmdpropietario.CommandType = CommandType.StoredProcedure;

                            cmdpropietario.Parameters.AddWithValue("@CODIGO", TxtEntrada.Text);

                            SqlDataAdapter dapropietario = new SqlDataAdapter(cmdpropietario);
                            DataTable dtpropietario = new DataTable();
                            //Rellenar el objeto DataTable con el resultado de la consulta sql
                            dapropietario.Fill(dtpropietario);

                            idpropietario = Convert.ToInt64(dtpropietario.Rows[0][0]);
                            
                            //---------MODIFICA EL BIEN Y DA SALIDA ---------------
                            if (idmaximo != 0)
                            {
                                
                                //CODIGO PARA DAR SALIDA
                                //Crear una instancia de la clase SqlCommand
                                SqlCommand cmd2 = new SqlCommand("Pa_Editar_Salida", conexion);

                                //ejecutar un procediento almacenado
                                cmd2.CommandType = CommandType.StoredProcedure;

                                cmd2.Parameters.AddWithValue("@ID_BIENES", id);
                                cmd2.Parameters.AddWithValue("@ID_REGISTRO", idmaximo);

                                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                //Rellenar el objeto DataTable con el resultado de la consulta sql
                                da2.Fill(dt2);
                                MessageBox.Show("SALIDA REGISTRADA", "REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            //INserta BIien y da entrada
                            else
                            {
                                //Crear una instancia de la clase SqlCommand
                                SqlCommand cmd2 = new SqlCommand("Pa_Insert_Registro_Entrada", conexion);

                                //ejecutar un procediento almacenado
                                cmd2.CommandType = CommandType.StoredProcedure;

                                cmd2.Parameters.AddWithValue("@ID_PROPIETARIO", idpropietario);
                                cmd2.Parameters.AddWithValue("@ID_BIENES", id);

                                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                                DataTable dt2 = new DataTable();
                                //Rellenar el objeto DataTable con el resultado de la consulta sql
                                da2.Fill(dt2);
                                MessageBox.Show("INGRESO REGISTRADO", "REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("ESTE BIEN NO ESTA REGISTRADO", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("INGRESE UN SERIAL");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FechaHora_Tick(object sender, EventArgs e)
        {
            LblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void GbMenu_Enter(object sender, EventArgs e)
        {

        }

        private void FrmMenuVigilante_Activated(object sender, EventArgs e)
        {
            LblRol.Text = "Rol: " + ClaseVariablesPublicas.Rol;
            LblUsuario.Text = "Usuario: " + ClaseVariablesPublicas.Usuario;
        }

        private void LblHora_Click(object sender, EventArgs e)
        {

        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
