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
    public partial class Sach : Form
    {
        BLL.Bll_Sach bll_Sach;

        public Sach()
        {
            InitializeComponent();
            bll_Sach = new BLL.Bll_Sach(this);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bll_Sach.Bll_Insert();
            bll_Sach.Bll_Load();
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Hệ Thống", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bll_Sach.Bll_Delete();
                bll_Sach.Bll_Load();
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bll_Sach.Bll_Update();
            bll_Sach.Bll_Load();
            setNull();
        }

        protected void setNull()
        {
            txtMaSach.Text =
            txtNamXuatBan.Text =
            txtNhaXuatBan.Text =
            txtTenSach.Text = "";
        }

        private void Sach_Load(object sender, EventArgs e)
        {
            bll_Sach.Bll_Load();

            dgvSach.Columns[0].HeaderText = "Mã sách";
            dgvSach.Columns[1].HeaderText = "Tên sách";
            dgvSach.Columns[2].HeaderText = "Năm xuất bản";
            dgvSach.Columns[3].HeaderText = "Nhà xuất bản";
            dgvSach.Columns[4].HeaderText = "Còn sách";

            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSach.Columns[dgvSach.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSach.Text = dgvSach.CurrentRow.Cells["maSach"].Value.ToString();
            txtNamXuatBan.Text = dgvSach.CurrentRow.Cells["namXuatBan"].Value.ToString();
            txtNhaXuatBan.Text = dgvSach.CurrentRow.Cells["nhaXuatBan"].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells["tenSach"].Value.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            bll_Sach.Bll_Search();
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

        private void quảnLýMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuMuon phieuMuon = new PhieuMuon();
            phieuMuon.Show();
            this.Hide();
        }
    }
}
