using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class UpdatePwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {
            Admin admin = (Admin)Session["Admin"];
            if (admin.Pwd != txtOldPwd.Value.Trim())
            {
                txtOldPwd.Focus();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('旧密码错误！');</script>");
                return;

            }
            else
            {
                admin.Pwd = txtNewPwd.Value.Trim();
                if (AdminBLL.UpdateUsers(admin) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码成功！\\n新密码为：" + txtNewPwd.Value.Trim() + "');location=location;</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码失败！');</script>");
                    return;
                }
            }
        }
        if (Session["Teacher"] != null)
        {
            Teacher teacher = (Teacher)Session["Teacher"];
            if (teacher.Pwd != txtOldPwd.Value.Trim())
            {
                txtOldPwd.Focus();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('旧密码错误！');</script>");
                return;

            }
            else
            {
                teacher.Pwd = txtNewPwd.Value.Trim();
                if (TeacherBLL.UpdateTeacher(teacher) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码成功！\\n新密码为：" + txtNewPwd.Value.Trim() + "');location=location;</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码失败！');</script>");
                    return;
                }
            }
        }
        if (Session["Sudents"] != null)
        {
            Sudents sudents = (Sudents)Session["Sudents"];
            if (sudents.Pwd != txtOldPwd.Value.Trim())
            {
                txtOldPwd.Focus();
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('旧密码错误！');</script>");
                return;

            }
            else
            {
                sudents.Pwd = txtNewPwd.Value.Trim();
                if (SudentsBLL.UpdateSudents(sudents) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码成功！\\n新密码为：" + txtNewPwd.Value.Trim() + "');location=location;</script>");
                    return;
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码失败！');</script>");
                    return;
                }
            }
        }
    }
}