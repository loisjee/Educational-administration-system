using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class DepartmentManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Department model = DepartmentBLL.GetIdByDepartment(Convert.ToInt32(Request.QueryString["uid"]));
                txtDeptName.Value = model.DeptName.Trim();
                txtContact.Value = model.Contact.Trim();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {
        rpView.DataSource = DepartmentBLL.AllData("", "DeptId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Department model = new Department();
            model.DeptName = txtDeptName.Value.Trim();
            model.Contact = txtContact.Value.Trim();
            if (DepartmentBLL.IsTrue(model.DeptName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该院系名称已存在，不能重复！');</script>");
                return;
            }
            else
            {

                if (DepartmentBLL.AddDepartment(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('DepartmentManage.aspx');</script>");
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
            Department model = DepartmentBLL.GetIdByDepartment(Convert.ToInt32(Request.QueryString["uid"]));
            model.DeptName = txtDeptName.Value.Trim();
            model.Contact = txtContact.Value.Trim();

            if (DepartmentBLL.IsTrue(model.DeptName,model.DeptId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该院系名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (DepartmentBLL.UpdateDepartment(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('DepartmentManage.aspx');</script>");
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

        if (DepartmentBLL.DeleteDepartment(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('DepartmentManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }
          
    }
}