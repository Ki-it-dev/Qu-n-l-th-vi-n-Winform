using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_TheThuVien
    {
        DAL.Dal_TheThuVien dal_TheThuVien;
        TheThuVien theThuVien;

        public Bll_TheThuVien(TheThuVien f_TV)
        {
            dal_TheThuVien = new DAL.Dal_TheThuVien();
            theThuVien = f_TV;
        }
        public void Bll_Load()
        {
            theThuVien.dgvTheThuVien.DataSource = dal_TheThuVien.loadData();
        }

        public void Bll_LoadCBB()
        {
            dal_TheThuVien.loadCbbDocGiaChuaCoTheThuVien(theThuVien.cbbMaDocGia);
        }

        public void Bll_Insert()
        {
            dal_TheThuVien.DAL_ThemTheThuVien(theThuVien.txtMaThe.Text,
                Convert.ToDateTime(theThuVien.txtNgayBatDau.Text), Convert.ToDateTime(theThuVien.txtNgayKetThuc.Text),
                theThuVien.txtGhiChu.Text, theThuVien.cbbMaDocGia.Text);
            //dal_TheThuVien.DAL_ThemSuaTheThuVien(theThuVien.cbbMaDocGia.Text, theThuVien.txtMaThe.Text);
        }
        public void Bll_Update()
        {
            dal_TheThuVien.DAL_SuaTheThuVien(theThuVien.txtMaThe.Text,
                Convert.ToDateTime(theThuVien.txtNgayBatDau.Text), Convert.ToDateTime(theThuVien.txtNgayKetThuc.Text),
                theThuVien.txtGhiChu.Text, theThuVien.cbbMaDocGia.Text);
            //dal_TheThuVien.DAL_ThemSuaTheThuVien(theThuVien.cbbMaDocGia.Text, theThuVien.txtMaThe.Text);
        }
        public void Bll_Delete()
        {
            //dal_TheThuVien.DAL_XoaSuaTheThuVien(theThuVien.cbbMaDocGia.Text);
            dal_TheThuVien.DAL_XoaTheThuVien(theThuVien.txtMaThe.Text,theThuVien.cbbMaDocGia.Text);
        }
        public void Bll_Search()
        {
            theThuVien.dgvTheThuVien.DataSource = dal_TheThuVien.DAL_TimKiem(theThuVien.txtTimKiem.Text);
        }
    }
}
