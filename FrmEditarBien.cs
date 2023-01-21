using BarcodeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_simple
{
    public partial class FrmEditarBien : Form
    {
        long id = 0;
        public FrmEditarBien()
        {
            InitializeComponent();
        }

        private void FrmEditarBien_Load(object sender, EventArgs e)
        {
            TxtCodigoBien.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            {
                if (TxtCodigoBien.Text != "")
                {

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

                    TxtNombreBien.Focus();
                    TxtNombreBien.Enabled = true;
                    TxtCedula.Enabled = true;
                    pictureBox5.Enabled = true;
                    BtnGuardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Escriba Un Codgio");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (TxtBuscador.Text != "")
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
            else
            {
                MessageBox.Show("ESCRIBA UN CODIGO CORRECTO", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToUInt32(Dgv.CurrentRow.Cells[0].Value.ToString());
                TxtNombreBien.Text = Dgv.CurrentRow.Cells[2].Value.ToString();
                TxtCodigoBien.Text = Dgv.CurrentRow.Cells[3].Value.ToString();

                TxtCodigoBien.Focus();
                TxtCodigoBien.Enabled = true;
                BtnGenerar.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-UAASQ2C;Initial Catalog=ProyectoSena;User ID=Juan;Password=juan789;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Abrir conexión
            conexion.Open();
            //Crear una instancia de la clase SqlCommand
            SqlCommand cmd = new SqlCommand("Pa_Editar_Bienes", conexion);

            //ejecutar un procediento almacenado
            cmd.CommandType = CommandType.StoredProcedure;

            int id = Convert.ToInt32(Dgv.CurrentRow.Cells[0].Value);
            //agregan parametros
            cmd.Parameters.AddWithValue("@ID_BIENES", id);
            cmd.Parameters.AddWithValue("@BIENES", TxtNombreBien.Text);
            cmd.Parameters.AddWithValue("@CODIGO", TxtCodigoBien.Text);
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
            rpta = MessageBox.Show("¿Desea Guardar  El Bien Editado?", "EDITAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (rpta == DialogResult.OK)
            {
                this.Close();
            }
            conexion.Close();
        }
    }
}
