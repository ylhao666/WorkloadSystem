using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// SXRW 的摘要说明
    /// </summary>
    public class SXRW
    {
        #region 私有成员
	    
        private string _jsxm;
        private string _jsbh;	    
        private string _bjmc;
        private string _bjbh;
        private string _sxmc;
        private string _sxlx;
        private string _yxmc;
        private string _yxbh;
        private double _sxzsts;
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
        public string Bjmc
        {
            set
            {
                this._bjmc = value;
            }
            get
            {
                return this._bjmc;
            }
        }
        public string Bjbh
        {
            set
            {
                this._bjbh = value;
            }
            get
            {
                return this._bjbh;
            }
        }
        public string Sxmc
        {
            set
            {
                this._sxmc = value;
            }
            get
            {
                return this._sxmc;
            }
        }
        public string Sxlx
        {
            set
            {
                this._sxlx = value;
            }
            get
            {
                return this._sxlx;
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
        public string Yxbh
        {
            set
            {
                this._yxbh = value;
            }
            get
            {
                return this._yxbh;
            }

        }
        public double Sxzsts
        {
            set
            {
                this._sxzsts = value;
            }
            get
            {
                return this._sxzsts;
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
        public void LoadData(string jsbh,string bjmc,string sxlx,string kbxn,string kbxq)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [sxb],[jsb],[yxb],[bjb] where [jsb].jsbh = "
                + SqlStringConstructor.GetQuotedString(jsbh)+" And [bjb].bjmc = "+SqlStringConstructor.GetQuotedString(bjmc)
                +" And sxlx = "+SqlStringConstructor.GetQuotedString(sxlx)+" And kbxn = "+SqlStringConstructor.GetQuotedString(kbxn)+" And kbxq ="
                +SqlStringConstructor.GetQuotedString(kbxq)+"And [sxb].jsbh=[jsb].jsbh And [sxb].bjbh=[bjb].bjbh And [sxb].yxbh=[yxb].yxbh";


            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jsxm = GetSafeData.ValidateDataRow_S(dr, "jsxm");
                this._bjmc = GetSafeData.ValidateDataRow_S(dr, "bjmc");
                this._sxmc = GetSafeData.ValidateDataRow_S(dr, "sxmc");
                this._sxlx = GetSafeData.ValidateDataRow_S(dr, "sxlx");
                this._yxmc = GetSafeData.ValidateDataRow_S(dr, "yxmc");
                this._sxzsts = GetSafeData.ValidateDataRow_F(dr, "sxzsts");
                this._kbxn = GetSafeData.ValidateDataRow_S(dr, "kbxn");
                this._kbxq = GetSafeData.ValidateDataRow_S(dr, "kbxq");
                this._jsbh = GetSafeData.ValidateDataRow_S(dr, "jsbh");
                this._bjbh = GetSafeData.ValidateDataRow_S(dr, "bjbh");
                this._yxbh = GetSafeData.ValidateDataRow_S(dr, "yxbh");
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
            string sql = "Select * From [sxb],[jsb],[bjb],[yxb] " + where;

            if (where == "")
                sql += " Where";
            else
                sql += " And";

            sql += "[sxb].jsbh=[jsb].jsbh And [sxb].bjbh=[bjb].bjbh And [sxb].yxbh=[yxb].yxbh";
            Database db = new Database();
            return db.GetDataTable(sql);
        }

        /// <summary>
        /// 删除实习任务
        /// </summary>
        /// <param name="sxbh"></param>
        public static void Delete(string jsbh,string bjmc,string sxlx,string kbxn,string kbxq)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [sxb] Where [jsbh] ="
                + SqlStringConstructor.GetQuotedString(jsbh) + " And [bjbh] = (select bjbh from [bjb] where bjmc = "
                + SqlStringConstructor.GetQuotedString(bjmc) + ") And [sxlx] = " + SqlStringConstructor.GetQuotedString(sxlx)
            + " And [kbxn] = " + SqlStringConstructor.GetQuotedString(kbxn) + " And [kbxq] = "
            + SqlStringConstructor.GetQuotedString(kbxq);
             
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 向数据库添加一个实习任务
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[sxb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }


        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="htUserInfo">用户信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[sxb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        public static bool HasSXRW(string jsbh,string bjbh,string sxlx,string kbxn,string kbxq)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [sxb] where [jsbh] = "
                + SqlStringConstructor.GetQuotedString(jsbh) + " And bjbh = " + SqlStringConstructor.GetQuotedString(bjbh) + " And sxlx ="
                + SqlStringConstructor.GetQuotedString(sxlx) + " And kbxn = " + SqlStringConstructor.GetQuotedString(kbxn)
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
