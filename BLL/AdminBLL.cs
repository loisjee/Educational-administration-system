using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
   public class AdminBLL
    {
          /// <summary> 
        /// 根据用户名查询实体 
        ///</summary>
       public static Admin GetIdByAdminName(string AdminName)
       {
           return AdminDAL.GetIdByAdminName(AdminName);
       }



       /// <summary>
       /// 验证用户是否能登录成功
       /// </summary>
       /// <param name="UserName"></param>
       /// <param name="Pwd"></param>
       /// <param name="users"></param>
       /// <returns></returns>
       public static bool GetUsersLogin(string AdminName, string Pwd, out Admin admin)
       {
           admin = AdminDAL.GetIdByAdminName(AdminName);
           if (admin != null && admin.Pwd == Pwd)
           {
               return true;
           }
           return false;
       }

       /// <summary> 
       /// 修改 
       ///</summary> 
       public static int UpdateUsers(Admin AdminModel)
       {
           return AdminDAL.UpdateAdmin(AdminModel);
       }

    }
}
