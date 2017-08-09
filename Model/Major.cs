using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Major
    {
        public Major() { } //无参构造函数


        #region Model 
        private int _MajorId;
        private string _MajorName;
        private int _DeptId;
        private string _Note;

        /// <summary>
        /// 
        /// </summary>
        public int MajorId
        {
            set { _MajorId = value; }
            get { return _MajorId; }
        }

        

        /// <summary>
        /// 
        /// </summary>
        public string MajorName
        {
            set { _MajorName = value; }
            get { return _MajorName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DeptId
        {
            set { _DeptId = value; }
            get { return _DeptId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _Note = value; }
            get { return _Note; }
        }

        #endregion 
    }
}