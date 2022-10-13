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
    public partial class DangNhap : Form
    {
        BLL.Bll_DangNhap Bll_DangNhap;
        BLL.Bll_Thoat Bll_Thoat;
        public DangNhap()
        {
            InitializeComponent();
            Bll_DangNhap = new BLL.Bll_DangNhap(this);
            Bll_Thoat = new BLL.Bll_Thoat(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int ketqua = Bll_DangNhap.BLL_Login();
            if (ketqua >= 1)
            {
                Sach sach = new Sach();
                sach.Show();
                this.Hide();
            }
            else MessageBox.Show("Nhap sai");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Bll_Thoat.BLL_Exit();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
    }
}
