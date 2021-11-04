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

namespace Do_AN
{
    public partial class frmADD_MIND : Form
    {
        public frmADD_MIND()
        {
            InitializeComponent();
            load();
        }

        QLBHEntities1 db = new QLBHEntities1();
        public static DateTime NgayBD;
        public static DateTime NgayKT;
        private void radAnAccount_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void load()
        {
            dgv_QLSP.DataSource = db.SANPHAMs.Include(s => s.MALOAI).Where(s => s.MASP != null)
                    .Select(s => new
                    {
                        MA_SP = s.MASP,
                        TEN_SP = s.TENSP,
                        LOAI_SP = s.LOAISP.TENLOAI,
                        DVT = s.DVT,
                        GIA = s.GIA ?? 0
                    }).ToList().Select(d => new {
                        d.MA_SP,
                        d.TEN_SP,
                        d.LOAI_SP,
                        d.DVT,
                        GIA = d.GIA.ToString("N0")
                    }).ToList();
            List<LOAISP> dssp = db.LOAISPs.ToList();
            cmbType_Sp_tap1.DataSource = dssp;
            cmbType_Sp_tap1.ValueMember = "MALOAI";
            cmbType_Sp_tap1.DisplayMember = "TENLOAI";

            List<LOAISP> dssp1 = db.LOAISPs.ToList();
            cmbLoai_SP_tap1.DataSource = dssp1;
            cmbLoai_SP_tap1.ValueMember = "MALOAI";
            cmbLoai_SP_tap1.DisplayMember = "TENLOAI";
            cmbLoai_SP_tap1.SelectedIndex = -1;

            // load tap 2
            dgvDSNV_tap2.DataSource = db.TAIKHOANs.Include(s => s.MANV).Include(s => s.NHANVIEN.MALUONG)
                                        .Select(s => new
                                        {
                                            MA_NV = s.MANV,
                                            TEN_NV = s.NHANVIEN.HOTEN,
                                            CHUC_VU = s.CV,
                                            LUONG = s.NHANVIEN.LUONG.SOLUONG ?? 0,
                                            TAI_KHOAN = s.TK,
                                            MAT_KHAU = s.MK,
                                            GMAIL = s.NHANVIEN.MAIL,
                                            SDT = s.NHANVIEN.SDT
                                        }).ToList().Select(g => new
                                        {
                                            g.MA_NV,
                                            g.TEN_NV,
                                            g.CHUC_VU,
                                            LUONG = g.LUONG.ToString("N0"),
                                            g.TAI_KHOAN,
                                            g.MAT_KHAU,
                                            g.GMAIL,
                                            g.SDT
                                        }).ToList();
            // tap 3
            dgvLuong_NV_tap3.DataSource = db.TAIKHOANs.Include(s => s.MANV).Include(s => s.NHANVIEN.MALUONG)
                .Select(s => new
                {
                    MA_NV = s.MANV,
                    Ho_Ten = s.NHANVIEN.HOTEN,
                    Chuc_Vu = s.CV,
                    Luong = s.NHANVIEN.LUONG.SOLUONG ?? 0
                }).ToList().Select(t => new
                {
                    t.MA_NV,
                    t.Ho_Ten,
                    t.Chuc_Vu,
                    Luong = t.Luong.ToString("N0")
                }).ToList();
            // tap4
            dgvDOanh_thu_tap4.DataSource = db.HOADONs.Include(s => s.MANV)
                .Select(s => new
                {
                    SO_HOA_DON = s.SOHD,
                    Thu_Ngan = s.NHANVIEN.HOTEN,
                    Ngay = s.NGHD,
                    Tri_Gia = s.TRIGIA ?? 0,
                }).ToList().Select(g=>new
                {
                    g.SO_HOA_DON,
                    g.Thu_Ngan,
                    g.Ngay,
                    TRI_Gia = g.Tri_Gia.ToString("N0")
                }).ToList();
            decimal tongdt = 0;
            for (int i = 0; i < dgvDOanh_thu_tap4.Rows.Count; i++)
            {
                decimal ttam = decimal.Parse(dgvDOanh_thu_tap4.Rows[i].Cells[3].Value.ToString());
                tongdt = tongdt + ttam;
            }
            txtTong_DoanhThu_tap4.Text = tongdt.ToString("N0");
            // load tap5
            dgvPhan_hoi.DataSource = db.PHANHOIs.Include(t => t.MANV)
                .Select(s => new
                {
                    s.MANV,
                    s.NHANVIEN.HOTEN,
                    s.NGPH,
                    s.LOIPH
                }).ToList();


        }
        private void frmADD_MIND_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDieu_huong dieh = new frmDieu_huong();
            dieh.Show();
        }

        // datagird TAP 1
        private void dgv_QLSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMa_Sp_tap1.Text = dgv_QLSP.Rows[index].Cells[0].Value.ToString();
                txtName_Sp_tap1.Text = dgv_QLSP.Rows[index].Cells[1].Value.ToString();                
                txtPriceSp_tap1.Text = dgv_QLSP.Rows[index].Cells[4].Value.ToString();
                //int gia = int.Parse(dgv_QLSP.Rows[index].Cells[4].Value.ToString);
                string gia = dgv_QLSP.Rows[index].Cells[4].Value.ToString();
                txtDVT_tap1.Text = dgv_QLSP.Rows[index].Cells[3].Value.ToString();

                /*if (dgv_QLSP.Rows[index].Cells[2].Value.ToString() == null)
                {
                    cmbType_Sp_tap1.SelectedIndex = -1;
                }*/
                if (dgv_QLSP.Rows[index].Cells[2].Value.ToString() == "Thức uống")
                {
                    cmbType_Sp_tap1.SelectedIndex = 0;
                }
                if (dgv_QLSP.Rows[index].Cells[2].Value.ToString() == "Thức ăn")
                {
                    cmbType_Sp_tap1.SelectedIndex = 1;
                }
                if (dgv_QLSP.Rows[index].Cells[2].Value.ToString() == "Đồ dùng")
                {
                    cmbType_Sp_tap1.SelectedIndex = 2;
                }
                if (dgv_QLSP.Rows[index].Cells[2].Value.ToString() == "")
                {
                    cmbType_Sp_tap1.SelectedIndex = -1;
                }
            }
             
        }

        private void txtTen_Sp_tap1_TextChanged(object sender, EventArgs e)
        {
            dgv_QLSP.DataSource = db.SANPHAMs.Include(s => s.MALOAI).Where(s => s.TENSP.Contains(txtTen_Sp_tap1.Text))
                       .Select(s => new
                       {
                           MA_SP = s.MASP,
                           TEN_SP = s.TENSP,
                           LOAI_SP = s.LOAISP.TENLOAI,
                           DVT = s.DVT,
                           GIA = s.GIA ?? 0
                       }).ToList().Select(d => new {
                           d.MA_SP,
                           d.TEN_SP,
                           d.LOAI_SP,
                           d.DVT,
                           GIA = d.GIA.ToString("N0")
                       }).ToList();
        }

        private void btnLam_Moi_tap1_Click(object sender, EventArgs e)
        {
            dgv_QLSP.DataSource = null;
            load();
        }

        private void btnTHemSP_tap1_Click(object sender, EventArgs e)
        {
            SANPHAM a = new SANPHAM();
            try
            {
                if (txtMa_Sp_tap1.Text == "" || txtPriceSp_tap1.Text == "" || txtName_Sp_tap1.Text == "" || cmbType_Sp_tap1.SelectedIndex ==-1)
                    MessageBox.Show("vui lòng điền đầy đủ thông tin ", "Warring", MessageBoxButtons.OK);
                else
                {
                    a.MASP = txtMa_Sp_tap1.Text;
                    a.TENSP = txtName_Sp_tap1.Text;
                    a.GIA = decimal.Parse(txtPriceSp_tap1.Text.ToString());
                  
                    if (cmbType_Sp_tap1.SelectedIndex == 0)
                        a.MALOAI = "L01";
                    if (cmbType_Sp_tap1.SelectedIndex == 1)
                        a.MALOAI = "L02";
                    if (cmbType_Sp_tap1.SelectedIndex == 2)
                        a.MALOAI = "L03";
                    a.DVT = txtDVT_tap1.Text;

                    db.SANPHAMs.Add(a);
                    MessageBox.Show("Đã thêm thành công", "Add Product", MessageBoxButtons.OK);
                    db.SaveChanges();
                    load();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("vui lòng điền đầy đủ thông tin!", "cảnh báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Sp_tap1_Click(object sender, EventArgs e)
        {
            
            if(txtMa_Sp_tap1.Text != "")
            {
                string masp = txtMa_Sp_tap1.Text;
                SANPHAM sp = db.SANPHAMs.Find(masp);
                DialogResult t = MessageBox.Show("bạn có chắc muốn xoá sản phẩm này ?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(t== DialogResult.Yes)
                {
                    db.SANPHAMs.Remove(sp);
                    db.SaveChanges();
                    load();
                }                               
            }
            else
            {
                DialogResult t = MessageBox.Show("chưa xác định được sản phẩm cần xoá !", "Delete Product ?", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_SP_tap1_Click_1(object sender, EventArgs e)
        {

            if (txtMa_Sp_tap1.Text != "")
            {
                string masp = txtMa_Sp_tap1.Text;
                SANPHAM sp = db.SANPHAMs.Find(masp);
                DialogResult t = MessageBox.Show("bạn có chắc muốn xoá sản phẩm này ?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    db.SANPHAMs.Remove(sp);
                    db.SaveChanges();
                    MessageBox.Show("Đã xoá thành công !", "Delete Product ", MessageBoxButtons.OK);
                    load();
                }
            }
            else
            {
                DialogResult t = MessageBox.Show("chưa xác định được sản phẩm cần xoá !", "Delete Product ?", MessageBoxButtons.OK);
            }

        }

        private void btnChinh_Sua_tap1_Click(object sender, EventArgs e)
        {
            if (txtMa_Sp_tap1.Text != "")
            {
                string masp = txtMa_Sp_tap1.Text;
                SANPHAM sp = db.SANPHAMs.Find(masp);
                DialogResult t = MessageBox.Show("bạn có chắc muốn sửa sản phẩm này ?", "fix Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (t == DialogResult.Yes)
                {
                    sp.MASP = txtMa_Sp_tap1.Text;
                    sp.TENSP = txtName_Sp_tap1.Text;
                    sp.GIA = decimal.Parse(txtPriceSp_tap1.Text.ToString());
                    if (cmbType_Sp_tap1.SelectedIndex == 0)
                        sp.MALOAI = "L01";
                    if (cmbType_Sp_tap1.SelectedIndex == 1)
                        sp.MALOAI = "L02";
                    if (cmbType_Sp_tap1.SelectedIndex == 2)
                        sp.MALOAI = "L03";
                    sp.DVT = txtDVT_tap1.Text;                    
                    db.SaveChanges();
                    MessageBox.Show("Đã sửa thành công !", "fix Product ?", MessageBoxButtons.OK);
                    load();
                }
            }
            else
            {
                DialogResult t = MessageBox.Show("chưa xác định được sản phẩm cần sủa !", "fix Product ?", MessageBoxButtons.OK);
            }
        }

        private void btnTim_Kiem_tap1_Click(object sender, EventArgs e)
        {
            if(cmbLoai_SP_tap1.SelectedIndex ==0)
            {
                dgv_QLSP.DataSource = db.SANPHAMs.Include(s => s.MALOAI).Where(s => s.MALOAI == "L01")
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
            if (cmbLoai_SP_tap1.SelectedIndex == 1)
            {
                dgv_QLSP.DataSource = db.SANPHAMs.Include(s => s.MALOAI).Where(s => s.MALOAI == "L02")
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


            if (cmbLoai_SP_tap1.SelectedIndex == 2)
            {
                dgv_QLSP.DataSource = db.SANPHAMs.Include(s => s.MALOAI).Where(s => s.MALOAI == "L03")
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
        }

        private void dgvDSNV_tap2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >=0)
            {
                txtMA_NV_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[0].Value.ToString();
                txtName_acc_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[1].Value.ToString();
                txtSdt_Acc_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[7].Value.ToString();
                txtGmail_acc_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[6].Value.ToString();
                txtLuong_theo_ca_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[3].Value.ToString();
                txtTai_Khoang_tap2.Text = dgvDSNV_tap2.Rows[index].Cells[4].Value.ToString();
                if (dgvDSNV_tap2.Rows[index].Cells[2].Value.ToString() == "admin")
                {
                    radNhan_Vien_tap2.Checked = false;
                    rad_Admin_tap2.Checked = true;
                }
                if (dgvDSNV_tap2.Rows[index].Cells[2].Value.ToString() == "nhanvien")
                {
                    radNhan_Vien_tap2.Checked = true;
                    rad_Admin_tap2.Checked = false ;
                }
               

                                            /*MA_NV = s.MANV,
                                            TEN_NV = s.NHANVIEN.HOTEN,
                                            CHUC_VU = s.CV,
                                            LUONG = s.NHANVIEN.LUONG.SOLUONG,
                                            TAI_KHOAN = s.TK,
                                            MAT_KHAU = s.MK,
                                            GMAIL = s.NHANVIEN.MAIL,
                                            SDT = s.NHANVIEN.SDT*/
            }
        }

        private void btnThem_Moi_tap2_Click(object sender, EventArgs e)
        {
            if(txtMA_NV_tap2.Text =="" || txtName_acc_tap2.Text =="" || txtSdt_Acc_tap2.Text =="" ||
                txtGmail_acc_tap2.Text =="" )
            {
                MessageBox.Show("vui lòng điền đầy đủ thông tin !", "Add Account", MessageBoxButtons.OK);
            }    
            else
            {
                TAIKHOAN tam = db.TAIKHOANs.FirstOrDefault(t => t.MANV == txtMA_NV_tap2.Text.Trim());
                TAIKHOAN xettk = db.TAIKHOANs.FirstOrDefault(t => t.TK == txtTai_Khoang_tap2.Text.Trim());               
                NHANVIEN xetnv = db.NHANVIENs.FirstOrDefault(t => t.MANV == txtMA_NV_tap2.Text.Trim());               

                if (tam != null || xettk != null || xetnv != null)
                {
                    MessageBox.Show("Tài khoản này đã tồn tại", "Add Account", MessageBoxButtons.OK);
                }
                else
                {
                    NHANVIEN item = new NHANVIEN();
                    item.MANV = txtMA_NV_tap2.Text;
                    item.HOTEN = txtName_acc_tap2.Text;
                    item.SDT = txtSdt_Acc_tap2.Text;
                    item.MAIL = txtGmail_acc_tap2.Text;
                    if (radNhan_Vien_tap2.Checked == true)
                    {
                        item.MACV = "1";
                        item.MALUONG = "0";
                    }

                    if (rad_Admin_tap2.Checked == true)
                    {
                        item.MACV = "2";
                        item.MALUONG = "1";
                    }
                    db.NHANVIENs.Add(item);
                    //db.SaveChanges();

                    TAIKHOAN a = new TAIKHOAN();
                    a.TK = txtTai_Khoang_tap2.Text;
                    a.MK = "12345";
                    if (radNhan_Vien_tap2.Checked == true)
                    {
                        a.MACV = "1";
                        a.CV = "nhanvien";
                    }

                    if (rad_Admin_tap2.Checked == true)
                    {
                        a.MACV = "2";
                        a.CV = "admin";
                    }
                    a.MANV = txtMA_NV_tap2.Text;
                    db.TAIKHOANs.Add(a);
                    db.SaveChanges();
                }    
               
            }
            load();

        }

        private void btnXoa_tk_tap2_Click(object sender, EventArgs e)
        {
            
            if(txtMA_NV_tap2.Text != "")
            {
                string MATK = txtMA_NV_tap2.Text;
                TAIKHOAN a = db.TAIKHOANs.FirstOrDefault(t => t.MANV == txtMA_NV_tap2.Text.Trim());
                NHANVIEN b = db.NHANVIENs.FirstOrDefault(t => t.MANV == txtMA_NV_tap2.Text.Trim());
                db.TAIKHOANs.Remove(a);
                db.SaveChanges();
                db.NHANVIENs.Remove(b);
                db.SaveChanges();
                MessageBox.Show("Đã xoá thành công !", "Remove Account", MessageBoxButtons.OK);
                load();
            }    

        }

        private void btnLam_Moi_tap2_Click(object sender, EventArgs e)
        {
            load();
            radNhan_Vien_tap2.Checked = false;
            rad_Admin_tap2.Checked = false;
            txtMA_NV_tap2.Text ="";
            txtName_acc_tap2.Text ="";
             txtSdt_Acc_tap2.Text ="";
            txtGmail_acc_tap2.Text ="";
            txtLuong_theo_ca_tap2.Text = "";
            txtTai_Khoang_tap2.Text = "";
        }

        private void btnKhoiPhuc_tap2_Click(object sender, EventArgs e)
        {
            string id = txtTai_Khoang_tap2.Text;
            TAIKHOAN tk = db.TAIKHOANs.FirstOrDefault(s => s.TK == id);
            if(tk != null)
            {
                tk.MK = "12345";
                MessageBox.Show("Đổi mật khẩu về mặc định thành công! ", "Restart Passwword", MessageBoxButtons.OK);
                db.SaveChanges();
                load();
            }
        }

        private void btnThoat_tap2_Click(object sender, EventArgs e)
        {

        }

        private void btnChinh_sua_tap2_Click(object sender, EventArgs e)
        {
            TAIKHOAN tk = db.TAIKHOANs.FirstOrDefault(s => s.TK == txtTai_Khoang_tap2.Text);
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(s => s.MANV== txtMA_NV_tap2.Text);
            if(nv != null)
            {
                nv.HOTEN = txtName_acc_tap2.Text;
                nv.MAIL = txtGmail_acc_tap2.Text;
                nv.SDT = txtSdt_Acc_tap2.Text;
                MessageBox.Show("Đã Cập nhật thành công !", "Update Account", MessageBoxButtons.OK);
                db.SaveChanges();
                load();
                
            }   
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản cần sửa !", "", MessageBoxButtons.OK);
            }

        }

        private void frmADD_MIND_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_tat_ca_Tap5_Click(object sender, EventArgs e)
        {
            dgvPhan_hoi.DataSource = null;
            dgvPhan_hoi.DataSource = db.PHANHOIs.Include(t => t.MANV)
                .Select(s => new
                {
                    s.MANV,
                    s.NHANVIEN.HOTEN,
                    s.NGPH,
                    s.LOIPH
                }).ToList();
        }

        private void btnLam_Moi_tap5_Click(object sender, EventArgs e)
        {
            dgvPhan_hoi.DataSource = null;
            load();
        }

        private void btnXem_tap5_Click(object sender, EventArgs e)
        {
            dgvPhan_hoi.DataSource = null;
            DateTime tiem = dtpNgay_BdPhanHoi_tap5.Value;
            dgvPhan_hoi.DataSource = db.PHANHOIs.Include(s => s.MANV).Where(s=> s.NGPH >= dtpNgay_BdPhanHoi_tap5.Value)
                .Select(s => new
                {
                    s.MANV,
                    s.NHANVIEN.HOTEN,
                    s.NGPH,
                    s.LOIPH
                }).ToList();
        }

        private void btnLam_Moi_tap4_Click(object sender, EventArgs e)
        {
            dgvDOanh_thu_tap4.DataSource = null;
            load();
        }

        private void btnXem_Tat_Ca_tap4_Click(object sender, EventArgs e)
        {
            dgvDOanh_thu_tap4.DataSource = null;
            load();
            NgayBD = new DateTime(2006, 1, 06);
            NgayKT = DateTime.Now;
        }

        private void btnXem_tap4_Click(object sender, EventArgs e)
        {
            dgvDOanh_thu_tap4.DataSource = db.HOADONs.Include(s => s.MANV).Where(s=> s.NGHD >= dtpbNgay_dau_tap4.Value && s.NGHD <= dtpngay_cuoi_Tap4.Value)
               .Select(s => new
               {
                   SO_HOA_DON = s.SOHD,
                   Thu_Ngan = s.NHANVIEN.HOTEN,
                   Ngay = s.NGHD,
                   Tri_Gia = s.TRIGIA ?? 0,
               }).ToList().Select(g => new
               {
                   g.SO_HOA_DON,
                   g.Thu_Ngan,
                   g.Ngay,
                   TRI_Gia = g.Tri_Gia.ToString("N0")
               }).ToList();
            decimal tongdt = 0;
            for (int i = 0; i < dgvDOanh_thu_tap4.Rows.Count; i++)
            {
                decimal ttam = decimal.Parse(dgvDOanh_thu_tap4.Rows[i].Cells[3].Value.ToString());
                tongdt = tongdt + ttam;
            }
            txtTong_DoanhThu_tap4.Text = tongdt.ToString("N0");
            NgayBD = dtpbNgay_dau_tap4.Value;
            NgayKT = dtpngay_cuoi_Tap4.Value;
        }

        private void btnXuat_baoCao_tap4_Click(object sender, EventArgs e)
        {
            frmreport_thongke rp = new frmreport_thongke();
            rp.ShowDialog();
        }
    }
}
