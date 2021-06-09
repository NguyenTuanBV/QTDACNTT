using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc_cnpm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sanpham m = new sanpham();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien m = new nhanvien();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            khachhang m = new khachhang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            donhang m = new donhang();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            this.Hide();
            m.ShowDialog();
            this.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongke tk = new thongke();
            this.Hide();
            tk.ShowDialog();
            this.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr;
            //dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}

        }
    }
}
