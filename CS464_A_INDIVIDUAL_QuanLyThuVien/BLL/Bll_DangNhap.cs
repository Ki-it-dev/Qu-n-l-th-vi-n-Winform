using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_DangNhap
    {
        DAL.Dal_DangNhap dal_DangNhap;
        DangNhap DN;

        public Bll_DangNhap(DangNhap f_DN)
        {
            dal_DangNhap = new DAL.Dal_DangNhap();
            DN = f_DN;
        }

        public int BLL_Login()
        {
            return dal_DangNhap.DAL_DangNhap(DN.txtTaiKhoan.Text,DN.txtMatKhau.Text);
        }
    }
}
