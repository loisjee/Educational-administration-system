using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CourseDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddCourse(Course CourseModel)
        {
            string sql = string.Format("insert into  Course (CourseName,Note,TeacherId,Credits )values('{0}','{1}',{2},{3})",  CourseModel.CourseName, CourseModel.Note, CourseModel.TeacherId, CourseModel.Credits);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateCourse(Course CourseModel)
        {
            string sql = string.Format(" UPDATE Course  set CourseName='{0}',Note='{1}',TeacherId={2},Credits={3} where CourseId={4} ",  CourseModel.CourseName, CourseModel.Note, CourseModel.TeacherId, CourseModel.Credits, CourseModel.CourseId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteCourse(int Id)
        {
            string sql = string.Format("delete from Course where CourseId={0}", Id);
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
                sql = "select count(*) from Course where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Course";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Course> PageSelectCourse(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Course> list = new List<Course>(); 
	    string sql = string.Format("SELECT top {0} * FROM Course where CourseId not in( select top {1} CourseId from Course where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Course GetIdByCourse(int Id)
        {
            string sql = string.Format("SELECT * FROM Course where CourseId={0} ",Id);
            Course CourseModel = new Course();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                CourseModel= GetMode(table);
            }
            return CourseModel;
        }

        /// <summary> 
        /// 根据课程名查询实体 
        ///</summary>
        public static Course GetIdByName(string Name)
        {
            string sql = string.Format("SELECT * FROM Course where CourseName collate Chinese_PRC_CS_AS_WS = '{0}'", Name);
            Course CourseModel = new Course();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                CourseModel = GetMode(table);
            }
            return CourseModel;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Course> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Course> list = new List<Course>();


            string sql = "select * from Course where 1=1";
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
        private static List<Course> GetList(DataTable table)
        {
            List<Course> list = new List<Course>();
            foreach (DataRow row in table.Rows)
            {
                Course CourseModel = new Course(); 
                CourseModel.CourseId = Convert.ToInt32(row["CourseId"]); 
                CourseModel.CourseName = Convert.ToString(row["CourseName"]); 
                CourseModel.Note = Convert.ToString(row["Note"]);
                CourseModel.TeacherId = Convert.ToInt16(row["TeacherId"]); 
                CourseModel.Credits = Convert.ToInt32(row["Credits"]); 
                list.Add(CourseModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Course GetMode(DataTable table)
        {
            Course CourseModel = new Course();
            foreach (DataRow row in table.Rows)
            {
                CourseModel.CourseId = Convert.ToInt32(row["CourseId"]);  
                CourseModel.CourseName = Convert.ToString(row["CourseName"]); 
                CourseModel.Note = Convert.ToString(row["Note"]);
                CourseModel.TeacherId = Convert.ToInt16(row["TeacherId"]); 
                CourseModel.Credits = Convert.ToInt32(row["Credits"]); 

            }
            return CourseModel;
        }
    }
}