using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// KCSJ 的摘要说明
    /// </summary>
    public class KCSJ
    {
        #region 私有成员

        private string _kcsjbh;			//教师编号  
        private string _kcsjmc;		    //教师姓名
        private string _kcsjzs;           //教师性别
        private bool _yxbz;             //在职状态
        private bool _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

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
        public string Kcsjzs
        {
            set
            {
                this._kcsjzs = value;
            }
            get
            {
                return this._kcsjzs;
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
        /// 根据参数kcsjbh，获取课程设计详细信息
        /// </summary>
        /// <param name="kcsjbh">课程设计编号/param>
        public void LoadData(string kcsjbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [kcsjb] where kcsjbh = " + SqlStringConstructor.GetQuotedString(kcsjbh);


            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._kcsjbh = GetSafeData.ValidateDataRow_S(dr, "Kcsjbh");
                this._kcsjmc = GetSafeData.ValidateDataRow_S(dr, "Kcsjmc");
                this._kcsjzs = GetSafeData.ValidateDataRow_S(dr, "Kcsjzs");
                this._yxbz = GetSafeData.ValidateDataRow_B(dr, "Yxbz");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        /// <summary>
        /// 向数据库添加一个课程设计
        /// </summary>
        /// <param name="htUserInfo">课程设计信息哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[kcsjb]", userInfo);	//利用Database类的Insert方法添加课程设计数据
        }

        /// <summary>
        /// 修改课程设计数据
        /// </summary>
        /// <param name="htUserInfo">课程设计信息哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[kcsjb]", userInfo, where);	//利用Database类的Update方法修改课程设计数据
        }

        /// <summary>
        /// 判断是否存在课程编号为kcsjbh
        /// </summary>
        /// <param name="kcsjbh">课程设计编号</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasKCSJ(string kcsjbh)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [kcsjb] where [kcsjbh] = "
                + SqlStringConstructor.GetQuotedString(kcsjbh);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除课程设计数据
        /// </summary>
        /// <param name="kcsjbh">课程设计编号</param>
        public static void Delete(string kcsjbh)
        {
            Database db = new Database();		//实例化一个Database类
            string sql = "Delete from [kcsjb] Where [kcsjbh] = "
                + SqlStringConstructor.GetQuotedString(kcsjbh);
            db.ExecuteSQL(sql);
        }

        public static DataTable QueryKCSJ(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [kcsjb] " + where;


            Database db = new Database();
            return db.GetDataTable(sql);
        }
        #endregion 方法



    }
}
