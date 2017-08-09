<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalTeacher.aspx.cs" Inherits="PersonalTeacher" %>

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
            text-decoration: none;
        }
    </style>

    <script src="js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>


 
 
 
 


    <script language="javascript" type="text/javascript">

        function check() {

            var txtTeacherName = document.getElementById("txtTeacherName");


            if (txtTeacherName.value == "") {
                alert("带红色 * 号项不能为空！");
                txtTeacherName.focus();
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
                                                    <span class="STYLE1">个人教师信息</span>
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
                <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#a8c7ce"
                    style="line-height: 25px; text-align: center; font-size: 12px; color: #344b50;">
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    <tr>
                      
                         <th bgcolor="d3eaef" style=" width:25%;">
                         教工号
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left; width:25%;" >
                            <asp:Label ID="lblTeacherCode" runat="server" ></asp:Label>
                            </td>

                          <th bgcolor="d3eaef" style=" width:25%;">
                            教师名称
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;  width:25%;">

                            <input id="txtTeacherName" runat="server" type="text"/><span style="color: Red;">*</span>
                        </td>
                    </tr>
                    <tr>
                    <td bgcolor="#FFFFFF" style="text-align:center;" colspan="4"><asp:Button ID="btnAdd" runat="server" Text="修改" Width="60px" OnClientClick="return check()"
                                OnClick="btnAdd_Click" /></td>
                    </tr>


                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>