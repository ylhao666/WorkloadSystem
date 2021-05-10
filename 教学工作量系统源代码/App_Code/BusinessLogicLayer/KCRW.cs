using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// KCSJ 的摘要说明
    /// </summary>
    public class KCRW
    {

        #region 私有成员

        private string _jsxm;
        private string _jsbh;
        private string _kcmc;
        private string _kcbh;
        private string _jxbbh;
        private string _jxbmc;
        private string _kbxn;
        private string _kbxq;
        private int _llxs;
        private double _lldxs;
        private int _syxs;
        private double _sydxs;
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
        public int Llxs
        {
            set
            {
                this._llxs = value;
            }
            get
            {
                return this._llxs;
            }
        }
        public double Lldxs
        {
            set
            {
                this._lldxs = value;
            }
            get
            {
                return this._lldxs;
            }
        }
        public int Syxs
        {
            set
            {
                this._syxs = value;
            }
            get
            {
                return this._syxs;
            }
        }
        public double Sydxs
        {
            set
            {
                this._sydxs = value;
            }
            get
            {
                return this._sydxs;
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
        public void LoadData(string jsbh, string kcmc, string jxbmc, string kbxn, string kbxq)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [js_kc_gxb],[jsb],[kcb],[jxbb] where [jsb].jsbh = "
                + SqlStringConstructor.GetQuotedString(jsbh) + " And [kcb].kcmc = " + SqlStringConstructor.GetQuotedString(kcmc)
                + " And [jxbb].jxbmc = " + SqlStringConstructor.GetQuotedString(jxbmc) + " And kbxn = " + SqlStringConstructor.GetQuotedString(kbxn) + " And kbxq ="
                + SqlStringConstructor.GetQuotedString(kbxq) + "And [js_kc_gxb].jsbh=[jsb].jsbh And [js_kc_gxb].kcbh=[kcb].kcbh And [js_kc_gxb].jxbbh=[jxbb].jxbbh";


            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jsxm = GetSafeData.ValidateDataRow_S(dr, "jsxm");
                this._jsbh = GetSafeData.ValidateDataRow_S(dr, "jsbh");
                this._kcmc = GetSafeData.ValidateDataRow_S(dr, "kcmc");
                this._kcbh = GetSafeData.ValidateDataRow_S(dr, "kcbh");
                this._jxbbh = GetSafeData.ValidateDataRow_S(dr, "jxbbh");
                this._jxbmc = GetSafeData.ValidateDataRow_S(dr, "jxbmc");
                this._kbxn = GetSafeData.ValidateDataRow_S(dr, "kbxn");
                this._kbxq = GetSafeData.ValidateDataRow_S(dr, "kbxq");
                this._llxs = GetSafeData.ValidateDataRow_N(dr, "llxs");
                this._lldxs = GetSafeData.ValidateDataRow_F(dr, "lldxs");
                this._syxs = GetSafeData.ValidateDataRow_N(dr, "syxs");
                this._sydxs = GetSafeData.ValidateDataRow_F(dr, "sydxs");

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
            string sql = "Select * from [js_kc_gxb],[jsb],[kcb],[jxbb] " + where;

            if (where == "")
                sql += " Where";
            else
                sql += " And";

            sql += " [js_kc_gxb].jsbh=[jsb].jsbh And [js_kc_gxb].kcbh=[kcb].kcbh  And [js_kc_gxb].jxbbh=[jxbb].jxbbh";
            Database db = new Database();
            return db.GetDataTable(sql);
        }

        /// <summary>
        /// 删除课程设计任务
        /// </summary>
        /// <param name="sxbh"></param>
        public static void Delete(string jsbh, string kcmc, string jxbmc, string kbxn, string kbxq)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [js_kc_gxb] Where [jsbh] ="
                + SqlStringConstructor.GetQuotedString(jsbh) + " And [kcbh] = (select kcbh from [kcb] where kcmc = "
                + SqlStringConstructor.GetQuotedString(kcmc) + ") And [jxbbh] = (select jxbbh from [jxbb] where jxbmc = " + SqlStringConstructor.GetQuotedString(jxbmc)
            + " ) And [kbxn] = " + SqlStringConstructor.GetQuotedString(kbxn) + " And [kbxq] = " + SqlStringConstructor.GetQuotedString(kbxq);

            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 向数据库添加一个课程设计任务
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[js_kc_gxb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改课程设计任务数据
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[js_kc_gxb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        public static bool HasKCRW(string jsbh, string kcbh,string jxbbh, string kbxn, string kbxq)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [js_kc_gxb] where [jsbh] = " + SqlStringConstructor.GetQuotedString(jsbh)
                +" And kcbh = " + SqlStringConstructor.GetQuotedString(kcbh) + " And jxbbh ="
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
