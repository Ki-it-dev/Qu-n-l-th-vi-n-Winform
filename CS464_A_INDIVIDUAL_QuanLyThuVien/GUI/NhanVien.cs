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
    public partial class NhanVien : Form
    {
        BLL.Bll_NhanVien bll_NhanVien;
        public NhanVien()
        {
            InitializeComponent();
            bll_NhanVien = new BLL.Bll_NhanVien(this);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bll_NhanVien.Bll_Insert();
            bll_NhanVien.Bll_Load();
            setNull();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Hệ Thống", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bll_NhanVien.Bll_Delete();
                bll_NhanVien.Bll_Load();
                setNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bll_NhanVien.Bll_Update();
            bll_NhanVien.Bll_Load();
            setNull();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["maUser"].Value.ToString();
            txtHoTen.Text = dgvNhanVien.CurrentRow.Cells["tenUser"].Value.ToString();

            if(dgvNhanVien.CurrentRow.Cells["ngaySinh"].Value.ToString() != "")
            {
                txtNgaySinh.Text = Convert.ToDateTime(dgvNhanVien.CurrentRow.Cells["ngaySinh"].Value.ToString()).ToString("dd-MM-yyyy");
            }

            txtSDT.Text = dgvNhanVien.CurrentRow.Cells["soDienThoai"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["diaChi"].Value.ToString();
        }

        protected void setNull()
        {
            txtMaNhanVien.Text =
            txtHoTen.Text =
            txtNgaySinh.Text =
            txtSDT.Text =
            txtDiaChi.Text = "";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            bll_NhanVien.Bll_Search();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            bll_NhanVien.Bll_Load();

            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Họ và tên";
            dgvNhanVien.Columns[2].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[3].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[4].HeaderText = "Địa chỉ";


            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNhanVien.Columns[dgvNhanVien.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
