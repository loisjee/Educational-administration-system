<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MajorManage.aspx.cs" Inherits="MajorManage" %>

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
    
      <script language="javascript" type="text/javascript">

          function check() {

              var txtMajorName = document.getElementById("txtMajorName");


              if (txtMajorName.value == "") {
                  alert("带红色 * 号项不能为空！");
                  txtMajorName.focus();
                  return false;
              }



          }


      </script>
    
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
                                                    <span class="STYLE1">专业管理</span>
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
                                    院系名称
                                </th>
                                <th bgcolor="d3eaef">
                                    专业名称
                                </th>
                                 <th bgcolor="d3eaef">
                                    专业描述
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
                             <%#BLL.DepartmentBLL.GetIdByDepartment(Convert.ToInt32( Eval("DeptId"))).DeptName%>
                            </td>
                            <td bgcolor="#FFFFFF">
                                      <%#Eval("MajorName")%>
                            </td>
                             <td bgcolor="#FFFFFF">
                                      <%#Eval("Note")%>
                            </td>
                            <td bgcolor="#FFFFFF"><a href="MajorManage.aspx?uid=<%#Eval("MajorId")%>" class="STYLE22">编辑</a>&nbsp;|&nbsp;<asp:LinkButton
                                    ID="lnkbDel" runat="server" CssClass="STYLE22" OnClientClick='return confirm("确定要删除该项？")' 
            onclick="lnkbDel_Click" CommandArgument='<%#Eval("MajorId")%>'  >删除</asp:LinkButton>
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
   <legend>添加/修改</legend>
   
    &nbsp;&nbsp;&nbsp;院系名称：<asp:DropDownList ID="ddlDeptId"
       runat="server">
   </asp:DropDownList>&nbsp;专业名称：<input type="text" id="txtMajorName" runat="server" /><span style="color:Red;">*</span>&nbsp;专业描述：<input type="text" id="txtNote" runat="server" style="width:200px;" />&nbsp;<asp:Button 
            ID="btnAdd" runat="server" OnClientClick="return check();"  style="width:60px;" 
            Text="添加" onclick="btnAdd_Click" />
        
    </fieldset>
    </form>
</body>
</html>
