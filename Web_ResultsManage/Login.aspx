<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>学生信息选课成绩管理系统</title>
<link rel="stylesheet" type="text/css" href="css/style.css"/>
<script type="text/javascript" src="js/js.js"></script>
<script language="javascript" type="text/javascript">

    function check() {

        
        


        if (document.getElementById("txtUserName").value == "") {
            alert("用户名不能为空！");
            document.getElementById("txtUserName").focus();
            return false;
        }
        if (document.getElementById("txtPwd").value == "") {
            alert("密码不能为空！");
            document.getElementById("txtPwd").focus();
            return false;
        }



    }
      </script>
</head>
<body>
<div id="top"> </div>
<form id="form1" runat="server">
  <div id="center">
    <div id="center_left"></div>
    <div id="center_middle">
      <div class="user">用户名：<input type="text"  runat="server" id="txtUserName" /></div>
      <div class="user">密&nbsp;&nbsp; 码：<input type="password" runat="server" id="txtPwd" /></div>
      <div class="chknumber">角&nbsp;&nbsp; 色：<asp:DropDownList ID="ddlType" runat="server">
                <asp:ListItem>学生</asp:ListItem>
                <asp:ListItem>教师</asp:ListItem>
                <asp:ListItem>管理员</asp:ListItem>
            </asp:DropDownList></div>
    </div>
    <div id="center_middle_right"></div>
    <div id="center_submit">
      <div class="button"><asp:ImageButton ID="imgbLogin" runat="server" 
              ImageUrl="~/images/dl.gif"  width="57" height="20" OnClientClick="return check();"  onclick="imgbLogin_Click" /></div>
      <div class="button"><asp:ImageButton ID="imgbReset" runat="server" 
              ImageUrl="~/images/cz.gif"  width="57" height="20" onclick="imgbReset_Click"/></div>
    </div>
    <div id="center_right"></div>
  </div>
</form>
<div id="footer"></div>
</body>
</html>
