using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class ClassBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddClass(Class ClassModel)
        {
            return ClassDAL.AddClass(ClassModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteClass(int Id)
        {
            return ClassDAL.DeleteClass(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Class> PageSelectClass(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return ClassDAL.PageSelectClass(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateClass( Class ClassModel)
        {
            return ClassDAL.UpdateClass(ClassModel);
        }
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Class> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return ClassDAL.AllData(WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return ClassDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Class GetIdByClass(int Id)
        {
            return ClassDAL.GetIdByClass(Id);
        }

        //添加验证是否存在
        public static bool IsTrue(string Name)
        {
            Class model = ClassDAL.GetIdByName(Name);
            if (model != null && model.ClassId != 0)
            {
                return true;
            }
            return false;
        }

        // 修改验证是否存在
        public static bool IsTrue(string Name, int Id)
        {
            Class model = ClassDAL.GetIdByName(Name);
            if (model != null && model.ClassId != 0 && model.ClassId != Id)
            {
                return true;
            }
            return false;
        }

    }
}