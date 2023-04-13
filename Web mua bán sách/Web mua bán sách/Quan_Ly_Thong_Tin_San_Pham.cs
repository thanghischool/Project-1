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

        

        

        private void btn_Add_Click(object sender, EventArgs e)
        {
                conn.Open();
                string query_insert = "insert into book (Book_Name, Author, Price, Image_Url, Created_At, Update_At) values (@Book_Name, @Author, @Price, @Image_Url, @Created_At, @Update_At)";
                MySqlCommand command = new MySqlCommand(query_insert, conn);
                command.Parameters.AddWithValue("@Book_Name", tbt_Book_Name.Text);
                command.Parameters.AddWithValue("@Author", tbt_Author.Text);
                command.Parameters.AddWithValue("@Price", tbt_Price.Text);
                command.Parameters.AddWithValue("@Image_Url", tbt_Image_Url.Text);
                command.Parameters.AddWithValue("@Created_At", tbt_Created_At.Text);
                command.Parameters.AddWithValue("@Update_At", tbt_Update_At.Text);
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

    }
}
            
            

