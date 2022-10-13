using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_NhanVien
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_NhanVien()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public DataTable loadData()
        {
            string sql = "Select tbUser.maUser,tbUser.tenUser,tbUser.ngaySinh,tbUser.soDienThoai,tbUser.diaChi from tbUser";
            return lOPDUNGCHUNG.LoadData(sql);
        }

        public void DAL_ThemNV(string maUser, string tenUser, DateTime ngaySinh, string sDT, string diaChi)
        {
            string sql = "Insert into tbUser values (N'" + maUser + "','2',N'" + tenUser + "','" + ngaySinh +
                "','" + sDT + "',N'" + diaChi + "','12345')";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_SuaNV(string maUser, string tenUser, DateTime ngaySinh, string sDT, string diaChi)
        {
            string sql = "Update tbUser set maUser = N'" + maUser + "',maQuyen = '2',tenUser=N'" + tenUser + "'," +
                "ngaySinh = '" + ngaySinh + "',soDienThoai = '" + sDT + "',diaChi=N'" + diaChi +
                "' where maUser = '" + maUser + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_XoaNV(string maUser)
        {
            string sql = "Delete tbUser where maUser = N'" + maUser + "'";
            lOPDUNGCHUNG.Nonquery(sql);
        }

        public DataTable DAL_TimKiem(string timKiem)
        {
            string sql;

            sql = "select tbUser.maUser,tbUser.tenUser,tbUser.ngaySinh,tbUser.soDienThoai,tbUser.diaChi" +
            " from tbUser where maUser like N'%" + timKiem + "%'" +
            " or tenUser like N'%" + timKiem + "%'" +
            //"or ngaySinh like %'" + timKiem + "'% ";
            " or diaChi like N'%" + timKiem + "%'"+
            " or soDienThoai like '%" + timKiem + "%'";

            return lOPDUNGCHUNG.LoadData(sql);
        }
    }
}
