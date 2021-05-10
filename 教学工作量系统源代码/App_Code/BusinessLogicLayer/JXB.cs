using System;
using System.Data;
using System.Collections;

using Gzl.DataAccessLayer;
using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.BusinessLogicLayer
{
    /// <summary>
    /// JXB 的摘要说明
    /// </summary>
    public class JXB
    {

        #region 私有成员

        private string _jxbbh;	    //教学班编号
        private string _jxbmc;	    //教学班名称
        private string _jxbzrs;	    //教学班人数
        private string _bjbh;		//班级编号
        private string _bjmc;       //班级名称
        private int _bjrs;          //班级人数
        private bool _exist;		//是否存在标志

        #endregion 私有成员

        #region 属性


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
        public string Jxbzrs
        {
            set
            {
                this._jxbzrs = value;
            }
            get
            {
                return this._jxbzrs;
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
        public static DataTable LoadDataGX(string jxbbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [bj_jxb_gxb],[bjb] where jxbbh = "
                + SqlStringConstructor.GetQuotedString(jxbbh)
                + " And [bj_jxb_gxb].bjbh=[bjb].bjbh ";

            return db.GetDataTable(sql);
        }

        /// <summary>
        /// 根据参数Jxbbh，获取教学班详细信息
        /// </summary>
        /// <param name="jxbbh">教学班编号</param>
        public void LoadDataJXB(string jxbbh)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [jxbb] where jxbbh = "
                + SqlStringConstructor.GetQuotedString(jxbbh);
             

            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jxbbh = GetSafeData.ValidateDataRow_S(dr, "jxbbh");
                this._jxbmc = GetSafeData.ValidateDataRow_S(dr, "jxbmc");
                this._jxbzrs = GetSafeData.ValidateDataRow_S(dr, "jxbzrs");


                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }

        public void LoadDataJXB2(string jxbmc)
        {
            Database db = new Database();		//实例化一个Database类

            string sql = "";
            sql = "Select * from [jxbb] where jxbmc = "
                + SqlStringConstructor.GetQuotedString(jxbmc);


            DataRow dr = db.GetDataRow(sql);	//利用Database类的GetDataRow方法查询用户数据

            //根据查询得到的数据，对成员赋值
            if (dr != null)
            {
                this._jxbbh = GetSafeData.ValidateDataRow_S(dr, "jxbbh");
                this._jxbmc = GetSafeData.ValidateDataRow_S(dr, "jxbmc");
                this._jxbzrs = GetSafeData.ValidateDataRow_S(dr, "jxbzrs");


                this._exist = true;
            }
            else
            {
                this._exist = false;
            }
        }



        /// <summary>
        /// 向数据库添加一个教学班
        /// </summary>
        /// <param name="htUserInfo">教学班信息哈希表</param>
        public static void AddGXX(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[jxbb]", userInfo);	//利用Database类的Insert方法添加用户数据
        }
        public static void AddBX(Hashtable userInfo)
        {
            Database db = new Database();		//实例化一个Database类
            db.Insert("[bj_jxb_gxb]", userInfo);
        }

        /// <summary>
        /// 修改教学班数据
        /// </summary>
        /// <param name="htUserInfo">教学班信息哈希表</param>
        public static void UpdateGXX(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[jxbb]", userInfo, where);	//利用Database类的Update方法修改用户数据
        }

        public static void UpdateBX(Hashtable userInfo, string where)
        {
            Database db = new Database();		//实例化一个Database类
            db.Update("[bj_jxb_gxb]", userInfo, where);
        }


        /// <summary>
        /// 删除教学班数据
        /// </summary>
        /// <param name="jxbbh">教学班编号</param>
        public static void Delete(string jxbbh)
        {
            Database db = new Database();	//实例化一个Database类

            string sql = "Delete from [jxbb] Where [jxbbh] = "
                + SqlStringConstructor.GetQuotedString(jxbbh);
            db.ExecuteSQL(sql);

        }

        public static void DeleteBJ(string jxbbh)
        {
            Database db = new Database();	//实例化一个Database类
            string sql = "Delete from [bj_jxb_gxb] where [jxbbh] = "
                + SqlStringConstructor.GetQuotedString(jxbbh);
            db.ExecuteSQL(sql);
        }

        /// <summary>
        /// 查询教学班
        /// </summary>
        /// <param name="queryItems"></param>
        /// <returns></returns>
        public static DataTable QueryJXB(Hashtable queryItems)
        {
            string where = SqlStringConstructor.GetConditionClause(queryItems);
            string sql = "Select * From [jxbb] " + where;
            Database db = new Database();
            return db.GetDataTable(sql);
        }

        public static bool HasJXB(string jxbmc)
        {
            Database db = new Database();

            string sql = "";
            sql = "Select * from [jxbb] where [jxbmc] = "
                + SqlStringConstructor.GetQuotedString(jxbmc);

            DataRow row = db.GetDataRow(sql);
            if (row != null)
                return true;
            else
                return false;
        }


        #endregion 方法

    }

}
