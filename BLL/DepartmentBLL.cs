using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class DepartmentBLL
    {
        /// <summary> 
        /// 添加 
        ///</summary> 
        public static int AddDepartment(Department DepartmentModel)
        {
            return DepartmentDAL.AddDepartment(DepartmentModel);
        }
        /// <summary> 
        /// 根据主键删除 
        ///</summary> 
        public static int DeleteDepartment(int Id)
        {
            return DepartmentDAL.DeleteDepartment(Id);
        }
        /// <summary> 
        /// 分页 
        ///</summary> 
        public static List<Department> PageSelectDepartment(int pageSize, int pageIndex, string WhereSrc, string PXzd, string PXType)
        {
            pageIndex = pageIndex - 1;
            return DepartmentDAL.PageSelectDepartment(pageSize, pageIndex, WhereSrc, PXzd, PXType);
        }
        /// <summary> 
        /// 修改 
        ///</summary> 
        public static int UpdateDepartment(Department DepartmentModel)
        {
            return DepartmentDAL.UpdateDepartment(DepartmentModel);
        }
        
        /// <summary> 
        /// 查询全部
        ///</summary>
        public static List<Department> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return DepartmentDAL.AllData(WhereSrc, PXzd, PXType);
        }

        /// <summary> 
        /// 查询条数 
        ///</summary>
        public static int CountNumber(string NewWHere)
        {
            return DepartmentDAL.CountNumber(NewWHere);
        }
        /// <summary> 
        /// 根据主键查询实体 
        ///</summary> 
        public static Department GetIdByDepartment(int Id)
        {
            return DepartmentDAL.GetIdByDepartment(Id);
        }

        //添加验证是否存在
        public static bool IsTrue(string Name)
        {
            Department model = DepartmentDAL.GetIdByName(Name);
            if (model != null && model.DeptId != 0)
            {
                return true;
            }
            return false;
        }

        // 修改验证是否存在
        public static bool IsTrue(string Name, int Id)
        {
            Department model = DepartmentDAL.GetIdByName(Name);
            if (model != null && model.DeptId != 0 && model.DeptId != Id)
            {
                return true;
            }
            return false;
        }
    }
}