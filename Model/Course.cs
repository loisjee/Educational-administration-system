using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Course
    {
        public Course() { } //无参构造函数

        public Course(int CourseId,  string CourseName, string Note, int TeacherId, int Credits)//带参构造函数
        {
            _CourseId = CourseId;
            _CourseName = CourseName;
            _Note = Note;
            _TeacherId=TeacherId;
            _Credits = Credits;
        }


        #region Model 
        private int _CourseId;
        private string _CourseName;
        private string _Note;
        private int _TeacherId;
        private int _Credits;

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
        public string CourseName
        {
            set { _CourseName = value; }
            get { return _CourseName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _Note = value; }
            get { return _Note; }
        }

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
        public int Credits
        {
            set { _Credits = value; }
            get { return _Credits; }
        }

        #endregion 
    }
}