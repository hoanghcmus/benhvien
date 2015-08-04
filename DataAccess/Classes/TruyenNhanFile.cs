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
    public class TruyenNhanFile
    {
        #region khai bao cac thuoc tinh anh xa
        public int ID { get; set; }
        public int IDThanhVienGui { get; set; }
        public string DuongDan { get; set; }
        public string MoTa { get; set; }
        public int IDThanhVienNhan { get; set; }
        public string NgayGui { get; set; }

        public string TenThanhVienGui { get; set; }
        public string TenThanhVienNhan { get; set; }

        public TruyenNhanFile() { }
        #endregion

        #region Cac phuong thuc Update du lieu
        public static int Them(TruyenNhanFile nd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQueryWithOutput("@ID", "TruyenNhanFile_Them", nd.ID, nd.IDThanhVienGui, nd.DuongDan, nd.MoTa, nd.IDThanhVienNhan, nd.NgayGui);
                return Convert.ToInt32(rs);
            }
            catch
            {
                return 0;
            }

        }
        public static bool Sua(TruyenNhanFile nd)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TruyenNhanFile_Sua", nd.ID, nd.IDThanhVienGui, nd.DuongDan, nd.MoTa, nd.IDThanhVienNhan, nd.NgayGui);
                return Convert.ToInt32(rs) > 0;
            }
            catch
            {
                return false;
            }
        }
        public static bool Xoa(string idTruyenNhanFile)
        {
            try
            {
                object rs = DataProvider.Instance.ExecuteNonQuery("TruyenNhanFile_Xoa", Convert.ToInt32(idTruyenNhanFile));
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
                return Convert.ToInt32(DataProvider.Instance.ExecuteScalar("TruyenNhanFile_Dem"));
            }
            catch
            {
                return 0;
            }
        }

        public static TruyenNhanFile LayTheoID(string id)
        {
            try
            {
                return CBO.FillObject<TruyenNhanFile>(DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTheoID", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<TruyenNhanFile> LayTatCa()
        {
            try
            {
                return CBO.FillCollection<TruyenNhanFile>(DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTatCa"));
            }
            catch
            {
                return null;
            }
        }

        public static List<TruyenNhanFile> LayTatCa_TheoTV(string id)
        {
            try
            {
                return CBO.FillCollection<TruyenNhanFile>(DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTatCa_TheoTV", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<TruyenNhanFile> LayTatCa_Nhan(string id)
        {
            try
            {
                return CBO.FillCollection<TruyenNhanFile>(DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTatCa_Nhan", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<TruyenNhanFile> LayTatCa_Gui(string id)
        {
            try
            {
                return CBO.FillCollection<TruyenNhanFile>(DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTatCa_Gui", Convert.ToInt32(id)));
            }
            catch
            {
                return null;
            }
        }

        public static List<TruyenNhanFile> Tim(string sreach, string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("TruyenNhanFile_Tim", sreach, GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<TruyenNhanFile>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<TruyenNhanFile>();
            }
        }

        public static List<TruyenNhanFile> LayTatCa_PhanTrang(string page, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {
                int pageSize = GlobalConfiguration.PageSize;
                reader = DataProvider.Instance.ExecuteReader("TruyenNhanFile_LayTatCa_PhanTrang", GlobalConfiguration.DescriptionLength, page, GlobalConfiguration.PageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<TruyenNhanFile>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<TruyenNhanFile>();
            }
        }


        #endregion
    }

}
