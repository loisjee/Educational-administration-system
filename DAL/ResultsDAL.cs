using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ResultsDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddResults(Results ResultsModel)
        {
            string sql = string.Format("insert into  Results (SutId,CourseId,Score,SemesterId )values({0},{1},{2},{3})",ResultsModel.SutId,ResultsModel.CourseId,ResultsModel.Score,ResultsModel.SemesterId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateResults(Results ResultsModel)
        {
            string sql = string.Format(" UPDATE Results  set SutId={0},CourseId={1},Score={2},SemesterId={3} where ResultsId={4} ", ResultsModel.SutId, ResultsModel.CourseId, ResultsModel.Score, ResultsModel.SemesterId, ResultsModel.ResultsId);
            return DBHelper.ExecuteCommand(sql);
        }


        public static Results GetByWhere(int SutId, int CourseId)
        {
            string sql = string.Format("select * From dbo.Results where SutId={0} and CourseId={1}", SutId, CourseId);
            Results ResultsModel = new Results();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ResultsModel = GetMode(table);
            }
            return ResultsModel;
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteResults(int Id)
        {
            string sql = string.Format("delete from Results where ResultsId={0}", Id);
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
                sql = "select count(*) from Results where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Results";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Results> PageSelectResults(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Results> list = new List<Results>(); 
	    string sql = string.Format("SELECT top {0} * FROM Results where ResultsId not in( select top {1} ResultsId from Results where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Results GetIdByResults(int Id)
        {
            string sql = string.Format("SELECT * FROM Results where ResultsId={0} ",Id);
            Results ResultsModel = new Results();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                ResultsModel= GetMode(table);
            }
            return ResultsModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Results> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Results> list = new List<Results>();
            string sql = "select * from Results where 1=1";
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
        /// 查询全部
        /// </summary>
        public static DataTable GetAllData(string WhereSrc, string PXzd, string PXType)
        {

            string sql = @"SELECT Semester.*, Course.*, Sudents.*, Results.* FROM Semester INNER JOIN
                      Results ON Semester.SemesterId = Results.SemesterId INNER JOIN
                      Course ON Results.CourseId = Course.CourseId INNER JOIN
                      Sudents ON Results.SutId = Sudents.SutId where 1=1";
            if (!string.IsNullOrEmpty(WhereSrc))
            {
                sql += string.Format(WhereSrc + " order by {0} {1}", PXzd, PXType);
            }
            else
            {
                sql += string.Format(" order by {0} {1}", PXzd, PXType);
            }

            return DBHelper.GetDataSet(sql);
        }

       


        /// <summary>
        /// 根据成绩统计
        /// </summary>
        public static List<Results> StatisticalByType(int CourseId,int SemesterId)
        {
            List<Results> list = new List<Results>();


            string sql = @"select CourseId,SemesterId ,count(*) as StuCount from 
(select CourseId,SemesterId  From Results where CourseId=" + CourseId + " and SemesterId=" + SemesterId + " group by CourseId,SemesterId,SutId) as CountTable group by CourseId,SemesterId";

            using (DataTable table = DBHelper.GetDataSet(sql))
            {

                list = GetList2(table);
            }
            return list;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static List<Results> GetList(DataTable table)
        {
            List<Results> list = new List<Results>();
            foreach (DataRow row in table.Rows)
            {
                Results ResultsModel = new Results(); 
                ResultsModel.ResultsId = Convert.ToInt32(row["ResultsId"]); 
                ResultsModel.SutId = Convert.ToInt32(row["SutId"]); 
                ResultsModel.CourseId = Convert.ToInt32(row["CourseId"]); 
                ResultsModel.Score = Convert.ToInt32(row["Score"]);
                ResultsModel.SemesterId = Convert.ToInt32(row["SemesterId"]); 
                list.Add(ResultsModel);

            }
            return list;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static List<Results> GetList2(DataTable table)
        {
            List<Results> list = new List<Results>();
            foreach (DataRow row in table.Rows)
            {
                Results ResultsModel = new Results();
                ResultsModel.CourseId = Convert.ToInt32(row["CourseId"]);
                ResultsModel.SemesterId = Convert.ToInt32(row["SemesterId"]);
                ResultsModel.StuCount = Convert.ToInt32(row["StuCount"]);
                list.Add(ResultsModel);

            }
            return list;
        }

        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Results GetMode(DataTable table)
        {
            Results ResultsModel = new Results();
            foreach (DataRow row in table.Rows)
            {
                ResultsModel.ResultsId = Convert.ToInt32(row["ResultsId"]); 
                ResultsModel.SutId = Convert.ToInt32(row["SutId"]); 
                ResultsModel.CourseId = Convert.ToInt32(row["CourseId"]); 
                ResultsModel.Score = Convert.ToInt32(row["Score"]);
                ResultsModel.SemesterId = Convert.ToInt32(row["SemesterId"]); 

            }
            return ResultsModel;
        }
    }
}