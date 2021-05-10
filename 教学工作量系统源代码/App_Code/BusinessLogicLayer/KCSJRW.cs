using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// KCSJRW 的摘要说明
    /// </summary>
    public class KCSJRW
    {

        #region 私有成员

        private string _jsxm;
        private string _jsbh;
        private string _kcsjmc;
        private string _kcsjbh;
        private string _jxbbh;
        private string _jxbmc;
        private string _kbxn;
        private string _kbxq;
        private bool _exist;

        #endregion 私有成员

        #region 属性

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
        public string Kcsjmc
        {
            set
            {
                this._kcsjmc = value;
            }
            get
            {
                return this._kcsjmc;
            }
        }
        public string Kcsjbh
        {
            set
            {
                this._kcsjbh = value;
            }
            get
            {
                return this._kcsjbh;
            }
        }
        public string Jxbbh
        {
            set
            {
                this._jxbbh = value;
            }
            get
            {
                return this._jxbbh;
            }
        }
        public string Jxbmc
        {
            set
            {
                this._jxbmc = value;
            }
            get
            {
                return this._jxbmc;
            }
        }
        public string Kbxn
        {
            set
            {
                this._kbxn = value;
            }
            get
            {
                return this._kbxn;
            }

        }
        public string Kbxq
        {
            set
            {
                this._kbxq = value;
            }
            get
            {
                return this._kbxq;
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
        /// 根据参数Jxbbh，获取教学班详细信息
        /// </summary>
        /// <param name="jxbbh">教学班编号</param>
        public void LoadData(string jsbh, string kcsjmc, string jxbmc, string kbxn, string kbxq)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [js_kcsj_gxb],[jsb],[kcsjb],[jxbb] where [jsb].jsbh = "
                + SqlStringConstructor.GetQuotedString(jsbh) + " And [kcsjb].kcsjmc = " + SqlStringConstructor.GetQuotedString(kcsjmc)
                + " And [jxbb].jxbmc = " + SqlStringConstructor.GetQuotedString(jxbmc) + " And kbxn = " + SqlStringConstructor.GetQuotedString(kbxn) + " And kbxq ="
                + SqlStringConstructor.GetQuotedString(kbxq) + "And [js_kcsj_gxb].jsbh=[jsb].jsbh And [js_kcsj_gxb].kcsjbh=[kcsjb].kcsjbh And [js_kcsj_gxb].jxbbh=[jxbb].jxbbh";


            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jsxm = GetSafeData.ValidateDataRow_S(dr, "jsxm");
                this._jsbh = GetSafeData.ValidateDataRow_S(dr, "jsbh");
                this._kcsjmc = GetSafeData.ValidateDataRow_S(dr, "kcsjmc");
                this._kcsjbh = GetSafeData.ValidateDataRow_S(dr, "kcsjbh");
                this._jxbbh = GetSafeData.ValidateDataRow_S(dr, "jxbbh");
                this._jxbmc = GetSafeData.ValidateDataRow_S(dr, "jxbmc");
                this._kbxn = GetSafeData.ValidateDataRow_S(dr, "kbxn");
                this._kbxq = GetSafeData.ValidateDataRow_S(dr, "kbxq");

                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 查询教学班
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable Query(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * from [js_kcsj_gxb],[jsb],[kcsjb],[jxbb] " + where;

            if (where == "")
                sql += " Where";
            else
                sql += " And";

            sql += " [js_kcsj_gxb].jsbh=[jsb].jsbh And [js_kcsj_gxb].kcsjbh=[kcsjb].kcsjbh  And [js_kcsj_gxb].jxbbh=[jxbb].jxbbh";
            Database db = new Database();
            return db.GetDataTable(sql);
        }

        /// <summary>
        /// 删除课程设计任务
        /// </summary>
        /// <param name="sxbh"></param>
        public static void Delete(string jsbh, string kcsjmc, string jxbmc, string kbxn, string kbxq)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [js_kcsj_gxb] Where [jsbh] = "
                + SqlStringConstructor.GetQuotedString(jsbh) + " And [kcsjbh] = (select kcsjbh from [kcsjb] where kcsjmc = "
                + SqlStringConstructor.GetQuotedString(kcsjmc) + ") And [jxbbh] = (select jxbbh from [jxbb] where jxbmc = "+ SqlStringConstructor.GetQuotedString(jxbmc)
            + ") And [kbxn] = " + SqlStringConstructor.GetQuotedString(kbxn) + " And [kbxq] = "+ SqlStringConstructor.GetQuotedString(kbxq);

            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 向数据库添加一个课程设计任务
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[js_kcsj_gxb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改课程设计任务数据
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[js_kcsj_gxb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        public static bool HasKCRWSJ(string jsbh, string kcsjbh, string jxbbh, string kbxn, string kbxq)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [js_kcsj_gxb] where [jsbh] = " + SqlStringConstructor.GetQuotedString(jsbh)
                + " And kcsjbh = " + SqlStringConstructor.GetQuotedString(kcsjbh) + " And jxbbh ="
                + SqlStringConstructor.GetQuotedString(jxbbh) + " And kbxn = " + SqlStringConstructor.GetQuotedString(kbxn)
                + " And kbxq =" + SqlStringConstructor.GetQuotedString(kbxq);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }
        #endregion 方法
    }
}