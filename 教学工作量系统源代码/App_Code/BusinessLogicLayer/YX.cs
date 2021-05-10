using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// YX 的摘要说明。
    /// </summary>
    public class YX
    {
        #region 私有成员

        private string _yxbh;			//院系编号
        private string _yxmc;		   //院系名称
        private bool _yxbz;            //有效标志
        private bool _exist;		   //是否存在标志

        #endregion 私有成员

        #region 属性

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
        /// 根据参数yxbh，获取部门详细信息
        /// </summary>
        /// <param name="yxbh">院系编号 </param >
        public void LoadData(string yxbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [yxb] where yxbh = " + yxbh;

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._yxbh = GetSafeData.ValidateDataRow_S(dr, "Yxbh");
                this._yxmc = GetSafeData.ValidateDataRow_S(dr, "Yxmc");
                this._yxbz = GetSafeData.ValidateDataRow_B(dr, "Yxbz");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个院系
        /// </summary>
        /// <param name="htUserInfo">职称信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[yxb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }

        /// <summary>
        /// 修改院系数据
        /// </summary>
        /// <param name="htUserInfo">职称信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[yxb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        /// <summary>
        /// 删除院系数据
        /// </summary>
        /// <param name="yxbh">院系编号</param>
        public static void Delete(string yxbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [yxb] Where [yxbh] = "
                + SqlStringConstructor.GetQuotedString(yxbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 判断是否存在院系编号为yxbh的用户
        /// </summary>
        /// <param name="yxbh">院系编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasYX(string yxbh)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [yxb] where [yxbh] = "
                + SqlStringConstructor.GetQuotedString(yxbh);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 查询院系
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryYX(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [yxb] " + where;
            Database db = new Database();
            return db.GetDataTable(sql);
        }
        #endregion 方法
    }
}