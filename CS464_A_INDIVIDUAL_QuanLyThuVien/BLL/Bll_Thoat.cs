using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_Thoat
    {
        DAL.Dal_DangNhap dal_DangNhap;
        DangNhap DN;
        public Bll_Thoat(DangNhap f_DN)
        {
            dal_DangNhap = new DAL.Dal_DangNhap();
            DN = f_DN;
        }

        public void BLL_Exit()
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
