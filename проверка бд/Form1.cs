using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace проверка_бд
{
    public partial class Form1 : Form
    {
        Bdconect dataBase = new Bdconect();
      
        public Form1()
        {
            InitializeComponent();
            
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet11.Orderr". При необходимости она может быть перемещена или удалена.
            this.orderrTableAdapter.Fill(this.database1DataSet11.Orderr);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet9.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter2.Fill(this.database1DataSet9.Order);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet8.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter1.Fill(this.database1DataSet8.Order);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet7.Order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.database1DataSet7.Order);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet6.Supplier". При необходимости она может быть перемещена или удалена.
            this.supplierTableAdapter.Fill(this.database1DataSet6.Supplier);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet5.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.database1DataSet5.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet4.Material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter.Fill(this.database1DataSet4.Material);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter1.Fill(this.database1DataSet3.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet2.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.database1DataSet2.Client);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataBase.opemConnection();
            var client_fio = textBox12.Text;
            var phone_number = textBox13.Text;
            var adress = textBox14.Text;
            var email = textBox15.Text;
            var order_number = textBox16.Text;
            var addQuery = $"insert into client (client_fio,phone_number,adress,email,order_number) values ('{client_fio}', '{phone_number}', '{adress}', '{email}', '{order_number}') ";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Вы успешно добавили продукт!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataIntoDataGridView1();
        }
        private void LoadDataIntoDataGridView1()
        {
            dataBase.opemConnection();
            try
            {
               
                
                  
                    string selectQuery = "SELECT client_fio, phone_number, adress, email, order_number FROM client";
                    using (SqlCommand command = new SqlCommand(selectQuery, dataBase.getConnection()))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable; // Или bindingSource1, если используете его.
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataIntoDataGridView2()
        {
            dataBase.opemConnection();
            try
            {



                string selectQuery = "SELECT name, country, price  FROM material";
                using (SqlCommand command = new SqlCommand(selectQuery, dataBase.getConnection()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataIntoDataGridView3()
        {
            dataBase.opemConnection();
            try
            {



                string selectQuery = "SELECT article, name, material, price FROM product";
                using (SqlCommand command = new SqlCommand(selectQuery, dataBase.getConnection()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView3.DataSource = dataTable; 
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataIntoDataGridView4()
        {
            dataBase.opemConnection();
            try
            {



                string selectQuery = "SELECT supplier_name, product_name, material, product_quantity, purchase_cost FROM supplier";
                using (SqlCommand command = new SqlCommand(selectQuery, dataBase.getConnection()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView4.DataSource = dataTable; 
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDataIntoDataGridView5()
        {
            dataBase.opemConnection();
            try
            {



                string selectQuery = "SELECT orderr_number, order_date, delivery_date, product_article FROM Orderr";
                using (SqlCommand command = new SqlCommand(selectQuery, dataBase.getConnection()))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView5.DataSource = dataTable; 
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            var selectedValue = comboBox5.SelectedItem.ToString();


            var deleteQuery = "DELETE FROM orderr WHERE orderr_number = @orderr_number";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@orderr_number", selectedValue);
            command.ExecuteNonQuery();



            LoadDataIntoDataGridView5();
        }
        

        private void button12_Click(object sender, EventArgs e)
        {
            
            dataBase.opemConnection();
            var supplier_name = textBox17.Text;
            var product_name = textBox18.Text;
            var material = textBox19.Text;
            var product_quantity = textBox20.Text;
            var purchase_cost = textBox21.Text;
            var addQuery = $"insert into supplier (supplier_name,product_name,material,product_quantity,purchase_cost) values ('{supplier_name}', '{product_name}', '{material}', '{product_quantity}', '{purchase_cost}') ";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Вы успешно добавили продукт!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataIntoDataGridView4();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();
            var orderr_number = textBox4.Text;
            var order_date = Convert.ToDateTime(textBox5.Text);
            var delivery_date = Convert.ToDateTime(textBox6.Text);
            var product_article = textBox7.Text;
            var addQuery = $"insert into [dbo].[Orderr] (orderr_number,order_date,delivery_date,product_article) values ('{orderr_number}', '{order_date}','{delivery_date}', '{product_article}') ";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Вы успешно добавили продукт!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataIntoDataGridView5();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();
            var article = textBox8.Text;
            var name = textBox9.Text;
            var price = textBox10.Text;
            var material = textBox11.Text;
            var addQuery = $"insert into [dbo].[product] (article,name,price,material) values ('{article}', '{name}', '{price}', '{material}') ";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Вы успешно добавили продукт!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataIntoDataGridView3();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();
            var name = textBox1.Text;
            var country = textBox2.Text;
            var price = textBox3.Text;
            var addQuery = $"insert into material (name,country,price) values ('{name}', '{country}', '{price}') ";
            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Вы успешно добавили продукт!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataIntoDataGridView2();
        }

        private void dataGridView1_ClientDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }
        private void dataGridView2_MaterialDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            var selectedValue = comboBox5.Text.ToString();


            var deleteQuery = "DELETE FROM orderr WHERE orderr_number = @orderr_number";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@orderr_number", selectedValue);
            command.ExecuteNonQuery();



            dataBase.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox1.SelectedItem.ToString();


            var deleteQuery = "DELETE FROM client WHERE client_fio = @client_fio"; 
                var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                command.Parameters.AddWithValue("@client_fio", selectedValue);
                command.ExecuteNonQuery();
            

         
            dataBase.CloseConnection();
          
            LoadDataIntoDataGridView1();

        }
    


        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox4.SelectedItem.ToString();


            var deleteQuery = "DELETE FROM supplier WHERE supplier_name = @supplier_name";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@supplier_name", selectedValue);
            command.ExecuteNonQuery();


            LoadDataIntoDataGridView4();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox2.SelectedItem.ToString();


            var deleteQuery = "DELETE FROM material WHERE name = @name";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@name", selectedValue);
            command.ExecuteNonQuery();



            LoadDataIntoDataGridView2();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox3.SelectedItem.ToString();


            var deleteQuery = "DELETE FROM product WHERE article = @article";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@article", selectedValue);
            command.ExecuteNonQuery();



            LoadDataIntoDataGridView3();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedFio = comboBox1.Text.ToString();


            var deleteQuery = "DELETE FROM client WHERE client_fio = @client_fio";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@client_fio", selectedFio);
            command.ExecuteNonQuery();



            dataBase.CloseConnection();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox2.Text.ToString();


            var deleteQuery = "DELETE FROM material WHERE name = @name";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@name", selectedValue);
            command.ExecuteNonQuery();



            dataBase.CloseConnection();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox3.Text.ToString();


            var deleteQuery = "DELETE FROM product WHERE article = @article";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@article", selectedValue);
            command.ExecuteNonQuery();



            dataBase.CloseConnection();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBase.opemConnection();


            string selectedValue = comboBox4.Text.ToString();


            var deleteQuery = "DELETE FROM supplier WHERE supplier_name = @supplier_name";
            var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            command.Parameters.AddWithValue("@supplier_name", selectedValue);
            command.ExecuteNonQuery();



            dataBase.CloseConnection();

        }
    }
 }



