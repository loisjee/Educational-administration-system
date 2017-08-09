using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Sudents
    {
        public Sudents() { } //无参构造函数


        public Sudents(int SutId, string SutCode, string SutName, int ClassId, string Native, DateTime Born, string National, string Political, string Sex, int Grade, string Contact, string Note, string Pwd)//带参构造函数
        {
            _SutId = SutId;
            _SutCode = SutCode;
            _SutName = SutName;
            _ClassId = ClassId;
            _Native=Native;
                _Born=Born;
                _National = National;
                _Political=Political;
                _Sex=Sex;
                _Grade=Grade;
                _Contact=Contact;

                _Note=Note;
                _Pwd = Pwd;
        }


        //建立学生属性，属性与数据库中的属性一一对应
        #region Model 
        private int _SutId;
        private string _SutCode;
        private string _SutName;
        private int _ClassId;
        private string _Native;
        private DateTime _Born;
        private string _National;
        private string _Political;
        private string _Sex;
        private int _Grade;
        private string _Contact;
        private string _Note;
        private string _Pwd;
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
        public string SutCode
        {
            set { _SutCode = value; }
            get { return _SutCode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SutName
        {
            set { _SutName = value; }
            get { return _SutName; }
        }

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
        public string Native
        {
            set { _Native = value; }
            get { return _Native; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Born
        {
            set { _Born = value; }
            get { return _Born; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string National
        {
            set { _National = value; }
            get { return _National; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Political
        {
            set { _Political = value; }
            get { return _Political; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _Sex = value; }
            get { return _Sex; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Grade
        {
            set { _Grade = value; }
            get { return _Grade; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Contact
        {
            set { _Contact = value; }
            get { return _Contact; }
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
        public string Pwd
        {
            set { _Pwd = value; }
            get { return _Pwd; }
        }

        #endregion 
    }
}