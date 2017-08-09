<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalSudents.aspx.cs" Inherits="PersonalSudents" %>

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

           

            var txtSutName = document.getElementById("txtSutName");

            


          
            if (txtSutName.value == "") {

                alert("带红色 * 号项不能为空！");
                txtSutName.focus();
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
                                                    <span class="STYLE1">个人学生信息</span>
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
                        <th bgcolor="d3eaef" style="width: 20%">
                            专业名称
                        </th>
                        <td bgcolor="#FFFFFF" style="width: 30%; text-align: left;">
                            <asp:DropDownList ID="ddlMajorId" runat="server" Enabled="False" >
                            </asp:DropDownList>
                        </td>
                         <th bgcolor="d3eaef" style="width: 20%">
                            班级名称
                        </th>
                        <td bgcolor="#FFFFFF" style="width: 30%; text-align: left;">
                            <asp:DropDownList ID="ddlClassId" runat="server" Enabled="False" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="d3eaef">
                            学号
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <asp:Label ID="lblSutCode" runat="server" ></asp:Label>
                            <asp:Label ID="lblPwd" runat="server" Visible="False" ></asp:Label>
                        </td>
                         <th bgcolor="d3eaef">
                            姓名
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <input id="txtSutName" runat="server" type="text"  /><span style="color: Red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="d3eaef">
                            入学年份
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <asp:DropDownList ID="ddlGrade" runat="server" Enabled="False" >
                                <asp:ListItem>2010</asp:ListItem>
                                <asp:ListItem>2011</asp:ListItem>
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2013</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                            </asp:DropDownList>年
                        </td>
                        <th bgcolor="d3eaef">
                            性别
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <asp:DropDownList ID="ddlSex" runat="server" >
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="d3eaef">
                            出生日期
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <input id="txtBorn" runat="server" type="text" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  />
                        </td>
                        <th bgcolor="d3eaef">
                            籍贯
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                            <input id="txtNative" runat="server" type="text"  />
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="d3eaef">
                            民族
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                                 <asp:DropDownList ID="ddlNational" runat="server" >
                                     <asp:ListItem>汉族</asp:ListItem>
                                     <asp:ListItem>蒙古族</asp:ListItem>
                                     <asp:ListItem>满族</asp:ListItem>
                                     <asp:ListItem>朝鲜族</asp:ListItem>
                                     <asp:ListItem>赫哲族</asp:ListItem>
                                     <asp:ListItem>达斡尔族</asp:ListItem>
                                     <asp:ListItem>鄂温克族</asp:ListItem>
                                     <asp:ListItem>鄂伦春族</asp:ListItem>
                                     <asp:ListItem>回族</asp:ListItem>
                                     <asp:ListItem>东乡族</asp:ListItem>
                                     <asp:ListItem>土族</asp:ListItem>
                                     <asp:ListItem>撒拉族</asp:ListItem>
                                     <asp:ListItem>保安族</asp:ListItem>
                                     <asp:ListItem>裕固族</asp:ListItem>
                                     <asp:ListItem>维吾尔族</asp:ListItem>
                                     <asp:ListItem>哈萨克族</asp:ListItem>
                                     <asp:ListItem>柯尔克孜族</asp:ListItem>
                                     <asp:ListItem>锡伯族</asp:ListItem>
                                     <asp:ListItem>塔吉克族</asp:ListItem>
                                     <asp:ListItem>乌孜别克族</asp:ListItem>
                                     <asp:ListItem>俄罗斯族</asp:ListItem>
                                     <asp:ListItem>塔塔尔族</asp:ListItem>
                                     <asp:ListItem>藏族</asp:ListItem>
                                     <asp:ListItem>门巴族</asp:ListItem>
                                     <asp:ListItem>珞巴族</asp:ListItem>
                                     <asp:ListItem>羌族</asp:ListItem>
                                     <asp:ListItem>彝族</asp:ListItem>
                                     <asp:ListItem>白族</asp:ListItem>
                                     <asp:ListItem>哈尼族</asp:ListItem>
                                     <asp:ListItem>傣族</asp:ListItem>
                                     <asp:ListItem>僳僳族</asp:ListItem>
                                     <asp:ListItem>佤族</asp:ListItem>
                                     <asp:ListItem>拉祜族</asp:ListItem>
                                     <asp:ListItem>纳西族</asp:ListItem>
                                     <asp:ListItem>景颇族</asp:ListItem>
                                      <asp:ListItem>布朗族</asp:ListItem>
                                       <asp:ListItem>阿昌族</asp:ListItem>
                                        <asp:ListItem>普米族</asp:ListItem>
                                         <asp:ListItem>怒族</asp:ListItem>
                                          <asp:ListItem>德昂族</asp:ListItem>
                                           <asp:ListItem>独龙族</asp:ListItem>
                                            <asp:ListItem>基诺族</asp:ListItem>
                                             <asp:ListItem>苗族</asp:ListItem>
                                              <asp:ListItem>布依族</asp:ListItem>
                                               <asp:ListItem>侗族</asp:ListItem>
                                                <asp:ListItem>水族</asp:ListItem>
                                                 <asp:ListItem>仡佬族</asp:ListItem>
                                                  <asp:ListItem>壮族</asp:ListItem>
                                                   <asp:ListItem>瑶族</asp:ListItem>
                                                    <asp:ListItem>仫佬族</asp:ListItem>
                                                     <asp:ListItem>毛南族</asp:ListItem>
                                                    <asp:ListItem>京族</asp:ListItem>
                                                     <asp:ListItem>土家族</asp:ListItem>
                                                    <asp:ListItem>黎族</asp:ListItem>
                                                     <asp:ListItem>畲族</asp:ListItem>
                                                    <asp:ListItem>高山族</asp:ListItem>
                            </asp:DropDownList></td>
                        <th bgcolor="d3eaef">
                            政治面貌
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                              <asp:DropDownList ID="ddlPolitical" runat="server" >
                               <asp:ListItem>群众</asp:ListItem>
                               <asp:ListItem>共青团员</asp:ListItem>
                               <asp:ListItem>中共预备党员</asp:ListItem>
                                   <asp:ListItem>中共党员</asp:ListItem>
                                  <asp:ListItem>民革党员</asp:ListItem>
                                   <asp:ListItem>民盟盟员</asp:ListItem>
                                    <asp:ListItem>民建会员</asp:ListItem>
                                     <asp:ListItem>民进会员</asp:ListItem>
                                      <asp:ListItem>农工党党员</asp:ListItem>
                                       <asp:ListItem>致公党党员</asp:ListItem>
                                        <asp:ListItem>九三学社社员</asp:ListItem>
                                         <asp:ListItem>台盟盟员</asp:ListItem>
                                          <asp:ListItem>无党派人士</asp:ListItem>
                                           
                                            <asp:ListItem>港澳同胞</asp:ListItem>
                                             <asp:ListItem>叛徒</asp:ListItem>
                                              <asp:ListItem>反革命分子</asp:ListItem>
                            </asp:DropDownList> 
                        </td>
                    </tr>
                    <tr>
                        <th bgcolor="d3eaef">
                            电话号码
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
                           <input id="txtContact" runat="server" type="text"  />
                        </td>
                          <th bgcolor="d3eaef" rowspan="2">
                          
                        备注
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;" rowspan="2">
                                                    
                            <textarea id="txtNote" runat="server" style=" width:400px; height:100px;"></textarea>
                        </td>
                    </tr>
                    
                    
                    
                    <tr>
                        <th bgcolor="d3eaef">
                         
                        </th>
                        <td bgcolor="#FFFFFF" style="text-align: left;">
        
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
