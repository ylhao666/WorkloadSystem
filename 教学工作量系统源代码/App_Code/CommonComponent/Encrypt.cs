using System;
using System.Text;
using System.Security.Cryptography;

namespace Gzl.CommonComponent
{
	/// <summary>
	/// һ��ͨ�õļ��ܡ�������
	/// </summary>
	public class Encrypt
	{
		/// <summary>
		/// ����
		/// </summary>
		/// <param name="str">�����ܵ������ַ���</param>
		/// <param name="key">��Կ</param>
		/// <returns>���ܺ���ַ���</returns>
		public static string EncryptString(string str,string key)
		{
			byte[] bStr=(new UnicodeEncoding()).GetBytes(str);
			byte[] bKey=(new UnicodeEncoding()).GetBytes(key);
			for(int i=0; i<bStr.Length; i+=2) 
			{ 
				for(int j=0; j<bKey.Length; j+=2) 
				{ 
					bStr[i] = Convert.ToByte(bStr[i]^bKey[j]); 
				} 
			}

			return (new UnicodeEncoding()).GetString(bStr).TrimEnd('\0');
		}

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="str">�����ܵ������ַ���</param>
		/// <param name="key">��Կ</param>
		/// <returns>���ܺ������</returns>
		public static string DecryptString(string str,string key)
		{
			return EncryptString(str,key);
		}
	}
}
