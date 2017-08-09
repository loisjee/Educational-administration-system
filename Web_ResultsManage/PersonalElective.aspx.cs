using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class PersonalElective : System.Web.UI.Page
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
        ddlCourseId.DataSource = CourseBLL.AllData("", "CourseId", "");
        ddlCourseId.DataTextField = "CourseName";
        ddlCourseId.DataValueField = "CourseId";
        ddlCourseId.DataBind();

        ddlSemesterId.DataSource = SemesterBLL.AllData("", "SemesterId", "");
        ddlSemesterId.DataTextField = "SemesterName";
        ddlSemesterId.DataValueField = "SemesterId";
        ddlSemesterId.DataBind();


        rpView.DataSource = ResultsBLL.AllData(" and SutId=" + sudents.SutId, "ResultsId", "asc");
        rpView.DataBind();
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Results model = new Results();
        model.CourseId = Convert.ToInt32(ddlCourseId.SelectedValue);
        model.SemesterId = Convert.ToInt32(ddlSemesterId.SelectedValue);
        model.SutId = Convert.ToInt32(sudents.SutId);
        model.Score = -1;
        if (ResultsBLL.IsTrue(model.SutId, model.CourseId))
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该课程你已选过！');</script>");
            return;
        }
        else
        {
            if (ResultsBLL.AddResults(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交成功！');window.location.replace('PersonalElective.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('提交失败！');</script>");
                return;
            }
        }
    }
}