using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Help;
using System.Data;
using DataAccess.Connect;

namespace DataAccess.Classes
{
    public class VanBan
    {
        #region khai bao cac thuoc tinh anh xa

        public int ID { get; set; }
        public string SoHieu { get; set; }
        public string TenVanBan { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string DuongDan { get; set; }
        public int IDTheLoai { get; set; }

        //Anh xa tu bang the loai
        public string TenTheLoai_Vn { get; set; }
        public VanBan() { }

        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(VanBan noiDung)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "VanBan_Them", noiDung.ID, noiDung.SoHieu,
                    noiDung.TenVanBan, noiDung.MoTa, noiDung.NgayBanHanh, noiDung.DuongDan, noiDung.IDTheLoai);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }
        }
        public static bool Sua(VanBan noiDung)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("VanBan_Sua", noiDung.ID, noiDung.SoHieu,
                    noiDung.TenVanBan, noiDung.MoTa, noiDung.NgayBanHanh, noiDung.DuongDan, noiDung.IDTheLoai);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaLuotXem(string id, string luotXem)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("VanBan_SuaLuotXem", Convert.ToInt32(id), Convert.ToInt32(luotXem));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaLuotXemTangLen1(string id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("[VanBan_SuaLuotXemTangLen1]", Convert.ToInt32(id));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTrangThai(string id, string trangThai)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("VanBan_SuaTrangThai", Convert.ToInt32(id), Convert.ToInt32(trangThai));
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTrangChu(int id, bool trangChu)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("VanBan_SuaTrangChu", id, trangChu);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Xoa(string id)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("VanBan_Xoa", Convert.ToInt32(id));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("VanBan_Dem"));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTrangThai(string trangThai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("VanBan_DemTheoTrangThai", ConvertType.ToInt32(trangThai)));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoModule(string module)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("VanBan_DemTheoModule", ConvertType.ToInt32(module)));
            }
            catch
            {
                return 0;
            }
        }
        public static int DemTheoTheLoai(string idTheLoai)
        {
            try
            {
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("VanBan_DemTheoTheLoai", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            {
                return 0;
            }
        }
        public static List<VanBan> LayTheoIDTheLoai_List(string id)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoai", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static VanBan LayTheoID(string id)
        {
            try
            {
                //return ctx.VanBan_LayTheoID(Convert.ToInt32(id)).ToList().First();
                return CBO.FillObject<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }
        public static VanBan LayTheoIDTheLoai(string id)
        {
            try
            {
                return CBO.FillObject<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoai", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<VanBan> LayTheoParentNoPaging(string theloai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoParentNoPaging", ConvertType.ToInt32(theloai)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoTheLoaiKoPhanTrang(string theloai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoai", ConvertType.ToInt32(theloai)));
            }
            catch
            { return null; }
        }

        public static List<VanBan> GetAll()
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_GetAll"));
            }
            catch
            { return null; }
        }

        public static List<VanBan> LayTheoIDParentTop6(string idParent)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDParentTop6", ConvertType.ToInt32(idParent)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoIDParentTop8(string idParent)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDParentTop8", ConvertType.ToInt32(idParent)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoIDParentTop2(string parent)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDParentTop2", ConvertType.ToInt32(parent)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoIDTheLoaiTop6(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoaiTop6", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoIDTheLoaiTop10(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoaiTop10", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoIDTheLoaiTop20(string idtheloai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoIDTheLoaiTop20", ConvertType.ToInt32(idtheloai)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTatCa(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTatCa", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();

                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoParent(string parent, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoParent", ConvertType.ToInt32(parent), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoTheLoai_All(string idTheLoai)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoTheLoai_All", ConvertType.ToInt32(idTheLoai)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoTheLoai(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoTheLoai_4item(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = 6;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, 6);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);

                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }


        //Phan trang trong thủ tục
        public static List<VanBan> LayDanhSachVanBanVaPhanTrangTrongThuTuc(string IDTheLoai, string page, int recordPerPage, int pageSize, out string chuoiPhanTrang)
        {
            IDataReader reader = null;
            try
            {
                pageSize = 6;
                reader = DataProvider.Instance.ExecuteReader("spVanBan_PhanTrang", ConvertType.ToInt32(IDTheLoai), ConvertType.ToInt32(page), recordPerPage, pageSize);

                reader.Read();
                chuoiPhanTrang = reader.GetString(0);

                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                chuoiPhanTrang = "";
                return new List<VanBan>();
            }
        }
        //Phan trang trong thủ tục - end


        public static List<VanBan> LayTheoTheLoai20Page(string idTheLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize2;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTheLoai", ConvertType.ToInt32(idTheLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize2);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoModuleTop20(string idmodule)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoModule_Top20", ConvertType.ToInt32(idmodule)));
            }
            catch
            { return null; }
        }

        public static List<VanBan> LayTheoModuleAll(string idmodule)
        {
            try
            {
                return CBO.FillCollection<VanBan>(DataProvider.Instance.ExecuteReader("VanBan_LayTheoModule_All", ConvertType.ToInt32(idmodule)));
            }
            catch
            { return null; }
        }
        public static List<VanBan> LayTheoModule(string module, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoModule", ConvertType.ToInt32(module), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoTrangThai(string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTrangThai", ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoTrangThaiVaModule(string module, string trangThai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTrangThaiVaModule", ConvertType.ToInt32(module), ConvertType.ToInt32(trangThai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoLoaiMenuVaTrangThai(string trangThai, string loaiMenu, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoLoaiMenuVaTrangThai", ConvertType.ToInt32(trangThai), ConvertType.ToInt32(loaiMenu), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> LayTheoIDTheLoai(string theLoai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("VanBan_LayTheoTheLoai", ConvertType.ToInt32(theLoai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> TimKiem(string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize1;
                reader = DataProvider.Instance.ExecuteReader("VanBan_TimKiem", sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize1);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> TimTheoModule(string module, string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_TimTheoModule", ConvertType.ToInt32(module), sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }

        public static List<VanBan> TimTheoModule_ExceptID(string module, string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_TimTheoModule_ExceptID", ConvertType.ToInt32(module), sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        public static List<VanBan> TimTheoTheLoai(string sreach, string theloai, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("VanBan_TimTheoTheLoai", sreach, ConvertType.ToInt32(theloai), GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<VanBan>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<VanBan>();
            }
        }
        #endregion
    }
}
