using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class SudentsTop : System.Web.UI.Page
{
    public Sudents sudents = new Sudents();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Sudents"] != null)
        {
            sudents = (Sudents)Session["Sudents"];
        }
        else
        {
            Response.Write("<script>parent.window.location.href='Login.aspx'</script>");
        }
    }
    protected void imgbOut_Click(object sender, ImageClickEventArgs e)
    {
        Session["Sudents"] = null;
        Response.Write("<script>top.location.href='Login.aspx'</script>");
    }
}