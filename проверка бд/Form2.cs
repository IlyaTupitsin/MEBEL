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

namespace проверка_бд
{
    public partial class Form2 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Пользователь\source\repos\проверка бд\проверка бд\Database1.mdf"";Integrated Security=True";
        string sql = "SELECT * FROM client";
        public Form2()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
              
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet10.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.database1DataSet10.Client);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // удаляем выделенные строки из dataGridView1
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_Createclient", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, "фио"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@phone_number", SqlDbType.Decimal, 18, "телефон"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@adress", SqlDbType.VarChar, 50, "адрес"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@client_fio", SqlDbType.NVarChar, 50, "фио");
                parameter.Direction = ParameterDirection.Output;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@order_number", SqlDbType.Int, 0, "номер"));


                adapter.Update(ds);
            }
        }
    }
}
