using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class ResultsManage : System.Web.UI.Page
{
    public string strWhere="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindsTypes();
            if (Request.QueryString["uid"] != null)
            {
                Results model = ResultsBLL.GetIdByResults(Convert.ToInt32(Request.QueryString["uid"]));
                txtScore.Value = model.Score!=(-1)?model.Score.ToString().Trim():"";
                ddlCourseId.SelectedValue = model.CourseId.ToString();
                ddlSemesterId.SelectedValue = model.SemesterId.ToString();
                ddlSutId.SelectedValue = model.SutId.ToString();
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void BindsTypes()
    {
        ddlCourseId.DataSource = CourseBLL.AllData("", "CourseId", "");
        ddlCourseId.DataTextField = "CourseName";
        ddlCourseId.DataValueField = "CourseId";
        ddlCourseId.DataBind();

        ddlSutId.DataSource = SudentsBLL.AllData("", "SutId", "");
        ddlSutId.DataTextField = "SutName";
        ddlSutId.DataValueField = "SutId";
        ddlSutId.DataBind();


        ddlSemesterId.DataSource = SemesterBLL.AllData("", "SemesterId", "");
        ddlSemesterId.DataTextField = "SemesterName";
        ddlSemesterId.DataValueField = "SemesterId";
        ddlSemesterId.DataBind();

        ddlSemesterName.DataSource = SemesterBLL.AllData("", "SemesterId", "");
        ddlSemesterName.DataTextField = "SemesterName";
        ddlSemesterName.DataValueField = "SemesterId";
        ddlSemesterName.DataBind();
        ddlSemesterName.Items.Insert(0, new ListItem("全部", "0"));


        ddlCourseName.DataSource = CourseBLL.AllData("", "CourseId", "");
        ddlCourseName.DataTextField = "CourseName";
        ddlCourseName.DataValueField = "CourseId";
        ddlCourseName.DataBind();
        ddlCourseName.Items.Insert(0, new ListItem("全部", "0"));
    }

    private void Binds()
    {
        if (ddlSemesterName.SelectedValue != "0")
        {
            strWhere += " and Semester.SemesterId=" + ddlSemesterName.SelectedValue;
        }

        if (ddlCourseName.SelectedValue != "0")
        {
            strWhere += " and Course.CourseId=" + ddlCourseName.SelectedValue;
        }
        if (txtSutName.Value.Length != 0)
        {
            strWhere += " and Sudents.SutName='"+txtSutName.Value.Trim()+"'";
        }


        rpView.DataSource = ResultsBLL.GetAllData(strWhere, "Results.Score", "desc");
        rpView.DataBind();



        rpPrint.DataSource = ResultsBLL.GetAllData(strWhere, "Results.Score", "desc");
        rpPrint.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Results model = new Results();
            model.CourseId = Convert.ToInt32(ddlCourseId.SelectedValue);
            model.Score = Convert.ToInt32(txtScore.Value.Trim());
            model.SemesterId = Convert.ToInt32(ddlSemesterId.SelectedValue);
            model.SutId = Convert.ToInt32(ddlSutId.SelectedValue);
            if (ResultsBLL.AddResults(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('ResultsManage.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败！');</script>");
                return;
            }

        }
        else
        {
            Results model = ResultsBLL.GetIdByResults(Convert.ToInt32(Request.QueryString["uid"]));
            model.CourseId = Convert.ToInt32(ddlCourseId.SelectedValue);
            model.Score = Convert.ToInt32(txtScore.Value.Trim());
            model.SemesterId = Convert.ToInt32(ddlSemesterId.SelectedValue);
            model.SutId = Convert.ToInt32(ddlSutId.SelectedValue);
            if (ResultsBLL.UpdateResults(model) > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('ResultsManage.aspx');</script>");
                return;
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
                return;
            }
        }
    }
    protected void lnkbDel_Click(object sender, EventArgs e)
    {
        LinkButton lnkbDel = (LinkButton)sender;

        if (ResultsBLL.DeleteResults(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('ResultsManage.aspx');</script>");
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