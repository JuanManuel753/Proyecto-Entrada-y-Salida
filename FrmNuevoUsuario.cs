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
using System.IO;
using System.Data;


namespace login_simple
{
	public partial class FrmNuevoUsuario : Form
	{
		public FrmNuevoUsuario()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
			byte[] bytes = Convertir_Imagen_Bytes(PbxFoto.Image);
			string nombre = TxtNombre.Text;
			string apellido = TxtApellido.Text;
			try
			{
				SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
				//Abrir conexión
				conexion.Open();
				//Crear una instancia de la clase SqlCommand
				SqlCommand cmd = new SqlCommand("Pa_insert_Nuevo_Usuario", conexion);

				//ejecutar un procediento almacenado
				cmd.CommandType = CommandType.StoredProcedure;

				//agregan parametros
				cmd.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
				cmd.Parameters.AddWithValue("@Apellido", TxtApellido.Text);
				cmd.Parameters.AddWithValue("@Cedula", TxtCedula.Text);
				cmd.Parameters.AddWithValue("@Rol", TxtRol.Text);
				cmd.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
				cmd.Parameters.AddWithValue("@Contraseña", TxtContraseña.Text);
				cmd.Parameters.AddWithValue("@Foto", bytes);
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
				rpta = MessageBox.Show("¿Desea Guardar El Propietario?: " + nombre + " " + apellido, "GUARDAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
				if (rpta == DialogResult.OK)
				{
					this.Close();
				}
				conexion.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);

			}
		}
		public static byte[] Convertir_Imagen_Bytes(Image img)
		{
			string sTemp = Path.GetTempFileName();
			FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
			fs.Position = 0;

			int imgLength = Convert.ToInt32(fs.Length);
			byte[] bytes = new byte[imgLength];
			fs.Read(bytes, 0, imgLength);
			fs.Close();
			return bytes;
		}

		// Comvierte una Byte en Imagen
		// Parametros: Byte
		// Retorna: Imagen
		public static Image Convertir_Bytes_Imagen(byte[] bytes)
		{
			if (bytes == null) return null;

			MemoryStream ms = new MemoryStream(bytes);
			Bitmap bm = null;
			try
			{
				bm = new Bitmap(ms);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			return bm;
			// Funcion insertar datos
			// Retorna: Verdadero o falso (True o False)
			//Parametros: id, nombre imagen(byte)
		}

        private void BtnAdjuntar_Click(object sender, EventArgs e)
        {
			openFileDialog1.Filter = "Image Files (JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF";
			openFileDialog1.Title = "Buscar imagen";
			openFileDialog1.ShowDialog(this);
			string ruta = openFileDialog1.FileName;
			PbxFoto.Image = Image.FromFile(ruta);

			// Comvierte una imagen a bytes
			// Parametros: Imagen
			// Retorna: Byte
		}
	}
}

