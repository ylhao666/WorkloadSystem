using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// ZY 的摘要说明。
    /// </summary>
    public class ZY
    {
        #region 私有成员

        private string _zybh;			//专业编号  
        private string _zymc;		    //专业名称
        private string _zylx;           //专业类型
        private bool _yxbz;             //有效标志
        private bool _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

        public string Zybh
        {
            set
            {
                this._zybh = value;
            }
            get
            {
                return this._zybh;
            }
        }
        public string Zymc
        {
            set
            {
                this._zymc = value;
            }
            get
            {
                return this._zymc;
            }
        }
        public string Zylx
        {
            set
            {
                this._zylx = value;
            }
            get
            {
                return this._zylx;
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
        /// 根据参数zybh，获取专业详细信息
        /// </summary>
        /// <param name="zybh">专业编号</param>
        public void LoadData(string zybh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [zyb] where zybh = " + zybh;

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._zybh = GetSafeData.ValidateDataRow_S(dr, "Zybh");
                this._zymc = GetSafeData.ValidateDataRow_S(dr, "Zymc");
                this._zylx = GetSafeData.ValidateDataRow_S(dr, "Zylx");
                this._yxbz = GetSafeData.ValidateDataRow_B(dr, "Yxbz");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个专业
        /// </summary>
        /// <param name="htUserInfo">专业信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[zyb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改专业数据
        /// </summary>
        /// <param name="htUserInfo">专业信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[zyb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除专业数据
        /// </summary>
        /// <param name="zybh">专业编号</param>
        public static void Delete(string zybh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [zyb] Where [zybh] = "
                + SqlStringConstructor.GetQuotedString(zybh);
            db.ExecuteSQL(sql);
        }


        /// <summary>
        /// 查询专业
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryZY(Hashtable queryItems)
        {
            int Count = 0;
            string where = "";
            foreach (DictionaryEntry item in queryItems)
            {
                if (Count == 0)
                    where = " Where ";
                else
                    where += " And ";
                if (item.Value.GetType().ToString() == "System.String")
                {

                    where +=  item.Key.ToString()
                             + " Like "
                             + SqlStringConstructor.GetQuotedString(
                             item.Value.ToString()
                             + "%");
                }
                else
                {
                    where += item.Key.ToString() + "= " + item.Value;
                }
                Count++;
            }

            string sql = "Select * From [zyb] " + where;
            Database db = new Database();
            return db.GetDataTable(sql);
        }


        public static bool HasZY(string zymc)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [zyb] where [zymc] = "
                + SqlStringConstructor.GetQuotedString(zymc);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        #endregion 方法
    }
}