using CS464_A_INDIVIDUAL_QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.GUI
{
    public partial class PhieuMuon : Form
    {
        BLL.Bll_PhieuMuon bll_PhieuMuon;

        string chuoiketnoi = @"Data Source=DESKTOP-KMNS09Q;Initial Catalog=dbQLTV;Integrated Security=True";
        SqlConnection ketNoi;
        SqlCommand thucHien;
        SqlDataReader docDuLieu;
        int i = 0;

        LopDungChung lopDungChung;
        public PhieuMuon()
        {
            InitializeComponent();
            bll_PhieuMuon = new BLL.Bll_PhieuMuon(this);
        }

        private void quảnLýSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sach sach = new Sach();
            sach.Show();
            this.Hide();
        }

        private void quảnLýĐọcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocGia docGia = new DocGia();
            docGia.Show();
            this.Hide();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();
            nhanVien.Show();
            this.Hide();
        }

        private void quảnLýPhiếuThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheThuVien theThuVien = new TheThuVien();
            theThuVien.Show();
            this.Hide();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            bll_PhieuMuon.Bll_Search();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bll_PhieuMuon.Bll_Insert();
            bll_PhieuMuon.Bll_Load();
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Hệ Thống", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bll_PhieuMuon.Bll_Delete();
                bll_PhieuMuon.Bll_Load();
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bll_PhieuMuon.Bll_Update();
            bll_PhieuMuon.Bll_Load();
            setNull();
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMuonTra.ReadOnly = true;

            txtMaMuonTra.Text = dgvPhieuMuon.CurrentRow.Cells["maMuonTra"].Value.ToString();
            cbbMaDocGia.Text = dgvPhieuMuon.CurrentRow.Cells["maDocGia"].Value.ToString();
            txtMaThe.Text = dgvPhieuMuon.CurrentRow.Cells["maThe"].Value.ToString();
            cbbTenSach.Text = dgvPhieuMuon.CurrentRow.Cells["tenSach"].Value.ToString();

            if(dgvPhieuMuon.CurrentRow.Cells["ngayMuon"].Value.ToString() != "" && dgvPhieuMuon.CurrentRow.Cells["ngayTra"].Value.ToString() != "")
            {
                txtNgayKetThuc.Text = Convert.ToDateTime(dgvPhieuMuon.CurrentRow.Cells["ngayTra"].Value.ToString()).ToString("dd-MM-yyyy");
                txtNgayBatDau.Text = Convert.ToDateTime(dgvPhieuMuon.CurrentRow.Cells["ngayMuon"].Value.ToString()).ToString("dd-MM-yyyy");
            }
            
            txtGhiChu.Text = dgvPhieuMuon.CurrentRow.Cells["ghiChu"].Value.ToString();
            txtMaSach.Text = dgvPhieuMuon.CurrentRow.Cells["maSach"].Value.ToString();
        }

        private void PhieuMuon_Load(object sender, EventArgs e)
        {
            ketNoi = new SqlConnection(chuoiketnoi);

            bll_PhieuMuon.Bll_Load();
            bll_PhieuMuon.Bll_LoadCBB();

            dgvPhieuMuon.Columns[0].HeaderText = "Mã phiếu mượn";
            dgvPhieuMuon.Columns[1].HeaderText = "Mã độc giả";
            dgvPhieuMuon.Columns[2].HeaderText = "Mã sách";
            dgvPhieuMuon.Columns[3].HeaderText = "Họ và tên";
            dgvPhieuMuon.Columns[4].HeaderText = "Mã thẻ thư viện";
            dgvPhieuMuon.Columns[5].HeaderText = "Tên sách";
            dgvPhieuMuon.Columns[6].HeaderText = "Ngày mượn";
            dgvPhieuMuon.Columns[7].HeaderText = "Ngày trả";
            dgvPhieuMuon.Columns[8].HeaderText = "Ghi chú";

            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPhieuMuon.Columns[dgvPhieuMuon.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            txtMaMuonTra.ReadOnly = false;

            setNull();
        }

        protected void setNull()
        {
            txtMaMuonTra.Text =
            cbbMaDocGia.Text =
            txtMaThe.Text =
            cbbTenSach.Text =
            txtNgayBatDau.Text =
            txtNgayKetThuc.Text =
            txtGhiChu.Text =
            txtMaSach.Text = "";
        }

        private void cbbMaDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select tbDocGia.maThe from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe" +
                " where tbDocGia.maDocGia = '" + cbbMaDocGia.Text + "'";
            ketNoi.Open();
            thucHien = new SqlCommand(sql, ketNoi);
            docDuLieu = thucHien.ExecuteReader();
            while (docDuLieu.Read())
            {
                txtMaThe.Text = docDuLieu[0].ToString();
                i++;
            }
            ketNoi.Close();
        }

        private void cbbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select tbSach.maSach from tbSach" +
                            " where tbSach.tenSach = N'" + cbbTenSach.Text + "'";
            ketNoi.Open();
            thucHien = new SqlCommand(sql, ketNoi);
            docDuLieu = thucHien.ExecuteReader();
            while (docDuLieu.Read())
            {
                txtMaSach.Text = docDuLieu[0].ToString();
                i++;
            }
            ketNoi.Close();
        }

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Show();
            this.Hide();
        }
    }
}
