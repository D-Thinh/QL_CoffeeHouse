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
using Microsoft.Reporting.WinForms;

namespace Do_AN
{
    public partial class frmreport_thongke : Form
    {
        public frmreport_thongke()
        {
            InitializeComponent();
            load();
        }
        QLBHEntities1 db = new QLBHEntities1();
        DataTable data = new DataTable();
        
        public void load()
        {
            
            
        }

        private void frmreport_thongke_Load(object sender, EventArgs e)
        {
            List<DoanhThu_rp> ls = new List<DoanhThu_rp>();
            List<HOADON> HD = db.HOADONs.ToList();
            decimal Tong_DT = 0;
            foreach (HOADON a in HD)
            {
                DoanhThu_rp tam = new DoanhThu_rp();
                if (a.NGHD >= frmADD_MIND.NgayBD && a.NGHD <= frmADD_MIND.NgayKT)
                {
                    NHANVIEN nv = db.NHANVIENs.FirstOrDefault(s => s.MANV == a.MANV);
                    tam.MAHD = a.SOHD;
                    tam.NV = nv.HOTEN;
                    tam.ngay = (DateTime)a.NGHD;
                    Tong_DT = Tong_DT + (decimal)a.TRIGIA;
                    int tien = (int)a.TRIGIA;
                    tam.Gia = tien.ToString();
                    ls.Add(tam);
                }
            }
            //dgvDEMO.DataSource = ls;
            txtTong_DT.Text = Tong_DT.ToString("N0");

            this.reportViewer1.LocalReport.ReportPath = "./rpdoanhthu.rdlc";
            ReportDataSource dts = new ReportDataSource("DataSet1", ls);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dts);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
