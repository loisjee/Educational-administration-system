using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class SudentsAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindsTypes();

            if (Request.QueryString["uid"] != null)
            {
                Sudents model = SudentsBLL.GetIdBySudents(Convert.ToInt32(Request.QueryString["uid"]));

               
                ddlGrade.SelectedValue = model.Grade.ToString();
                ddlMajorId.SelectedValue = ClassBLL.GetIdByClass(model.ClassId).MajorId.ToString();

  ddlClassId.DataSource = ClassBLL.AllData(" and MajorId =" + ddlMajorId.SelectedValue, "ClassId", "asc");
                ddlClassId.DataTextField = "ClassName";
                ddlClassId.DataValueField = "ClassId";
                ddlClassId.DataBind();

                ddlClassId.SelectedValue = model.ClassId.ToString();
                ddlNational.SelectedValue = model.National.Trim();
                ddlPolitical.SelectedValue = model.Political.Trim();
                txtBorn.Value = model.Born.ToString("yyyy-MM-dd") != "1900-01-01" ? model.Born.ToString("yyyy-MM-dd") : "";
                txtContact.Value = model.Contact.Trim();
                txtNative.Value = model.Native.Trim();
                txtNote.Value = model.Note.Trim();
                txtPwd.Value = model.Pwd.Trim();
                txtSutCode.Value = model.SutCode.Trim();
                txtSutName.Value = model.SutName.Trim();
                ddlSex.SelectedValue = model.Sex.Trim();
                btnAdd.Text = "修改";
            }

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
    



    //添加、修改
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (btnAdd.Text == "添加")
        {
            Sudents model = new Sudents();
            model.Born = txtBorn.Value != "" ? Convert.ToDateTime(txtBorn.Value) : Convert.ToDateTime("1900-01-01");
            model.ClassId = Convert.ToInt32(ddlClassId.SelectedValue);
            model.Contact = txtContact.Value.Trim();
            model.Grade = Convert.ToInt32(ddlGrade.SelectedValue);
            model.National = ddlNational.SelectedValue.Trim();
            model.Native = txtNative.Value.Trim();
            model.Note = txtNote.Value.Trim();
            model.Political = ddlPolitical.SelectedValue.Trim();
            model.Pwd = txtPwd.Value.Trim();
            model.Sex=ddlSex.SelectedValue.Trim();
            model.SutCode = txtSutCode.Value.Trim();
            model.SutName = txtSutName.Value.Trim();

            if (SudentsBLL.IsTrue(model.SutCode))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该学号已经存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (SudentsBLL.AddSudents(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！');window.location.replace('SudentsManage.aspx');</script>");
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
            Sudents model = SudentsBLL.GetIdBySudents(Convert.ToInt32(Request.QueryString["uid"]));
            model.Born = txtBorn.Value != "" ? Convert.ToDateTime(txtBorn.Value) : Convert.ToDateTime("1900-01-01");
            model.ClassId = Convert.ToInt32(ddlClassId.SelectedValue);
            model.Contact = txtContact.Value.Trim();
            model.Grade = Convert.ToInt32(ddlGrade.SelectedValue);
            model.National = ddlNational.SelectedValue.Trim();
            model.Native = txtNative.Value.Trim();
            model.Note = txtNote.Value.Trim();
            model.Political = ddlPolitical.SelectedValue.Trim();
            model.Pwd = txtPwd.Value.Trim();
            model.Sex=ddlSex.SelectedValue.Trim();
            model.SutCode = txtSutCode.Value.Trim();
            model.SutName = txtSutName.Value.Trim();

            if (SudentsBLL.IsTrue(model.SutCode,model.SutId))
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该学号已经存在，不能重复！');</script>");
                return;
            }
            else
            {
                if (SudentsBLL.UpdateSudents(model) > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');window.location.replace('SudentsManage.aspx');</script>");
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
    protected void ddlMajorId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlClassId.DataSource = ClassBLL.AllData(" and MajorId =" + ddlMajorId.SelectedValue, "ClassId", "asc");
        ddlClassId.DataTextField = "ClassName";
        ddlClassId.DataValueField = "ClassId";
        ddlClassId.DataBind();
    }
}