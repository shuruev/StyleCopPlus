using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopPlus
{
	/// <summary>
	/// More custom rules represented by StyleCop+ plug-in.
	/// </summary>
	public class MoreCustomRules
	{
		private readonly StyleCopPlusRules m_parent;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public MoreCustomRules(StyleCopPlusRules parent)
		{
			if (parent == null)
				throw new ArgumentNullException("parent");

			m_parent = parent;
		}

		/// <summary>
		/// Analyzes source document.
		/// </summary>
		public void AnalyzeDocument(CodeDocument document)
		{
			CustomRulesSettings settings = new CustomRulesSettings();
			settings.Initialize(m_parent, document);

			CsDocument doc = (CsDocument)document;
			AnalyzePlainText(doc, settings);
			AnalyzeElements(doc.RootElement.ChildElements, settings);
		}

		#region Plain text analysis

		/// <summary>
		/// Analyzes source code as plain text.
		/// </summary>
		private void AnalyzePlainText(CsDocument document, CustomRulesSettings settings)
		{
			string source;
			using (TextReader reader = document.SourceCode.Read())
			{
				source = reader.ReadToEnd();
			}

			List<string> lines = new List<string>(
				source.Split(
					new[] { "\r\n", "\r", "\n" },
					StringSplitOptions.None));

			for (int i = 0; i < lines.Count; i++)
			{
				int currentLineNumber = i + 1;
				string currentLine = lines[i];
				string previousLine = i > 0 ? lines[i - 1] : null;

				CheckLineEnding(document, currentLine, currentLineNumber);
				CheckIndentation(document, currentLine, previousLine, currentLineNumber, settings);
				CheckLineLength(document, currentLine, currentLineNumber, settings);
			}

			CheckLastLine(document, source, lines.Count, settings);
		}

		/// <summary>
		/// Checks the ending of specified code line.
		/// </summary>
		private void CheckLineEnding(
			CsDocument document,
			string currentLine,
			int currentLineNumber)
		{
			if (currentLine.Length == 0)
				return;

			char lastChar = currentLine[currentLine.Length - 1];
			if (Char.IsWhiteSpace(lastChar))
			{
				AddViolation(
					document,
					currentLineNumber,
					Rules.CodeLineMustNotEndWithWhitespace);
			}
		}

		/// <summary>
		/// Checks indentation in specified code line.
		/// </summary>
		private void CheckIndentation(
			CsDocument document,
			string currentLine,
			string previousLine,
			int currentLineNumber,
			CustomRulesSettings settings)
		{
			if (currentLine.Trim().Length == 0)
				return;

			string currentIndent = ExtractIndentation(currentLine);

			bool failed = true;
			switch (settings.IndentOptions.Mode)
			{
				case IndentMode.Tabs:
					failed = currentIndent.Contains(" ");
					break;

				case IndentMode.Spaces:
					failed = currentIndent.Contains("\t");
					break;

				case IndentMode.Both:
					failed = currentIndent.Contains(" ") && currentIndent.Contains("\t");
					break;
			}

			if (!failed)
				return;

			if (settings.IndentOptions.AllowPadding)
			{
				if (previousLine != null)
				{
					string previousIndent = ExtractIndentation(previousLine);
					if (IsPaddingAllowed(document, currentIndent, previousIndent, currentLineNumber))
						return;
				}
			}

			AddViolation(
				document,
				currentLineNumber,
				Rules.CheckAllowedIndentationCharacters,
				settings.IndentOptions.GetContextValues());
		}

		/// <summary>
		/// Extracts indentation part from specified string.
		/// </summary>
		private static string ExtractIndentation(string text)
		{
			StringBuilder sb = new StringBuilder();
			foreach (char c in text)
			{
				if (!Char.IsWhiteSpace(c))
					break;

				sb.Append(c);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Checks whether padding is allowed in specified situation.
		/// </summary>
		private static bool IsPaddingAllowed(
			CsDocument document,
			string currentIndent,
			string previousIndent,
			int currentLineNumber)
		{
			if (currentIndent.TrimStart('\t').TrimEnd(' ').Length > 0)
				return false;

			if (currentIndent.TrimEnd(' ').Length != previousIndent.TrimEnd(' ').Length)
				return false;

			return IsSuitableForPadding(document, currentLineNumber);
		}

		/// <summary>
		/// Checks whether specified line is suitable for padding.
		/// </summary>
		private static bool IsSuitableForPadding(CsDocument document, int lineNumber)
		{
			Expression expr = CodeHelper.GetExpressionByLine(document, lineNumber);
			if (expr != null)
			{
				Expression root = CodeHelper.GetRootExpression(expr);
				if (root.Location.LineSpan > 1)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Checks length of specified code line.
		/// </summary>
		private void CheckLineLength(
			CsDocument document,
			string currentLine,
			int currentLineNumber,
			CustomRulesSettings settings)
		{
			int length = 0;
			foreach (char c in currentLine)
			{
				if (c == '\t')
				{
					length += settings.CharLimitOptions.TabSize.Value;
				}
				else
				{
					length += 1;
				}
			}

			if (length > settings.CharLimitOptions.Limit.Value)
			{
				AddViolation(
					document,
					currentLineNumber,
					Rules.CodeLineMustNotBeLongerThan,
					settings.CharLimitOptions.Limit.Value,
					length);
			}
		}

		/// <summary>
		/// Checks the last code line.
		/// </summary>
		private void CheckLastLine(
			CsDocument document,
			string sourceText,
			int lastLineNumber,
			CustomRulesSettings settings)
		{
			if (sourceText.Length == 0)
				return;

			char lastChar = sourceText[sourceText.Length - 1];
			bool endsWithLineBreak =
				lastChar == '\r'
				|| lastChar == '\n';

			bool passed = false;
			switch (settings.LastLineOptions.Mode)
			{
				case LastLineMode.Empty:
					passed = endsWithLineBreak;
					break;

				case LastLineMode.NotEmpty:
					passed = !endsWithLineBreak;
					break;
			}

			if (!passed)
			{
				AddViolation(
					document,
					lastLineNumber,
					Rules.CheckWhetherLastCodeLineIsEmpty,
					settings.LastLineOptions.GetContextValues());
			}
		}

		#endregion

		#region Analysis by elements

		/// <summary>
		/// Analyzes a collection of elements.
		/// </summary>
		private void AnalyzeElements(IEnumerable<CsElement> elements, CustomRulesSettings settings)
		{
			foreach (CsElement element in elements)
			{
				AnalyzeElement(element, settings);
				AnalyzeElements(element.ChildElements, settings);
			}
		}

		/// <summary>
		/// Analyzes specified element.
		/// </summary>
		private void AnalyzeElement(CsElement element, CustomRulesSettings settings)
		{
			switch (element.ElementType)
			{
				case ElementType.Constructor:
					AnalyzeConstructor(element, settings);
					break;
				case ElementType.Destructor:
					AnalyzeDestructor(element, settings);
					break;
				case ElementType.Indexer:
					AnalyzeIndexer(element, settings);
					break;
				case ElementType.Method:
					AnalyzeMethod(element, settings);
					break;
				case ElementType.Property:
					AnalyzeProperty(element, settings);
					break;
			}
		}

		/// <summary>
		/// Analyzes constructor element.
		/// </summary>
		private void AnalyzeConstructor(CsElement element, CustomRulesSettings settings)
		{
			CheckSizeLimit(
				element,
				Rules.MethodMustNotContainMoreLinesThan,
				settings.MethodSizeOptions.Limit);
		}

		/// <summary>
		/// Analyzes destructor element.
		/// </summary>
		private void AnalyzeDestructor(CsElement element, CustomRulesSettings settings)
		{
			CheckSizeLimit(
				element,
				Rules.MethodMustNotContainMoreLinesThan,
				settings.MethodSizeOptions.Limit);
		}

		/// <summary>
		/// Analyzes indexer element.
		/// </summary>
		private void AnalyzeIndexer(CsElement element, CustomRulesSettings settings)
		{
			Indexer indexer = (Indexer)element;

			if (indexer.GetAccessor != null)
			{
				CheckSizeLimit(
					indexer.GetAccessor,
					Rules.PropertyMustNotContainMoreLinesThan,
					settings.PropertySizeOptions.Limit);
			}

			if (indexer.SetAccessor != null)
			{
				CheckSizeLimit(
					indexer.SetAccessor,
					Rules.PropertyMustNotContainMoreLinesThan,
					settings.PropertySizeOptions.Limit);
			}
		}

		/// <summary>
		/// Analyzes method element.
		/// </summary>
		private void AnalyzeMethod(CsElement element, CustomRulesSettings settings)
		{
			CheckSizeLimit(
				element,
				Rules.MethodMustNotContainMoreLinesThan,
				settings.MethodSizeOptions.Limit);
		}

		/// <summary>
		/// Analyzes property element.
		/// </summary>
		private void AnalyzeProperty(CsElement element, CustomRulesSettings settings)
		{
			Property property = (Property)element;

			if (property.GetAccessor != null)
			{
				CheckSizeLimit(
					property.GetAccessor,
					Rules.PropertyMustNotContainMoreLinesThan,
					settings.PropertySizeOptions.Limit);
			}

			if (property.SetAccessor != null)
			{
				CheckSizeLimit(
					property.SetAccessor,
					Rules.PropertyMustNotContainMoreLinesThan,
					settings.PropertySizeOptions.Limit);
			}
		}

		/// <summary>
		/// Checks if specified element violates size limit.
		/// </summary>
		private void CheckSizeLimit(CsElement element, Rules rule, NumericValue limit)
		{
			int size = CodeHelper.GetElementSizeByDeclaration(element);

			if (size > limit.Value)
			{
				m_parent.AddViolation(
					element,
					rule,
					limit.Value,
					size);
			}
		}

		#endregion

		#region Firing violations

		/// <summary>
		/// Fires violation.
		/// </summary>
		private void AddViolation(
			CsDocument document,
			int lineNumber,
			Rules rule,
			params object[] values)
		{
			m_parent.AddViolation(
				StyleCop43Compatibility.GetElementByLine(document, lineNumber) ?? document.RootElement,
				lineNumber,
				rule,
				values);
		}

		#endregion
	}
}
