using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopPlus.Tests.ComplexTests
{
	/// <summary>
	/// Running complex batch tests for StyleCop+ plug-in.
	/// </summary>
	[TestClass]
	public class ComplexTest
	{
		private readonly string m_tempFileName;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ComplexTest()
		{
			m_tempFileName = Path.Combine(
				AppDomain.CurrentDomain.BaseDirectory,
				"Test.cs");
		}

		[TestMethod]
		public void One_Run_Complex_Tests()
		{
			RunTests(Source.OneRun);
		}

		[TestMethod]
		public void Environmental_Complex_Tests()
		{
			RunTests(Source.Environmental);
		}

		[TestMethod]
		public void Advanced_Naming_Rules_Complex_Tests()
		{
			RunTests(Source.AdvancedNamingRules);
		}

		[TestMethod]
		public void Extended_Original_Rules_Complex_Tests()
		{
			RunTests(Source.ExtendedOriginalRules);
		}

		[TestMethod]
		public void More_Custom_Rules_Complex_Tests()
		{
			RunTests(Source.MoreCustomRules);
		}

		#region Reading test definition file

		/// <summary>
		/// Reads a list of blocks.
		/// </summary>
		private static List<BlockItem> ParseBlocks(string allText)
		{
			List<BlockItem> blocks = new List<BlockItem>();

			StringBuilder sb = new StringBuilder();
			BlockItem block = new BlockItem();

			string[] lines = allText.Split(
				new[] { "\r\n", "\r", "\n" },
				StringSplitOptions.None);

			foreach (string line in lines)
			{
				if (line.StartsWith("#region "))
				{
					string[] parts = line.Substring(8).Split(new[] { " // " }, StringSplitOptions.None);
					if (parts.Length == 0 || String.IsNullOrEmpty(parts[0]))
						ThrowWrongTestFile();

					block.Rule = parts[0];
					if (parts.Length > 1)
						block.Comment = parts[1];

					continue;
				}

				if (line.StartsWith("#endregion"))
				{
					block.Content = sb.ToString();
					blocks.Add(block);

					sb.Length = 0;
					block = new BlockItem();
					continue;
				}

				if (line.StartsWith("//# ("))
				{
					string setting = line.Substring(5, line.Length - 6);
					string[] parts = setting.Split(new[] { " = " }, 2, StringSplitOptions.None);
					if (parts.Length != 2)
						ThrowWrongTestFile();

					string settingName = parts[0];
					object settingValue = parts[1];

					bool booleanValue;
					if (Boolean.TryParse(parts[1], out booleanValue))
						settingValue = booleanValue;

					block.CustomSettings.Add(settingName, settingValue);

					continue;
				}

				sb.AppendLine(line);
			}

			return blocks;
		}

		/// <summary>
		/// Reads a list of tests.
		/// </summary>
		private static List<TestItem> ParseTests(string blockText)
		{
			List<TestItem> tests = new List<TestItem>();

			int index = 0;
			while (index < blockText.Length)
			{
				int start = blockText.IndexOf("//# [", index);
				if (start < 0)
					break;

				int end = blockText.IndexOf("//# [END]", start);
				if (end < 0)
					break;

				string testText = blockText.Substring(start, end - start);
				TestItem test = ParseTest(testText);
				tests.Add(test);

				index = end + 1;
			}

			return tests;
		}

		/// <summary>
		/// Reads a test.
		/// </summary>
		private static TestItem ParseTest(string testText)
		{
			TestItem test = new TestItem();

			List<string> lines = new List<string>(
				testText.Split(
					new[] { "\r\n", "\r", "\n" },
					StringSplitOptions.None));

			if (lines.Count < 3)
				ThrowWrongTestFile();

			string headerLine = lines[0];
			if (!headerLine.StartsWith("//# ["))
				ThrowWrongTestFile();

			if (headerLine.Contains("-- SKIP"))
			{
				test.Skip = true;
			}
			else if (headerLine == "//# [OK]")
			{
				test.ErrorCount = 0;
			}
			else if (headerLine == "//# [ERROR]")
			{
				test.ErrorCount = 1;
			}
			else
			{
				if (!headerLine.StartsWith("//# [ERROR:"))
					ThrowWrongTestFile();

				string[] parts = headerLine.Split(
					new[] { "//# [ERROR:", "]" },
					StringSplitOptions.RemoveEmptyEntries);

				if (parts.Length != 1)
					ThrowWrongTestFile();

				if (!Int32.TryParse(parts[0], out test.ErrorCount))
					ThrowWrongTestFile();
			}

			string descriptionLine = lines[1];
			if (!descriptionLine.StartsWith("//# "))
				ThrowWrongTestFile();

			test.Description = descriptionLine.Substring(4);
			if (String.IsNullOrEmpty(test.Description))
				ThrowWrongTestFile();

			lines.RemoveAt(0);
			lines.RemoveAt(0);
			test.SourceCode = String.Join(Environment.NewLine, lines.ToArray());

			return test;
		}

		/// <summary>
		/// Throws exception about wrong test definition file.
		/// </summary>
		private static void ThrowWrongTestFile()
		{
			throw new InvalidDataException("Test definition file appears to have wrong format.");
		}

		#endregion

		#region Running tests

		/// <summary>
		/// Runs all test from definition file.
		/// </summary>
		private void RunTests(string definitionFile)
		{
			List<BlockItem> blocks = ParseBlocks(definitionFile);
			foreach (BlockItem block in blocks)
			{
				List<TestItem> tests = ParseTests(block.Content);
				foreach (TestItem test in tests)
				{
					if (test.Skip)
						continue;

					RunTest(
						block.Rule,
						block.Comment,
						block.CustomSettings,
						test.ErrorCount,
						test.Description,
						test.SourceCode);
				}
			}
		}

		/// <summary>
		/// Runs specified test.
		/// </summary>
		private void RunTest(
			string targetRule,
			string comment,
			Dictionary<string, object> customSettings,
			int errorCount,
			string description,
			string sourceCode)
		{
			if (File.Exists(m_tempFileName))
			{
				File.Delete(m_tempFileName);
			}

			File.WriteAllText(m_tempFileName, sourceCode);

			StyleCopPlusRunner runner = new StyleCopPlusRunner();
			runner.Run(
				m_tempFileName,
				new SpecialRunningParameters
				{
					OnlyEnabledRule = targetRule,
					CustomSettings = customSettings
				});

			string message;
			if (String.IsNullOrEmpty(comment))
			{
				message = String.Format(
					"{0}: {1}",
					targetRule,
					description);
			}
			else
			{
				message = String.Format(
					"{0} ({1}): {2}",
					targetRule,
					comment,
					description);
			}

			Assert.AreEqual(
				errorCount,
				runner.Violations.Count,
				message);

			for (int i = 0; i < errorCount; i++)
			{
				runner.Violations.Remove(targetRule);
			}

			Assert.AreEqual(
				0,
				runner.Violations.Count,
				message);
		}

		#endregion
	}
}
