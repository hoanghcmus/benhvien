using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Classes;

public partial class UserControl_UC_Left_Video_Block : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<ImageAndClips> imageAndClipsFirst = ImageAndClips.LayDanhSachTheoSoLuong(12, 0, 1);
            if (imageAndClipsFirst != null)
            {
                rptVideoFirst.DataSource = imageAndClipsFirst;
                rptVideoFirst.DataBind();
            }
            List<ImageAndClips> listImageAndClipsRemain = ImageAndClips.LayDanhSachTheoSoLuong(12, 2, 4);
            if (listImageAndClipsRemain != null)
            {
                rptVideoRemain.DataSource = listImageAndClipsRemain;
                rptVideoRemain.DataBind();
            }
        }
    }
}