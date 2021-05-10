using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// BJ 的摘要说明。
    /// </summary>
    public class BJ
    {
        #region 私有成员

        private string _bjbh;			//班级编号  
        private string _bjmc;		    //班级名称
        private int    _bjrs;           //班级人数
        private bool   _yxbz;           //有效标志
        private bool   _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

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
        public int Bjrs
        {
            set
            {
                this._bjrs = value;
            }
            get
            {
                return this._bjrs;
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
        /// 根据参数bjbh，获取班级详细信息
        /// </summary>
        /// <param name="bjbh">班级编号/param>
        public void LoadData(string bjbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [bjb] where bjbh = " + bjbh;

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._bjbh = GetSafeData.ValidateDataRow_S(dr, "Bjbh");
                this._bjmc = GetSafeData.ValidateDataRow_S(dr, "Bjmc");
                this._bjrs = GetSafeData.ValidateDataRow_N(dr, "Bjrs");
                this._yxbz = GetSafeData.ValidateDataRow_B(dr, "Yxbz");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个班级
        /// </summary>
        /// <param name="htUserInfo">班级信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[bjb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改班级数据
        /// </summary>
        /// <param name="htUserInfo">班级信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[bjb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除班级数据
        /// </summary>
        /// <param name="bjbh">班级编号</param>
        public static void Delete(string bjbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [bjb] Where [bjbh] = "
                + SqlStringConstructor.GetQuotedString(bjbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在班级编号为bjbh
        /// </summary>
        /// <param name="bjbh">班级编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasBJ(string bjmc)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [bjb] where [bjmc] = "
                + SqlStringConstructor.GetQuotedString(bjmc);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询班级
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryBJ(Hashtable queryItems)
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
                             "____" + item.Value.ToString()
                             + "______") + " OR " + item.Key.ToString()
                             + " Like "
                             + SqlStringConstructor.GetQuotedString(
                             "____" + item.Value.ToString() + "__");

                }
                else
                {
                    where += item.Key.ToString() + "= " + item.Value;
                }
                Count++;
            }



            string sql = "Select * From [bjb] " + where;
            Database db = new Database();
            return db.GetDataTable(sql);
        }

        public static DataTable Query(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [bjb] " + where;

            Database db = new Database();
            return db.GetDataTable(sql);
        }

        #endregion 方法
    }
}