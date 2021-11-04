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
using System.Data.Entity;

namespace Do_AN
{
    public partial class frmGoi_Do_uong : Form
    {

        public static string MAHD;

        public frmGoi_Do_uong()
        {
            InitializeComponent();
            load();
        }
        //Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True
        QLBHEntities1 db = new QLBHEntities1();
        SqlConnection conect = new SqlConnection(@"Data Source=DESKTOP-990CIN8;Initial Catalog=QLBH;Integrated Security=True");

        public void load()
        {
            List<LOAISP> ds_loaisp = db.LOAISPs.ToList();
            List<NHANVIEN> dsnv = db.NHANVIENs.ToList();
            for(int i=0; i<dsnv.Count;i++)
            {
                if (dsnv[i].MANV == Form1.taikhoan.MANV)
                    txtHien_Thi_TenNV.Text = dsnv[i].HOTEN;
            }
            DateTime today = DateTime.Now;
            int ngay = today.Day;
            int thang = today.Month;
            int nam = today.Year;
            txtHien_Thi_ngay_Thang.Text = ngay.ToString() +"-" + thang.ToString() + "-" + nam.ToString();

            cmb_Tim_Loai_Sp.DataSource = ds_loaisp;
            //cmbThem_SLSP.DataSource = ds_loaisp;

            cmb_Tim_Loai_Sp.ValueMember = "MALOAI";
            cmb_Tim_Loai_Sp.DisplayMember = "TENLOAI";

            //cmbThem_SLSP.ValueMember = "MALOAI";
            //cmbThem_SLSP.DisplayMember = "TENLOAI";
            cmb_Tim_Loai_Sp.SelectedIndex = 0;
            cmbThem_SLSP.SelectedIndex = 0;

           /* SqlCommand cm = new SqlCommand("select   s.TENSP, l.TENLOAI, s.DVT ,s.GIA FROM SANPHAM s, LOAISP l WHERE s.MALOAI = l.MALOAI", conect);
            SqlDataAdapter ad = new SqlDataAdapter(cm);
            DataTable data_SP = new DataTable();
            ad.Fill(data_SP);*/

            //dgcTim_DSSP.DataSource = data_SP;
            dgcTim_DSSP.DataSource = db.SANPHAMs.Include(s => s.LOAISP).Where(s => s.TENSP != null)
                       .Select(s => new
                       {
                           TENSP = s.TENSP,
                           TENLOAI = s.LOAISP.TENLOAI,
                           DVT = s.DVT,
                           GIA = s.GIA ?? 0
                       }).ToList()
                       .Select(d => new {
                           d.TENSP,
                           d.TENLOAI,
                           d.DVT,
                           GIA = d.GIA.ToString("N0")
                       }).ToList();
            txtTongTien.Text = "";
            txtTao_Ma_hoa_don.Text = "";
            dssp_k_o.Clear();
            dgvDSSP_khacChon.DataSource = null;

        }
        private void frmGoi_Do_uong_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // thanh toán

            if(txtTao_Ma_hoa_don.Text != "")
            {
                //string shd = "100" + MaHD.ToString();
                string manv = Form1.taikhoan.MANV;
                DateTime datetime = DateTime.Now;
                int nam = datetime.Year;
                int thang = datetime.Month;
                int ngay = datetime.Day;
                int gio = datetime.Hour;
                int phut = datetime.Minute;
                int giay = datetime.Second;
                DateTime today = new DateTime(nam, thang, ngay, gio, phut, giay);

                decimal Tiem_tam = 0;
                for (int i = 0; i < dssp_k_o.Count; i++)
                {
                    Tiem_tam += (decimal)(dssp_k_o[i].Gia * dssp_k_o[i].SL);
                }

                HOADON item = new HOADON();
                item.SOHD = MAHD;
                item.NGHD = today;
                item.MANV = manv;
                item.TRIGIA = Tiem_tam;
                db.HOADONs.Add(item);

                for (int i = 0; i < dssp_k_o.Count; i++)
                {
                    CTHD a = new CTHD();
                    a.SOHD = MAHD;
                    a.MASP = dssp_k_o[i].MASP;
                    a.SL = dssp_k_o[i].SL;
                    db.CTHDs.Add(a);
                    db.SaveChanges();
                }

                db.SaveChanges();
                frmThanh_toan bill = new frmThanh_toan();
                bill.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng tạo hoá đơn !", "Create HD", MessageBoxButtons.OK);
            }


            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmGoi_Do_uong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDieu_huong dieh = new frmDieu_huong();
            dieh.Show();
        }

        private void dgcTim_DSSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtThem_Ten_SP.Text = dgcTim_DSSP.Rows[index].Cells[0].Value.ToString();
                if (dgcTim_DSSP.Rows[index].Cells[1].Value.ToString() == "Thức uống")
                    cmbThem_SLSP.SelectedIndex = 0;
                if (dgcTim_DSSP.Rows[index].Cells[1].Value.ToString() == "Thức ăn")
                    cmbThem_SLSP.SelectedIndex = 1;
                if (dgcTim_DSSP.Rows[index].Cells[1].Value.ToString() == "Đồ dùng")
                    cmbThem_SLSP.SelectedIndex = 2;




            }
        }

        private void tbtTim_Click(object sender, EventArgs e)
        {
            
           /* if(txtTim_Ten_Sp.Text != "")
            {
                SqlCommand cm = new SqlCommand("select   s.TENSP, l.TENLOAI, s.DVT ,s.GIA FROM SANPHAM s, LOAISP l WHERE s.MALOAI = l.MALOAI and s.TENSP LIKE N'%"+txtTim_Ten_Sp.Text  +"%'", conect);
                SqlDataAdapter ad = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgcTim_DSSP.DataSource = dt;
            }    */
        }

        private void txtTim_Ten_Sp_TextChanged(object sender, EventArgs e)
        {
            //SqlCommand cm = new SqlCommand("select   s.TENSP, l.TENLOAI, s.DVT ,s.GIA FROM SANPHAM s, LOAISP l WHERE s.MALOAI = l.MALOAI and s.TENSP LIKE N'%" + txtTim_Ten_Sp.Text + "%'", conect);
            //SqlDataAdapter ad = new SqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            //ad.Fill(dt);
            //dgcTim_DSSP.DataSource = dt;

            
            dgcTim_DSSP.DataSource = db.SANPHAMs.Include(s => s.LOAISP).Where(s => s.TENSP.Contains(txtTim_Ten_Sp.Text))
                       .Select(s => new
                       {
                           TENSP = s.TENSP,
                           TENLOAI = s.LOAISP.TENLOAI,
                           DVT = s.DVT,
                           GIA = s.GIA ?? 0
                       }).ToList()
                       .Select(d => new {
                            d.TENSP,
                            d.TENLOAI,
                            d.DVT,
                            GIA = d.GIA.ToString("N0")
                       }).ToList();

        }


         List<SP_K_order> dssp_k_o = new List<SP_K_order>();
        
        private void btnTim_Click(object sender, EventArgs e)
        {
            decimal Tiem_tam = 0;
            List<SANPHAM> dssp = db.SANPHAMs.ToList(); 
           for(int i=0; i< dssp.Count ; i++)
            {
               // SP_K_order dk = (SP_K_order)dssp_k_o.Where(s => s.TenSP == txtThem_Ten_SP.Text.ToString());
                if(dssp_k_o.Count >0)
                {
                    for(int j=0; j<dssp_k_o.Count; j++)
                    {
                        if(dssp_k_o[j].TenSP == txtThem_Ten_SP.Text)
                        {
                            int Sol = int.Parse(cmbThem_SLSP.SelectedItem.ToString());
                            int slt = dssp_k_o[j].SL;
                            int tong = Sol + slt;
                            dssp_k_o[j].SL = tong;
                            txtThem_Ten_SP.Text = "";
                            //continue;
                        }
                    }
                    
                }
                if (txtThem_Ten_SP.Text == dssp[i].TENSP)
                {
                    SP_K_order item = new SP_K_order();
                    item.MASP = dssp[i].MASP;
                    item.TenSP = dssp[i].TENSP;
                    item.SL = int.Parse(cmbThem_SLSP.SelectedItem.ToString());
                    item.DVT = dssp[i].DVT;
                    item.Gia = (decimal)dssp[i].GIA;
                    int Sol = int.Parse(cmbThem_SLSP.SelectedItem.ToString());
                    int cvgia = (int)dssp[i].GIA * Sol;
                    item.Hien_Gia = cvgia.ToString();
                    dssp_k_o.Add(item);
                    txtThem_Ten_SP.Text = "";
                }
                
                
            }

            dgvDSSP_khacChon.DataSource = null;
            dgvDSSP_khacChon.DataSource = dssp_k_o;
            for(int i=0; i<dssp_k_o.Count; i++)
            {
                Tiem_tam += (decimal)(dssp_k_o[i].Gia * dssp_k_o[i].SL);
            }
            int tam = (int)Tiem_tam;
            txtTongTien.Text = tam.ToString();
        }

        private void tbnXoa_SP_khachChon_Click(object sender, EventArgs e)
        {            
            try
            {
                if(dssp_k_o.Count >0)
                {
                    int vt = dgvDSSP_khacChon.CurrentCell.RowIndex;
                    if (vt != null)
                    {
                        dssp_k_o.RemoveAt(vt);
                    }


                    dgvDSSP_khacChon.DataSource = null;
                    dgvDSSP_khacChon.DataSource = dssp_k_o;


                    decimal Tiem_tam = 0;
                    for (int i = 0; i < dssp_k_o.Count; i++)
                    {
                        Tiem_tam += (decimal)(dssp_k_o[i].Gia * dssp_k_o[i].SL);
                    }
                    int tam = (int)Tiem_tam;
                    txtTongTien.Text = tam.ToString();
                }    
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnTao_hoa_don_Click(object sender, EventArgs e)
        {
            int sohd = db.HOADONs.Count();
            int MaHD = sohd + 1;
            txtTao_Ma_hoa_don.Text = "100" + MaHD.ToString();
            MAHD = "100" + MaHD.ToString();

            
        }

        private void btnHuy_hoa_don_Click(object sender, EventArgs e)
        {
            MAHD = "";            
            txtTao_Ma_hoa_don.Text = "";
            dssp_k_o.Clear();
            dgvDSSP_khacChon.DataSource = null;
            txtTongTien.Text = "";
        }

        private void btnLam_Moi_Click(object sender, EventArgs e)
        {
            load();
        }
    }
}
