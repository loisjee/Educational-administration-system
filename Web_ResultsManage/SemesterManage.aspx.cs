using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
public partial class SemesterManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["uid"] != null)
            {
                Semester model = SemesterBLL.GetIdBySemester(Convert.ToInt32(Request.QueryString["uid"]));
                txtSemesterName.Value = model.SemesterName.Trim();
                
                btnAdd.Text = "修改";
            }
            Binds();
        }
    }

    private void Binds()
    {
        rpView.DataSource = SemesterBLL.AllData("", "SemesterId", "asc");
        rpView.DataBind();
    }

    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Semester model = new Semester();
            model.SemesterName = txtSemesterName.Value.Trim();

            if (SemesterBLL.IsTrue(model.SemesterName))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该学期名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (SemesterBLL.AddSemester(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('SemesterManage.aspx');</script>");
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
            Semester model = SemesterBLL.GetIdBySemester(Convert.ToInt32(Request.QueryString["uid"]));
            model.SemesterName = txtSemesterName.Value.Trim();
            if (SemesterBLL.IsTrue(model.SemesterName,model.SemesterId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该学期名称已存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (SemesterBLL.UpdateSemester(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('SemesterManage.aspx');</script>");
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

        if (SemesterBLL.DeleteSemester(Convert.ToInt32(lnkbDel.CommandArgument)) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');window.location.replace('SemesterManage.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            return;
        }

    }
}