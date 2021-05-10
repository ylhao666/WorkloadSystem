using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration.Assemblies;

namespace Gzl.CommonComponent
{

	/// <summary>
	/// 类，事件日志类。
	/// </summary>
	public class MyEventsLog
	{
		/// <summary>
		/// 保护变量，默认事件源。
		/// </summary>
		protected string EVENT_LOG_SOURCE = "Gzl.Login";

		/// <summary>
		/// 保护属性，日志对象
		/// </summary>
		protected EventLog eventLog = null;

		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="Source">事件源的名称</param>
		public MyEventsLog(String source)
		{
			try
			{
				EVENT_LOG_SOURCE = source;
				// 确认事件日志源存在
				if (!(EventLog.SourceExists(EVENT_LOG_SOURCE))) 
				{
					EventLog.CreateEventSource(EVENT_LOG_SOURCE, "Application");
				}
				//得到日志对象
				if (eventLog == null)
				{
					eventLog = new EventLog("Application");
					eventLog.Source = EVENT_LOG_SOURCE;
				}
			}
			catch(Exception e)
			{
				string str=e.Message;
			}
		}
		/// <summary>
		/// 公有方法，将事件日志记录到系统日志\应用程序。
		/// </summary>
		/// <param name="Type">类型
		/// {
		///		错误 = EventLogEntryType.Error，
		///		信息 = EventLogEntryType.Information，
		///		警告 = EventLogEntryType.Warning
		///	}</param>
		/// <param name="message">日志内容</param>		
		public void WriteLog(System.Diagnostics.EventLogEntryType type,string message)
		{
			// 写日志
			try
			{
				eventLog.WriteEntry(message, type);
			}
			catch{}
		}

		/// <summary>
		/// 读日志
		/// </summary>
		/// <returns>以DataTable的形式，返回当前事件源中所有的日志信息</returns>
		public DataTable ReadLog()
		{
			//构造DataTable对象，包含3列，分别为事件类型、发生时间、内容属性
			DataTable dt=new DataTable();
			dt.Columns.Add(new DataColumn("EntryType",System.Type.GetType("System.String")));		//类型
			dt.Columns.Add(new DataColumn("TimeGenerated",System.Type.GetType("System.DateTime")));	//发生时间
			dt.Columns.Add(new DataColumn("Message",System.Type.GetType("System.String")));			//内容

			//读取日志，把项加入DataTable对象
			try
			{
				foreach(EventLogEntry entry in eventLog.Entries)
				{
					if(entry.Source==this.EVENT_LOG_SOURCE)
						dt.Rows.Add(new object[]{entry.EntryType,entry.TimeGenerated,entry.Message});
				}
			}
			catch{}
			return dt;
		}
	}
}