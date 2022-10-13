using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_DocGia
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_DocGia()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public DataTable loadData()
        {
            string sql = "Select tbDocGia.maDocGia,tbDocGia.tenUser,tbDocGia.soDienThoai,tbDocGia.maThe," +
                "tbTheThuVien.ngayBatDau,tbTheThuVien.ngayKetThuc from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe";
            return lOPDUNGCHUNG.LoadData(sql);
        }

        public void DAL_ThemDocGia(string maDocGia, string tenDocGia, string sDT)
        {
            string sql = "Insert into tbDocGia values (N'" + maDocGia + "',N'"+ tenDocGia + "','"+ sDT + "',N'Chưa có')";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_SuaDocGia(string maDocGia, string tenDocGia, string sDT)
        {
            string sql = "Update tbDocGia set maDocGia = N'" + maDocGia +
                "',tenUser = N'" + tenDocGia + "',soDienThoai = '" +
                sDT + "'" +
                "where maDocGia = '" + maDocGia + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_XoaDocGia(string maDocGia)
        {
            string sql = "Delete tbDocGia where maDocGia = N'" + maDocGia + "'";
            lOPDUNGCHUNG.Nonquery(sql);
        }

        public DataTable DAL_TimKiem(string timKiem)
        {
            string sql;

            sql = "Select tbDocGia.maDocGia,tbDocGia.tenUser,tbDocGia.soDienThoai,tbDocGia.maThe," +
                "tbTheThuVien.ngayBatDau,tbTheThuVien.ngayKetThuc from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe" +
            " where maDocGia like N'%" + timKiem + "%' " +
            " or tenUser like N'%" + timKiem + "%'" +
            " or tbDocGia.maThe like N'%" + timKiem + "%'" +
            " or soDienThoai like '%" + timKiem + "%'";

            return lOPDUNGCHUNG.LoadData(sql);
        }

    }
}
