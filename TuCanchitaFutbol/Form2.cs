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
using System.Net;
using System.Security.Cryptography;


namespace TuCanchitaFutbol
{
    public partial class frmAgregar : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security= True");
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(txtBoxDNI.Text);
            string NOMBRE = txtBoxNombre.Text;
            int DIA = Convert.ToInt32(txtBoxDia.Text);
            int MES = Convert.ToInt32(txtBoxMes.Text);
            int HORA = Convert.ToInt32(txtBoxHora.Text);
            int PRECIO = Convert.ToInt32(txtBoxPrecio.Text);

            string consulta = "INSERT INTO Cancha (DNI, NOMBRE, DIA, MES, HORA, PRECIO) VALUES (@dni, @nombre, @dia, @mes, @hora, @precio)";
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@dni", DNI);
                    cmd.Parameters.AddWithValue("@nombre", NOMBRE);
                    cmd.Parameters.AddWithValue("@dia", DIA);
                    cmd.Parameters.AddWithValue("@mes", MES);
                    cmd.Parameters.AddWithValue("@hora", HORA);
                    cmd.Parameters.AddWithValue("@precio", PRECIO);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LimpiarTextBoxes();
            MessageBox.Show("Datos ingresados");
        }


        private void groupBoxRellenaLosDatos_Enter(object sender, EventArgs e)
        {

        }

        private void LimpiarTextBoxes()
        {
            txtBoxDNI.Clear();
            txtBoxNombre.Clear();
            txtBoxDia.Clear();
            txtBoxMes.Clear();
            txtBoxHora.Clear();
            txtBoxPrecio.Clear();
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
