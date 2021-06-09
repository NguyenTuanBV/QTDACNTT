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

namespace bc_cnpm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (txttaikhoan.Text == "" || txtmatkhau.Text== "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                SqlCommand sqlCmd = new SqlCommand(
                "SELECT * FROM Login WHERE taikhoan=@taiKhoan AND matkhau=@matKhau", db.Connection);
                sqlCmd.Parameters.AddWithValue("@taiKhoan", txttaikhoan.Text);
                sqlCmd.Parameters.AddWithValue("@matKhau", txtmatkhau.Text);

                db.Connection.Open();

                SqlDataReader dr = sqlCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Tên người dùng hoặc Mật khẩu không đúng!");
                }

                db.Connection.Close();

                if (DialogResult == DialogResult.OK)
                {
                    Main m = new Main();
                    this.Hide();
                    m.ShowDialog();
                    this.Show();
                }
            }
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr;
            //dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
            Application.Exit();
        }
    }
}
