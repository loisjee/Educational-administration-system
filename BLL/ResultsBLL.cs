using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class ResultsBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddResults(Results ResultsModel)
        {
            return ResultsDAL.AddResults(ResultsModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteResults(int Id)
        {
            return ResultsDAL.DeleteResults(Id);
        }

        
        /// <summary>
        /// 查询全部
        /// </summary>
        public static DataTable GetAllData(string WhereSrc, string PXzd, string PXType)
        {
            return ResultsDAL.GetAllData(WhereSrc, PXzd, PXType);
        }

        /// <summary>
        /// 添加验证是否存在
        /// </summary>
        /// <param name="SutId"></param>
        /// <param name="CourseId"></param>
        /// <param name="SemesterId"></param>
        /// <returns></returns>
        public static bool IsTrue(int SutId, int CourseId)
        {
            Results res = ResultsDAL.GetByWhere(SutId, CourseId);
            if (res != null && res.ResultsId != 0)
            {
                return true;
            }
            return false;
        }
     
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Results> PageSelectResults(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return ResultsDAL.PageSelectResults(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateResults(Results ResultsModel)
        {
            return ResultsDAL.UpdateResults(ResultsModel);
        }
       
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Results> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return ResultsDAL.AllData(WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return ResultsDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Results GetIdByResults(int Id)
        {
            return ResultsDAL.GetIdByResults(Id);
        }

        /// <summary>
        /// 根据成绩统计
        /// </summary>
        public static List<Results> StatisticalByType(int CourseId, int SemesterId)
        {
            return ResultsDAL.StatisticalByType(CourseId, SemesterId);
        }
    }
}