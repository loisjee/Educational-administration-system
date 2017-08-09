using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class TeacherTop : System.Web.UI.Page
{
    public Teacher teacher = new Teacher();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Teacher"] != null)
        {
            teacher = (Teacher)Session["Teacher"];
        }
        else
        {
            Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
        }
    }

    protected void imgbOut_Click(object sender, ImageClickEventArgs e)
    {
        Session["Teacher"] = null;
        Response.Write("<script>top.location.href='Login.aspx'</script>");
    }
}