using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace DAL
{
   public class AdminDAL
    {
        /// <summary> 
        /// 根据用户名查询实体 
        ///</summary>
       public static Admin GetIdByAdminName(string AdminName)
        {
            string sql = string.Format("SELECT * FROM Admin where AdminName collate Chinese_PRC_CS_AS_WS = '{0}'", AdminName);
            Admin AdminModel = new Admin();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                AdminModel = GetMode(table);
            }
            return AdminModel;
        }

       /// <summary> 
       /// 根据ID修改 
       ///</summary>
       public static int UpdateAdmin(Admin AdminModel)
       {
           string sql = string.Format(" UPDATE Admin  set AdminName='{0}',Pwd='{1}' where AdminId={2} ", AdminModel.AdminName, AdminModel.Pwd, AdminModel.AdminId);
           return DBHelper.ExecuteCommand(sql);
       }

       /// <summary> 
       /// 私有方法 
       ///</summary>
       private static Admin GetMode(DataTable table)
       {
           Admin UsersModel = new Admin();
           foreach (DataRow row in table.Rows)
           {
               UsersModel.AdminId = Convert.ToInt32(row["AdminId"]);
               UsersModel.AdminName = Convert.ToString(row["AdminName"]);
               UsersModel.Pwd = Convert.ToString(row["Pwd"]);
               

           }
           return UsersModel;
       }
    }
}
