using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class PersonalTeacher : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            Teacher teh = TeacherBLL.GetIdByTeacher(teacher.TeacherId);
            lblTeacherCode.Text = teh.TeacherCode;
            txtTeacherName.Value = teh.TeacherName.Trim();
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Teacher teh = TeacherBLL.GetIdByTeacher(teacher.TeacherId);
        teh.TeacherName = txtTeacherName.Value.Trim();
        if (TeacherBLL.UpdateTeacher(teh) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('PersonalTeacher.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
            return;
        }

       
    }
}