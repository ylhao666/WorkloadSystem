using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// User 的摘要说明。
    /// </summary>
    public class User
    {
        #region 私有成员

        private string _czy;	    //操作员
        private string _dlmm;	    //登录密码
        private string _yxmc;	    //所属部门
        private string _qx;		    //权限

        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性


        public string Czy
        {
            set
            {
                this._czy = value;
            }
            get
            {
                return this._czy;
            }
        }
        public string Dlmm
        {
            set
            {
                this._dlmm = value;
            }
            get
            {
                return this._dlmm;
            }
        }
        public string Yxmc
        {
            set
            {
                this._yxmc = value;
            }
            get
            {
                return this._yxmc;
            }
        }
        public string Qx
        {
            set
            {
                this._qx = value;
            }
            get
            {
                return this._qx;
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
        /// 根据参数loginName，获取用户详细信息
        /// </summary>
        /// <param name="czy">用户登录名</param>
        public void LoadData(string czy)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [czyb],[yxb] where czy = "
                + SqlStringConstructor.GetQuotedString(czy)
                + " And [czyb].yxbh=[yxb].yxbh";

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._czy = GetSafeData.ValidateDataRow_S(dr, "czy");
                this._dlmm = GetSafeData.ValidateDataRow_S(dr, "dlmm");
                this._yxmc = GetSafeData.ValidateDataRow_S(dr, "yxmc");
                this._qx = GetSafeData.ValidateDataRow_S(dr, "qx");

                //解密口令
                this._dlmm = Encrypt.DecryptString(_dlmm, _czy);

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个用户
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[czyb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[czyb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="czy">用户登录名</param>
        public static void Delete(string czy)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [czyb] Where [czy] = "
                + SqlStringConstructor.GetQuotedString(czy);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在登录名为loginName的用户
        /// </summary>
        /// <param name="czy">用户登录名</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasUser(string czy)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [czyb] where [czy] = "
                + SqlStringConstructor.GetQuotedString(czy);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryUsers(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [czyb],[yxb] " + where;

            if (where == "")
                sql += " Where";
            else
                sql += " And";

            sql += " [czyb].yxbh=[yxb].yxbh";

            Database db = new Database();
            return db.GetDataTable(sql);
        }

        #endregion 方法
    }
}
