using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Do_AN
{
    public partial class frm_Phan_Hoi : Form
    {
        public frm_Phan_Hoi()
        {
            InitializeComponent();
        }

        QLBHEntities1 db = new QLBHEntities1();
        SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True");
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPhan_hoi_Click(object sender, EventArgs e)
        {
            List<PHANHOI> dsph = db.PHANHOIs.ToList();
            int soph = dsph.Count()+1;
            //PHANHOI a = new PHANHOI();
            for (int i=0; i<6;i++)
            {
                #region Lỗi đóng đột ngột 
                if (ckbloi_dong_dot_ngot.Checked == true )
                {
                    soph += 1;
                   
                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "Lỗi đóng ưng dụng đột ngột";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;
                    
                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    ckbloi_dong_dot_ngot.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi lag 
                if (ckbloi_lag.Checked == true)
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "ứng dụng bị lag";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    ckbloi_lag.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi đăng nhập 
                if (cbkLoi_dang_nhap.Checked == true)
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "lỗi đăng nhập";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    cbkLoi_dang_nhap.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi hệ thống dữ liệu trống
                if (ckbloi_du_lieu_trong.Checked == true)
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "lỗi trống dữ liệu hệ thống";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    ckbloi_du_lieu_trong.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi giao diện chưa phù hợp
                if (ckbloi_giaodien_chua_phu_hop.Checked == true)
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "giao diện khó sử dụng";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    ckbloi_giaodien_chua_phu_hop.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi phông chữ
                if (ckbloi_phong_chu.Checked == true)
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = "lỗi phông chữ ";
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    ckbloi_phong_chu.Checked = false;
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion

                #region lỗi khác
                if (rtbGhi_loi.Text != "")
                {
                    soph += 1;

                    string shd = "PH0" + soph.ToString();
                    string manv = Form1.taikhoan.MANV;
                    DateTime datetime = DateTime.Now;

                    string loi = rtbGhi_loi.Text;
                    int nam = datetime.Year;
                    int thang = datetime.Month;
                    int ngay = datetime.Day;
                    int gio = datetime.Hour;
                    int phut = datetime.Minute;
                    int giay = datetime.Second;
                    DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);
                    PHANHOI a = new PHANHOI();
                    a.SOPH = shd;
                    a.MANV = manv;
                    a.NGPH = today;
                    a.LOIPH = loi;

                    db.PHANHOIs.Add(a);
                    db.SaveChanges();
                    rtbGhi_loi.Text = "";
                    //MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);
                    //string s =" insert into phanhoi values('PH01','NV05','23/07/2006',N'Lỗi đăng nhập')  ";
                }
                #endregion
            }
            MessageBox.Show("Đã phản hồi thành công ", "Phản hồi", MessageBoxButtons.OK);

        }
    }
}
