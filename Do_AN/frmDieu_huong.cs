using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_AN
{
    public partial class frmDieu_huong : Form
    {
        TAIKHOAN tk_benf1;

        public frmDieu_huong()
        {
            InitializeComponent();
            load();
        }
        public frmDieu_huong(TAIKHOAN a)
        {
            InitializeComponent();
            this.tk_benf1 = a;
            load();
        }

        QLBHEntities1 db = new QLBHEntities1();
        public void load()
        {

            /* TAIKHOAN a = Form1.taikhoan;
             //txtHienTK.Text = Form1.taikhoan.TK;
             txtHienTK.Text = Form1.taikhoan.CV;
             List<NHANVIEN> ds = db.NHANVIENs.ToList();
             for (int i = 0; i < ds.Count; i++)
             {
                 if (Form1.taikhoan.MANV == ds[i].MANV)
                 {
                     txtHien_NV.Text = ds[i].HOTEN;
                 }
             }*/
            TAIKHOAN a = Form1.Lay_TKF1();
           // txtHienTK.Text = a.TK;
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            //Form1 DN = new Form1();
            //Hide();
            //Form1.taikhoan = null;
            //DN.ShowDialog();

            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_In_For infor = new frm_In_For();
            infor.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Doi_MK doimk = new frm_Doi_MK();
            doimk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_Phan_Hoi phanhoi = new frm_Phan_Hoi();
            phanhoi.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
           /* var LayTen = (from tk in db.TAIKHOANs
                          join nv in db.NHANVIENs
                          on tk.MANV equals nv.MANV
                          select new
                          {
                              tk.TK,
                              tk.MK,
                              tk.MACV,
                              tk.MANV,
                              tk.CV,
                              nv.HOTEN,
                              nv.MAIL,
                              nv.SDT,
                              nv.MALUONG
                          }
                          ).ToList();
             LayTen.Select(m => m.HOTEN );*/

            if(Form1.taikhoan.CV == "nhanvien" || Form1.taikhoan.CV == "admin")
            {
                NHANVIEN a = new NHANVIEN();
                

                frmGoi_Do_uong order = new frmGoi_Do_uong();
                Hide();
                order.ShowDialog();
            }    
            else
            {
                MessageBox.Show("tài khoản của bạn không có quyền này !","",MessageBoxButtons.OK);
            }    
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {

            if ( Form1.taikhoan.CV == "admin")
            {
                NHANVIEN a = new NHANVIEN();


                frmADD_MIND addmin = new frmADD_MIND();
                Hide();
                addmin.ShowDialog();
            }
            else
            {
                MessageBox.Show("tài khoản của bạn không có quyền này !", "", MessageBoxButtons.OK);
            }
           
        }

        private void frmDieu_huong_Load(object sender, EventArgs e)
        {
           // txtHienTK.Text = tk_benf1.TK;
           /* List<NHANVIEN> dsnv = db.NHANVIENs.ToList();
            for (int i = 0; i < dsnv.Count; i++)
            {
                if(dsnv[i].MANV == tk_benf1.MANV)
                {
                    txtHien_NV.Text = dsnv[i].HOTEN;
                }
            }
                
*/
        }

        private void frmDieu_huong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
