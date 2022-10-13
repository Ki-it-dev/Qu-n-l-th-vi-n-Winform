using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_TheThuVien
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_TheThuVien()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public DataTable loadData()
        {
            //string sql = "Select tbDocGia.maDocGia,tbDocGia.tenUser,tbDocGia.maThe," +
            //            "tbTheThuVien.ngayBatDau,tbTheThuVien.ngayKetThuc,tbTheThuVien.ghiChu" +
            //            "from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe";

            string sql = "Select tbDocGia.maDocGia,tbDocGia.tenUser," +
                "tbTheThuVien.maThe,tbTheThuVien.ngayBatDau,tbTheThuVien.ngayKetThuc,tbTheThuVien.ghiChu " +
                "from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe";

            return lOPDUNGCHUNG.LoadData(sql);
        }

        public void loadCbbDocGiaChuaCoTheThuVien(ComboBox cbb)
        {
            string sql = "select *from tbDocGia where maThe = N'Chưa có'";

            cbb.DataSource = lOPDUNGCHUNG.LoadData(sql);
            cbb.DisplayMember = "maDocGia";
            cbb.ValueMember = "maDocGia";
        }

        public void DAL_ThemTheThuVien(string maThe, DateTime ngayBatDau, DateTime ngayKetThuc, string ghiChu, string maDocGia)
        {
            string sql = "Insert into tbTheThuVien values (N'" + maThe + "','" + ngayBatDau + "','" + ngayKetThuc + "',N'" + ghiChu + "');" +
                "Update tbDocGia set maThe = N'" + maThe + "' where maDocGia = '" + maDocGia + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        //public void DAL_ThemSuaTheThuVien(string maDocGia,string maThe)
        //{
        //    string sql = "Update tbDocGia set maThe = N'" + maThe + "' where maDocGia = '" + maDocGia + "'";
        //    lOPDUNGCHUNG.Nonquery(sql);
        //}

        public void DAL_SuaTheThuVien(string maThe, DateTime ngayBatDau, DateTime ngayKetThuc, string ghiChu, string maDocGia)
        {
            string sql = "Update tbTheThuVien set maThe = N'" + maThe +
                "',ngayBatDau = '" + ngayBatDau + "',ngayKetThuc = '" +
                ngayKetThuc + "',ghiChu = '" + ghiChu + "'" +
                "where maThe = '" + maThe + "';" +
                "Update tbDocGia set maThe = N'" + maThe + "' where maDocGia = '" + maDocGia + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_XoaTheThuVien(string maThe,string maDocGia)
        {
            string sql = "Update tbDocGia set maThe = N'Chưa có' where maDocGia = '" + maDocGia + "'" +
                "Delete tbTheThuVien where maThe = N'" + maThe + "'";
            lOPDUNGCHUNG.Nonquery(sql);
        }

        //public void DAL_XoaSuaTheThuVien(string maDocGia)
        //{
        //    string sql = "Update tbDocGia set maThe = N'Chưa có' where maDocGia = '" + maDocGia + "'";
        //    lOPDUNGCHUNG.Nonquery(sql);
        //}

        public DataTable DAL_TimKiem(string timKiem)
        {
            string sql;

            sql = "Select tbDocGia.maDocGia,tbDocGia.tenUser," +
                "tbTheThuVien.maThe,tbTheThuVien.ngayBatDau,tbTheThuVien.ngayKetThuc,tbTheThuVien.ghiChu " +
                "from tbDocGia inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe" +
            " where maDocGia like N'%" + timKiem + "%'" +
            " or tenUser like N'%" + timKiem + "%'" +
            " or tbTheThuVien.ghiChu like N'%" + timKiem + "%'" +
            " or tbTheThuVien.maThe like '%" + timKiem + "%'";

            return lOPDUNGCHUNG.LoadData(sql);
        }
    }
}
