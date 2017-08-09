<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalElective.aspx.cs" Inherits="PersonalElective" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <style type="text/css">
        body
        {
            margin-left: 3px;
            margin-top: 0px;
            margin-right: 3px;
            margin-bottom: 0px;
        }
        .STYLE1
        {
            color: #e1e2e3;
            font-size: 12px;
        }
       
        .STYLE22
        {
            font-size: 12px;
            color: #295568;
             text-decoration:none;
        }
    </style>
    
      
    
</head>
<body>
    <form id="form1" runat="server">

    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="24" bgcolor="#353c44">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="3%" height="19" valign="bottom">
                                                    <div align="center">
                                                        <img src="images/tb.gif" width="14" height="14" /></div>
                                                </td>
                                                <td width="97%" valign="bottom">
                                                    <span class="STYLE1">个人学生选课</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <div align="right">
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Repeater ID="rpView" runat="server">
                <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
                            style="line-height: 25px; text-align: center; font-size: 12px; color: #344b50;">
                            <tr>
                                <th bgcolor="d3eaef">
                                    序号
                                </th>
                               
                              <th bgcolor="d3eaef">
                                    课程名称
                                </th>
                                

                                 <th bgcolor="d3eaef">
                                    学期名称
                                </th>
                                
                               
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                           
                            <td bgcolor="#FFFFFF">
                                <%#Container.ItemIndex + 1 %>
                            </td>
                             
                              <td bgcolor="#FFFFFF">
                                <%#BLL.CourseBLL.GetIdByCourse(Convert.ToInt32(Eval("CourseId"))).CourseName%>
                            </td>

                          
                            

                          
                            
                            <td bgcolor="#FFFFFF">
                                          <%#BLL.SemesterBLL.GetIdBySemester(Convert.ToInt32(Eval("SemesterId"))).SemesterName%>
                            </td>
                           
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        </FooterTemplate>
                        </asp:Repeater>
            </td>
        </tr>
        
    </table>
    <fieldset style="height:50px;  font-size:12px;color: #344b50; border:1px solid #344b50">
   <legend>选课提交</legend>
   
    &nbsp;&nbsp;&nbsp;课程名称：<asp:DropDownList
        ID="ddlCourseId" runat="server">
    </asp:DropDownList>&nbsp;学期名称：<asp:DropDownList
        ID="ddlSemesterId" runat="server">
    </asp:DropDownList>&nbsp;<asp:Button 
            ID="btnAdd" runat="server"   style="width:60px;" 
            Text="确定" OnClientClick="return confirm('确定要选择该课程？')" onclick="btnAdd_Click" /><span style="color: Red;">* 注：确定后不可取消，如要取消请联系管理员。</span>
    </fieldset>
    </form>
</body>
</html>
