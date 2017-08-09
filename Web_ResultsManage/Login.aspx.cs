using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgbLogin_Click(object sender, ImageClickEventArgs e)
    {
        //判断是学生、教师、还是老师登录
        if (ddlType.SelectedValue == "学生")      //学生登录
        {
            Sudents sudents = new Sudents();      //验证该学生登录信息是否与数据库中一致
            if (SudentsBLL.GetUsersLogin(txtUserName.Value.Trim(), txtPwd.Value.Trim(), out sudents))
            {                                     //学生登录信息正确，将该学生添加到session并跳转到学生主页
                Session["Sudents"] = sudents;
                Response.Redirect("SudentsMain.aspx", false);
            }
            else
            {                                     //学生登录信息错误，提示登录错误
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "<script>alert('用户名或者密码错误！');</script>");
                return;
            }
        }
        else if (ddlType.SelectedValue == "教师") //教师登录
        {

            Teacher teacher = new Teacher();      //验证该教师登录信息是否与数据库中一致
            if (TeacherBLL.GetUsersLogin(txtUserName.Value.Trim(), txtPwd.Value.Trim(), out teacher))
            {                                     //教师登录信息正确，将该教师添加到session中并跳转到教师主页
                Session["Teacher"] = teacher;
                Response.Redirect("TeacherMain.aspx", false);
            }
            else
            {                                     //教师登录信息错误，提示登录错误
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "<script>alert('用户名或者密码错误！');</script>");
                return;
            }
        }
        else if (ddlType.SelectedValue == "管理员")//管理员登录
        {
            Admin admin = new Admin();             //验证该管理员信息是否与数据库中一致
            if (AdminBLL.GetUsersLogin(txtUserName.Value.Trim(), txtPwd.Value.Trim(), out admin))
            {                                      //管理员登录信息正确，将该管理员添加到session中并跳转到管理员主页
                Session["Admin"] = admin;
                Response.Redirect("AdminMain.aspx", false);
            }
            else
            {                                      //管理员登录信息错误，提示登录错误
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "<script>alert('用户名或者密码错误！');</script>");
                return;
            }
        }

    }
    //将两个输入框中的文本清空
    protected void imgbReset_Click(object sender, ImageClickEventArgs e)
    {
        txtUserName.Value = "";
        txtPwd.Value = "";
    }
}