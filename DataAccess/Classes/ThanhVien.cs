using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Help;
using Core;
using System.Data;
using DataAccess.Connect;

namespace DataAccess.Classes
{
    public class ThanhVien
    {
        #region khai bao cac thuoc tinh anh xa
        public int IDNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        //Các thuộc tính kết
        public string TenNguoiDung { get; set; }
        public string ChucVu { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string NgayCapNhat { get; set; }
        public ThanhVien() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(ThanhVien nd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@IDNguoiDung", "ThanhVien_Them", nd.IDNguoiDung,
                   nd.TenDangNhap, nd.MatKhau, nd.TenNguoiDung, nd.ChucVu, nd.DiaChi, nd.NgaySinh, nd.SoDT, nd.NgayCapNhat);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool Sua(ThanhVien nd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("ThanhVien_Sua", nd.IDNguoiDung, nd.TenDangNhap, nd.MatKhau, nd.TenNguoiDung, nd.ChucVu, nd.DiaChi, nd.NgaySinh, nd.SoDT, nd.NgayCapNhat);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Xoa(string idThanhVien)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("ThanhVien_Xoa", Convert.ToInt32(idThanhVien));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Cac phuong thuc truy xuat du lieu
        public static int Dem()
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("ThanhVien_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTenDangNhap(string tenDangNhap)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("ThanhVien_DemTenDangNhap", tenDangNhap));
            }
            catch
            {
                return 0;
            }
        }
        public static ThanhVien KiemTraDangNhapThanhVien(string tenDangNhap, string matKhau)
        {
            try
            {
                return CBO.FillObject<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_KiemTraDangNhap", tenDangNhap, matKhau));
            }
            catch
            {
                return null;
            }
        }
        public static ThanhVien KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                return CBO.FillObject<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_KiemTraDangNhap", tenDangNhap, matKhau));
            }
            catch
            {
                return null;
            }
        }
        public static ThanhVien KiemTraMatKhau(string idThanhVien, string matKhau)
        {
            try
            {
                return CBO.FillObject<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_KiemTraMatKhau", ConvertType.ToInt32(idThanhVien), matKhau));
            }
            catch
            {
                return null;
            }
        }
        public static List<ThanhVien> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }
        public static List<ThanhVien> LayTatCa_EceptID(string ID)
        {
            try
            {
                return CBO.FillCollection<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_LayTatCa_ExceptID", Convert.ToInt32(ID)));
            }
            catch
            {
                return null;
            }
        }
        public static ThanhVien LayThongTinDangNhap(string idThanhVien)
        {
            try
            {
                return CBO.FillObject<ThanhVien>(DataProvider.Instance.ExecuteReader("ThanhVien_LayThongTinDangNhap", ConvertType.ToInt32(idThanhVien)));
            }
            catch
            {
                return null;
            }
        }

        public static List<ThanhVien> Tim(string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("ThanhVien_Tim", sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<ThanhVien>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<ThanhVien>();
            }
        }

        public static List<ThanhVien> LayTatCa_PhanTrang(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("ThanhVien_LayTatCa_PhanTrang", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<ThanhVien>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<ThanhVien>();
            }
        }


        #endregion
    }
}
