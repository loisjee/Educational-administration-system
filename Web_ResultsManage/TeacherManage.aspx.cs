using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class TeacherManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Teacher model = TeacherBLL.GetIdByTeacher(Convert.ToInt32(Request.QueryString["uid"]));
                txtPwd.Value = model.Pwd.Trim();
                txtTeacherCode.Value = model.TeacherCode.Trim();
                txtTeacherName.Value = model.TeacherName.Trim();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {
        rpView.DataSource = TeacherBLL.AllData("", "TeacherId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Teacher model = new Teacher();
            model.Pwd = txtPwd.Value.Trim();
            model.TeacherCode = txtTeacherCode.Value.Trim();
            model.TeacherName = txtTeacherName.Value.Trim();

            if (TeacherBLL.IsTrue(model.TeacherCode))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该教工号已经存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (TeacherBLL.AddTeacher(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('TeacherManage.aspx');</script>");
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
            Teacher model = TeacherBLL.GetIdByTeacher(Convert.ToInt32(Request.QueryString["uid"]));
            model.Pwd = txtPwd.Value.Trim();
            model.TeacherCode = txtTeacherCode.Value.Trim();
            model.TeacherName = txtTeacherName.Value.Trim();
            if (TeacherBLL.IsTrue(model.TeacherCode,model.TeacherId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该教工号已经存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (TeacherBLL.UpdateTeacher(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('TeacherManage.aspx');</script>");
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

        if (TeacherBLL.DeleteTeacher(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('TeacherManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
}