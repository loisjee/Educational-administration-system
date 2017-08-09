<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalResults.aspx.cs" Inherits="PersonalResults" %>

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
                                                    <span class="STYLE1">个人成绩查询</span>
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
                                    姓名
                                </th>
                                
                                <th bgcolor="d3eaef">
                                    分数
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
                                      <%#BLL.SudentsBLL.GetIdBySudents(Convert.ToInt32(Eval("SutId"))).SutName%>
                            </td>
                            

                            <td bgcolor="#FFFFFF">
                                    <%#Eval("Score")%>
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
    
    </form>
</body>
</html>
