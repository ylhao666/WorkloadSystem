using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration.Assemblies;

namespace Gzl.CommonComponent
{

	/// <summary>
	/// �࣬�¼���־�ࡣ
	/// </summary>
	public class MyEventsLog
	{
		/// <summary>
		/// ����������Ĭ���¼�Դ��
		/// </summary>
		protected string EVENT_LOG_SOURCE = "Gzl.Login";

		/// <summary>
		/// �������ԣ���־����
		/// </summary>
		protected EventLog eventLog = null;

		/// <summary>
		/// ���캯����
		/// </summary>
		/// <param name="Source">�¼�Դ������</param>
		public MyEventsLog(String source)
		{
			try
			{
				EVENT_LOG_SOURCE = source;
				// ȷ���¼���־Դ����
				if (!(EventLog.SourceExists(EVENT_LOG_SOURCE))) 
				{
					EventLog.CreateEventSource(EVENT_LOG_SOURCE, "Application");
				}
				//�õ���־����
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
		/// ���з��������¼���־��¼��ϵͳ��־\Ӧ�ó���
		/// </summary>
		/// <param name="Type">����
		/// {
		///		���� = EventLogEntryType.Error��
		///		��Ϣ = EventLogEntryType.Information��
		///		���� = EventLogEntryType.Warning
		///	}</param>
		/// <param name="message">��־����</param>		
		public void WriteLog(System.Diagnostics.EventLogEntryType type,string message)
		{
			// д��־
			try
			{
				eventLog.WriteEntry(message, type);
			}
			catch{}
		}

		/// <summary>
		/// ����־
		/// </summary>
		/// <returns>��DataTable����ʽ�����ص�ǰ�¼�Դ�����е���־��Ϣ</returns>
		public DataTable ReadLog()
		{
			//����DataTable���󣬰���3�У��ֱ�Ϊ�¼����͡�����ʱ�䡢��������
			DataTable dt=new DataTable();
			dt.Columns.Add(new DataColumn("EntryType",System.Type.GetType("System.String")));		//����
			dt.Columns.Add(new DataColumn("TimeGenerated",System.Type.GetType("System.DateTime")));	//����ʱ��
			dt.Columns.Add(new DataColumn("Message",System.Type.GetType("System.String")));			//����

			//��ȡ��־���������DataTable����
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