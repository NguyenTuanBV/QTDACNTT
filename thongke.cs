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
    public partial class thongke : Form
    {
        public thongke()
        {
            InitializeComponent();
            db.Connection.Open();

            SqlCommand sqlCmd = new SqlCommand(
                "select masp, COUNT(*) as solanmua, SUM(tongtien) as tongtien from Donhang where year(Donhang.ngaydat) = 2020 group by masp having COUNT(*) >= all(select COUNT(*) from Donhang group by masp)", db.Connection);
            SqlDataAdapter adapt = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "TK");
            dgvmuanhieu.DataSource = ds.Tables["TK"];

            //SqlCommand cmd = new SqlCommand(
            //    "select SUM(Donhang.tongtien) as tongtienbanduoc from Donhang where year(Donhang.ngaydat) = 2020", db.Connection);
            //SqlDataAdapter adt = new SqlDataAdapter(cmd);
            //DataSet ds1 = new DataSet();
            //adt.Fill(ds1, "TT");
            //dgvtienbanduoc.DataSource = ds1.Tables["TT"];

            db.Connection.Close();
        }

        private void btninbanchay_Click(object sender, EventArgs e)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgvmuanhieu.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 60;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dgvmuanhieu.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                //cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgvmuanhieu.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = "C:\\Thongke\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "BaoCaoThongKe.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("in thông tin thống kê thành công!");
            this.Close();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
