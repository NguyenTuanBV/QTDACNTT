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
    public partial class khachhang : Form
    {
        public khachhang()
        {
            InitializeComponent();
            db.Connection.Open();

            SqlCommand sqlCmd = new SqlCommand(
                "SELECT * FROM Khachhang", db.Connection);
            SqlDataAdapter adapt = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "KH");
            dgvkhachhang.DataSource = ds.Tables["KH"];

            db.Connection.Close();
        }
        private void Loadkh()
        {
            db.Connection.Open();
            string sql = "SELECT * FROM Khachhang";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvkhachhang.DataSource = ds.Tables[0];
            db.Connection.Close();
        }
        private void Clearkh()
        {
            txtmakh.Text = string.Empty;
            txttenkh.Text = string.Empty;
            txtdiachikh.Text = string.Empty;
            txtsdtkh.Text = string.Empty;
        }
        private void btnthemkh_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachikh.Text == "" || txtsdtkh.Text == "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Khachhang(makh, tenkh, diachi, sdt) VALUES(@makh, @tenkh, @diachi, @sdt)", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@makh", txtmakh.Text);
                cmd.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachikh.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtkh.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thông tin khách hàng thành công!!!");
                db.Connection.Close();
                //db.Connection.Open();
                //string makh = txtmakh.Text;
                //string tenkh = txttenkh.Text;
                //string diachikh = txtdiachikh.Text;
                //string sdtkh = txtsdtkh.Text;
                //SqlCommand query = new SqlCommand( "Insert into Khachhang Values('" + makh + "','" + tenkh + "','" + diachikh + "','" + sdtkh + "')", db.Connection);
                //query.ExecuteNonQuery();
                //db.Connection.Close();

                Loadkh();
                Clearkh();
            }
            
        }

        private void btnsuakh_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachikh.Text == "" || txtsdtkh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin muốn sửa");
            }
            else
            {
                db.Connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Khachhang SET makh = N'" + txtmakh.Text + @"', tenkh=N'" + txttenkh.Text + @"', diachi=N'" + txtdiachikh.Text + @"', sdt=N'" + txtsdtkh.Text + @"' WHERE makh = N'" + txtmakh.Text + @"'", db.Connection);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thông tin khách hàng thành công!!!");
                db.Connection.Close();


                Loadkh();
                Clearkh();
            }
            
        }

        private void btnxoakh_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachikh.Text == "" || txtsdtkh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin muốn xóa");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Khachhang WHERE makh = @makh", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@makh", txtmakh.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thông tin khách hàng thành công!!!");
                db.Connection.Close();



                Loadkh();
                Clearkh();
            }
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntimkiemkh_Click(object sender, EventArgs e)
        {
            db.Connection.Open();

            string sql = "SELECT * FROM Khachhang WHERE Khachhang.tenkh LIKE N'" + txttimkiemkh.Text + "%'";

            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvkhachhang.DataSource = ds.Tables[0];

            db.Connection.Close();
        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txtmakh.Text = dgvkhachhang.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttenkh.Text = dgvkhachhang.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdiachikh.Text = dgvkhachhang.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsdtkh.Text = dgvkhachhang.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
