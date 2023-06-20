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
            conn.Open();
            int DNI = int.Parse(txtBoxDNI.Text);
            string NOMBRE = txtBoxNombre.Text;
            int DIA = int.Parse(txtBoxDia.Text);
            int MES = int.Parse(txtBoxMes.Text);
            int AÑO = int.Parse(txtBoxAño.Text);
            int PRECIO = int.Parse(txtBoxPrecio.Text);

            SqlCommand Query = new SqlCommand("INSERT INTO Cancha VALUES('"+DNI+"','"+NOMBRE+"','"+DIA+"','"+MES+"','"+AÑO+ "','"+PRECIO+"',)", conn);

            MessageBox.Show("Datos ingresados");
            
            conn.Close();
        }


        private void groupBoxRellenaLosDatos_Enter(object sender, EventArgs e)
        {

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
