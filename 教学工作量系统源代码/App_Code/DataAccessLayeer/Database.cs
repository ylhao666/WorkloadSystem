using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Gzl.DataAccessHelper;
using Gzl.CommonComponent;

namespace Gzl.DataAccessLayer
{
	/// <summary>
	/// 类，用于数据访问的类。
	/// </summary>
	public class Database : IDisposable 
	{
		/// <summary>
		/// 保护变量，数据库连接。
		/// </summary>
		protected SqlConnection Connection;

		/// <summary>
		/// 保护变量，数据库连接串。
		/// </summary>
		protected String ConnectionString;

		/// <summary>
		/// 系统日志对象，日志来源为“Gzl.Database”
		/// </summary>
		protected MyEventsLog log = new MyEventsLog("Gzl.Database");
		
		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="DatabaseConnectionString">数据库连接串</param>
		public Database()
		{
			ConnectionString = ConfigurationManager.AppSettings["DBConnectionString"];
		}

		/// <summary>
		/// 析构函数，释放非托管资源
		/// </summary>
		~Database()
		{
			try
			{
				if (Connection != null)
					Connection.Close();
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Warning,"Close失败，系统异常信息："+e.Message);
			}
			try
			{
				Dispose();
			}
			catch{}
		}

		/// <summary>
		/// 保护方法，打开数据库连接。
		/// </summary>
		protected void Open() 
		{
			if (Connection == null)
			{
				try
				{
					Connection = new SqlConnection(ConnectionString);
				}
				catch(Exception e)
				{
					log.WriteLog(EventLogEntryType.Error,"创建数据库连接失败，系统异常信息："+e.Message);
				}
			}
			if (Connection.State.Equals(ConnectionState.Closed))
			{
				try
				{
					Connection.Open();
				}
				catch(Exception e)
				{
					log.WriteLog(EventLogEntryType.Error,"打开数据库连接失败，系统异常信息："+e.Message);
				}
			}
		}

		/// <summary>
		/// 公有方法，关闭数据库连接。
		/// </summary>
		public void Close() 
		{
			try
			{
				if (Connection != null)
					Connection.Close();
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Warning,"Close失败，系统异常信息："+e.Message);
			}
		}

		/// <summary>
		/// 公有方法，释放资源。
		/// </summary>
		public void Dispose() 
		{
			// 确保连接被关闭
			try
			{
			if (Connection != null) 
			{
				Connection.Dispose();
				Connection = null;
			}	
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Warning,"Dispose失败，系统异常信息："+e.Message);
			}
		}

		/// <summary>
		/// 公有方法，获取数据，返回一个SqlDataReader （调用后主意调用SqlDataReader.Close()）。
		/// </summary>
		/// <param name="SqlString">Sql语句</param>
		/// <returns>SqlDataReader</returns>
		public SqlDataReader GetDataReader(String SqlString)
		{
			Open();
			try
			{
				SqlCommand cmd = new SqlCommand(SqlString,Connection);
				return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Error,"GetDataReader失败，SqlString="+SqlString+",系统异常信息："+e.Message);
				return null;
			}
		}

		/// <summary>
		/// 公有方法，获取数据，返回一个DataSet。
		/// </summary>
		/// <param name="SqlString">Sql语句</param>
		/// <returns>DataSet</returns>
		public DataSet GetDataSet(String SqlString)
		{
			DataSet dataset = new DataSet();
			Open();
			try
			{
				SqlDataAdapter adapter = new SqlDataAdapter(SqlString,Connection);
				adapter.Fill(dataset);
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Warning,"GetDataSet失败，SqlString="+SqlString+",系统异常信息："+e.Message);
			}
			finally
			{
				Close();
			}
			return dataset;
		}

		/// <summary>
		/// 公有方法，获取数据，返回一个DataTable。
		/// </summary>
		/// <param name="SqlString">Sql语句</param>
		/// <returns>DataTable</returns>
		public DataTable GetDataTable(String SqlString)
		{
			DataSet dataset = GetDataSet(SqlString);
			dataset.CaseSensitive = false;
			return dataset.Tables[0];
		}

		/// <summary>
		/// 公有方法，获取数据，返回一个DataRow。
		/// </summary>
		/// <param name="SqlString">Sql语句</param>
		/// <returns>DataRow</returns>
		public DataRow GetDataRow(String SqlString)
		{
			DataSet dataset = GetDataSet(SqlString);
			dataset.CaseSensitive = false;
			if (dataset.Tables[0].Rows.Count>0)
			{
				return dataset.Tables[0].Rows[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 公有方法，执行Sql语句。
		/// </summary>
		/// <param name="SqlString">Sql语句</param>
		/// <returns>对Update、Insert、Delete为影响到的行数，其他情况为-1</returns>
		public int ExecuteSQL(String SqlString)
		{
			int count = -1;
			Open();
			try
			{
				SqlCommand cmd = new SqlCommand(SqlString,Connection);
				count = cmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Error,"ExecuteSQL失败，SqlString="+SqlString+",系统异常信息："+e.Message);
                count = -1;
			}
			finally
			{
				Close();
			}
			return count;
		}

		/// <summary>
		/// 公有方法，执行一组Sql语句。
		/// </summary>
		/// <param name="SqlStrings">Sql语句组</param>
		/// <returns>是否成功</returns>
		public bool ExecuteSQL(String[] SqlStrings)
		{
			bool success = true;
			Open();
			SqlCommand cmd = new SqlCommand();
			SqlTransaction trans = Connection.BeginTransaction();
			cmd.Connection = Connection;
			cmd.Transaction = trans;

			int i=0;
			try
			{
				foreach (String str in SqlStrings)
				{
					cmd.CommandText = str;
					cmd.ExecuteNonQuery();
					i++;
				}
				trans.Commit();
			}
			catch(Exception e)
			{
				log.WriteLog(EventLogEntryType.Error,"ExecuteSQL失败，SqlString="+SqlStrings[i]+",系统异常信息："+e.Message);
				success = false;
				trans.Rollback();
			}
			finally
			{
				Close();
			}
			return success;
		}

		/// <summary>
		/// 公有方法，在一个数据表中插入一条记录。
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="Cols">哈西表，键值为字段名，值为字段值</param>
		/// <returns>是否成功</returns>
		public bool Insert(String TableName,Hashtable Cols)
		{
			int Count = 0;

			if (Cols.Count<=0)			
			{
				return true;
			}

			String Fields = " (";
			String Values = " Values(";			
			foreach(DictionaryEntry item in Cols)
			{
				if (Count!=0)
				{
					Fields += ",";
					Values += ",";
				}
				Fields += "["+item.Key.ToString()+"]";
				Values += item.Value.ToString();
				Count ++;
			}
			Fields += ")";
			Values += ")";

			String SqlString = "Insert into "+TableName+Fields+Values;

			String[] Sqls = {SqlString};
			return ExecuteSQL(Sqls);
		}

	
		/// <summary>
		/// 公有方法，更新一个数据表。
		/// </summary>
		/// <param name="TableName">表名</param>
		/// <param name="Cols">哈西表，键值为字段名，值为字段值</param>
		/// <param name="Where">Where子句</param>
		/// <returns>是否成功</returns>
		public bool Update(String TableName,Hashtable Cols,String Where)
		{
			int Count = 0;
			if (Cols.Count<=0)			
			{
				return true;
			}
			String Fields = " ";
			foreach(DictionaryEntry item in Cols)
			{
				if (Count!=0)
				{
					Fields += ",";
				}
				Fields += "["+item.Key.ToString()+"]";
				Fields += "=";
				Fields += item.Value.ToString();
				Count ++;
			}
			Fields += " ";

			String SqlString = "Update "+TableName+" Set "+Fields+Where;

			String[] Sqls = {SqlString};
			return ExecuteSQL(Sqls);
		}		
	}
}