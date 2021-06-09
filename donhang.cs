using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bc_cnpm
{
    public partial class donhang : Form
    {
        public donhang()
        {
            InitializeComponent();

            db.Connection.Open();

            SqlCommand sqlCmd = new SqlCommand(
                "SELECT * FROM Donhang", db.Connection);


            SqlDataAdapter adapt = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "DH");
            dgvdonhang.DataSource = ds.Tables["DH"];
            
            cbbmakh.DisplayMember = "tenkh";
            cbbmakh.ValueMember = "makh";

            cbbmasp.DisplayMember = "tensp";
            cbbmasp.ValueMember = "masp";
            db.Connection.Close();
            
        }
        private void Loaddh()
        {
            db.Connection.Open();
            string sql = "SELECT * FROM Donhang ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvdonhang.DataSource = ds.Tables[0];
            db.Connection.Close();
        }
        private void Cleardh()
        {
            txtmadh.Text = string.Empty;
            cbbmakh.Text = "";
            cbbmasp.Text = "";
            txtsoluongdh.Text = string.Empty;
            txtdongiadh.Text = string.Empty;
            txttongtiendh.Text = string.Empty;
            dtpngaydat.Text = string.Empty;
            txtnoinhandh.Text = string.Empty;
        }
        //private void btnsuadh_Click(object sender, EventArgs e)
        //{
        //    if(txtmadh.Text == "" || txtnoinhandh.Text == "" || txtsoluongdh.Text == "")
        //    {
        //        MessageBox.Show("Vui lòng chọn đơn hàng cần sửa");
        //    }
        //    else
        //    {
                
        //        //SqlCommand cmd = new SqlCommand("UPDATE Donhang SET madh = N'" + txtmadh.Text + @"', masp=N'" + txtmaspdh.Text + @"', 
        //        //makh=N'" + txtmakhdh.Text + @"',soluong=N'" + txtsoluongdh.Text + @"', dongia=N'" + txtdongiadh.Text + @"',
        //        //tongtien=N'" + txttongtiendh.Text + @"',ngaydat=N'" + dtpngaydat.Text + @"',
        //        //noinhan=N'" + txtnoinhandh.Text + @"' WHERE madh = N'" + txtmadh.Text + @"'", db.Connection);
        //        SqlCommand cmd = new SqlCommand("UPDATE Donhang SET soluong = @soluong," +
        //            " dongia = @dongia, tongtien = @tongtien, ngaydat = @ngaydat, noinhan = @noinhan WHERE madh=@madh", db.Connection);
        //        db.Connection.Open();
        //        cmd.Parameters.AddWithValue("@madh", txtmadh.Text);
        //        cmd.Parameters.AddWithValue("@masp", cbbmasp.SelectedValue);
        //        cmd.Parameters.AddWithValue("@makh", cbbmakh.SelectedValue);
        //        cmd.Parameters.AddWithValue("@soluong", txtsoluongdh.Text);
        //        cmd.Parameters.AddWithValue("@dongia", txtdongiadh.Text);
        //        cmd.Parameters.AddWithValue("@tongtien", txttongtiendh.Text);
        //        cmd.Parameters.AddWithValue("@ngaydat", dtpngaydat.Value);
        //        cmd.Parameters.AddWithValue("@noinhan", txtnoinhandh.Text);
        //        cmd.ExecuteNonQuery();

        //        db.Connection.Close();

        //        MessageBox.Show("Sửa thông tin đơn hàng thành công!!!");
        //        Loaddh();
        //        Cleardh();
        //    }
            
        //}

        private void btnthemdh_Click(object sender, EventArgs e)
        {
            if (txtmadh.Text == "" || txtnoinhandh.Text == "" || txtsoluongdh.Text == "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Donhang(madh, masp, makh, soluong, dongia, tongtien, ngaydat, noinhan) " +
                "VALUES(@madh, @masp, @makh, @soluong, @dongia, @tongtien, @ngaydat, @noinhan)", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@madh", txtmadh.Text);
                cmd.Parameters.AddWithValue("@masp", cbbmasp.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@makh", cbbmakh.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@soluong", txtsoluongdh.Text);
                cmd.Parameters.AddWithValue("@dongia", txtdongiadh.Text);
                cmd.Parameters.AddWithValue("@tongtien", txttongtiendh.Text);
                cmd.Parameters.AddWithValue("@ngaydat", dtpngaydat.Text);
                cmd.Parameters.AddWithValue("@noinhan", txtnoinhandh.Text);
                cmd.ExecuteNonQuery();

                db.Connection.Close();
                //db.Connection.Open();
                //string madh = txtmadh.Text;
                //string masp = cbbmasp.SelectedValue.ToString();
                //string makh = cbbmakh.SelectedValue.ToString();
                //string soluong1 = txtsoluongdh.Text;
                //string dongia1 = txtdongiadh.Text;
                //string tongtien1 = txttongtiendh.Text;
                //string ngaydat = dtpngaydat.Value.ToString();
                //string noinhan = txtnoinhandh.Text;

                //SqlCommand query = new SqlCommand("Insert into Donhang Values('" + madh + "','" + masp + "','" + makh + "','" + soluong1 + "','" + dongia1 + "','" + tongtien1 + "','" + ngaydat + "',N'" + noinhan + "')", db.Connection);
                //query.ExecuteNonQuery();
                MessageBox.Show("Thêm thông tin đơn hàng thành công!!!");
                //db.Connection.Close();
                Loaddh();
                Cleardh();
            }
                
        }
        public void GetIdSp()
        {
            SqlCommand cmd = new SqlCommand("SELECT masp FROM Sanpham", db.Connection);
            db.Connection.Open();
            var dr2 = cmd.ExecuteReader();
            var dt2 = new DataTable();
            dt2.Load(dr2);
            dr2.Dispose();
            cbbmasp.DisplayMember = "masp";
            cbbmasp.DataSource = dt2;
            db.Connection.Close();
        }
        public void GetIdKh()
        {
            SqlCommand cmd = new SqlCommand("SELECT makh FROM Khachhang", db.Connection);
            db.Connection.Open();
            var dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbbmakh.DisplayMember = "makh";
            cbbmakh.DataSource = dt;
            db.Connection.Close();
        }

        private void cbbmasp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sanpham WHERE masp = '" + cbbmasp.Text + "'", db.Connection);
                db.Connection.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string dongia = (string)dr["dongia"].ToString();
                    txtdongiadh.Text = dongia;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                db.Connection.Close();
            }
        }

        private void donhang_Load(object sender, EventArgs e)
        {

            GetIdSp();
            GetIdKh();

        }

        private void dgvdonhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txtmadh.Text = dgvdonhang.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbmasp.SelectedValue = dgvdonhang.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbbmakh.SelectedValue = dgvdonhang.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsoluongdh.Text = dgvdonhang.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdongiadh.Text = dgvdonhang.Rows[e.RowIndex].Cells[4].Value.ToString();
            txttongtiendh.Text = dgvdonhang.Rows[e.RowIndex].Cells[5].Value.ToString();
            dtpngaydat.Text = dgvdonhang.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtnoinhandh.Text = dgvdonhang.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
        //int dongia = 0;
        //int soluong = 0;
        //dongia = Convert.ToInt32(txtsoluongdh.Text);
        //soluong = Convert.ToInt32(txtdongiadh.Text);
        //txttongtiendh.Text = (dongia * soluong).ToString();
        private void btnxoadh_Click(object sender, EventArgs e)
        {
            if (txtmadh.Text == "" || txtnoinhandh.Text == "" || txtsoluongdh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin muốn xóa");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Donhang WHERE madh = @madh", db.Connection);
                db.Connection.Open();

                cmd.Parameters.AddWithValue("@madh", txtmadh.Text);

                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Xóa thông tin đơn hàng thành công!!!");

                Loaddh();
                Cleardh();
            }
            
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgvdonhang.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 60;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvdonhang.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                //cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgvdonhang.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "testDGV.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("in đơn hàng thành công!");
            this.Close();
        }

        private void btntimkiemdh_Click(object sender, EventArgs e)
        {
            db.Connection.Open();

            string sql = "SELECT * FROM Donhang WHERE Donhang.madh LIKE N'" + txttimkiemdh.Text + "%'";

            SqlDataAdapter adapt = new SqlDataAdapter(sql, db.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dgvdonhang.DataSource = ds.Tables[0];

            db.Connection.Close();
        }

        private void btnsuadh_Click_1(object sender, EventArgs e)
        {
            if (txtmadh.Text == "" || txtnoinhandh.Text == "" || txtsoluongdh.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin đơn hàng cần sửa");
            }
            else
            {
                db.Connection.Open();
                //SqlCommand cmd = new SqlCommand("UPDATE Donhang SET madh = N'" + txtmadh.Text + @"', masp=N'" + txtmaspdh.Text + @"', makh=N'" + txtmakhdh.Text + @"',soluong=N'" + txtsoluongdh.Text + @"', dongia=N'" + txtdongiadh.Text + @"',tongtien=N'" + txttongtiendh.Text + @"',ngaydat=N'" + dtpngaydat.Text + @"',noinhan=N'" + txtnoinhandh.Text + @"' WHERE madh = N'" + txtmadh.Text + @"'", db.Connection);
                SqlCommand cmd = new SqlCommand("UPDATE Donhang SET masp = @masp, makh = @makh, soluong = @soluong, " +
                    "dongia = @dongia, tongtien = @tongtien, ngaydat = @ngaydat, noinhan = @noinhan WHERE madh = @madh ", db.Connection);

                cmd.Parameters.AddWithValue("@madh", txtmadh.Text);
                cmd.Parameters.AddWithValue("@masp", cbbmasp.SelectedValue);
                cmd.Parameters.AddWithValue("@makh", cbbmakh.SelectedValue);
                cmd.Parameters.AddWithValue("@soluong", txtsoluongdh.Text);
                cmd.Parameters.AddWithValue("@dongia", txtdongiadh.Text);
                cmd.Parameters.AddWithValue("@tongtien", txttongtiendh.Text);
                cmd.Parameters.AddWithValue("@ngaydat", dtpngaydat.Value);
                cmd.Parameters.AddWithValue("@noinhan", txtnoinhandh.Text);


                cmd.ExecuteNonQuery();

                db.Connection.Close();

                MessageBox.Show("Sửa thông tin đơn hàng thành công!!!");
                Loaddh();
                Cleardh();
            }
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsoluongdh_TextChanged(object sender, EventArgs e)
        {
            //double tt, dg, sl;
            //dg = double.Parse(txtdongiadh.Text);
            //sl = double.Parse(txtsoluongdh.Text);
            //tt = 1.0 * (sl * dg);
            //txttongtiendh.Text = tt.ToString();
        }
    }
    
}
