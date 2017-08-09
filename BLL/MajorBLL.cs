using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class MajorBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddMajor(Major MajorModel)
        {
            return MajorDAL.AddMajor(MajorModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteMajor(int Id)
        {
            return MajorDAL.DeleteMajor(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Major> PageSelectMajor(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return MajorDAL.PageSelectMajor(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateMajor( Major MajorModel)
        {
            return MajorDAL.UpdateMajor(MajorModel);
        }
    

        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Major> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return MajorDAL.AllData(WhereSrc, PXzd, PXType);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return MajorDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Major GetIdByMajor(int Id)
        {
            return MajorDAL.GetIdByMajor(Id);
        }
        //添加验证是否存在
        public static bool IsTrue(string Name)
        {
            Major model = MajorDAL.GetIdByName(Name);
            if (model != null && model.MajorId != 0)
            {
                return true;
            }
            return false;
        }

        // 修改验证是否存在
        public static bool IsTrue(string Name, int Id)
        {
            Major model = MajorDAL.GetIdByName(Name);
            if (model != null && model.MajorId != 0 && model.MajorId != Id)
            {
                return true;
            }
            return false;
        }
    }
}