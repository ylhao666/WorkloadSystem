using System;
using System.Collections;

namespace Gzl.DataAccessHelper
{
	/// <summary>
	/// SQLString 的摘要说明。
	/// </summary>
	public class SqlStringConstructor
	{
		/// <summary>
		/// 公有静态方法，将文本转换成适合在Sql语句里使用的字符串。
		/// </summary>
		/// <returns>转换后文本</returns>	
		public static String GetQuotedString(String pStr)
		{
			return ("'" + pStr.Replace("'","''") + "'");
		}

		/// <summary>
		/// 根据条件哈希表,构造SQL语句中的AND条件子句
		/// </summary>
		/// <param name="conditionHash">条件哈希表</param>
		/// <returns>AND关系条件子句</returns>
		public static String GetConditionClause(Hashtable queryItems)
		{

			int Count = 0;
			String Where = "";

			//根据哈希表，循环生成条件子句
			foreach(DictionaryEntry item in queryItems)
			{
				if (Count == 0)
					Where = " Where ";
				else
					Where += " And ";

				//根据查询列的数据类型，决定是否加单引号
				if(item.Value.GetType().ToString()=="System.String" || item.Value.GetType().ToString()=="System.DateTime")
				{
					Where +=  item.Key.ToString()  
						+ " Like " 
						+ SqlStringConstructor.GetQuotedString("%"
						+ item.Value.ToString()
						+ "%");
				}
				else
				{
					Where +=  item.Key.ToString() + "= " + item.Value.ToString();
				}
				Count ++;
			}
			return Where;
		}

		/// <summary>
		/// 根据条件哈希表,构造SQL语句中的条件子句
		/// </summary>
		/// <param name="conditionHash">条件哈希表</param>
		/// <param name="type">与还是或查询，取值={"AND","OR"}</param>
		/// <returns>AND关系条件子句</returns>
		public static String GetConditionClause(Hashtable queryItems,string type)
		{

			int Count = 0;
			String Where = "";

			//根据哈希表，循环生成条件子句
			foreach(DictionaryEntry item in queryItems)
			{
				if (Count == 0)
					Where = " Where ";
				else
					Where += " "+type+" ";

				//根据查询列的数据类型，决定是否加单引号
				if(item.Value.GetType().ToString()=="System.String" || item.Value.GetType().ToString()=="System.DateTime")
				{
					Where +=  item.Key.ToString()  
						+ " Like " 
						+ SqlStringConstructor.GetQuotedString("%"
						+ item.Value.ToString()
						+ "%");
				}
				else
				{
					Where +=  item.Key.ToString() + "= " + item.Value.ToString();
				}
				Count ++;
			}
			return Where;
		}
	}
}
