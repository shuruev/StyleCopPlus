using System;
using System.IO;
using System.Threading;

namespace StyleCopPlus.Tests
{
	public class Class1
	{
		private int m_field = 5;

		public Class1()
		{
			try
			{
lab1:			m_field = 6;
			}
			catch (Exception ex)
			{
				throw;
			}

			for (int i = 0; i < 10; i++)
			{
lab2:			m_field = 6;
			}

			foreach (string s in new[] { "1", "2" })
			{
lab3:			m_field = 6;
			}

			using (MemoryStream ms = new MemoryStream())
			{
lab4:			m_field = 6;
			}

			goto lab7;
lab5:
			m_field = 6;
lab6:		m_field = 6;
lab7:

			m_field = 6;
			lab8: m_field = 6;

			Thread thread1 = new Thread(delegate()
				{
lab9:				m_field = 6;
				});

			Thread thread2 = new Thread(() =>
				{
lab10:				m_field = 6;
				});
		}
	}
}
