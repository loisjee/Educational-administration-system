using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;

namespace BLL
{
    public class TeacherBLL
    {



        /// <summary>
        /// 验证用户是否能登录成功
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        public static bool GetUsersLogin(string TeacherCode, string Pwd, out Teacher teacher)
        {
            teacher = TeacherDAL.GetIdByTeacherCode(TeacherCode);
            if (teacher != null && teacher.Pwd == Pwd)
            {
                return true;
            }
            return false;
        }



        //添加验证是否存在
        public static bool IsTrue(string TeacherCode)
        {
            Teacher tch = TeacherDAL.GetIdByTeacherCode(TeacherCode);
            if (tch != null && tch.TeacherId != 0)
            {
                return true;
            }
            return false;
        }



        // 修改验证是否存在
        public static bool IsTrue(string TeacherCode, int TeacherId)
        {
            Teacher tch = TeacherDAL.GetIdByTeacherCode(TeacherCode);
            if (tch != null && tch.TeacherId != 0 && tch.TeacherId != TeacherId)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加 
        ///</summary>
        public static int AddTeacher(Teacher TeacherModel)
        {
            return TeacherDAL.AddTeacher(TeacherModel);
        }

        /// <summary> 
        /// 根据ID修改 
        ///</summary>
        public static int UpdateTeacher(Teacher TeacherModel)
        {
            return TeacherDAL.UpdateTeacher(TeacherModel);
        }

        /// <summary> 
        /// 根据主键删除 
        ///</summary>
        public static int DeleteTeacher(int Id)
        {
            return TeacherDAL.DeleteTeacher(Id);
        }





        /// <summary> 
        /// 根据主键查询实体 
        ///</summary>
        public static Teacher GetIdByTeacher(int Id)
        {
            return TeacherDAL.GetIdByTeacher(Id);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        public static List<Teacher> AllData(string WhereSrc, string PXzd, string PXType)
        {
            return TeacherDAL.AllData(WhereSrc, PXzd, PXType);
        }
    }
}