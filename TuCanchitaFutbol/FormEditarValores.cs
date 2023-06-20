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

namespace TuCanchitaFutbol
{
    public partial class FormEditarValores : Form
    {
        public FormEditarValores()
        {
            InitializeComponent();
        }

        private void FormEditarValores_Load(object sender, EventArgs e)
        {

        }
        // Propiedades públicas para los valores a editar
        public int DNI { get; private set; }
        public string Nombre { get; private set; }
        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Hora { get; private set; }
        public int Precio { get; private set; }
        public bool GuardarCambios { get; private set; }

        private SqlConnection conn;

        public FormEditarValores(int dni, string nombre, int dia, int mes, int hora, int precio)
        {
            InitializeComponent();

            // Asignar los valores recibidos a las propiedades correspondientes
            DNI = dni;
            Nombre = nombre;
            Dia = dia;
            Mes = mes;
            Hora = hora;
            Precio = precio;

            // Mostrar los valores en los TextBox correspondientes
            EditValtxtBoxDNI.Text = dni.ToString();
            EditValtxtBoxNombre.Text = nombre;
            EditValtxtBoxDia.Text = dia.ToString();
            EditValtxtBoxMes.Text = mes.ToString();
            EditValtxtBoxHora.Text = hora.ToString();
            EditValtxtBoxPrecio.Text = precio.ToString();

            // Establecer la conexión a la base de datos
            conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security=True");
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Obtener los nuevos valores de los TextBox
            DNI = Convert.ToInt32(EditValtxtBoxDNI.Text);
            Nombre = EditValtxtBoxNombre.Text;
            Dia = Convert.ToInt32(EditValtxtBoxDia.Text);
            Mes = Convert.ToInt32(EditValtxtBoxMes.Text);
            Hora = Convert.ToInt32(EditValtxtBoxHora.Text);
            Precio = Convert.ToInt32(EditValtxtBoxPrecio.Text);

            // Actualizar los valores en la base de datos
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cancha SET NOMBRE = @nombre, DIA = @dia, MES = @mes, HORA = @hora, PRECIO = @precio WHERE DNI = @dni", conn);
                cmd.Parameters.AddWithValue("@dni", DNI);
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@dia", Dia);
                cmd.Parameters.AddWithValue("@mes", Mes);
                cmd.Parameters.AddWithValue("@hora", Hora);
                cmd.Parameters.AddWithValue("@precio", Precio);
                cmd.ExecuteNonQuery();

                // Indicar que se guardaron los cambios
                GuardarCambios = true;
            }
            catch (Exception ex)
            {
                // Manejar el error de actualización de la base de datos
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GuardarCambios = false;
            }
            finally
            {
                conn.Close();
            }

            this.Close();
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            // Indicar que no se guardaron los cambios
            GuardarCambios = false;

            // Cerrar el formulario
            this.Close();
        }
    }
}
