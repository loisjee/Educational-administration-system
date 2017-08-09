using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ClassDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddClass(Class ClassModel)
        {
            string sql = string.Format("insert into  Class (ClassName,MajorId )values('{0}',{1})",ClassModel.ClassName,ClassModel.MajorId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateClass(Class ClassModel)
        {
            string sql = string.Format(" UPDATE Class  set ClassName='{0}',MajorId={1} where ClassId={2} ",ClassModel.ClassName,ClassModel.MajorId  ,ClassModel.ClassId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteClass(int Id)
        {
            string sql = string.Format("delete from Class where ClassId={0}", Id);
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
                sql = "select count(*) from Class where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Class";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Class> PageSelectClass(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Class> list = new List<Class>(); 
	    string sql = string.Format("SELECT top {0} * FROM Class where ClassId not in( select top {1} ClassId from Class where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Class GetIdByClass(int Id)
        {
            string sql = string.Format("SELECT * FROM Class where ClassId={0} ",Id);
            Class ClassModel = new Class();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ClassModel= GetMode(table);
            }
            return ClassModel;
        }


        /// <summary> 
        /// 根据班级名查询实体 
        ///</summary>
        public static Class GetIdByName(string Name)
        {
            string sql = string.Format("SELECT * FROM Class where ClassName collate Chinese_PRC_CS_AS_WS = '{0}'", Name);
            Class ClassModel = new Class();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ClassModel = GetMode(table);
            }
            return ClassModel;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Class> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Class> list = new List<Class>();
            string sql = "select * from Class where 1=1";
            if (!string.IsNullOrEmpty(WhereSrc))
            {
                sql += string.Format(WhereSrc + " order by {0} {1}",PXzd,PXType);
            }
            else
            {
                sql += string.Format(" order by {0} {1}",PXzd,PXType);
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
        private static List<Class> GetList(DataTable table)
        {
            List<Class> list = new List<Class>();
            foreach (DataRow row in table.Rows)
            {
                Class ClassModel = new Class(); 
                ClassModel.ClassId = Convert.ToInt32(row["ClassId"]); 
                ClassModel.ClassName = Convert.ToString(row["ClassName"]); 
                ClassModel.MajorId = Convert.ToInt32(row["MajorId"]); 
                list.Add(ClassModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Class GetMode(DataTable table)
        {
            Class ClassModel = new Class();
            foreach (DataRow row in table.Rows)
            {
                ClassModel.ClassId = Convert.ToInt32(row["ClassId"]); 
                ClassModel.ClassName = Convert.ToString(row["ClassName"]); 
                ClassModel.MajorId = Convert.ToInt32(row["MajorId"]); 

            }
            return ClassModel;
        }
    }
}