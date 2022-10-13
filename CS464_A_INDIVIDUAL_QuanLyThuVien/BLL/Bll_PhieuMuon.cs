using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_PhieuMuon
    {

        DAL.Dal_PhieuMuon dal_PhieuMuon;
        PhieuMuon phieuMuon;

        public Bll_PhieuMuon(PhieuMuon f_PM)
        {
            dal_PhieuMuon = new DAL.Dal_PhieuMuon();
            phieuMuon = f_PM;
        }
        public void Bll_Load()
        {
            phieuMuon.dgvPhieuMuon.DataSource = dal_PhieuMuon.loadData();
        }

        public void Bll_LoadCBB()
        {
            dal_PhieuMuon.loadCbb(phieuMuon.cbbMaDocGia,phieuMuon.cbbTenSach);
        }

        public void Bll_Insert()
        {
            dal_PhieuMuon.DAL_ThemPhieuMuon(phieuMuon.txtMaMuonTra.Text, phieuMuon.cbbMaDocGia.Text, 
                Convert.ToDateTime(phieuMuon.txtNgayBatDau.Text), Convert.ToDateTime(phieuMuon.txtNgayKetThuc.Text), 
                phieuMuon.txtGhiChu.Text, phieuMuon.txtMaSach.Text);
        }
        public void Bll_Update()
        {
            dal_PhieuMuon.DAL_SuaPhieuMuon(phieuMuon.cbbMaDocGia.Text,
                Convert.ToDateTime(phieuMuon.txtNgayBatDau.Text), Convert.ToDateTime(phieuMuon.txtNgayKetThuc.Text),
                phieuMuon.txtGhiChu.Text, phieuMuon.txtMaSach.Text,phieuMuon.txtMaMuonTra.Text);
        }
        public void Bll_Delete()
        {
            dal_PhieuMuon.DAL_XoaPhieuMuon(phieuMuon.txtMaMuonTra.Text);
        }
        public void Bll_Search()
        {
            phieuMuon.dgvPhieuMuon.DataSource = dal_PhieuMuon.DAL_TimKiem(phieuMuon.txtTimKiem.Text);
        }

    }
}
