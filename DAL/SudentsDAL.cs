using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class SudentsDAL
    {


        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddSudents(Sudents SudentsModel)
        {
            string sql = string.Format("insert into  Sudents (SutCode,SutName,ClassId,Native,Born,[National],Political,Sex,Grade,Contact,Note,Pwd )values(@SutCode,@SutName,@ClassId,@Native,@Born,@National,@Political,@Sex,@Grade,@Contact,@Note,@Pwd)");
            SqlParameter[] para = {
                    new SqlParameter("@SutCode", SqlDbType.NVarChar),
					new SqlParameter("@SutName", SqlDbType.NVarChar),
					new SqlParameter("@ClassId", SqlDbType.Int),
					new SqlParameter("@Native", SqlDbType.NVarChar),
					new SqlParameter("@Born", SqlDbType.DateTime),
					new SqlParameter("@National", SqlDbType.NVarChar),
					new SqlParameter("@Political", SqlDbType.NVarChar),
					new SqlParameter("@Sex", SqlDbType.NVarChar),
					new SqlParameter("@Grade", SqlDbType.Int),
					new SqlParameter("@Contact", SqlDbType.NVarChar),
					new SqlParameter("@Note", SqlDbType.NText),
                    new SqlParameter("@Pwd", SqlDbType.NVarChar)
                                  };
            para[0].Value = SudentsModel.SutCode;
            para[1].Value = SudentsModel.SutName;
            para[2].Value = SudentsModel.ClassId;
            para[3].Value = SudentsModel.Native;
            para[4].Value = SudentsModel.Born;
            para[5].Value = SudentsModel.National;
            para[6].Value = SudentsModel.Political;
            para[7].Value = SudentsModel.Sex;
            para[8].Value = SudentsModel.Grade;
            para[9].Value = SudentsModel.Contact;
            para[10].Value = SudentsModel.Note;
            para[11].Value = SudentsModel.Pwd;
            
            return DBHelper.ExecuteCommand(sql,para);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateSudents(Sudents SudentsModel)
        {
            string sql = string.Format("UPDATE Sudents  set SutCode=@SutCode,SutName=@SutName,ClassId=@ClassId,Native=@Native,Born=@Born,[National]=@National,Political=@Political,Sex=@Sex,Grade=@Grade,Contact=@Contact,Note=@Note,Pwd=@Pwd where SutId=@SutId");

            SqlParameter[] para = {
                    new SqlParameter("@SutCode", SqlDbType.NVarChar),
					new SqlParameter("@SutName", SqlDbType.NVarChar),
					new SqlParameter("@ClassId", SqlDbType.Int),
					new SqlParameter("@Native", SqlDbType.NVarChar),
					new SqlParameter("@Born", SqlDbType.DateTime),
					new SqlParameter("@National", SqlDbType.NVarChar),
					new SqlParameter("@Political", SqlDbType.NVarChar),
					new SqlParameter("@Sex", SqlDbType.NVarChar),
					new SqlParameter("@Grade", SqlDbType.Int),
					new SqlParameter("@Contact", SqlDbType.NVarChar),
					new SqlParameter("@Note", SqlDbType.NText),
                     new SqlParameter("@Pwd", SqlDbType.NVarChar),
                    new SqlParameter("@SutId",SqlDbType.Int)
                                  };
            para[0].Value = SudentsModel.SutCode;
            para[1].Value = SudentsModel.SutName;
            para[2].Value = SudentsModel.ClassId;
            para[3].Value = SudentsModel.Native;
            para[4].Value = SudentsModel.Born;
            para[5].Value = SudentsModel.National;
            para[6].Value = SudentsModel.Political;
            para[7].Value = SudentsModel.Sex;
            para[8].Value = SudentsModel.Grade;
            para[9].Value = SudentsModel.Contact;
            para[10].Value = SudentsModel.Note;
            para[11].Value = SudentsModel.Pwd;
            para[12].Value = SudentsModel.SutId;
            
            return DBHelper.ExecuteCommand(sql,para);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteSudents(int Id)
        {
            string sql = string.Format("delete from Sudents where SutId={0}", Id);
            return DBHelper.ExecuteCommand(sql);
        }






        /// <summary> 
        /// 根据学号查询实体 
        ///</summary>
        public static Sudents GetIdBySutCode(string SutCode)
        {
            string sql = string.Format("SELECT * FROM Sudents where SutCode collate Chinese_PRC_CS_AS_WS = '{0}'", SutCode);
            Sudents SudentsModel = new Sudents();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                SudentsModel = GetMode(table);
            }
            return SudentsModel;
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            string sql = "";
            if (!string.IsNullOrEmpty(NewWHere))
            {
                sql = "select count(*) from Sudents where " + NewWHere;
            }
            else
            {
                sql = "select count(*) from Sudents";

            }
            return DBHelper.GetIntScalar(sql);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Sudents> PageSelectSudents(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            List<Sudents> list = new List<Sudents>(); 
	    string sql = string.Format("SELECT top {0} * FROM Sudents where SutId not in( select top {1} SutId from Sudents where 1=1 {2} order by {3} {4}) and 1=1 {2} order by {3} {4} ",pageSize, pageSize*pageIndex,WhereSrc, PXzd,PXType);
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                list = GetList(table);
            }
            return list;
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Sudents GetIdBySudents(int Id)
        {
            string sql = string.Format("SELECT * FROM Sudents where SutId={0} ",Id);
            Sudents SudentsModel = new Sudents();
            using (DataTable table = DBHelper.GetDataSet(sql))
            {
                SudentsModel= GetMode(table);
            }
            return SudentsModel;
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Sudents> AllData(string WhereSrc, string PXzd, string PXType)
        {
            List<Sudents> list = new List<Sudents>();
            string sql = "select * from Sudents where 1=1";
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
        public static DataTable AllDataTable(string WhereSrc, string PXzd, string PXType)
        {
            string sql = "select * from Sudents where 1=1";
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
        /// 私有方法 
        ///</summary>
        private static List<Sudents> GetList(DataTable table)
        {
            List<Sudents> list = new List<Sudents>();
            foreach (DataRow row in table.Rows)
            {
                Sudents SudentsModel = new Sudents(); 
                SudentsModel.SutId = Convert.ToInt32(row["SutId"]); 
                SudentsModel.SutCode = Convert.ToString(row["SutCode"]);
                SudentsModel.SutName = Convert.ToString(row["SutName"]);
                SudentsModel.ClassId = Convert.ToInt32(row["ClassId"]); 
                SudentsModel.Native = Convert.ToString(row["Native"]); 
                SudentsModel.Born = Convert.ToDateTime(row["Born"]); 
                SudentsModel.National = Convert.ToString(row["National"]); 
                SudentsModel.Political = Convert.ToString(row["Political"]); 
                SudentsModel.Sex = Convert.ToString(row["Sex"]); 
                SudentsModel.Grade = Convert.ToInt32(row["Grade"]); 
                SudentsModel.Contact = Convert.ToString(row["Contact"]);
                SudentsModel.Pwd = Convert.ToString(row["Pwd"]); 
                list.Add(SudentsModel);

            }
            return list;
        }
        /// <summary> 
        /// 私有方法 
        ///</summary>
        private static Sudents GetMode(DataTable table)
        {
            Sudents SudentsModel = new Sudents();
            foreach (DataRow row in table.Rows)
            {
                SudentsModel.SutId = Convert.ToInt32(row["SutId"]); 
                SudentsModel.SutCode = Convert.ToString(row["SutCode"]);
                SudentsModel.SutName = Convert.ToString(row["SutName"]);
                SudentsModel.ClassId = Convert.ToInt32(row["ClassId"]); 
                SudentsModel.Native = Convert.ToString(row["Native"]); 
                SudentsModel.Born = Convert.ToDateTime(row["Born"]); 
                SudentsModel.National = Convert.ToString(row["National"]); 
                SudentsModel.Political = Convert.ToString(row["Political"]); 
                SudentsModel.Sex = Convert.ToString(row["Sex"]); 
                SudentsModel.Grade = Convert.ToInt32(row["Grade"]); 
                SudentsModel.Contact = Convert.ToString(row["Contact"]);
                SudentsModel.Note = Convert.ToString(row["Note"]);
                SudentsModel.Pwd = Convert.ToString(row["Pwd"]); 
            }
            return SudentsModel;
        }
    }
}