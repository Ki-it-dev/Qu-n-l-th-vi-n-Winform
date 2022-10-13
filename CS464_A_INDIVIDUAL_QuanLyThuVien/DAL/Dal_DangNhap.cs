using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_DangNhap
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_DangNhap()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public int DAL_DangNhap(string tenDN, string pass)
        {
            string sqlLogin = "select count(*) from tbUser where tenUser ='" + tenDN + "' " +
                "and matKhauUser='" + pass + "' ";
            return (int)lOPDUNGCHUNG.Scalar(sqlLogin);
        }

    }
}
