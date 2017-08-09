using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DepartmentDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddDepartment(Department DepartmentModel)
        {
            string sql = string.Format("insert into  Department (DeptName,Contact )values('{0}','{1}')",DepartmentModel.DeptName,DepartmentModel.Contact);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateDepartment(Department DepartmentModel)
        {
            string sql = string.Format(" UPDATE Department  set DeptName='{0}',Contact='{1}' where DeptId={2} ",DepartmentModel.DeptName,DepartmentModel.Contact  ,DepartmentModel.DeptId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteDepartment(int Id)
        {
            string sql = string.Format("delete from Department where DeptId={0}", Id);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
                sql = "select count(*) from Department where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Department";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Department> PageSelectDepartment(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Department> list = new List<Department>(); 
	    string sql = string.Format("SELECT top {0} * FROM Department where DeptId not in( select top {1} DeptId from Department where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Department GetIdByDepartment(int Id)
        {
            string sql = string.Format("SELECT * FROM Department where DeptId={0} ",Id);
            Department DepartmentModel = new Department();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                DepartmentModel= GetMode(table);
            }
            return DepartmentModel;
        }


        /// <summary> 
        /// 根据院系名查询实体 
        ///</summary>
        public static Department GetIdByName(string Name)
        {
            string sql = string.Format("SELECT * FROM Department where DeptName collate Chinese_PRC_CS_AS_WS = '{0}'", Name);
            Department DepartmentModel = new Department();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                DepartmentModel = GetMode(table);
            }
            return DepartmentModel;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Department> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Department> list = new List<Department>();
           

            string sql = "select * from Department where 1=1";
            if (!string.IsNullOrEmpty(WhereSrc))
            {
                sql += string.Format(WhereSrc + " order by {0} {1}", PXzd, PXType);
            }
            else
            {
                sql += string.Format(" order by {0} {1}", PXzd, PXType);
            }

            using (DataTable table = DBHelper.GetDataSet(sql))
            {

                list = GetList(table);
            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static List<Department> GetList(DataTable table)
        {
            List<Department> list = new List<Department>();
            foreach (DataRow row in table.Rows)
            {
                Department DepartmentModel = new Department(); 
                DepartmentModel.DeptId = Convert.ToInt32(row["DeptId"]); 
                DepartmentModel.DeptName = Convert.ToString(row["DeptName"]); 
                DepartmentModel.Contact = Convert.ToString(row["Contact"]); 
                list.Add(DepartmentModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Department GetMode(DataTable table)
        {
            Department DepartmentModel = new Department();
            foreach (DataRow row in table.Rows)
            {
                DepartmentModel.DeptId = Convert.ToInt32(row["DeptId"]); 
                DepartmentModel.DeptName = Convert.ToString(row["DeptName"]); 
                DepartmentModel.Contact = Convert.ToString(row["Contact"]); 

            }
            return DepartmentModel;
        }
    }
}