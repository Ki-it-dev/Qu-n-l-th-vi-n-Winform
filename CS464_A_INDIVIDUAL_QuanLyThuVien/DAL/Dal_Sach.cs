using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_Sach
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_Sach()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public DataTable loadData()
        {
            string sql = "Select * from tbSach";
            return lOPDUNGCHUNG.LoadData(sql);
        }

        public void DAL_ThemSACH(string maSach, string tenSach, int namXuatBan, string nhaXuatBan)
        {
            string sql = "Insert into tbSach values (N'" + maSach + "',N'" + tenSach + "','" + namXuatBan + "',N'" + nhaXuatBan + "','0')";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_SuaSACH(string maSach, string tenSach, int namXuatBan, string nhaXuatBan)
        {
            string sql = "Update tbSach set maSach = N'" + maSach + "',tenSach=N'" + tenSach + "',namXuatBan = '" + namXuatBan + "',nhaXuatBan = N'" + nhaXuatBan + "' where maSach = N'" + maSach + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_XoaSACH(string maSach)
        {
            string sql = "Delete tbSach where maSach = N'" + maSach + "'";
            lOPDUNGCHUNG.Nonquery(sql);
        }

        public DataTable DAL_TimKiem(string timKiem)
        {
            string sql;

            sql = "select *from tbSach where maSach like N'%" + timKiem + "%' " +
            "or tenSach like N'%" + timKiem + "%'" +
            //"or namXuatBan like %'" + namXuatBan + "'% " +
            "or nhaXuatBan like N'%" + timKiem + "%'";

            return lOPDUNGCHUNG.LoadData(sql);
        }

    }
}
