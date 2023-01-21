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
//libreria codigo barras
using BarcodeLib;
//.net espacios nombres obligatorios
using System.Drawing;
using System.Drawing.Imaging;
using Color = System.Drawing.Color;

namespace login_simple
{
	public partial class FrmNuevoBien : Form
	{
		int id = 0;	
		public FrmNuevoBien()
		{
			InitializeComponent();
		}

		private void BtnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
			SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			//Abrir conexión
			conexion.Open();
			//Crear una instancia de la clase SqlCommand
			SqlCommand cmd = new SqlCommand("Pa_Insert_Nuevo_Bien", conexion);

			//ejecutar un procediento almacenado
			cmd.CommandType = CommandType.StoredProcedure;

			//agregan parametros
			cmd.Parameters.AddWithValue("@Bien", TxtNombreBien.Text);
			cmd.Parameters.AddWithValue("@ID_PROPIETARIO", id);
			cmd.Parameters.AddWithValue("@Codigo", TxtCodigoBien.Text);
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
			rpta = MessageBox.Show("¿Desea Guardar  El Bien?", "GUARDAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (rpta == DialogResult.OK)
			{
				this.Close();
			}
			conexion.Close();
	}

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
			try
			{
				if (TxtCedula.Text != "")
				{
					SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					//Abrir conexión
					conexion.Open();
					//Crear una instancia de la clase SqlCommand
					SqlCommand cmd = new SqlCommand("Pa_Select_Cedula_Propietarios", conexion);

					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@CEDULA", TxtCedula.Text);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();

					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(dt);
					if (dt.Rows.Count > 0)
					{
						id = Convert.ToInt32(dt.Rows[0][0]);
						string nombre = dt.Rows[0][1].ToString();
						string apellido = dt.Rows[0][2].ToString();
						TxtNombrePropietario.Text = nombre+" "+apellido;
					}
					else
					{
						MessageBox.Show("Coloque una cedula ya registrada");
					}
				}
			} 
			catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }

		}

        private void FrmNuevoBien_Load(object sender, EventArgs e)
        {
			TxtCodigoBien.Focus();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
			if (TxtCodigoBien.Text != "" ) { 
			BtnGuardar.Enabled = true;
			TxtNombreBien.Enabled = true;
			TxtCedula.Enabled= true;
			TxtCedula.Focus();
			
			//crea una instancia de la API
			Barcode barcodeAPI = new Barcode();

			// Definir la configuracion basica de la imagen
			int imgWidth = 373;
			int imgHeight = 175;
			Color foreColor = Color.Black;
			Color BackColor = Color.White;
			string data = TxtCodigoBien.Text;

			//Generar el codigo de barras con tu configuracion
			Image BarcodeImage = barcodeAPI.Encode(TYPE.CODE128, data, foreColor, BackColor, imgWidth, imgHeight);

			//Almacenar la imagen en la ruta conn el formato deseado
			string ruta = Application.StartupPath + "\\" + TxtCodigoBien.Text + ".png";
			BarcodeImage.Save(ruta, ImageFormat.Png);
			//muestro la imagen
			PBCodigoBien.Image = BarcodeImage;
			}
			else
            {
				MessageBox.Show("Escriba Un Codgio");
            }
		}

        private void TxtCodigoBien_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
			try
			{
				if (TxtCedula.Text != "")
				{
					SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
					//Abrir conexión
					conexion.Open();
					//Crear una instancia de la clase SqlCommand
					SqlCommand cmd = new SqlCommand("Pa_Select_Cedula_Propietarios", conexion);

					//Indicar que el tipo de comando a ejecutar es un procediento almacenado
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@CEDULA", TxtCedula.Text);
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();

					//Rellenar el objeto DataTable con el resultado de la consulta sql
					da.Fill(dt);
					if (dt.Rows.Count > 0)
					{
						id = Convert.ToInt32(dt.Rows[0][0]);
						string nombre = dt.Rows[0][1].ToString();
						string apellido = dt.Rows[0][2].ToString();
						TxtNombrePropietario.Text = nombre + " " + apellido;
					}
					else
					{
						MessageBox.Show("Coloque una cedula ya registrada");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
    }
}

