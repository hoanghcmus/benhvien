using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DataAccess.Help;

namespace DataAccess.Connect
{
    public static class Link
    {
        #region Uri
        private static string BuildAbsolute(string relativeUrl)
        {
            Uri uri = HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
                app += "/";
            relativeUrl = relativeUrl.TrimStart('/');
            return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUrl));
        }
        #endregion

        #region link Website
        public static string Toimages(string fileName)
        {
            return String.Format(fileName);
        }
        public static string ToFiles(string fileName)
        {
            return String.Format(fileName);
        }
        #endregion

        #region VietNam
        public static string Videos(string trang)
        {
            if (trang == "1")
                return String.Format("../video-clips.html");
            return String.Format("../video-clips.html?Page={0}", trang);
        }
        public static string Videos()
        {
            return Videos("1");
        }
        public static string Photos(string trang)
        {
            if (trang == "1")
                return String.Format("../hinh-anh.html");
            return String.Format("../hinh-anh.html?Page={0}", trang);
        }
        public static string Photos()
        {
            return Photos("1");
        }
        public static string DetailArticle(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return String.Format("../bai-viet/{0}-{1}.html", valus, id);
        }
        public static string DetailAbouts(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return BuildAbsolute(String.Format("../gioi-thieu/{0}-{1}.html", valus, id));
        }
        public static string DetailProduct(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return String.Format("../xem-mon-an/{0}-{1}.html", valus, id);
        }
        public static string DetailBrand(string title, string idbrand, string theloai)
        {
            string valus = Helper.ToSeoString(title);
            return String.Format("../mon-an/{0}-{1}-{2}.html", valus, idbrand, theloai);
        }
        public static string DetailPhoto(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return String.Format("../hinh-anh/{0}-{1}.html", valus, id);
        }
        public static string Categorys(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return String.Format("../the-loai/{0}-{1}.html", valus, theLoai);
            return String.Format("../the-loai/{0}-{1}.html?Page={2}", valus, theLoai, trang);
        }

        public static string Services(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../dich-vu/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../dich-vu/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }


        public static string Categorys(string title, string theLoai)
        {
            return Categorys(title, theLoai, "1");
        }

        public static string TimKiem(string timKiem, string trang)
        {

            if (trang == "1")
                return String.Format("../tim-kiem-{0}.html", timKiem);
            return String.Format("../tim-kiem-{0}.html?Page={1}", timKiem, trang);
        }

        public static string TimKiem(string timkiem)
        {
            return TimKiem(timkiem, "1");
        }

        public static string Services(string title, string theLoai)
        {
            return Services(title, theLoai, "1");
        }
        public static string CategorysList(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../danh-sach-the-loai/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../danh-sach-the-loai/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string CategorysList(string title, string theLoai)
        {
            return CategorysList(title, theLoai, "1");
        }
        public static string Products(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../mon-an/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../mon-an/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string Products(string title, string theLoai)
        {
            return Products(title, theLoai, "1");
        }
        public static string AddToCart(string productId)
        {
            return BuildAbsolute(String.Format("View/ProAddToCart.aspx?ProductID={0}", productId));
        }
        public static string Letter(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../y-kien-khach-hang.html"));
            return BuildAbsolute(String.Format("../y-kien-khach-hang.html?Page={0}", trang));
        }
        public static string Letter()
        {
            return Letter("1");
        }
        #endregion

        #region English
        public static string EnPhotos(string trang)
        {
            if (trang == "1")
                return BuildAbsolute(String.Format("../Photos.html"));
            return BuildAbsolute(String.Format("../Photos.html?Page={0}", trang));
        }
        public static string EnPhotos()
        {
            return EnPhotos("1");
        }
        public static string EnDetailArticle(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return BuildAbsolute(String.Format("../Articles/{0}-{1}.html", valus, id));
        }
        public static string EnDetailAbouts(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return BuildAbsolute(String.Format("../Abouts/{0}-{1}.html", valus, id));
        }
        public static string EnDetailProduct(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return BuildAbsolute(String.Format("../View-Products/{0}-{1}.html", valus, id));
        }
        public static string EnDetailPhoto(string title, string id)
        {
            string valus = Helper.ToSeoString(title);
            return BuildAbsolute(String.Format("../Photos/{0}-{1}.html", valus, id));
        }
        public static string EnCategorys(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Categorys/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Categorys/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnCategorys(string title, string theLoai)
        {
            return EnCategorys(title, theLoai, "1");
        }
        public static string EnCategorysList(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Categorys-list/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Categorys-list/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnCategorysList(string title, string theLoai)
        {
            return EnCategorysList(title, theLoai, "1");
        }
        public static string EnProducts(string title, string theLoai, string trang)
        {
            string valus = Helper.ToSeoString(title);
            if (trang == "1")
                return BuildAbsolute(String.Format("../Products/{0}-{1}.html", valus, theLoai));
            return BuildAbsolute(String.Format("../Products/{0}-{1}.html?Page={2}", valus, theLoai, trang));
        }
        public static string EnProducts(string title, string theLoai)
        {
            return EnProducts(title, theLoai, "1");
        }
        public static string EnAddToCart(string productId)
        {
            return BuildAbsolute(String.Format("En/ProAddToCart.aspx?ProductID={0}", productId));
        }
        #endregion

        #region link Manager Article
        public static string MgerArticle(string _TrangThai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Status={0}", _TrangThai));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Status={0}&Page={1}", _TrangThai, _Trang));
        }
        public static string MgerArticle(string _TrangThai)
        {
            return MgerArticle(_TrangThai, "1");
        }
        public static string EditArticle(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditArticle.aspx?ID={0}", id));
        }
        public static string EditArticleToMenu(string _TheLoai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?ID={0}", _TheLoai));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?ID={0}&Page={1}", _TheLoai, _Trang));
        }
        public static string EditArticleToMenu(string _TheLoai)
        {
            return EditArticleToMenu(_TheLoai, "1");
        }
        public static string EditArticleToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerArticle.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string EditArticleToSreach(string chuoiTimKiem)
        {
            return EditArticleToSreach(chuoiTimKiem, "1");
        }
        public static string MgerContact(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerContact.aspx?Status={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerContact.aspx?Status={0}&Page={1}", _TinhTrang, _Trang));
        }
        public static string MgerContact(string _TinhTrang)
        {
            return MgerContact(_TinhTrang, "1");
        }


        public static string MgerHoiDap(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLetter.aspx?Status={0}", _TinhTrang));
            else
                return BuildAbsolute(String.Format("Admin/MgerLetter.aspx?Status={0}&Page={1}", _TinhTrang, _Trang));
        }
        public static string MgerHoiDap(string _TinhTrang)
        {
            return MgerHoiDap(_TinhTrang, "1");
        }



        public static string HoiDap(string _TinhTrang, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("/hoi-dap.html", _TinhTrang));
            else
                return BuildAbsolute(String.Format("/hoi-dap.html?Page={1}", _TinhTrang, _Trang));
        }
        public static string HoiDap(string _TinhTrang)
        {
            return HoiDap(_TinhTrang, "1");
        }
        #endregion

        #region link Manager Images And Clips
        /// Images
        public static string MgerPhoto(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Page={0}", _Trang));
        }
        public static string MgerPhoto()
        {
            return MgerPhoto("1");
        }
        public static string EditPhoto(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditPhoto.aspx?ID={0}", id));
        }
        public static string MgerPhotoToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerPhoto.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerPhotoToSreach(string chuoiTimKiem)
        {
            return MgerPhotoToSreach(chuoiTimKiem, "1");
        }
        /// Clips-Videos
        public static string MgerVideo(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?"));
            else
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Page={0}", _Trang));
        }
        public static string MgerVideo()
        {
            return MgerVideo("1");
        }
        public static string EditVideo(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditVideo.aspx?ID={0}", id));
        }
        public static string MgerVideoToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerVideo.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerVideoToSreach(string chuoiTimKiem)
        {
            return MgerVideoToSreach(chuoiTimKiem, "1");
        }
        #endregion

        #region link Manager Product
        public static string MgerProduct(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?"));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Page={0}", _Trang));
        }
        public static string MgerProduct()
        {
            return MgerProduct("1");
        }
        public static string EditProduct(string id)
        {
            return BuildAbsolute(String.Format("Admin/EditProduct.aspx?ID={0}", id));
        }
        public static string MgerProductToMenu(string _TheLoai, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?MenuID={0}", _TheLoai));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?MenuID={0}&Page={1}", _TheLoai, _Trang));
        }
        public static string MgerProductToMenu(string _TheLoai)
        {
            return MgerProductToMenu(_TheLoai, "1");
        }
        public static string MgerProductToSreach(string chuoiTimKiem, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Search={0}", chuoiTimKiem));
            else
                return BuildAbsolute(String.Format("Admin/MgerProduct.aspx?Search={0}&Page={1}", chuoiTimKiem, _Trang));
        }
        public static string MgerProductToSreach(string chuoiTimKiem)
        {
            return MgerProductToSreach(chuoiTimKiem, "1");
        }
        #endregion

        #region Link Manager User
        public static string MgerLogin(string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx"));
            else
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?Page={0}", _Trang));
        }
        public static string MgerLogin()
        {
            return MgerLogin("1");
        }

        public static string MgerLoginUser(string _maNguoiDung, string _Trang)
        {
            if (_Trang == "1")
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?User={0}", _maNguoiDung));
            else
                return BuildAbsolute(String.Format("Admin/MgerLogin.aspx?User={0}&Page={1}", _maNguoiDung, _Trang));
        }
        public static string MgerLoginUser(string _maNguoiDung)
        {
            return MgerLoginUser(_maNguoiDung, "1");
        }
        #endregion

    }
}
