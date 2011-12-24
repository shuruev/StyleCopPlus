using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests
{
	/// <summary>
	/// Some additional assertion methods.
	/// </summary>
	public static class Ensure
	{
		/// <summary>
		/// Ensures that specified code throws exception.
		/// </summary>
		private static void EnsureThrow(Action action, bool shouldThrow)
		{
			bool throwed = false;

			try
			{
				action();
			}
			catch
			{
				throwed = true;
			}

			if (shouldThrow)
			{
				if (!throwed)
					throw new AssertFailedException("Expected exception was not thrown.");
			}
			else
			{
				if (throwed)
					throw new AssertFailedException("Unexpected exception was thrown.");
			}
		}

		/// <summary>
		/// Ensures that specified code throws exception.
		/// </summary>
		public static void Throws(Action action)
		{
			EnsureThrow(action, true);
		}

		/// <summary>
		/// Ensures that specified code does not throw exception.
		/// </summary>
		public static void NotThrows(Action action)
		{
			EnsureThrow(action, false);
		}
	}
}
