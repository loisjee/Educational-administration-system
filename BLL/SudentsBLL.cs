using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class SudentsBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddSudents(Sudents SudentsModel)
        {
            return SudentsDAL.AddSudents(SudentsModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteSudents(int Id)
        {
            return SudentsDAL.DeleteSudents(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Sudents> PageSelectSudents(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return SudentsDAL.PageSelectSudents(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateSudents(Sudents SudentsModel)
        {
            return SudentsDAL.UpdateSudents(SudentsModel);
        }
       
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return SudentsDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Sudents> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return SudentsDAL.AllData(WhereSrc, PXzd, PXType);
        }

          /// <summary>
        /// 查询全部
        /// </summary>
        public static DataTable AllDataTable(string WhereSrc, string PXzd, string PXType)
        {
            return SudentsDAL.AllDataTable(WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Sudents GetIdBySudents(int Id)
        {
            return SudentsDAL.GetIdBySudents(Id);
        }

        /// <summary>
        /// 验证用户是否能登录成功
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        public static bool GetUsersLogin(string SutCode, string Pwd, out  Sudents sudents)
        {
            sudents = SudentsDAL.GetIdBySutCode(SutCode);
            if (sudents != null && sudents.Pwd == Pwd)
            {
                return true;
            }
            return false;
        }


        //添加验证是否存在
        public static bool IsTrue(string SutCode)
        {
            Sudents sud = SudentsDAL.GetIdBySutCode(SutCode);
            if (sud != null && sud.SutId != 0)
            {
                return true;
            }
            return false;
        }
        


        // 修改验证是否存在
        public static bool IsTrue(string SutCode, int SutId)
        {
            Sudents sud = SudentsDAL.GetIdBySutCode(SutCode);
            if (sud != null && sud.SutId != 0 && sud.SutId != SutId)
            {
                return true;
            }
            return false;
        }

    }
}