using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// ZC 的摘要说明。
    /// </summary>
    public class ZC
    {
        #region 私有成员

        private string _zcbh;			//职称编号  
        private string _zcmc;		    //职称名称
        private string _zclx;           //职称类型
        private int    _bzgzl;          //标准工作量
        private bool   _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

        public string Zcbh
        {
            set
            {
                this._zcbh = value;
            }
            get
            {
                return this._zcbh;
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
        public string Zclx
        {
            set
            {
                this._zclx = value;
            }
            get
            {
                return this._zclx;
            }
        }
        public int Bzgzl
        {
            set
            {
                this._bzgzl = value;
            }
            get
            {
                return this._bzgzl;
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
        /// 根据参数zcbh，获取职称详细信息
        /// </summary>
        /// <param name="zcbh">职称编号/param>
        public void LoadData(string zcbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [zcb] where zcbh = " + zcbh;

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._zcbh = GetSafeData.ValidateDataRow_S(dr, "Zcbh");
                this._zcmc = GetSafeData.ValidateDataRow_S(dr, "Zcmc");
                this._zclx = GetSafeData.ValidateDataRow_S(dr, "Zclx");
                this._bzgzl = GetSafeData.ValidateDataRow_N(dr, "Bzgzl");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个职称
        /// </summary>
        /// <param name="htUserInfo">职称信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[zcb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改职称数据
        /// </summary>
        /// <param name="htUserInfo">职称信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[zcb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除职称数据
        /// </summary>
        /// <param name="zcbh">职称编号</param>
        public static void Delete(string zcbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [zcb] Where [zcbh] = "
                + SqlStringConstructor.GetQuotedString(zcbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在职称编号为zcbh的用户
        /// </summary>
        /// <param name="zcbh">职称编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasZC(string zcbh)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [zcb] where [zcbh] = "
                + SqlStringConstructor.GetQuotedString(zcbh);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断是否存在职称名称为zcmc的用户
        /// </summary>
        /// <param name="zcmc">职称名称</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasZCMC(string zcmc)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [zcb] where [zcmc] = "
                + SqlStringConstructor.GetQuotedString(zcmc);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询职称
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryZC(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [zcb] " + where;

            Database db = new Database();
            return db.GetDataTable(sql);
        }
        #endregion 方法
    }
}