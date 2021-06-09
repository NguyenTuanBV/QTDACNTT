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
    public partial class sanpham : Form
    {
        public sanpham()
        {
            InitializeComponent();
            db.Connection.Open();

            SqlCommand sqlCmd = new SqlCommand(
                "SELECT * FROM Sanpham", db.Connection);


            SqlDataAdapter adapt = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "SP");
            dgvsanpham.DataSource = ds.Tables["SP"];

            db.Connection.Close();
        }
        private void Loadsp()
        {
            db.Connection.Open();
            string sql = "SELECT * FROM Sanpham ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvsanpham.DataSource = ds.Tables[0];
            db.Connection.Close();
        }
        private void Clearsp()
        {
            txtmasp.Text = string.Empty;
            txttensp.Text = string.Empty;
            txtdongia.Text = string.Empty;
            txtsoluong.Text = string.Empty;
        }
        private void btnthemsp_Click(object sender, EventArgs e)
        {
            if(txtmasp.Text == "" || txttensp.Text == "" || txtdongia.Text == "" || txtsoluong.Text == "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Sanpham(masp, tensp, dongia, soluong) VALUES(@masp, @tensp, @dongia, @soluong)", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@masp", txtmasp.Text);
                cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                cmd.Parameters.AddWithValue("@dongia", txtdongia.Text);
                cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Thêm thông tin sản phẩm thành công!!!");

                Loadsp();
                Clearsp();
            }
            
        }

        private void btnsuasp_Click(object sender, EventArgs e)
        {
            if (txtmasp.Text == "" || txttensp.Text == "" || txtdongia.Text == "" || txtsoluong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm muốn sửa");
            }
            else
            {
                db.Connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Sanpham SET masp = N'" + txtmasp.Text + @"', tensp=N'" + txttensp.Text + @"', dongia=N'" + txtdongia.Text + @"', soluong=N'" + txtsoluong.Text + @"' WHERE masp = N'" + txtmasp.Text + @"'", db.Connection);


                //cmd.Parameters.AddWithValue("@masp", txtmasp.Text);
                //cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                //cmd.Parameters.AddWithValue("@dongia", txtdongia.Text);
                //cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Sửa thông tin sản phẩm thành công!!!");
                Loadsp();
                Clearsp();
            }
            

        }

        private void btnxoasp_Click(object sender, EventArgs e)
        {
            if (txtmasp.Text == "" || txttensp.Text == "" || txtdongia.Text == "" || txtsoluong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin sản phẩm muốn xóa");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Sanpham WHERE masp = @masp", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@masp", txtmasp.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Xóa thông tin sản phẩm thành công!!!");

                Loadsp();
                Clearsp();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db.Connection.Open();

            string sql = "SELECT * FROM Sanpham WHERE Sanpham.tensp LIKE N'" + txttimkiemsp.Text + "%'";

            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvsanpham.DataSource = ds.Tables[0];

            db.Connection.Close();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txtmasp.Text = dgvsanpham.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttensp.Text = dgvsanpham.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdongia.Text = dgvsanpham.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsoluong.Text = dgvsanpham.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
