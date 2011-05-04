namespace StyleCopPlus.Tests
{
	public class Class1
	{
		private int m_field = 5;

		public Class1()
		{
			int a = 10;
		}

		public Class1(
			int x,
			int y)
			: this() {
			int a = 10;
			int b = 20;
			int c = 30; }

		~Class1() { int a = 10; }

		public int Property
		{
			get { int a = 10;  return 0; }

			set
			{

				int a = 10;
				m_field = value;

			}
		}

		public int this[int x]
		{
			get {
				return 0; }

			set {
				m_field = value; }
		}

		public void Method1()
		{
			int a = 10;
		}

		public void Method2<T>(
			int x,
			int y)
			where T : struct
		{
			int a = 10;
			int b = 20;
		}

		public static bool operator +(Class1 x, Class1 y)
		{
			return false;
		}
	}
}
