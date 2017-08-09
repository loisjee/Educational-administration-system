using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class SudentsManage : System.Web.UI.Page
{
    public string strWhere = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlClassId.DataSource = ClassBLL.AllData("", "ClassId", "");
            ddlClassId.DataTextField = "ClassName";
            ddlClassId.DataValueField = "ClassId";
            ddlClassId.DataBind();
            ddlClassId.Items.Insert(0, new ListItem("全部", "0"));

            Binds();
        }
    }

    private void Binds()
    {
        if (ddlClassId.SelectedValue != "0")
        {
            strWhere += " and ClassId="+ddlClassId.SelectedValue;
        }
        if (txtSutCode.Value.Length != 0)
        {
            strWhere += " and SutCode like '%" + txtSutCode.Value.Trim()+"%'";
        }
        if (txtSutName.Value.Length != 0)
        {
            strWhere += " and SutName like '%" + txtSutName.Value.Trim()+"%'";
        }
        

        rpView.DataSource = SudentsBLL.AllData(strWhere, "SutId", "asc");
        rpView.DataBind();

        rpPrint.DataSource = SudentsBLL.AllData(strWhere, "SutId", "asc");
        rpPrint.DataBind();
    }


    protected void lnkbDel_Click(object sender, EventArgs e)
    {
        LinkButton lnkbDel = (LinkButton)sender;

        if (SudentsBLL.DeleteSudents(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('SudentsManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Binds();
    }
}