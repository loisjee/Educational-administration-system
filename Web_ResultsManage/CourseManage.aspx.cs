using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class CourseManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Course model = CourseBLL.GetIdByCourse(Convert.ToInt32(Request.QueryString["uid"]));
                txtCourseName.Value = model.CourseName.Trim();
                txtCredits.Value = model.Credits.ToString().Trim();
                txtNote.Value = model.Note.Trim();
                ddlTeacherId.SelectedValue = model.TeacherId.ToString();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {
        ddlTeacherId.DataSource = TeacherBLL.AllData("", "TeacherId", "");
        ddlTeacherId.DataTextField = "TeacherName";
        ddlTeacherId.DataValueField = "TeacherId";
        ddlTeacherId.DataBind();

        rpView.DataSource = CourseBLL.AllData("", "CourseId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Course model = new Course();
            model.CourseName = txtCourseName.Value.Trim();
            model.Credits = Convert.ToInt32(txtCredits.Value.Trim());
            model.Note = txtNote.Value.Trim();
            model.TeacherId = Convert.ToInt32(ddlTeacherId.SelectedValue);
            if (CourseBLL.IsTrue(model.CourseName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该课程名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (CourseBLL.AddCourse(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('CourseManage.aspx');</script>");
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
            Course model = CourseBLL.GetIdByCourse(Convert.ToInt32(Request.QueryString["uid"]));
            model.CourseName = txtCourseName.Value.Trim();
            model.Credits = Convert.ToInt32(txtCredits.Value.Trim());
            model.Note = txtNote.Value.Trim();
            model.TeacherId = Convert.ToInt32(ddlTeacherId.SelectedValue);
            if (CourseBLL.IsTrue(model.CourseName,model.CourseId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该课程名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (CourseBLL.UpdateCourse(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('CourseManage.aspx');</script>");
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

        if (CourseBLL.DeleteCourse(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('CourseManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
}