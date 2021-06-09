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
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
            SqlCommand sqlCmd = new SqlCommand(
                "SELECT * FROM Nhanvien", db.Connection);


            SqlDataAdapter adapt = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "nv");
            dgvnhanvien.DataSource = ds.Tables["nv"];

            db.Connection.Close();
        }
        private void Loadnv()
        {
            db.Connection.Open();
            string sql = "SELECT * FROM Nhanvien ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvnhanvien.DataSource = ds.Tables[0];
            db.Connection.Close();
        }
        private void Clearnv()
        {
            txtmanv.Text = string.Empty;
            txttennv.Text = string.Empty;
            cbbnv.Text = string.Empty;
            txtdiachinv.Text = string.Empty;
            txtsdtnv.Text = string.Empty;
            dtpnv.Text = string.Empty;
        }

        private void btnthemnv_Click(object sender, EventArgs e)
        {
            if(txtmanv.Text == "" || txttennv.Text == "" || txtdiachinv.Text == "" || txtsdtnv.Text == "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Nhanvien(manv, tennv, gioitinh, diachi, sdt, ngaysinh) VALUES(@manv, @tennv, @gioitinh, @diachi, @sdt, @ngaysinh)", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@manv", txtmanv.Text);
                cmd.Parameters.AddWithValue("@tennv", txttennv.Text);
                cmd.Parameters.AddWithValue("@gioitinh", cbbnv.Text);
                cmd.Parameters.AddWithValue("@diachi", txtdiachinv.Text);
                cmd.Parameters.AddWithValue("@sdt", txtsdtnv.Text);
                cmd.Parameters.AddWithValue("@ngaysinh", dtpnv.Text);
                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Thêm thông tin nhân viên thành công!!!");

                Loadnv();
                Clearnv();
            }
            
        }

        private void btnsuanv_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "" || txttennv.Text == "" || txtdiachinv.Text == "" || txtsdtnv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin muốn sửa");
            }
            else
            {
                db.Connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Nhanvien SET manv = N'" + txtmanv.Text + @"', tennv=N'" + txttennv.Text + @"', gioitinh=N'" + cbbnv.Text + @"', diachi=N'" + txtdiachinv.Text + @"', sdt = N'" + txtsdtnv.Text + @"',ngaysinh = N'" + dtpnv.Text + @"' WHERE manv = N'" + txtmanv.Text + @"'", db.Connection);


                //cmd.Parameters.AddWithValue("@masp", txtmasp.Text);
                //cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                //cmd.Parameters.AddWithValue("@dongia", txtdongia.Text);
                //cmd.Parameters.AddWithValue("@soluong", txtsoluong.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Sửa thông tin Nhân viên thành công!!!");
                Loadnv();
                Clearnv();
            }    
                
        }

        private void btnxoanv_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "" || txttennv.Text == "" || txtdiachinv.Text == "" || txtsdtnv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin muốn xóa");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Nhanvien WHERE manv = @manv", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@manv", txtmanv.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Xóa thông tin nhân viên thành công!!!");

                Loadnv();
                Clearnv();
            }
            
        }

        private void btntimkiemnv_Click(object sender, EventArgs e)
        {
            db.Connection.Open();

            string sql = "SELECT * FROM Nhanvien WHERE Nhanvien.tennv LIKE N'" + txttimkiemnv.Text + "%'";

            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvnhanvien.DataSource = ds.Tables[0];

            db.Connection.Close();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txtmanv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttennv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbbnv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdiachinv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsdtnv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpnv.Text = dgvnhanvien.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
