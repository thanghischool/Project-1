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
    public partial class Trang_chu : Form
    {
        public Trang_chu()
        {
            InitializeComponent();
        }

        private void Trang_chu_Load(object sender, EventArgs e)
        {

        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sach_Tieu_Thuyet d = new Sach_Tieu_Thuyet();
            this.Hide();
            d.ShowDialog();
            this.Show();    
        }

        private void sáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            } 
        }

        private void mns_Dang_Nhap_Click(object sender, EventArgs e)
        {
            Dang_nhap f = new Dang_nhap();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýThôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quan_Ly_Thong_Tin_San_Pham a = new Quan_Ly_Thong_Tin_San_Pham();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void mns_Dang_Xuat_Click(object sender, EventArgs e)
        {
            Dang_ki k = new Dang_ki();
            this.Hide();
            k.ShowDialog();
            this.Show();
        }
    }
}
