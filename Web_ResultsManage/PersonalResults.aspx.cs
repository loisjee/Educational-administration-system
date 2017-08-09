using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class PersonalResults : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            Binds();
        }
    }

    private void Binds()
    {
        rpView.DataSource = ResultsBLL.AllData(" and SutId=" + sudents.SutId + " and Score!="+(-1), "ResultsId", "asc");
        rpView.DataBind();
    }
}