using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_mua_bán_sách
{
    public partial class Dang_nhap : Form
    {
        public Dang_nhap()
        {
            InitializeComponent();
        }

        private void Dang_nhap_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbt_Tai_Khoan != null && tbt_Password != null)
            {
               MessageBox.Show("Bạn đã đăng nhập thành công", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
                

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, MouseEventArgs e)
        {
            tbt_Password.UseSystemPasswordChar = false;
        }

        private void pictureBox3_mouseup(object sender, MouseEventArgs e)
        {
            tbt_Password.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btndangnhap1_MouseEnter(object sender, EventArgs e)
        {
            btndangnhap1.ForeColor = Color.Black;
        }

        private void btndangnhap1_MouseLeave(object sender, EventArgs e)
        {
            btndangnhap1.ForeColor = Color.White;    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            return;
        }

        private void btnloithoat1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult bb = MessageBox.Show(" bạn có chắc chắn muốn thoát ?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (bb == DialogResult.Yes)
            {
                Close();
            }
            else if (bb == DialogResult.No)
                MessageBox.Show("bạn tiếp tục sử dụng ","confirm",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            { 
                Close();
            } 
        }
    }
}
