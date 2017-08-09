using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
   public class SemesterBLL
    {
        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddSemester(Semester SemesterModel)
        {
            return SemesterDAL.AddSemester(SemesterModel);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateSemester(Semester SemesterModel)
        {
            return SemesterDAL.UpdateSemester(SemesterModel);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteSemester(int Id)
        {
            return SemesterDAL.DeleteSemester(Id);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return SemesterDAL.CountNumber(NewWHere);
        }

        /// <summary>
        /// 分页 
        ///</summary> 
        public static List<Semester> PageSelectSemester(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return SemesterDAL.PageSelectSemester(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }

        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Semester GetIdBySemester(int Id)
        {
            return SemesterDAL.GetIdBySemester(Id);
        }
       

        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Semester> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return SemesterDAL.AllData(WhereSrc, PXzd, PXType);
        }

        //添加验证是否存在
        public static bool IsTrue(string Name)
        {
            Semester model = SemesterDAL.GetIdByName(Name);
            if (model != null && model.SemesterId != 0)
            {
                return true;
            }
            return false;
        }

        // 修改验证是否存在
        public static bool IsTrue(string Name, int Id)
        {
            Semester model = SemesterDAL.GetIdByName(Name);
            if (model != null && model.SemesterId != 0 && model.SemesterId != Id)
            {
                return true;
            }
            return false;
        }
    }
}
