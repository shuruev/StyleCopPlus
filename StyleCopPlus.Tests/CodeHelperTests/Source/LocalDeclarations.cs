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
				int a1, a2 = 10, a3 = 20;
				const int b1 = 30, b2 = 40;

				m_field = 6;
			}
			catch (OutOfMemoryException ex1)
			{
				throw;
			}
			catch (Exception ex2)
			{
				throw;
			}

			for (int
				i1,
				i2 = 0,
				i3 = 1;
				i2 < 10;
				i2++)
			for (int j1, j2 = 0,
				j3 = 1;
				j2 < 10;
				j2++)
			{
				int a1, a2 = 10, a3 = 20;
				const int b1 = 30, b2 = 40;

				m_field = 6;
			}

			foreach (string s1 in new[] { "1", "2" })
			foreach (string s2 in new[] { "1", "2" })
			{
				int a1, a2 = 10, a3 = 20;
				const int b1 = 30, b2 = 40;

				m_field = 6;
			}

			using (MemoryStream ms1 = new MemoryStream(),
				ms2 = new MemoryStream(),
				ms3 = new MemoryStream())
			{
				int a1, a2 = 10, a3 = 20;
				const int b1 = 30, b2 = 40;

				m_field = 6;
			}

			int
				c1, c2 = 10,
				c3 = 20;
			const int
				d1 = 30,
				d2 = 40;

			m_field = 6;

			Thread thread1 = new Thread(delegate()
				{
					int
						a1,
						a2 = 10,
						a3 = 20;
					const int
						b1 = 30,
						b2 = 40;

					m_field = 6;
				});

			Thread thread2 = new Thread(() =>
				{
					int a1, a2 = 10,
						a3 = 20;
					const int b1 = 30,
						b2 = 40;

					m_field = 6;
				});
		}
	}
}
