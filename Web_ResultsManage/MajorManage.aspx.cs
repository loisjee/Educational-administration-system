using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class MajorManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Major model = MajorBLL.GetIdByMajor(Convert.ToInt32(Request.QueryString["uid"]));
                
                txtMajorName.Value = model.MajorName.Trim();
                txtNote.Value = model.Note.Trim();
                ddlDeptId.SelectedValue = model.DeptId.ToString();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {
        ddlDeptId.DataSource = DepartmentBLL.AllData("", "DeptId", "");
        ddlDeptId.DataTextField = "DeptName";
        ddlDeptId.DataValueField = "DeptId";
        ddlDeptId.DataBind();

        rpView.DataSource = MajorBLL.AllData("", "MajorId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Major model = new Major();
            model.DeptId = Convert.ToInt32(ddlDeptId.SelectedValue);
            model.MajorName = txtMajorName.Value.Trim();
            model.Note = txtNote.Value.Trim();
            if (MajorBLL.IsTrue(model.MajorName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该专业名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (MajorBLL.AddMajor(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('MajorManage.aspx');</script>");
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
            Major model = MajorBLL.GetIdByMajor(Convert.ToInt32(Request.QueryString["uid"]));
            model.DeptId = Convert.ToInt32(ddlDeptId.SelectedValue);
            model.MajorName = txtMajorName.Value.Trim();
            model.Note = txtNote.Value.Trim();
            if (MajorBLL.IsTrue(model.MajorName,model.MajorId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该专业名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (MajorBLL.UpdateMajor(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('MajorManage.aspx');</script>");
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

        if (MajorBLL.DeleteMajor(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('MajorManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
}