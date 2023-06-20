using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TuCanchitaFutbol
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAgregar agregar= new frmAgregar();
            agregar.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Mostrar un cuadro de diálogo para confirmar la eliminación
                DialogResult resultado = MessageBox.Show("¿Desea borrar esta fila?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Obtener el índice de la fila seleccionada
                    int indiceFila = dataGridView1.SelectedRows[0].Index;

                    // Obtener el valor de la columna "DNI" de la fila seleccionada
                    int dni = Convert.ToInt32(dataGridView1.Rows[indiceFila].Cells["DNI"].Value);

                    // Eliminar la fila del DataGridView
                    dataGridView1.Rows.RemoveAt(indiceFila);

                    // Eliminar la fila de la tabla "Cancha" en la base de datos
                    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security=True"))
                    {
                        conn.Open();

                        // Consulta SQL para eliminar la fila con el DNI correspondiente
                        string consulta = "DELETE FROM Cancha WHERE DNI = @dni";

                        using (SqlCommand cmd = new SqlCommand(consulta, conn))
                        {
                            // Agregar el parámetro @dni a la consulta
                            cmd.Parameters.AddWithValue("@dni", dni);

                            // Ejecutar la consulta
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establecer la conexión
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security=True"))
            {
                // Consulta SQL para seleccionar todos los datos de la tabla "Cancha"
                string consulta = "SELECT * FROM Cancha";

                // Crear un adaptador de datos y un DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);
                DataTable dataTable = new DataTable();

                // Llenar el DataTable con los datos del adaptador
                adapter.Fill(dataTable);

                // Asignar el DataTable como origen de datos del DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            // Establecer la conexión
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-4EFFS3O\\SQLEXPRESS;database=TuCanchita;Integrated Security=True"))
            {
                // Consulta SQL para seleccionar todos los datos de la tabla "Cancha"
                string consulta = "SELECT * FROM Cancha";

                // Crear un adaptador de datos y un DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);
                DataTable dataTable = new DataTable();

                // Llenar el DataTable con los datos del adaptador
                adapter.Fill(dataTable);

                // Asignar el DataTable como origen de datos del DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener los valores de la fila seleccionada
                int dniModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                string nombreModificar = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int diaModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
                int mesModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value);
                int horaModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
                int precioModificar = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[5].Value);

                // Abrir el formulario de edición y pasar los valores
                FormEditarValores formEditar = new FormEditarValores(dniModificar, nombreModificar, diaModificar, mesModificar, horaModificar, precioModificar);
                formEditar.ShowDialog();

                // Verificar si se guardaron los cambios
                if (formEditar.GuardarCambios)
                {
                    // Actualizar el DataGridView
                    dataGridView1.SelectedRows[0].Cells[0].Value = formEditar.DNI;
                    dataGridView1.SelectedRows[0].Cells[1].Value = formEditar.Nombre;
                    dataGridView1.SelectedRows[0].Cells[2].Value = formEditar.Dia;
                    dataGridView1.SelectedRows[0].Cells[3].Value = formEditar.Mes;
                    dataGridView1.SelectedRows[0].Cells[4].Value = formEditar.Hora;
                    dataGridView1.SelectedRows[0].Cells[5].Value = formEditar.Precio;
                }
            }
        }
    }
}