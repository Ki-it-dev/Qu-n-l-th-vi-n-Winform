using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class Dal_PhieuMuon
    {
        LopDungChung lOPDUNGCHUNG;

        public Dal_PhieuMuon()
        {
            lOPDUNGCHUNG = new LopDungChung();
        }

        public DataTable loadData()
        {
            string sql = "Select tbMuonTra.maMuonTra,tbMuonTra.maDocGia,tbMuonTra.maSach,tbDocGia.tenUser,tbTheThuVien.maThe,tbSach.tenSach," +
                " tbMuonTra.ngayMuon,tbMuonTra.ngayTra,tbMuonTra.ghiChu from tbMuonTra " +
                " inner join tbDocGia on tbMuonTra.maDocGia = tbDocGia.maDocGia " +
                " inner join tbSach on tbMuonTra.maSach = tbSach.maSach " +
                " inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe";
            return lOPDUNGCHUNG.LoadData(sql);
        }

        public void loadCbb(ComboBox cbbMaDocGia, ComboBox cbbTenSach)
        {
            string sqlDocGia = "select *from tbDocGia";

            cbbMaDocGia.DataSource = lOPDUNGCHUNG.LoadData(sqlDocGia);
            cbbMaDocGia.DisplayMember = "maDocGia";
            cbbMaDocGia.ValueMember = "maDocGia";

            string sqlTenSach = "select *from tbSach where muonSach = 'false'";

            cbbTenSach.DataSource = lOPDUNGCHUNG.LoadData(sqlTenSach);
            cbbTenSach.DisplayMember = "tenSach";
            cbbTenSach.ValueMember = "maSach";
        }

        public void DAL_ThemPhieuMuon(string maMuonTra, string maDocGia, DateTime ngayMuon, DateTime ngayTra,
            string ghiChu, string maSach)
        {

            string sql = "Insert into tbMuonTra values (N'" + maMuonTra + "','" + maDocGia + "','2','" + ngayMuon + "','" + ngayTra + "',N'" + ghiChu + "',N'" + maSach + "');" +
                            "Update tbSach set muonSach = 'true' where tbSach.maSach = '" + maSach + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_SuaPhieuMuon(string maDocGia, DateTime ngayMuon, DateTime ngayTra, string ghiChu, string maSach, string maMuonTra)
        {

            string sql = "Update tbSach set muonSach = 'false' from tbSach " +
                "inner join tbMuonTra on tbSach.maSach = tbMuonTra.maSach " +
                "where tbMuonTra.maMuonTra = N'" + maMuonTra + "';" +
                "Update tbMuonTra set maDocGia = N'" + maDocGia + "',ngayMuon = '" + ngayMuon + "',ngayTra = '" + ngayTra + "',ghiChu=N'" + ghiChu + "'," +
                "maSach = N'" + maSach + "' where maMuonTra = N'" + maMuonTra + "';" +
                "Update tbSach set muonSach = 'true' where tbSach.maSach = '" + maSach + "'";

            lOPDUNGCHUNG.Nonquery(sql);
        }

        public void DAL_XoaPhieuMuon(string maMuonTra)
        {
            string sql = "Update tbSach set muonSach = 'false' from tbSach " +
                "inner join tbMuonTra on tbSach.maSach = tbMuonTra.maSach " +
                "where tbMuonTra.maMuonTra = N'" + maMuonTra + "';" +
                "Delete tbMuonTra where maMuonTra = N'" + maMuonTra + "'";
            lOPDUNGCHUNG.Nonquery(sql);
        }

        public DataTable DAL_TimKiem(string timKiem)
        {
            string sql;

            sql = "Select tbMuonTra.maMuonTra,tbMuonTra.maDocGia,tbMuonTra.maSach,tbDocGia.tenUser,tbTheThuVien.maThe,tbSach.tenSach," +
                "tbMuonTra.ngayMuon,tbMuonTra.ngayTra,tbMuonTra.ghiChu from tbMuonTra " +
                "inner join tbDocGia on tbMuonTra.maDocGia = tbDocGia.maDocGia " +
                "inner join tbSach on tbMuonTra.maSach = tbSach.maSach " +
                "inner join tbTheThuVien on tbDocGia.maThe = tbTheThuVien.maThe" +
            " where tbMuonTra.maMuonTra like N'%" + timKiem + "%' " +
            " or tenUser like N'%" + timKiem + "%'" +
            " or tenSach like N'%" + timKiem + "%'" +
            " or tbMuonTra.ghiChu like N'%" + timKiem + "%'" +
            " or tbMuonTra.maSach like '%" + timKiem + "%'";

            return lOPDUNGCHUNG.LoadData(sql);
        }
    }
}
