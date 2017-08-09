using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class AdminTop : System.Web.UI.Page
{
    public Admin admin = new Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
           admin = (Admin)Session["Admin"];
        }
        else
        {
            Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
        }
    }

    protected void imgbOut_Click(object sender, ImageClickEventArgs e)
    {
        Session["Admin"] = null;
        Response.Write("<script>top.location.href='Login.aspx'</script>");
    }
}