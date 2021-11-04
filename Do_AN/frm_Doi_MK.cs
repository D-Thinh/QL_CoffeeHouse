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
    public partial class frm_Doi_MK : Form
    {
        public frm_Doi_MK()
        {
            InitializeComponent();
            load();
        }

        QLBHEntities1 db = new QLBHEntities1();
        SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True");

        public void load()
        {

            TAIKHOAN tam = Form1.taikhoan;
            //txtTen_NV.Text = tam.MANV;

            /* SqlCommand cm = new SqlCommand("SELECT t.MK,t.MK,n.HOTEN FROM TAIKHOAN t, NHANVIEN n WHERE t.MANV = n.MANV ", conect);
             SqlDataAdapter ad = new SqlDataAdapter(cm);
             DataTable data = new DataTable();
             ad.Fill(data);*/

            List<NHANVIEN> ds = db.NHANVIENs.ToList();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MANV == tam.MANV)
                {
                    txtTen_NV.Text = ds[i].HOTEN;
                }
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbnDoi_MK_Click(object sender, EventArgs e)
        {
            List<TAIKHOAN> ds = db.TAIKHOANs.ToList();
            TAIKHOAN tam = Form1.taikhoan;
            string tkhoan = tam.TK;
            TAIKHOAN tk = db.TAIKHOANs.Find(tam.MANV,tam.MACV);
            SqlDataAdapter ad = new SqlDataAdapter("select count (*) From TAIKHOAN 	WHERE TAIKHOAN.TK =N'"+tam.TK +"' and TAIKHOAN.MK = N'"+tam.MK+"'",conect);
            DataTable data = new DataTable();
            ad.Fill(data);
            if(txtMat_Khau_cu.Text == tam.MK)
            {
               
                    if(data.Rows[0][0].ToString()=="1")
                    {
                        if (txt_Nhap_Lai_MK.Text == txtMK_Moi.Text)
                        {
                            SqlDataAdapter ad1 = new SqlDataAdapter("UPDATE TAIKHOAN SET MK ='"+txtMK_Moi.Text+"' where TK =N'"+tam.TK+"' and MK =N'"+tam.MK+"' ", conect);
                            DataTable data1 = new DataTable();
                            ad1.Fill(data1);
                            MessageBox.Show("Đổi mật khẩu thành công !", "Perfetch", MessageBoxButtons.OK);
                        Close();
                    }
                        else
                        {
                            MessageBox.Show("Mật khẩu không trùng khớp !", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }                                                     
            }    
            else
            {
                MessageBox.Show("Mật khẩu không đúng !", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void frm_Doi_MK_Load(object sender, EventArgs e)
        {

        }
    }
}
