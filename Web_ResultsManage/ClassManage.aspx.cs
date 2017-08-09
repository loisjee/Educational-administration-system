using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ClassManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Class model = ClassBLL.GetIdByClass(Convert.ToInt32(Request.QueryString["uid"]));

                txtClassName.Value = model.ClassName.Trim();
                ddlMajorId.SelectedValue = model.MajorId.ToString();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {

        ddlMajorId.DataSource = MajorBLL.AllData("", "MajorId", "");
        ddlMajorId.DataTextField = "MajorName";
        ddlMajorId.DataValueField = "MajorId";
        ddlMajorId.DataBind();

        rpView.DataSource = ClassBLL.AllData("", "ClassId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Class model = new Class();
            model.ClassName = txtClassName.Value.Trim();
            model.MajorId = Convert.ToInt32(ddlMajorId.SelectedValue);

            if (ClassBLL.IsTrue(model.ClassName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该班级名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (ClassBLL.AddClass(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('ClassManage.aspx');</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                    return;
                }
            }

        }
        else
        {
            Class model = ClassBLL.GetIdByClass(Convert.ToInt32(Request.QueryString["uid"]));
            model.ClassName = txtClassName.Value.Trim();
            model.MajorId = Convert.ToInt32(ddlMajorId.SelectedValue);

            if (ClassBLL.IsTrue(model.ClassName,model.ClassId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该班级名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (ClassBLL.UpdateClass(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('ClassManage.aspx');</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
                    return;
                }
            }
        }
    }
    protected void lnkbDel_Click(object sender, EventArgs e)
    {
        LinkButton lnkbDel = (LinkButton)sender;

        if (ClassBLL.DeleteClass(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('ClassManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
}