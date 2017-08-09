using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Semester
    {
        public Semester() { } //无参构造函数

        public Semester(int SemesterId, string SemesterName)//带参构造函数
        {
            _SemesterId = SemesterId;
            _SemesterName = SemesterName;
        }
      
        #region Model 
        private int _SemesterId;
        private string _SemesterName;

        /// <summary>
        /// 
        /// </summary>
        public int SemesterId
        {
            set { _SemesterId = value; }
            get { return _SemesterId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SemesterName
        {
            set { _SemesterName = value; }
            get { return _SemesterName; }
        }

      
      


        #endregion 
    }
}