using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class PersonalSudents : System.Web.UI.Page
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
            BindsTypes();
            Sudents sud = SudentsBLL.GetIdBySudents(sudents.SutId);

           
            ddlGrade.SelectedValue = sud.Grade.ToString();
            ddlMajorId.SelectedValue = ClassBLL.GetIdByClass(sud.ClassId).MajorId.ToString();
ddlClassId.DataSource = ClassBLL.AllData(" and MajorId =" + ddlMajorId.SelectedValue, "ClassId", "asc");
            ddlClassId.DataTextField = "ClassName";
            ddlClassId.DataValueField = "ClassId";
            ddlClassId.DataBind();

            ddlClassId.SelectedValue = sud.ClassId.ToString();

            ddlNational.SelectedValue = sud.National.Trim();
            ddlPolitical.SelectedValue = sud.Political.Trim();
            txtBorn.Value = sud.Born.ToString("yyyy-MM-dd") != "1900-01-01" ? sud.Born.ToString("yyyy-MM-dd") : "";
            txtContact.Value = sud.Contact.Trim();
            txtNative.Value = sud.Native.Trim();
            txtNote.Value = sud.Note.Trim();
            lblSutCode.Text = sud.SutCode.Trim();
            txtSutName.Value = sud.SutName.Trim();
            ddlSex.SelectedValue = sud.Sex.Trim();
            lblPwd.Text = sud.Pwd.Trim();

        }

    }

    private void BindsTypes()
    {
        ddlMajorId.DataSource = MajorBLL.AllData("", "MajorId", "asc");
        ddlMajorId.DataTextField = "MajorName";
        ddlMajorId.DataValueField = "MajorId";
        ddlMajorId.DataBind();


        ddlClassId.DataSource = ClassBLL.AllData(" and MajorId =" + ddlMajorId.SelectedValue, "ClassId", "asc");
        ddlClassId.DataTextField = "ClassName";
        ddlClassId.DataValueField = "ClassId";
        ddlClassId.DataBind();

      


    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Sudents sud = SudentsBLL.GetIdBySudents(sudents.SutId);
        sud.Born = txtBorn.Value != "" ? Convert.ToDateTime(txtBorn.Value) : Convert.ToDateTime("1900-01-01");
        sud.ClassId = Convert.ToInt32(ddlClassId.SelectedValue);
        sud.Contact = txtContact.Value.Trim();
        sud.Grade = Convert.ToInt32(ddlGrade.SelectedValue);
        sud.National = ddlNational.SelectedValue.Trim();
        sud.Native = txtNative.Value.Trim();
        sud.Note = txtNote.Value.Trim();
        sud.Political = ddlPolitical.SelectedValue.Trim();
        sud.Pwd = lblPwd.Text.Trim();
        sud.Sex = ddlSex.SelectedValue.Trim();
        sud.SutCode = lblSutCode.Text.Trim();
        sud.SutName = txtSutName.Value.Trim();
        if (SudentsBLL.UpdateSudents(sud) > 0)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('PersonalSudents.aspx');</script>");
            return;
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
            return;
        }


    }
}