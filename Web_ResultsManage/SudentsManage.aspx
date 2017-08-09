<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SudentsManage.aspx.cs" Inherits="SudentsManage" %>

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

    <!--调用打印-->
    <script>
        var prehtml;
        function preview() {
            document.getElementById('divPrint').style.display = "block";
            var bdhtml = window.document.body.innerHTML;
            var start = "<!--startprint-->";
            var end = "<!--endprint-->";

            prehtml = bdhtml.substr(bdhtml.indexOf(start) + 17);
            prehtml = prehtml.substring(0, prehtml.indexOf(end));
            //alert(prehtml);
            window.document.body.innerHTML = prehtml;
            window.print();
        }   
    
    </script>
    <!--调用打印-->
    
      
    
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
                                                    <span class="STYLE1">学生信息管理</span>
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
        <tr><td>
        <fieldset style="height:50px;  font-size:12px;color: #344b50; border:1px solid #344b50">
   <legend>查询</legend>
   
    &nbsp;&nbsp;&nbsp;班级名称：<asp:DropDownList ID="ddlClassId"
       runat="server">
   </asp:DropDownList>&nbsp;学号：<input type="text" id="txtSutCode" runat="server" />&nbsp;姓名：<input type="text" id="txtSutName" runat="server" />&nbsp;<asp:Button 
            ID="btnSearch" runat="server"   style="width:60px;" 
            Text="查询" onclick="btnSearch_Click"  />&nbsp;<input id="btnAdd" type="button"  style="width:110px;" onclick="window.location.href='SudentsAdd.aspx'" value="添加学生信息" />
    </fieldset>
    <div style="height:8px;"></div>
        </td></tr>
        <tr>
            <td>
                <!--startprint-->
                <div id="divPrint" style="display:none;">
                <asp:Repeater ID="rpPrint" runat="server">
                <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
                            style="line-height: 25px; text-align: center; font-size: 12px; color: #344b50;">
                            <tr>
                                <th bgcolor="d3eaef">
                                    序号
                                </th>
                                <th bgcolor="d3eaef">
                                    院系名称
                                </th>
                                <th bgcolor="d3eaef">
                                    专业名称
                                </th>
                                <th bgcolor="d3eaef">
                                    班级名称
                                </th>
                                 <th bgcolor="d3eaef">
                                    学号
                                </th>
                                <th bgcolor="d3eaef">
                                    姓名
                                </th>
                                <th bgcolor="d3eaef">
                                    性别
                                </th>
                                
                              
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                           
                            <td bgcolor="#FFFFFF">
                                <%#Container.ItemIndex + 1 %>
                            </td>
                             <td bgcolor="#FFFFFF">
                             <%#BLL.DepartmentBLL.GetIdByDepartment(BLL.MajorBLL.GetIdByMajor(BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).MajorId).DeptId).DeptName%>
                            </td>
                            <td bgcolor="#FFFFFF">
                             <%#BLL.MajorBLL.GetIdByMajor(BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).MajorId).MajorName%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).ClassName%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#Eval("SutCode")%>
                            </td>
                            <td bgcolor="#FFFFFF">
                                      <%#Eval("SutName")%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#Eval("Sex")%>
                            </td>
                          
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        </FooterTemplate>
                        </asp:Repeater>
                        </div>
                <!--endprint-->
                <asp:Repeater ID="rpView" runat="server">
                <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
                            style="line-height: 25px; text-align: center; font-size: 12px; color: #344b50;">
                            <tr>
                                <th bgcolor="d3eaef">
                                    序号
                                </th>
                                <th bgcolor="d3eaef">
                                    院系名称
                                </th>
                                <th bgcolor="d3eaef">
                                    专业名称
                                </th>
                                <th bgcolor="d3eaef">
                                    班级名称
                                </th>
                                 <th bgcolor="d3eaef">
                                    学号
                                </th>
                                <th bgcolor="d3eaef">
                                    姓名
                                </th>
                                <th bgcolor="d3eaef">
                                    性别
                                </th>
                                
                                <th bgcolor="d3eaef">
                                    基本操作
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                           
                            <td bgcolor="#FFFFFF">
                                <%#Container.ItemIndex + 1 %>
                            </td>
                             <td bgcolor="#FFFFFF">
                             <%#BLL.DepartmentBLL.GetIdByDepartment(BLL.MajorBLL.GetIdByMajor(BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).MajorId).DeptId).DeptName%>
                            </td>
                            <td bgcolor="#FFFFFF">
                             <%#BLL.MajorBLL.GetIdByMajor(BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).MajorId).MajorName%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#BLL.ClassBLL.GetIdByClass(Convert.ToInt32(Eval("ClassId"))).ClassName%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#Eval("SutCode")%>
                            </td>
                            <td bgcolor="#FFFFFF">
                                      <%#Eval("SutName")%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#Eval("Sex")%>
                            </td>
                            <td bgcolor="#FFFFFF"><a href="SudentsAdd.aspx?uid=<%#Eval("SutId")%>" class="STYLE22">编辑</a>&nbsp;|&nbsp;<asp:LinkButton
                                    ID="lnkbDel" runat="server" CssClass="STYLE22" OnClientClick='return confirm("确定要删除该项？")' 
            onclick="lnkbDel_Click" CommandArgument='<%#Eval("SutId")%>'  >删除</asp:LinkButton>
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
