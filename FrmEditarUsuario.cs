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
	public partial class FrmEditarUsuario : Form
	{
		long id = 0;
		public FrmEditarUsuario()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (TxtBuscador.Text != "") { 
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
				else
				{
					MessageBox.Show("ESCRIBA UNA CEDULA", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			
		}

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				id = Convert.ToUInt32(Dgv.CurrentRow.Cells[0].Value.ToString());
				TxtNombre.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
				TxtApellido.Text = Dgv.CurrentRow.Cells[3].Value.ToString();
				TxtCedula.Text = Dgv.CurrentRow.Cells[4].Value.ToString();
				TxtContraseña.Text = Dgv.CurrentRow.Cells[5].Value.ToString();
				TxtTelefono.Text = Dgv.CurrentRow.Cells[6].Value.ToString();
				TxtRol.Text = Dgv.CurrentRow.Cells[1].Value.ToString();	

		
			

			TxtRol.Enabled = true;
			TxtCedula.Enabled = true;
			TxtNombre.Enabled = true;
			TxtApellido.Enabled = true;
			TxtTelefono.Enabled = true;
			TxtContraseña.Enabled = true;
			BtnGuardar.Enabled = true;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			//Abrir conexión
			conexion.Open();
			//Crear una instancia de la clase SqlCommand
			SqlCommand cmd = new SqlCommand("Pa_Editar_Usuarios", conexion);

			//ejecutar un procediento almacenado
			cmd.CommandType = CommandType.StoredProcedure;

			//agregan parametros
			cmd.Parameters.AddWithValue("@ID_USUARIO", id);
			cmd.Parameters.AddWithValue("@CEDULA", TxtCedula.Text);
			cmd.Parameters.AddWithValue("@NOMBRE", TxtNombre.Text);
			cmd.Parameters.AddWithValue("@APELLIDO", TxtApellido.Text);
			cmd.Parameters.AddWithValue("@TELEFONO", TxtTelefono.Text);
			cmd.Parameters.AddWithValue("@ROL", TxtRol.Text);
			cmd.Parameters.AddWithValue("@CONTRASEÑA", TxtContraseña.Text);
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
			DialogResult rpta = new DialogResult();
			rpta = MessageBox.Show("¿Desea Guardar  El Usuario Editado?", "EDITAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (rpta == DialogResult.OK)
			{
				this.Close();
			}
			conexion.Close();
		}
			
		}
    }
