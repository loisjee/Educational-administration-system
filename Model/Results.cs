using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Results
    {
        public Results() { } //无参构造函数


        #region Model 
        private int _ResultsId;
        private int _SutId;
        private int _CourseId;
        private int _Score;
        private int _SemesterId;
        private int _StuCount;

        /// <summary>
        /// 
        /// </summary>
        public int ResultsId
        {
            set { _ResultsId = value; }
            get { return _ResultsId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SutId
        {
            set { _SutId = value; }
            get { return _SutId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int CourseId
        {
            set { _CourseId = value; }
            get { return _CourseId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Score
        {
            set { _Score = value; }
            get { return _Score; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SemesterId
        {
            set { _SemesterId = value; }
            get { return _SemesterId; }
        }

        /// <summary>
        /// 成绩统计个数
        /// </summary>
        public int StuCount
        {
            set { _StuCount = value; }
            get { return _StuCount; }
        }

        #endregion 
    }
}