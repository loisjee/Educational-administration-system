using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Teacher
    {
        public Teacher() { } //无参构造函数

        public Teacher(int TeacherId, string TeacherCode, string TeacherName,string Pwd)//带参构造函数
        {
            _TeacherId = TeacherId;
            _TeacherCode = TeacherCode;
            _TeacherName = TeacherName;
            _Pwd = Pwd;
        }


        #region Model 
        private int _TeacherId;
        private string _TeacherCode;
        private string _TeacherName;
        private string _Pwd;

        /// <summary>
        /// 
        /// </summary>
        public int TeacherId
        {
            set { _TeacherId = value; }
            get { return _TeacherId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TeacherCode
        {
            set { _TeacherCode = value; }
            get { return _TeacherCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TeacherName
        {
            set { _TeacherName = value; }
            get { return _TeacherName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _Pwd = value; }
            get { return _Pwd; }
        }
        

        #endregion 
    }
}