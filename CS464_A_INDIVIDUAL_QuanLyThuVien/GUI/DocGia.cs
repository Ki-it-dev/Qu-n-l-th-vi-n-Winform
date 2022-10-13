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
    public partial class DocGia : Form
    {
        BLL.Bll_DocGia bll_DocGia;

        public DocGia()
        {
            InitializeComponent();
            bll_DocGia = new BLL.Bll_DocGia(this);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bll_DocGia.Bll_Insert();
            bll_DocGia.Bll_Load();
            setNull();
        }

        private void DocGia_Load(object sender, EventArgs e)
        {
            bll_DocGia.Bll_Load();

            lbKiemTraPhieu.Text = "";

            dgvDocGia.Columns[0].HeaderText = "Mã đọc giả";
            dgvDocGia.Columns[1].HeaderText = "Họ và tên";
            dgvDocGia.Columns[2].HeaderText = "Số điện thoại";
            dgvDocGia.Columns[3].HeaderText = "Mã thẻ";
            dgvDocGia.Columns[4].HeaderText = "Ngày bắt đầu";
            dgvDocGia.Columns[5].HeaderText = "Ngày kết thúc";

            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDocGia.Columns[dgvDocGia.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Hệ Thống", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bll_DocGia.Bll_Delete();
                bll_DocGia.Bll_Load();
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bll_DocGia.Bll_Update();
            bll_DocGia.Bll_Load();
            setNull();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            bll_DocGia.Bll_Search();
        }
        protected void setNull()
        {
            txtMaDocGia.Text = 
            txtHoTen.Text = 
            txtSDT.Text = 
            lbKiemTraPhieu.Text = txtNgayBatDau.Text = txtNgayKetThuc.Text = "";
        }
        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDocGia.Text = dgvDocGia.CurrentRow.Cells["maDocGia"].Value.ToString();
            txtHoTen.Text = dgvDocGia.CurrentRow.Cells["tenUser"].Value.ToString();
            txtSDT.Text = dgvDocGia.CurrentRow.Cells["soDienThoai"].Value.ToString();
            lbKiemTraPhieu.Text = dgvDocGia.CurrentRow.Cells["maThe"].Value.ToString();

            if(lbKiemTraPhieu.Text != "Chưa có")
            {
                txtNgayBatDau.Text = Convert.ToDateTime(dgvDocGia.CurrentRow.Cells["ngayBatDau"].Value.ToString()).ToString("dd-MM-yyyy");
                txtNgayKetThuc.Text = Convert.ToDateTime(dgvDocGia.CurrentRow.Cells["ngayKetThuc"].Value.ToString()).ToString("dd-MM-yyyy");
            }
            else
            {
                txtNgayBatDau.Text = txtNgayKetThuc.Text = "";
            }
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
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Show();
            this.Hide();
        }

        private void btnTheThuVien_Click(object sender, EventArgs e)
        {
            TheThuVien theThuVien = new TheThuVien();
            theThuVien.Show();
            this.Hide();
        }

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Show();
            this.Hide();
        }
    }
}
