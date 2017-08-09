using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public class Department
    {
        public Department() { } //无参构造函数

        public Department(int DeptId, string DeptName, string Contact)//带参构造函数
        {
           _DeptId  =DeptId ;
           _DeptName = DeptName;
           _Contact = Contact;
        }
      
        #region Model 
        private int _DeptId;
        private string _DeptName;
        private string _Contact;

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
        public string DeptName
        {
            set { _DeptName = value; }
            get { return _DeptName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Contact
        {
            set { _Contact = value; }
            get { return _Contact; }
        }

      


        #endregion 
    }
}