using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Web_mua_bán_sách
{
    public partial class Quan_Ly_Thong_Tin_San_Pham : Form
    {
        MySqlConnection conn;
        MySqlCommandBuilder cmd;
        MySqlDataAdapter adapter;
        DataTable mytable;
        string strconn = "Server = localhost; Database = Quan_Ly_Thong_Tin; UId = root; Pwd = 123456; Pooling-false;Character Set=utf8";
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
                conn = new MySqlConnection("");
            }
            catch 
            {
                MessageBox.Show("Lỗi kết Nối", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

