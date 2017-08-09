using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Class
    {
        public Class() { } //无参构造函数


        #region Model 
        private int _ClassId;
        private string _ClassName;
        private int _MajorId;

        /// <summary>
        /// 
        /// </summary>
        public int ClassId
        {
            set { _ClassId = value; }
            get { return _ClassId; }
        }

       

        /// <summary>
        /// 
        /// </summary>
        public string ClassName
        {
            set { _ClassName = value; }
            get { return _ClassName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MajorId
        {
            set { _MajorId = value; }
            get { return _MajorId; }
        }

        #endregion 
    }
}