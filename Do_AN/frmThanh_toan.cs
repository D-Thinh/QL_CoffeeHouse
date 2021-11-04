using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Do_AN
{
    public partial class frmThanh_toan : Form
    {
        

        public frmThanh_toan()
        {
            InitializeComponent();

            load();
        }


        QLBHEntities1 db = new QLBHEntities1();



        public void load ()
        {
            txtSo_Hoa_Don.Text = frmGoi_Do_uong.MAHD;
            DateTime today = DateTime.Now;
            int ngay = today.Day;
            int thang = today.Month;
            int nam = today.Year;
            txtNgay.Text = ngay.ToString() + "-" + thang.ToString() + "-" + nam.ToString();
            string manv = Form1.taikhoan.MANV;

            NHANVIEN nv =  db.NHANVIENs.FirstOrDefault(t => t.MANV == manv);
            txtThu_Ngan.Text = nv.HOTEN;

            dgvHoa_Don.DataSource = db.CTHDs.Include(s => s.MASP).Where(s => s.SOHD == frmGoi_Do_uong.MAHD)
                       .Select(s => new
                       {
                           SOHD = s.SOHD,
                           TENSP = s.SANPHAM.TENSP,
                           SL = s.SL,
                           GIA =   s.SL * s.SANPHAM.GIA ?? 0
                       }).ToList()
                       .Select(d => new {
                           d.SOHD,
                           d.TENSP,
                           d.SL,
                           GIA = d.GIA.ToString("N0")
                       }).ToList();
            decimal tien = 0;
            HOADON HD = db.HOADONs.FirstOrDefault(k => k.SOHD == txtSo_Hoa_Don.Text.Trim() );
            decimal TIEN = (decimal)HD.TRIGIA;
            int money = (int)TIEN;
            txtThanh_tien.Text = money.ToString();
            txtTong_Tien.Text = money.ToString();
            txtGiam_gia.Text = "0";

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmThanh_toan_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmGoi_Do_uong orde = new frmGoi_Do_uong();
            orde.Show();*/
        }
    }
}
