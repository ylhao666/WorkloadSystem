using System;
using System.Data;
using System.Data.SqlClient;

namespace Gzl.DataAccessHelper
{
	/// <summary>
	/// 从数据库中安全获取数据，即当数据库中的数据为NULL时，保证读取不发生异常。
	/// </summary>
	public class GetSafeData
	{
		#region DataRow

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为字符串类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.String.Empty</returns>
		public static string ValidateDataRow_S(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return row[colname].ToString();
			else
				return System.String.Empty;
		}

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为整数类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
		public static int ValidateDataRow_N(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToInt32(row[colname]);
			else
				return System.Int32.MinValue;
		}

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为浮点数类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.Double.MinValue</returns>
		public static double ValidateDataRow_F(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDouble(row[colname]);
			else
				return System.Double.MinValue;	
		}

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为时间类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.DateTime.MinValue;</returns>
		public static DateTime ValidateDataRow_T(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDateTime(row[colname]);
			else 
				return System.DateTime.MinValue;	
		}

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为布尔类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Boolean.MinValue</returns>
        public static Boolean ValidateDataRow_B(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToBoolean(row[colname]);
            else
                return Convert.ToBoolean(System.Boolean.FalseString);
        }
		#endregion DataRow

		#region DataReader

		/// <summary>
		/// 从SqlDataReader中安全获取数据
		/// </summary>
		/// <param name="reader">数据读取器SqlDataReader</param>
		/// <param name="colname">列名</param>
		/// <returns>列中的字符串数据，如果为空，则返回System.String.Empty</returns>
		public static string ValidateDataReader_S(SqlDataReader reader,string colname)
		{
			if(reader.GetValue(reader.GetOrdinal(colname))!=DBNull.Value)
				return reader.GetString(reader.GetOrdinal(colname));
			else
				return System.String.Empty;
		}

		public static int ValidateDataReader_N(SqlDataReader reader,string colname)
		{
			if(reader.GetValue(reader.GetOrdinal(colname))!=DBNull.Value)
				return reader.GetInt32(reader.GetOrdinal(colname));
			else
				return System.Int32.MinValue;
		}

		public static double ValidateDataReader_F(SqlDataReader reader,string colname)
		{
			if(reader.GetValue(reader.GetOrdinal(colname))!=DBNull.Value)
				return reader.GetDouble(reader.GetOrdinal(colname));
			else
				return System.Double.MinValue;
		}

		public static DateTime ValidateDataReader_T(SqlDataReader reader,string colname)
		{
			if(reader.GetValue(reader.GetOrdinal(colname))!=DBNull.Value)
				return reader.GetDateTime(reader.GetOrdinal(colname));
			else
				return System.DateTime.MinValue;
		}

        public static string ValidateDataReader_B(SqlDataReader reader, string colname)
        {
            if (reader.GetValue(reader.GetOrdinal(colname)) != DBNull.Value)
                return Convert.ToString(reader.GetBoolean(reader.GetOrdinal(colname)));
            else
                return System.Boolean.FalseString;
        }

		#endregion DataReader
	}
}
