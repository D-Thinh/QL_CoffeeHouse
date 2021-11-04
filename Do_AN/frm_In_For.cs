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
    public partial class frm_In_For : Form
    {
        public frm_In_For()
        {
            InitializeComponent();
            load();
        }


        SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True");

        QLBHEntities1 db = new QLBHEntities1();
        public void load()
        {
            TAIKHOAN tam = Form1.taikhoan;
            txtMSNV.Text = tam.MANV;

            /* SqlCommand cm = new SqlCommand("SELECT t.MK,t.MK,n.HOTEN FROM TAIKHOAN t, NHANVIEN n WHERE t.MANV = n.MANV ", conect);
             SqlDataAdapter ad = new SqlDataAdapter(cm);
             DataTable data = new DataTable();
             ad.Fill(data);*/

            List<NHANVIEN> ds = db.NHANVIENs.ToList();
            for(int i=0; i< ds.Count; i++)
            {
                if(ds[i].MANV == tam.MANV)
                {
                    txt_in_chucvu.Text = tam.CV;
                    txt_in_Gmail.Text = ds[i].MAIL;
                    txt_in_ten.Text = ds[i].HOTEN;
                    txt_in_SDT.Text = ds[i].SDT;
                }    
            }    
                

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txt_in_ten.ReadOnly = false;
            txt_in_Gmail.ReadOnly = false;
            txt_in_SDT.ReadOnly = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
            txt_in_ten.ReadOnly = true;
            txt_in_Gmail.ReadOnly = true;
            txt_in_SDT.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> ds = db.NHANVIENs.ToList();
            TAIKHOAN tam = Form1.taikhoan;
            NHANVIEN tk = db.NHANVIENs.Find(tam.MANV);
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MANV == tam.MANV)
                {                    
                    tk.MAIL = txt_in_Gmail.Text;
                    tk.SDT = txt_in_SDT.Text;
                    tk.HOTEN = txt_in_ten.Text;
                }
                db.SaveChanges();
                txt_in_ten.ReadOnly = true;
                txt_in_Gmail.ReadOnly = true;
                txt_in_SDT.ReadOnly = true;
            }
            MessageBox.Show("Đã lưu thông tin thành công !", "Change Info", MessageBoxButtons.OK);
        }
    }
}
