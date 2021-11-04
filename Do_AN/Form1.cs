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
    public partial class Form1 : Form
    {
        public static TAIKHOAN taikhoan;
        public static SANPHAM sanpham;

        //Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True
        QLBHEntities1 db = new QLBHEntities1();
        public Form1()
        {
            InitializeComponent();
        }
        
        public TAIKHOAN Laygt { get { return taikhoan;  } }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void chkHien_MK_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHien_MK.Checked == true)
            {
                txtMat_Khau.UseSystemPasswordChar = false;
            }    
            else
            {
                txtMat_Khau.UseSystemPasswordChar = true;
            }    
        }
        public static TAIKHOAN Lay_TKF1()
        {
            return taikhoan;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDieu_huong DH = new frmDieu_huong();
            

            List<TAIKHOAN> ds = db.TAIKHOANs.ToList();
            int kt = 0;

            List<SANPHAM> dssp = db.SANPHAMs.ToList();
            for(int i=0; i<5;i++)
            {
                if(dssp[i].MASP == "SP01")
                {
                    sanpham = dssp[i];
                }
            }
            //var cm = new SqlCommand("")

            TAIKHOAN tk = db.TAIKHOANs.FirstOrDefault(t => t.TK == txtTai_Khoan.Text.Trim() && t.MK == txtMat_Khau.Text);

            if(tk != null)
            {
                kt = 1;
                taikhoan = tk;
                //frmDieu_huong gg = new frmDieu_huong(taikhoan);
                //Hide();
                DialogResult = DialogResult.OK;
                this.Close();
                //DH.ShowDialog();
            }
            else
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Tài Khoản hoặc Mật khẩu không chính xác !", "Lỗi đăng nhập", MessageBoxButtons.OK);
            }
            /*if(kt ==0)
            {
                MessageBox.Show("Tài Khoản hoặc Mật khẩu không chính xác !", "Lỗi đăng nhập", MessageBoxButtons.OK);
            }    */


        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programming version: 1.0\n Run perfect on Visual Studio 2019.\n Đồ án môn học.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*DialogResult t = MessageBox.Show("bạn muốn thoát ?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
