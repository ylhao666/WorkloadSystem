using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// JS 的摘要说明。
    /// </summary>
    public class JS
    {
        #region 私有成员

        private string _jsbh;			//教师编号  
        private string _jsxm;		    //教师姓名
        private string _jsxb;           //教师性别
        private string _yxmc;           //院系名称
        private string _zcmc;           //职称名称
        private string _zwlx;           //职务类型
        private string _dlmm;           //登陆密码
        private bool _zzzt;             //在职状态
        private bool _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

        public string Jsbh
        {
            set
            {
                this._jsbh = value;
            }
            get
            {
                return this._jsbh;
            }
        }
        public string Jsxm
        {
            set
            {
                this._jsxm = value;
            }
            get
            {
                return this._jsxm;
            }
        }
        public string Jsxb
        {
            set
            {
                this._jsxb = value;
            }
            get
            {
                return this._jsxb;
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
        public string Zcmc
        {
            set
            {
                this._zcmc = value;
            }
            get
            {
                return this._zcmc;
            }
        }
        public string Zwlx
        {
            set
            {
                this._zwlx = value;
            }
            get
            {
                return this._zwlx;
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
        public bool Zzzt
        {
            set
            {
                this._zzzt = value;
            }
            get
            {
                return this._zzzt;
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
        /// 根据参数jsbh，获取教师详细信息
        /// </summary>
        /// <param name="jsbh">教师编号/param>
        public void LoadData(string jsbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [jsb],[yxb],[zwb],[zcb] where jsbh = " + SqlStringConstructor.GetQuotedString(jsbh)
                +"And [jsb].yxbh = [yxb].yxbh And [jsb].zcbh = [zcb].zcbh And [jsb].zwbh = [zwb].zwbh";

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jsbh = GetSafeData.ValidateDataRow_S(dr, "Jsbh");
                this._jsxm = GetSafeData.ValidateDataRow_S(dr, "Jsxm");
                this._jsxb = GetSafeData.ValidateDataRow_S(dr, "Jsxb");
                this._yxmc = GetSafeData.ValidateDataRow_S(dr, "Yxmc");
                this._zcmc = GetSafeData.ValidateDataRow_S(dr, "Zcmc");
                this._zwlx = GetSafeData.ValidateDataRow_S(dr, "Zwlx");
                this._dlmm = GetSafeData.ValidateDataRow_S(dr, "Dlmm");
                this._zzzt = GetSafeData.ValidateDataRow_B(dr, "Zzzt");

                //解密口令
                this._dlmm = Encrypt.DecryptString(_dlmm, _jsbh);
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个教师
        /// </summary>
        /// <param name="htUserInfo">教师信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[jsb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改班级数据
        /// </summary>
        /// <param name="htUserInfo">班级信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[jsb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除教师数据
        /// </summary>
        /// <param name="jsbh">教师编号</param>
        public static void Delete(string jsbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [jsb] Where [jsbh] = "
                + SqlStringConstructor.GetQuotedString(jsbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在教师编号为jsbh
        /// </summary>
        /// <param name="jsbh">教师编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasJS(string bjbh)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [jsb] where [jsbh] = "
                + SqlStringConstructor.GetQuotedString(bjbh);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询教师
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryJS(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql  = "Select * from [jsb],[yxb],[zwb],[zcb] "+ where;

            if (where == "")
            {
                sql += " Where";
            }
            else
            {
                sql += " And";
            }

            sql += " [jsb].yxbh = [yxb].yxbh And [jsb].zcbh = [zcb].zcbh And [jsb].zwbh = [zwb].zwbh";
            
            Database db = new Database();
            return db.GetDataTable(sql);
        }
        #endregion 方法
    }
}