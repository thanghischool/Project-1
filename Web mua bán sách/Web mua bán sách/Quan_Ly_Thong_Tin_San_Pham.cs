using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Web_mua_bán_sách
{
    public partial class Quan_Ly_Thong_Tin_San_Pham : Form
    {
        MySqlConnection conn;
        MySqlCommandBuilder cmd;
        MySqlDataAdapter adapter;
        DataTable mytable;
        string strconn = "Server = localhost; Database = Quan_Ly_Thong_Tin; Port = 3306; User ID = root; Password=; Pooling = false; character Set=utf8";
        string query_select = "select * from book";
        public Quan_Ly_Thong_Tin_San_Pham()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Quan_Ly_Thong_Tin_San_Pham_Load(object sender, EventArgs e)
        {
            searchData("");
            try
            {
                conn = new MySqlConnection(strconn);
                conn.Open();
                adapter = new MySqlDataAdapter(query_select, strconn);
                cmd = new MySqlCommandBuilder(adapter);
                mytable = new DataTable();
                adapter.Fill(mytable);
                conn.Close();
                dataGridView1.DataSource = mytable;
            }
            catch 
            {
                MessageBox.Show("Lỗi kết Nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM book WHERE CONCAT(`Book_ID`, `Book_Name`, `Author`, `Price`, `Image_Url`, `Created_At`, `Update_At`) like '%" + valueToSearch + "%'";
            adapter = new MySqlDataAdapter(query, strconn);
            cmd = new MySqlCommandBuilder(adapter);
            mytable = new DataTable();
            adapter.Fill(mytable);

            dataGridView1.DataSource = mytable;
        }


            private void btn_Add_Click(object sender, EventArgs e)
        {
                conn.Open();
                string query_insert = "insert into book (`Book_ID`, `Book_Name`, `Author`, `Price`, `Image_Url`, `Created_At`, `Update_At`) values ('" + tbt_Book_ID.Text + "', '" + tbt_Book_Name.Text + "', '" + tbt_Author.Text + "', '" + tbt_Price.Text + "', '" + tbt_Image_Url.Text + "', '" + tbt_Created_At.Text + "', '" + tbt_Update_At.Text + "')";
                MySqlCommand command = new MySqlCommand(query_insert, conn);
                command.ExecuteNonQuery();
                conn.Close();
                Read_Data();
        }
            
            

                
        private void Read_Data()
        {
            conn.Open();
            adapter = new MySqlDataAdapter(query_select, strconn);
            cmd = new MySqlCommandBuilder(adapter);
            mytable = new DataTable();
            adapter.Fill(mytable);
            conn.Close();
            dataGridView1.DataSource = mytable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            tbt_Book_ID.Text = row.Cells["Book_ID"].Value.ToString();
            tbt_Book_Name.Text = row.Cells["Book_Name"].Value.ToString();
            tbt_Author.Text = row.Cells["Author"].Value.ToString();
            tbt_Price.Text = row.Cells["Price"].Value.ToString();
            tbt_Image_Url.Text = row.Cells["Image_Url"].Value.ToString();
            tbt_Created_At.Text = row.Cells["Created_At"].Value.ToString();
            tbt_Update_At.Text = row.Cells["Update_At"].Value.ToString();
            conn.Close();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            conn.Open();
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow newDataRow = dataGridView1.Rows[rowIndex];
            newDataRow.Cells["Book_ID"].Value = tbt_Book_ID.Text;
            newDataRow.Cells["Book_Name"].Value = tbt_Book_Name.Text;
            newDataRow.Cells["Author"].Value = tbt_Author.Text;
            newDataRow.Cells["Price"].Value = tbt_Price.Text;
            newDataRow.Cells["Image_Url"].Value = tbt_Image_Url.Text;
            newDataRow.Cells["Created_At"].Value = tbt_Created_At.Text;
            newDataRow.Cells["Update_At"].Value = tbt_Update_At.Text;
            conn.Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query_delete = "DELETE from book where Book_ID = '" + int.Parse(tbt_Book_ID.Text) + "'";
            MySqlCommand command = new MySqlCommand(query_delete, conn);
            command.ExecuteNonQuery();
            conn.Close();
            Read_Data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valueToSearch = textBoxValueToSearch.Text.ToString();
            searchData(valueToSearch);
        }
    }
}




            
            

