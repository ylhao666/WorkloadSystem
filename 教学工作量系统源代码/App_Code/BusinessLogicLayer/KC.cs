using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// KC 的摘要说明。
    /// </summary>
    public class KC
    {
        #region 私有成员

        private string _kcbh;			//教师编号  
        private string _kcmc;		    //教师姓名
        private string _kcxz;           //教师性别
        private string _kclx;           //院系名
        private bool _fdkcsj;             //在职状态
        private bool _yxbz;             //在职状态
        private bool _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

        public string Kcbh
        {
            set
            {
                this._kcbh = value;
            }
            get
            {
                return this._kcbh;
            }
        }
        public string Kcmc
        {
            set
            {
                this._kcmc = value;
            }
            get
            {
                return this._kcmc;
            }
        }
        public string Kcxz
        {
            set
            {
                this._kcxz = value;
            }
            get
            {
                return this._kcxz;
            }
        }
        public string Kclx
        {
            set
            {
                this._kclx = value;
            }
            get
            {
                return this._kclx;
            }
        }
        public bool Fdkcsj
        {
            set
            {
                this._fdkcsj = value;
            }
            get
            {
                return this._fdkcsj;
            }
        }
        public bool Yxbz
        {
            set
            {
                this._yxbz = value;
            }
            get
            {
                return this._yxbz;
            }
        }
        public bool Exist
        {
            get
            {
                return this._exist;
            }
        }

        #endregion 属性

        #region 方法

        /// <summary>
        /// 根据参数kcbh，获取课程详细信息
        /// </summary>
        /// <param name="kcbh">课程编号/param>
        public void LoadData(string kcbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [kcb] where kcbh = " + SqlStringConstructor.GetQuotedString(kcbh);
               

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._kcbh = GetSafeData.ValidateDataRow_S(dr, "Kcbh");
                this._kcmc = GetSafeData.ValidateDataRow_S(dr, "Kcmc");
                this._kcxz = GetSafeData.ValidateDataRow_S(dr, "Kcxz");
                this._kclx = GetSafeData.ValidateDataRow_S(dr, "Kclx");
                this._fdkcsj = GetSafeData.ValidateDataRow_B(dr, "Fdkcsj");
                this._yxbz = GetSafeData.ValidateDataRow_B(dr, "Yxbz");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个课程
        /// </summary>
        /// <param name="htUserInfo">课程信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[kcb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改课程数据
        /// </summary>
        /// <param name="htUserInfo">课程信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[kcb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除课程数据
        /// </summary>
        /// <param name="kcbh">课程编号</param>
        public static void Delete(string kcbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [kcb] Where [kcbh] = "
                + SqlStringConstructor.GetQuotedString(kcbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在课程编号为kcbh
        /// </summary>
        /// <param name="kcbh">课程编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasKC(string kcmc)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [kcb] where [kcmc] = "
                + SqlStringConstructor.GetQuotedString(kcmc);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询课程
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryKC(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [kcb] " + where;

            Database db = new Database();
            return db.GetDataTable(sql);
        }
        #endregion 方法
    }
}