using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS464_A_INDIVIDUAL_QuanLyThuVien.DAL
{
    class LopDungChung
    {
        string chuoiketnoi = @"Data Source=DESKTOP-KMNS09Q;Initial Catalog=dbQLTV;Integrated Security=True";
        SqlConnection conn;// = new SqlConnection(chuoiketnoi);
        public LopDungChung()
        {
            conn = new SqlConnection(chuoiketnoi);
        }
        public void Nonquery(string sqlNon)
        {
            SqlCommand comm = new SqlCommand(sqlNon, conn);
            conn.Open();
            try
            {
                int ketqua = comm.ExecuteNonQuery();
                if (ketqua >= 1) MessageBox.Show("Thành công");
                else MessageBox.Show("Lỗi try, ......");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi catch, ....");
            }
            conn.Close();
        }
        public object Scalar(string sqlScalar)
        {
            SqlCommand comm = new SqlCommand(sqlScalar, conn);
            conn.Open();
            int ketqua = (int)comm.ExecuteScalar();
            conn.Close();
            return ketqua;
        }
        public DataTable LoadData(string sqlData)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlData, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
