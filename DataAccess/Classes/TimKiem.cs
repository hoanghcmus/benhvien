using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Core;
using DataAccess.Connect;

namespace DataAccess.Classes
{
    public class TimKiem
    {
        #region khai bao cac thuoc tinh anh xa tim kiem
        public int ID { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string Module { get; set; }

        public TimKiem() { }
        #endregion

        #region cac phuong thuc tim kiem
        public static List<TimKiem> TimKiemTuBaiVietVaHoiDap(string tuKhoa)
        {
            try
            {
                return CBO.FillCollection<TimKiem>(DataProvider.Instance.ExecuteReader("TimKiem_BaiViet_Va_HoiDap_All", tuKhoa));
            }
            catch
            { return null; }
        }

        public static List<TimKiem> TimKiemThongTin(string sreach, string page, int pageSize, out int howManyPages)
        {
            IDataReader reader = null;
            try
            {

                reader = DataProvider.Instance.ExecuteReader("TimKiem_BaiViet_Va_HoiDap", sreach, page, pageSize);
                reader.Read();
                howManyPages = (int)Math.Ceiling((double)reader.GetInt32(0) / (double)pageSize);
                reader.NextResult();
                return CBO.FillCollection<TimKiem>(reader);
            }
            catch
            {
                if (reader != null && reader.IsClosed == false)
                    reader.Close();
                howManyPages = 0;
                return new List<TimKiem>();
            }
        }
        #endregion
    }
}
