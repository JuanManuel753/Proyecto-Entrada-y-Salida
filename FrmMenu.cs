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

namespace login_simple
{
	public partial class FrmMenu : Form
	{
		int n = 0;


        public FrmMenu()
		{
			InitializeComponent();
		}

		private void FrmMenu_Load(object sender, EventArgs e)
		{

		}

		private void PbxSalir_Click(object sender, EventArgs e)
		{
			DialogResult rpta = new DialogResult();
			rpta = MessageBox.Show("¿Desea Cerrar Sesion?","¡Cerrando Sesion!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (rpta == DialogResult.OK)
			{
				this.Hide();
				FrmLogin f = new FrmLogin();
				f.ShowDialog();
			}
		}

		private void BtnNuevo_Click(object sender, EventArgs e)
		{
			if (ClaseVariablesPublicas.modulo == "Usuarios")
			{
				FrmNuevoUsuario f = new FrmNuevoUsuario();
				f.ShowDialog();
			}
			else if (ClaseVariablesPublicas.modulo == "Propietarios")
			{
				FrmNuevoPropietario f = new FrmNuevoPropietario();
				f.ShowDialog();
			}
			else if (ClaseVariablesPublicas.modulo == "Bienes")
			{
				FrmNuevoBien f = new FrmNuevoBien();
				f.ShowDialog();
			}
			else if (ClaseVariablesPublicas.modulo == "Control E/S")
			{
				MessageBox.Show("Seleccione un modulo correcto!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				MessageBox.Show("Seleccione un modulo correcto!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void FrmMenu_Activated(object sender, EventArgs e)
		{

			LblRol.Text = "Rol: " + ClaseVariablesPublicas.Rol;
			LblUsuario.Text = "Usuario: " + ClaseVariablesPublicas.Usuario;


			if (ClaseVariablesPublicas.Rol == "Vigilante") 
			{
				BtnBienes.Enabled = false;
				BtnPropietarios.Enabled = false;
				BtnUsuario.Enabled = false;
				BtnEditar.Enabled = false;
				BtnEliminar.Enabled = false;
				BtnNuevo.Enabled = false;
			}
		}

        private void GbMenu_Enter(object sender, EventArgs e)
        {

        }
		//llamo procedimiento almacenado de sleccionar toda la tabla de usuarios
        private void BtnUsuario_Click(object sender, EventArgs e)
        {
			BtnEliminar.Visible = true;
			BtnEditar.Visible = true;
			BtnNuevo.Visible = true;
			BtnNuevo.Enabled = true;
			BtnEliminar.Enabled = true;
			BtnEditar.Enabled = true;
			ClaseVariablesPublicas.modulo = BtnUsuario.Text;
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			{
				//Abrir conexión
				conexion.Open();
				//Crear una instancia de la clase SqlCommand
				SqlCommand cmd = new SqlCommand("Pa_Tabla_Usuarios", conexion);

				//Indicar que el tipo de comando a ejecutar es un procediento almacenado
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

        private void BtnPropietarios_Click(object sender, EventArgs e)
        {
			BtnEliminar.Visible = true;
			BtnEditar.Visible = true;
			BtnNuevo.Visible = true;
			BtnNuevo.Enabled = true;
			BtnEliminar.Enabled = true;
			BtnEditar.Enabled = true;
			ClaseVariablesPublicas.modulo = BtnPropietarios.Text;
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			{
				//Abrir conexión
				conexion.Open();
				//Crear una instancia de la clase SqlCommand
				SqlCommand cmd = new SqlCommand("Pa_Tabla_Propietarios", conexion);

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

		private void BtnControlES_Click(object sender, EventArgs e)
		{
			BtnEliminar.Visible = true;
			BtnEditar.Visible = false;
			BtnNuevo.Visible = false;
			BtnEliminar.Enabled = true;
			BtnEditar.Enabled = false;
			BtnNuevo.Enabled = false;
			ClaseVariablesPublicas.modulo = BtnControlES.Text;
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

		public static DataTable Func_TablaBienes()
        {
			ClaseVariablesPublicas.modulo = "Bienes";
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			{
				//Abrir conexión
				conexion.Open();
				//Crear una instancia de la clase SqlCommand
				SqlCommand cmd = new SqlCommand("Pa_Tabla_Bienes", conexion);

				//ejecutar un procediento almacenado
				cmd.CommandType = CommandType.StoredProcedure;

				//No se agregan parametros ya que la consulta sql no las necesita

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				//Rellenar el objeto DataTable con el resultado de la consulta sql
				da.Fill(dt);
				//Vincular una fuenta de datos con el objeto DataGridView
				return dt;
			}
		}

        private void BtnBienes_Click(object sender, EventArgs e)
        {
			BtnEliminar.Visible = true;
			BtnEditar.Visible = true;
			BtnNuevo.Visible = true;
			BtnNuevo.Enabled = true;
			BtnEliminar.Enabled = true;
			BtnEditar.Enabled = true;
			Dgv.DataSource = Func_TablaBienes();
		}

        private void Nuevo_Usuario_Click(object sender, EventArgs e)
        {
			Form FrmNuevoUsuario = new FrmNuevoUsuario();
			FrmNuevoUsuario.Show();

		}

        private void Nuevo_Propietario_Click(object sender, EventArgs e)
        {
			Form FrmNuevoPropietario = new FrmNuevoPropietario();
			FrmNuevoPropietario.Show();
		}

        private void Nuevo_Bien_Click(object sender, EventArgs e)
        {
			Form FrmNuevoBien = new FrmNuevoBien();
			FrmNuevoBien.Show();
		}

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
			
			if (ClaseVariablesPublicas.modulo == "Usuarios")
			{
				long id = Convert.ToInt64(Dgv.CurrentRow.Cells[0].Value);
				long cedula = Convert.ToInt64(Dgv.CurrentRow.Cells[2].Value);
				string nombre = Dgv.CurrentRow.Cells[3].Value.ToString();
				string apellido = Dgv.CurrentRow.Cells[4].Value.ToString();

				DialogResult resp = MessageBox.Show("Desea eliminar al usuario :" + nombre + " " + apellido +" Identificad@ Con Cedula:"+cedula,"Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (resp == DialogResult.Yes)
					{
                    try { 
					DataTable dt = new DataTable();
					SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					SqlDataAdapter cmd = new SqlDataAdapter("Pa_Eliminar_Usuario", conexion);
					cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
					cmd.SelectCommand.Parameters.Add("@ID_USUARIO", SqlDbType.BigInt).Value = id;
					cmd.Fill(dt);
					MessageBox.Show("USUARIO ELIMINADO CORRECTAMENTE");
                        
					//Refresco el Datagrid con una consulta de select para ver los cambios aplicados!
					SqlCommand comando = new SqlCommand("Pa_Tabla_Usuarios", conexion);
					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					comando.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter da = new SqlDataAdapter(comando);
					DataTable tabla = new DataTable();
					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(tabla);
						//Vincular una fuenta de datos con el objeto DataGridView
						Dgv.DataSource = tabla;
					}
					catch (Exception ex)
                {
					MessageBox.Show(ex.Message);	
                }
				}
			}
			else if (ClaseVariablesPublicas.modulo == "Propietarios")
            {
				long id = Convert.ToInt64(Dgv.CurrentRow.Cells[0].Value);
				long cedula = Convert.ToInt64(Dgv.CurrentRow.Cells[1].Value);
				string nombre = Dgv.CurrentRow.Cells[2].Value.ToString();
				string apellido = Dgv.CurrentRow.Cells[3].Value.ToString();
				DialogResult resp = MessageBox.Show("Desea eliminar este propietario: "+ nombre +" "+ apellido + " Identificad@ Con Cedula:" + cedula, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (resp == DialogResult.Yes)
				{
					
						DataTable dt = new DataTable();
						SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
						SqlDataAdapter cmd = new SqlDataAdapter("Pa_Eliminar_Propietario", conexion);
						cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
						cmd.SelectCommand.Parameters.Add("@ID_PROPIETARIO", SqlDbType.BigInt).Value = id;
						cmd.Fill(dt);
						MessageBox.Show("PROPIETARIO ELIMINADO CORRECTAMENTE");

						//Refresco el Datagrid con una consulta de select para ver los cambios aplicados!
						SqlCommand comando = new SqlCommand("Pa_Tabla_Propietarios", conexion);
						//Indicar que el tipo de comando a ejecutar es un procediento almacenado
						comando.CommandType = CommandType.StoredProcedure;
						SqlDataAdapter da = new SqlDataAdapter(comando);
						DataTable tabla = new DataTable();
						//Rellenar el objeto DataTable con el resultado de la consulta sql
						da.Fill(tabla);
						//Vincular una fuenta de datos con el objeto DataGridView
						Dgv.DataSource = tabla;
				}
			}
			else if (ClaseVariablesPublicas.modulo == "Bienes")
			{
				long id = Convert.ToInt64(Dgv.CurrentRow.Cells[0].Value);
				string bien = Dgv.CurrentRow.Cells[2].Value.ToString();
				long codigo = Convert.ToInt64(Dgv.CurrentRow.Cells[3].Value.ToString());
				DialogResult resp = MessageBox.Show("Desea eliminar este Bien :"+bien+" Identificado con el codigo:" +codigo ,"Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (resp == DialogResult.Yes)
				{

					DataTable dt = new DataTable();
					SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					SqlDataAdapter cmd = new SqlDataAdapter("Pa_Eliminar_Bien", conexion);
					cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
					cmd.SelectCommand.Parameters.Add("@IDBIEN", SqlDbType.BigInt).Value = id;
					cmd.Fill(dt);
					MessageBox.Show("BIEN ELIMINADO CORRECTAMENTE");

					//Refresco el Datagrid con una consulta de select para ver los cambios aplicados!
					SqlCommand comando = new SqlCommand("Pa_Tabla_Bienes", conexion);
					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					comando.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter da = new SqlDataAdapter(comando);
					DataTable tabla = new DataTable();
					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(tabla);
					//Vincular una fuenta de datos con el objeto DataGridView
					Dgv.DataSource = tabla;
				}
			}
			else if (ClaseVariablesPublicas.modulo == "ControlE/S")
            {
				long id = Convert.ToInt64(Dgv.CurrentRow.Cells[0].Value);
				DateTime FechaEntrada = Convert.ToDateTime(Dgv.CurrentRow.Cells[3].Value);
				DateTime FechaSalida = Convert.ToDateTime(Dgv.CurrentRow.Cells[4].Value);


				DialogResult resp = MessageBox.Show("Desea eliminar  Registro con fecha de entrada:" + FechaEntrada +" Y fecha de salida: " +FechaSalida ,"Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (resp == DialogResult.Yes)
				{

					DataTable dt = new DataTable();
					SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					SqlDataAdapter cmd = new SqlDataAdapter("Pa_Eliminar_Registro", conexion);
					cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
					cmd.SelectCommand.Parameters.Add("@ID_REGISTRO", SqlDbType.BigInt).Value = id;
					cmd.Fill(dt);
					MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE");

					//Refresco el Datagrid con una consulta de select para ver los cambios aplicados!
					SqlCommand comando = new SqlCommand("Pa_Tabla_Registros", conexion);
					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					comando.CommandType = CommandType.StoredProcedure;
					SqlDataAdapter da = new SqlDataAdapter(comando);
					DataTable tabla = new DataTable();
					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(tabla);
					//Vincular una fuenta de datos con el objeto DataGridView
					Dgv.DataSource = tabla;
				}
			}
			else
            {
				MessageBox.Show("SELECCIONE ALGUNA TABLA O SEÑALE ALGUN DATO A ELIMINAR");
            }
		}

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
			if (ClaseVariablesPublicas.modulo == BtnUsuario.Text)
			{
				SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
				{
					//Abrir conexión
					conexion.Open();
					//Crear una instancia de la clase SqlCommand
					SqlCommand cmd = new SqlCommand("Pa_Select_Cedula_Usuarios", conexion);

					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("CEDULA", TxtBuscador.Text);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();

					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(dt);
					//Vincular una fuenta de datos con el objeto DataGridView
					Dgv.DataSource = dt;
				}
			}
			else if (ClaseVariablesPublicas.modulo == BtnPropietarios.Text)
			{
				SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
				{
					//Abrir conexión
					conexion.Open();
					//Crear una instancia de la clase SqlCommand
					SqlCommand cmd = new SqlCommand("Pa_Select_Cedula_Propietarios", conexion);

					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("CEDULA", TxtBuscador.Text);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();

					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(dt);
					//Vincular una fuenta de datos con el objeto DataGridView
					Dgv.DataSource = dt;
				}
			}
			else if (ClaseVariablesPublicas.modulo == BtnBienes.Text)
			{
				SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					
					//Abrir conexión
					conexion.Open();
					//Crear una instancia de la clase SqlCommand
					SqlCommand cmd = new SqlCommand("Pa_Select_Codigo_Barras", conexion);

					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@CODIGO", TxtBuscador.Text);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();

					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(dt);
					//Vincular una fuenta de datos con el objeto DataGridView
					Dgv.DataSource = dt;
			}
			else if (ClaseVariablesPublicas.modulo == BtnBienes.Text)
            {

            }
			else
            {
				MessageBox.Show("Señale un Modulo para hacer su busqueda","ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
		}

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
			if (ClaseVariablesPublicas.modulo == "Bienes") {
				FrmEditarBien f = new FrmEditarBien();
				f.ShowDialog();
			}
			else if (ClaseVariablesPublicas.modulo == "Propietarios")
            {
				FrmEditarPropietario f = new FrmEditarPropietario();
				f.ShowDialog();
            }
			else if (ClaseVariablesPublicas.modulo == "Usuarios")
            {
				FrmEditarUsuario f	= new FrmEditarUsuario();
				f.ShowDialog();
            }
			else
			{
				MessageBox.Show("Seleccione un modulo correcto!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
			LblHora.Text = DateTime.Now.ToString("hh:mm:ss");
			LblFecha.Text = DateTime.Now.ToLongDateString();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
			FrmMenuVigilante f = new FrmMenuVigilante();
			f.ShowDialog();

		}

		private void LblHora_Click(object sender, EventArgs e)
		{

		}
	}
}
