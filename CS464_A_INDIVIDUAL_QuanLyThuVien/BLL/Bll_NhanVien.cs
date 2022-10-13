using CS464_A_INDIVIDUAL_QuanLyThuVien.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.BLL
{
    class Bll_NhanVien
    {
        DAL.Dal_NhanVien dal_NhanVien;
        NhanVien nhanVien;

        public Bll_NhanVien(NhanVien f_NV)
        {
            dal_NhanVien = new DAL.Dal_NhanVien();
            nhanVien = f_NV;
        }
        public void Bll_Load()
        {
            nhanVien.dgvNhanVien.DataSource = dal_NhanVien.loadData();
        }
        public void Bll_Insert()
        {
            dal_NhanVien.DAL_ThemNV(nhanVien.txtMaNhanVien.Text,nhanVien.txtHoTen.Text,Convert.ToDateTime(nhanVien.txtNgaySinh.Text),nhanVien.txtSDT.Text,nhanVien.txtDiaChi.Text);
        }
        public void Bll_Update()
        {
            dal_NhanVien.DAL_SuaNV(nhanVien.txtMaNhanVien.Text, nhanVien.txtHoTen.Text, Convert.ToDateTime(nhanVien.txtNgaySinh.Text), nhanVien.txtSDT.Text, nhanVien.txtDiaChi.Text);
        }
        public void Bll_Delete()
        {
            dal_NhanVien.DAL_XoaNV(nhanVien.txtMaNhanVien.Text);
        }
        public void Bll_Search()
        {
            nhanVien.dgvNhanVien.DataSource = dal_NhanVien.DAL_TimKiem(nhanVien.txtTimKiem.Text);
        }
    }
}
