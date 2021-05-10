using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;


namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// XND 的摘要说明
    /// </summary>
    public class XND
    {
        #region 私有成员

        private string _xnd;			//学年度 
        private bool _mrxn;             //默认学年
        private bool _exist;		    //是否存在标志

        #endregion 私有成员

        #region 属性

        public string Xnd
        {
            set
            {
                this._xnd = value;
            }
            get
            {
                return this._xnd;
            }
        }
  
        public bool Mrxn
        {
            set
            {
                this._mrxn = value;
            }
            get
            {
                return this._mrxn;
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
        /// 获取学年度信息
        /// </summary>
        public void LoadData()
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [xndb] where [mrxn] = 1";

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._xnd = GetSafeData.ValidateDataRow_S(dr, "Xnd");
                this._mrxn = GetSafeData.ValidateDataRow_B(dr, "Mrxn");
                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }



        public static void SetData(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类


        }

        /// <summary>
        /// 判断是否存在学年度
        /// </summary>
        /// <param name="xnd">学年度</param>
        /// <returns>如果存在，返回true；否则，返回false</returns>
        public static bool HasXND(string xnd)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [xndb] where [xnd] = "
                + SqlStringConstructor.GetQuotedString(xnd);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 向数据库添加一个学年度
        /// </summary>
        /// <param name="htUserInfo">学年度哈希表</param>
        public static void Add(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[xndb]", userInfo);	//利用Database类的Insert方法添加学年度数据
        }

        /// <summary>
        /// 修改学年度数据
        /// </summary>
        /// <param name="htUserInfo">学年度哈希表</param>
        public static void Update(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[xndb]", userInfo, where);	//利用Database类的Update方法修改学年度数据
        }


        #endregion 方法
    
    
    
    }


}
