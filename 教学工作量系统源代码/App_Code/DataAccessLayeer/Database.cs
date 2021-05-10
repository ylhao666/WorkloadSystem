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
	/// �࣬�������ݷ��ʵ��ࡣ
	/// </summary>
	public class Database : IDisposable 
	{
		/// <summary>
		/// �������������ݿ����ӡ�
		/// </summary>
		protected SqlConnection Connection;

		/// <summary>
		/// �������������ݿ����Ӵ���
		/// </summary>
		protected String ConnectionString;

		/// <summary>
		/// ϵͳ��־������־��ԴΪ��Gzl.Database��
		/// </summary>
		protected MyEventsLog log = new MyEventsLog("Gzl.Database");
		
		/// <summary>
		/// ���캯����
		/// </summary>
		/// <param name="DatabaseConnectionString">���ݿ����Ӵ�</param>
		public Database()
		{
			ConnectionString = ConfigurationManager.AppSettings["DBConnectionString"];
		}

		/// <summary>
		/// �����������ͷŷ��й���Դ
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
				log.WriteLog(EventLogEntryType.Warning,"Closeʧ�ܣ�ϵͳ�쳣��Ϣ��"+e.Message);
			}
			try
			{
				Dispose();
			}
			catch{}
		}

		/// <summary>
		/// ���������������ݿ����ӡ�
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
					log.WriteLog(EventLogEntryType.Error,"�������ݿ�����ʧ�ܣ�ϵͳ�쳣��Ϣ��"+e.Message);
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
					log.WriteLog(EventLogEntryType.Error,"�����ݿ�����ʧ�ܣ�ϵͳ�쳣��Ϣ��"+e.Message);
				}
			}
		}

		/// <summary>
		/// ���з������ر����ݿ����ӡ�
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
				log.WriteLog(EventLogEntryType.Warning,"Closeʧ�ܣ�ϵͳ�쳣��Ϣ��"+e.Message);
			}
		}

		/// <summary>
		/// ���з������ͷ���Դ��
		/// </summary>
		public void Dispose() 
		{
			// ȷ�����ӱ��ر�
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
				log.WriteLog(EventLogEntryType.Warning,"Disposeʧ�ܣ�ϵͳ�쳣��Ϣ��"+e.Message);
			}
		}

		/// <summary>
		/// ���з�������ȡ���ݣ�����һ��SqlDataReader �����ú��������SqlDataReader.Close()����
		/// </summary>
		/// <param name="SqlString">Sql���</param>
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
				log.WriteLog(EventLogEntryType.Error,"GetDataReaderʧ�ܣ�SqlString="+SqlString+",ϵͳ�쳣��Ϣ��"+e.Message);
				return null;
			}
		}

		/// <summary>
		/// ���з�������ȡ���ݣ�����һ��DataSet��
		/// </summary>
		/// <param name="SqlString">Sql���</param>
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
				log.WriteLog(EventLogEntryType.Warning,"GetDataSetʧ�ܣ�SqlString="+SqlString+",ϵͳ�쳣��Ϣ��"+e.Message);
			}
			finally
			{
				Close();
			}
			return dataset;
		}

		/// <summary>
		/// ���з�������ȡ���ݣ�����һ��DataTable��
		/// </summary>
		/// <param name="SqlString">Sql���</param>
		/// <returns>DataTable</returns>
		public DataTable GetDataTable(String SqlString)
		{
			DataSet dataset = GetDataSet(SqlString);
			dataset.CaseSensitive = false;
			return dataset.Tables[0];
		}

		/// <summary>
		/// ���з�������ȡ���ݣ�����һ��DataRow��
		/// </summary>
		/// <param name="SqlString">Sql���</param>
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
		/// ���з�����ִ��Sql��䡣
		/// </summary>
		/// <param name="SqlString">Sql���</param>
		/// <returns>��Update��Insert��DeleteΪӰ�쵽���������������Ϊ-1</returns>
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
				log.WriteLog(EventLogEntryType.Error,"ExecuteSQLʧ�ܣ�SqlString="+SqlString+",ϵͳ�쳣��Ϣ��"+e.Message);
                count = -1;
			}
			finally
			{
				Close();
			}
			return count;
		}

		/// <summary>
		/// ���з�����ִ��һ��Sql��䡣
		/// </summary>
		/// <param name="SqlStrings">Sql�����</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
				log.WriteLog(EventLogEntryType.Error,"ExecuteSQLʧ�ܣ�SqlString="+SqlStrings[i]+",ϵͳ�쳣��Ϣ��"+e.Message);
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
		/// ���з�������һ�����ݱ��в���һ����¼��
		/// </summary>
		/// <param name="TableName">����</param>
		/// <param name="Cols">��������ֵΪ�ֶ�����ֵΪ�ֶ�ֵ</param>
		/// <returns>�Ƿ�ɹ�</returns>
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
		/// ���з���������һ�����ݱ�
		/// </summary>
		/// <param name="TableName">����</param>
		/// <param name="Cols">��������ֵΪ�ֶ�����ֵΪ�ֶ�ֵ</param>
		/// <param name="Where">Where�Ӿ�</param>
		/// <returns>�Ƿ�ɹ�</returns>
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