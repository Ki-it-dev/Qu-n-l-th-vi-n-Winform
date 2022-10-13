using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_DocGia
    {
        DAL.Dal_DocGia dal_DocGia;
        DocGia docGia;

        public Bll_DocGia(DocGia f_DG)
        {
            dal_DocGia = new DAL.Dal_DocGia();
            docGia = f_DG;
        }
        public void Bll_Load()
        {
            docGia.dgvDocGia.DataSource = dal_DocGia.loadData();
        }
        public void Bll_Insert()
        {
            dal_DocGia.DAL_ThemDocGia(docGia.txtMaDocGia.Text, docGia.txtHoTen.Text, docGia.txtSDT.Text);
        }
        public void Bll_Update()
        {
            dal_DocGia.DAL_SuaDocGia(docGia.txtMaDocGia.Text, docGia.txtHoTen.Text, docGia.txtSDT.Text);
        }
        public void Bll_Delete()
        {
            dal_DocGia.DAL_XoaDocGia(docGia.txtMaDocGia.Text);
        }
        public void Bll_Search()
        {
            docGia.dgvDocGia.DataSource = dal_DocGia.DAL_TimKiem(docGia.txtTimKiem.Text);
        }
    }
}
