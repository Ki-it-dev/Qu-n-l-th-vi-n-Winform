using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_Sach
    {
        DAL.Dal_Sach dal_Sach;
        Sach sach;

        public Bll_Sach(Sach f_Sach)
        {
            dal_Sach = new DAL.Dal_Sach();
            sach = f_Sach;
        }
        public void Bll_Load()
        {
            sach.dgvSach.DataSource = dal_Sach.loadData();
        }
        public void Bll_Insert()
        {
            dal_Sach.DAL_ThemSACH(sach.txtMaSach.Text, sach.txtTenSach.Text, int.Parse(sach.txtNamXuatBan.Text), sach.txtNhaXuatBan.Text);
        }
        public void Bll_Update()
        {
            dal_Sach.DAL_SuaSACH(sach.txtMaSach.Text, sach.txtTenSach.Text, int.Parse(sach.txtNamXuatBan.Text), sach.txtNhaXuatBan.Text);
        }
        public void Bll_Delete()
        {
            dal_Sach.DAL_XoaSACH(sach.txtMaSach.Text);
        }
        public void Bll_Search()
        {
            sach.dgvSach.DataSource = dal_Sach.DAL_TimKiem(sach.txtTimKiem.Text);
        }
    }
}
