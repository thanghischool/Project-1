using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Web_mua_bán_sách
{
    public partial class Dang_ki : Form
    {
        public Dang_ki()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Enter user name";
                    return;
                }
                textBox1.ForeColor = Color.Black;
                pnlusername.Visible = false;
            }
            catch { }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btndangnhap1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Enter user name")
            {
                pnlusername.Visible = true;
                return;
            }
            if (textBox2.Text == "Enter password")
            {
                pnlpassword.Visible = true;
                return;
            }
            if (textBox3.Text == " Enter confrim password")
            {
                pnlconfirmpassword.Visible = true;
                return;
            }
          else
          if (textBox1.Text == "Enter user name" && textBox2.Text == "Enter password" && textBox3.Text == " Enter confrim password")
            {
                pnlusername.Visible = true;
                pnlpassword.Visible = true;
                pnlconfirmpassword.Visible = true;
              
                Dang_nhap d = new Dang_nhap();
                this.Hide();
                d.ShowDialog();
                this.Show();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text = "Enter password";
                    return;
                }
                textBox2.ForeColor = Color.Black;
                 pnlpassword.Visible= false;
            }
            catch { }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (textBox3.Text == "")
                {
                    textBox3.Text = "Enter comfirm password";
                    return;
                }
                textBox3.ForeColor = Color.Black;
                pnlconfirmpassword.Visible = false;
            }
            catch { }
        }

        private void btnloinho_Click(object sender, EventArgs e)
        {

            DialogResult bb = MessageBox.Show(" bạn có chắc chắn muốn thoát ?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (bb == DialogResult.Yes)
            {
                Close();
            }
            else if (bb == DialogResult.No)
                MessageBox.Show("bạn tiếp tục sử dụng ", "confirm", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
