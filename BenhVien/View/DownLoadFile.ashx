<%@ WebHandler Language="C#" Class="DownLoadFile" %>

using System;
using System.Web;

public class DownLoadFile : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
        string fileName = request.QueryString["fileName"];

        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
        
        var server = HttpContext.Current.Server;
        response.TransmitFile(server.MapPath(fileName));
        
        response.Flush();
        response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}