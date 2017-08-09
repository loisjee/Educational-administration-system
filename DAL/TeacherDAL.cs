using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TeacherDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddTeacher(Teacher TeacherModel)
        {
            string sql = string.Format("insert into  Teacher (TeacherCode,TeacherName,Pwd)values('{0}','{1}','{2}')", TeacherModel.TeacherCode, TeacherModel.TeacherName, TeacherModel.Pwd);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据教工号查询实体 
        ///</summary>
        public static Teacher GetIdByTeacherCode(string TeacherCode)
        {
            string sql = string.Format("SELECT * FROM Teacher where TeacherCode collate Chinese_PRC_CS_AS_WS = '{0}'", TeacherCode);
            Teacher TeacherModel = new Teacher();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                TeacherModel = GetMode(table);
            }
            return TeacherModel;
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateTeacher(Teacher TeacherModel)
        {
            string sql = string.Format(" UPDATE Teacher  set TeacherCode='{0}',TeacherName='{1}',Pwd='{2}' where TeacherId={3} ", TeacherModel.TeacherCode, TeacherModel.TeacherName, TeacherModel.Pwd, TeacherModel.TeacherId);
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteTeacher(int Id)
        {
            string sql = string.Format("delete from Teacher where TeacherId={0}", Id);
            return DBHelper.ExecuteCommand(sql);
        }

     

      

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Teacher GetIdByTeacher(int Id)
        {
            string sql = string.Format("SELECT * FROM Teacher where TeacherId={0} ", Id);
            Teacher TeacherModel = new Teacher();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                TeacherModel= GetMode(table);
            }
            return TeacherModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Teacher> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Teacher> list = new List<Teacher>();
           

            string sql = "select * from Teacher where 1=1";
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
        private static List<Teacher> GetList(DataTable table)
        {
            List<Teacher> list = new List<Teacher>();
            foreach (DataRow row in table.Rows)
            {
                Teacher TeacherModel = new Teacher();
                TeacherModel.TeacherId = Convert.ToInt32(row["TeacherId"]);
                TeacherModel.TeacherCode = Convert.ToString(row["TeacherCode"]);
                TeacherModel.TeacherName = Convert.ToString(row["TeacherName"]);
                TeacherModel.Pwd = Convert.ToString(row["Pwd"]); 
                list.Add(TeacherModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Teacher GetMode(DataTable table)
        {
            Teacher TeacherModel = new Teacher();
            foreach (DataRow row in table.Rows)
            {
                TeacherModel.TeacherId = Convert.ToInt32(row["TeacherId"]);
                TeacherModel.TeacherCode = Convert.ToString(row["TeacherCode"]);
                TeacherModel.TeacherName = Convert.ToString(row["TeacherName"]);
                TeacherModel.Pwd = Convert.ToString(row["Pwd"]); 

            }
            return TeacherModel;
        }
    }
}