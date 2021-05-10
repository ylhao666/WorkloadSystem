using System;
using System.Data;
using System.Data.SqlClient;

namespace Gzl.DataAccessHelper
{
	/// <summary>
	/// �����ݿ��а�ȫ��ȡ���ݣ��������ݿ��е�����ΪNULLʱ����֤��ȡ�������쳣��
	/// </summary>
	public class GetSafeData
	{
		#region DataRow

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ�ַ�������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.String.Empty</returns>
		public static string ValidateDataRow_S(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return row[colname].ToString();
			else
				return System.String.Empty;
		}

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ��������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.Int32.MinValue</returns>
		public static int ValidateDataRow_N(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToInt32(row[colname]);
			else
				return System.Int32.MinValue;
		}

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ����������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.Double.MinValue</returns>
		public static double ValidateDataRow_F(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDouble(row[colname]);
			else
				return System.Double.MinValue;	
		}

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪʱ������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.DateTime.MinValue;</returns>
		public static DateTime ValidateDataRow_T(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDateTime(row[colname]);
			else 
				return System.DateTime.MinValue;	
		}

        /// <summary>
        /// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ��������
        /// </summary>
        /// <param name="row">�����ж���</param>
        /// <param name="colname">����</param>
        /// <returns>���ֵ���ڣ����أ����򣬷���System.Boolean.MinValue</returns>
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
		/// ��SqlDataReader�а�ȫ��ȡ����
		/// </summary>
		/// <param name="reader">���ݶ�ȡ��SqlDataReader</param>
		/// <param name="colname">����</param>
		/// <returns>���е��ַ������ݣ����Ϊ�գ��򷵻�System.String.Empty</returns>
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
