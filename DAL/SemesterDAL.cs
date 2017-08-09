using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class SemesterDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddSemester(Semester SemesterModel)
        {
            string sql = string.Format("insert into  Semester (SemesterName) values ('{0}')", SemesterModel.SemesterName);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateSemester(Semester SemesterModel)
        {
            string sql = string.Format(" UPDATE Semester set SemesterName='{0}' where SemesterId={1} ", SemesterModel.SemesterName,SemesterModel.SemesterId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteSemester(int Id)
        {
            string sql = string.Format("delete from Semester where SemesterId={0}", Id);
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
                sql = "select count(*) from Semester where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Semester";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Semester> PageSelectSemester(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Semester> list = new List<Semester>();
            string sql = string.Format("SELECT top {0} * FROM Semester where SemesterId not in( select top {1} SemesterId from Semester where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ", pageSize, pageSize * pageIndex, WhereSrc, PXzd, PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Semester GetIdBySemester(int Id)
        {
            string sql = string.Format("SELECT * FROM Semester where SemesterId={0} ", Id);
            Semester SemesterModel = new Semester();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                SemesterModel = GetMode(table);
            }
            return SemesterModel;
        }
        /// <summary> 
        /// 根据学期名查询实体 
        ///</summary>
        public static Semester GetIdByName(string Name)
        {
            string sql = string.Format("SELECT * FROM Semester where SemesterName collate Chinese_PRC_CS_AS_WS = '{0}'", Name);
            Semester SemesterModel = new Semester();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                SemesterModel = GetMode(table);
            }
            return SemesterModel;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Semester> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Semester> list = new List<Semester>();
            string sql = "select * from Semester where 1=1";
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
        private static List<Semester> GetList(DataTable table)
        {
            List<Semester> list = new List<Semester>();
            foreach (DataRow row in table.Rows)
            {
                Semester SemesterModel = new Semester();
                SemesterModel.SemesterId = Convert.ToInt32(row["SemesterId"]);
                SemesterModel.SemesterName = Convert.ToString(row["SemesterName"]);

                list.Add(SemesterModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Semester GetMode(DataTable table)
        {
            Semester SemesterModel = new Semester();
            foreach (DataRow row in table.Rows)
            {
                SemesterModel.SemesterId = Convert.ToInt32(row["SemesterId"]);
                SemesterModel.SemesterName = Convert.ToString(row["SemesterName"]);

               

            }
            return SemesterModel;
        }
    }
}