using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.GUI
{
    public partial class TheThuVien : Form
    {
        BLL.Bll_TheThuVien bll_TheThuVien;
        public TheThuVien()
        {
            InitializeComponent();
            bll_TheThuVien = new BLL.Bll_TheThuVien(this);
        }

        private void dgvTheThuVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaThe.Text = dgvTheThuVien.CurrentRow.Cells["maThe"].Value.ToString();
            txtGhiChu.Text = dgvTheThuVien.CurrentRow.Cells["ghiChu"].Value.ToString();
            cbbMaDocGia.Text = dgvTheThuVien.CurrentRow.Cells["maDocGia"].Value.ToString();

            if(dgvTheThuVien.CurrentRow.Cells["ngayBatDau"].Value.ToString() != "" && dgvTheThuVien.CurrentRow.Cells["ngayKetThuc"].Value.ToString() != "")
            {
                txtNgayBatDau.Text = Convert.ToDateTime(dgvTheThuVien.CurrentRow.Cells["ngayBatDau"].Value.ToString()).ToString("dd-MM-yyyy");
                txtNgayKetThuc.Text = Convert.ToDateTime(dgvTheThuVien.CurrentRow.Cells["ngayKetThuc"].Value.ToString()).ToString("dd-MM-yyyy");
            }
            
            txtMaThe.ReadOnly = true;

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            bll_TheThuVien.Bll_Search();
        }

        protected void setNull()
        {
            txtMaThe.Text =
            txtNgayBatDau.Text =
            txtNgayKetThuc.Text =
            txtGhiChu.Text =
            cbbMaDocGia.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bll_TheThuVien.Bll_Insert();
            bll_TheThuVien.Bll_Load();
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Hệ Thống", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bll_TheThuVien.Bll_Delete();
                bll_TheThuVien.Bll_Load();
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bll_TheThuVien.Bll_Update();
            bll_TheThuVien.Bll_Load();
            setNull();
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

        private void TheThuVien_Load(object sender, EventArgs e)
        {
            bll_TheThuVien.Bll_Load();
            bll_TheThuVien.Bll_LoadCBB();

            dgvTheThuVien.Columns[0].HeaderText = "Mã đọc giả";
            dgvTheThuVien.Columns[1].HeaderText = "Họ và tên";
            dgvTheThuVien.Columns[2].HeaderText = "Mã thẻ";
            dgvTheThuVien.Columns[3].HeaderText = "Ngày bắt đầu";
            dgvTheThuVien.Columns[4].HeaderText = "Ngày kết thúc";
            dgvTheThuVien.Columns[5].HeaderText = "Ghi chú";

            dgvTheThuVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTheThuVien.Columns[dgvTheThuVien.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Show();
            this.Hide();
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            setNull();
            txtMaThe.ReadOnly = false;
        }
    }
}
