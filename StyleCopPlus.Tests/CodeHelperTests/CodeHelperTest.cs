using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StyleCop;
using StyleCop.CSharp;

namespace StyleCopPlus.Tests.CodeHelperTests
{
	/// <summary>
	/// Testing code helper work.
	/// </summary>
	[TestClass]
	public class CodeHelperTest
	{
		#region Service methods

		/// <summary>
		/// Builds code document from specified source code.
		/// </summary>
		private static CsDocument BuildCodeDocument(string sourceCode)
		{
			string tempFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeHelperTest.cs");
			File.WriteAllText(tempFile, sourceCode);

			CodeProject project = new CodeProject(0, string.Empty, new Configuration(null));
			CsParser parser = new CsParser();
			CodeFile file = new CodeFile(tempFile, project, parser);

			CodeDocument doc = null;
			parser.ParseFile(file, 0, ref doc);

			File.Delete(tempFile);

			return (CsDocument)doc;
		}

		/// <summary>
		/// Gets element by name.
		/// </summary>
		private static CsElement GetElementByName(CsDocument document, string name)
		{
			return GetElementByName(
				document.RootElement.ChildElements,
				name,
				false);
		}

		/// <summary>
		/// Gets element by name.
		/// </summary>
		private static CsElement GetElementByQualifiedName(CsDocument document, string qualifiedName)
		{
			return GetElementByName(
				document.RootElement.ChildElements,
				qualifiedName,
				true);
		}

		/// <summary>
		/// Gets element by name.
		/// </summary>
		private static CsElement GetElementByName(IEnumerable<CsElement> elements, string name, bool fullyQualified)
		{
			foreach (CsElement element in elements)
			{
				if (fullyQualified)
				{
					if (element.FullyQualifiedName == name)
						return element;
				}
				else
				{
					if (element.Name == name)
						return element;
				}

				CsElement result = GetElementByName(element.ChildElements, name, fullyQualified);
				if (result != null)
					return result;
			}

			return null;
		}

		#endregion

		#region Special assert methods

		/// <summary>
		/// Checks specified parameter.
		/// </summary>
		private static void AssertParameter(
			string expectedName,
			int expectedLineNumber,
			ParameterItem parameter)
		{
			Assert.AreEqual(expectedName, parameter.Name);
			Assert.IsTrue(parameter.LineNumber.HasValue);
			Assert.AreEqual(expectedLineNumber, parameter.LineNumber);
		}

		/// <summary>
		/// Checks specified type parameter.
		/// </summary>
		private static void AssertTypeParameter(
			string expectedName,
			int expectedLineNumber,
			TypeParameterItem parameter)
		{
			Assert.AreEqual(expectedName, parameter.Name);
			Assert.IsTrue(parameter.LineNumber.HasValue);
			Assert.AreEqual(expectedLineNumber, parameter.LineNumber);
		}

		/// <summary>
		/// Checks specified local declaration.
		/// </summary>
		private static void AssertLocalDeclaration(
			string expectedName,
			bool expectedIsConstant,
			int expectedLineNumber,
			LocalDeclarationItem declaration)
		{
			Assert.AreEqual(expectedName, declaration.Name);
			Assert.AreEqual(expectedIsConstant, declaration.IsConstant);

			Assert.IsTrue(declaration.LineNumber.HasValue);
			Assert.AreEqual(expectedLineNumber, declaration.LineNumber);
		}

		/// <summary>
		/// Checks specified label.
		/// </summary>
		private static void AssertLabel(
			string expectedName,
			int expectedLineNumber,
			LabelItem label)
		{
			Assert.AreEqual(expectedName, label.Name);
			Assert.IsTrue(label.LineNumber.HasValue);
			Assert.AreEqual(expectedLineNumber, label.LineNumber);
		}

		#endregion

		#region Identifying elements

		[TestMethod]
		public void Is_Private_Event_Handler()
		{
			CsDocument document = BuildCodeDocument(Source.PrivateEventHandlers);
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseMethodIsNotPrivate")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseFirstArgumentIsNotObject")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseFirstArgumentHasWrongName")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseSecondArgumentIsNotEventArgs")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseSecondArgumentHasWrongName")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseUseAliasForObject1")));
			Assert.IsFalse(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method FalseUseAliasForObject2")));
			Assert.IsTrue(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method TrueSimple")));
			Assert.IsTrue(CodeHelper.IsPrivateEventHandler(GetElementByName(document, "method TrueComplexEventArgs")));
		}

		#endregion

		#region Working with element names

		[TestMethod]
		public void Extract_Pure_Name()
		{
			string name;

			name = "Exception";
			Assert.AreEqual("Exception", CodeHelper.ExtractPureName(name, true));

			name = "System.Exception";
			Assert.AreEqual("Exception", CodeHelper.ExtractPureName(name, true));

			name = "Dictionary<int, bool>";
			Assert.AreEqual("Dictionary", CodeHelper.ExtractPureName(name, true));

			name = "System.Collections.Dictionary<int, bool>";
			Assert.AreEqual("Dictionary", CodeHelper.ExtractPureName(name, true));

			name = "IDisposable.Dispose";
			Assert.AreEqual("Dispose", CodeHelper.ExtractPureName(name, true));

			name = "value";
			Assert.AreEqual("value", CodeHelper.ExtractPureName(name, true));

			name = "System.Collections.@Dictionary<int, bool>";
			Assert.AreEqual("Dictionary", CodeHelper.ExtractPureName(name, true));
			Assert.AreEqual("@Dictionary", CodeHelper.ExtractPureName(name, false));

			name = "@value";
			Assert.AreEqual("value", CodeHelper.ExtractPureName(name, true));
			Assert.AreEqual("@value", CodeHelper.ExtractPureName(name, false));
		}

		#endregion

		#region Working with parameters

		[TestMethod]
		public void Get_Parameters()
		{
			List<ParameterItem> parameters;
			CsDocument document = BuildCodeDocument(Source.Parameters);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "delegate Delegate1"));
			Assert.AreEqual(2, parameters.Count);
			AssertParameter("x", 7, parameters[0]);
			AssertParameter("y", 7, parameters[1]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "constructor Class1"));
			Assert.AreEqual(10, parameters.Count);
			AssertParameter("list", 12, parameters[0]);
			AssertParameter("comparer", 13, parameters[1]);
			AssertParameter("a", 16, parameters[2]);
			AssertParameter("b", 17, parameters[3]);
			AssertParameter("a", 21, parameters[4]);
			AssertParameter("b", 22, parameters[5]);
			AssertParameter("a", 25, parameters[6]);
			AssertParameter("b", 26, parameters[7]);
			AssertParameter("a", 30, parameters[8]);
			AssertParameter("b", 31, parameters[9]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "property Property1"));
			Assert.AreEqual(4, parameters.Count);
			AssertParameter("a", 38, parameters[0]);
			AssertParameter("b", 38, parameters[1]);
			AssertParameter("a", 43, parameters[2]);
			AssertParameter("b", 43, parameters[3]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "indexer this"));
			Assert.AreEqual(5, parameters.Count);
			AssertParameter("index", 47, parameters[0]);
			AssertParameter("a", 51, parameters[1]);
			AssertParameter("b", 51, parameters[2]);
			AssertParameter("a", 56, parameters[3]);
			AssertParameter("b", 56, parameters[4]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method Method1"));
			Assert.AreEqual(5, parameters.Count);
			AssertParameter("count", 61, parameters[0]);
			AssertParameter("size", 62, parameters[1]);
			AssertParameter("text", 63, parameters[2]);
			AssertParameter("a", 65, parameters[3]);
			AssertParameter("b", 65, parameters[4]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method Method2"));
			Assert.AreEqual(2, parameters.Count);
			AssertParameter("args", 69, parameters[0]);
			AssertParameter("obj", 72, parameters[1]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method Method3"));
			Assert.AreEqual(3, parameters.Count);
			AssertParameter("format", 78, parameters[0]);
			AssertParameter("args", 78, parameters[1]);
			AssertParameter("obj", 81, parameters[2]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method operator Class1"));
			Assert.AreEqual(3, parameters.Count);
			AssertParameter("x", 87, parameters[0]);
			AssertParameter("a", 89, parameters[1]);
			AssertParameter("b", 89, parameters[2]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method operator int"));
			Assert.AreEqual(3, parameters.Count);
			AssertParameter("x", 93, parameters[0]);
			AssertParameter("a", 95, parameters[1]);
			AssertParameter("b", 95, parameters[2]);

			parameters = CodeHelper.GetParameters(GetElementByName(document, "method operator +"));
			Assert.AreEqual(4, parameters.Count);
			AssertParameter("x", 99, parameters[0]);
			AssertParameter("y", 99, parameters[1]);
			AssertParameter("a", 101, parameters[2]);
			AssertParameter("b", 101, parameters[3]);
		}

		[TestMethod]
		public void Get_Type_Parameters()
		{
			List<TypeParameterItem> parameters;
			CsDocument document = BuildCodeDocument(Source.TypeParameters);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "delegate Delegate1<TInput,TOutput>"));
			Assert.AreEqual(2, parameters.Count);
			AssertTypeParameter("TInput", 6, parameters[0]);
			AssertTypeParameter("TOutput", 7, parameters[1]);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "delegate Delegate2<in TInput,out TOutput>"));
			Assert.AreEqual(2, parameters.Count);
			AssertTypeParameter("TInput", 12, parameters[0]);
			AssertTypeParameter("TOutput", 13, parameters[1]);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "delegate Delegate3<in TInput>"));
			Assert.AreEqual(1, parameters.Count);
			AssertTypeParameter("TInput", 17, parameters[0]);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "delegate Delegate4<out TOutput>"));
			Assert.AreEqual(1, parameters.Count);
			AssertTypeParameter("TOutput", 20, parameters[0]);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "class Class1<TKeys>"));
			Assert.AreEqual(1, parameters.Count);
			AssertTypeParameter("TKeys", 23, parameters[0]);

			parameters = CodeHelper.GetTypeParameters(GetElementByName(document, "method Method1<TResult>"));
			Assert.AreEqual(1, parameters.Count);
			AssertTypeParameter("TResult", 25, parameters[0]);
		}

		#endregion

		#region Working with local declarations and labels

		[TestMethod]
		public void Get_Local_Declarations()
		{
			CsDocument document = BuildCodeDocument(Source.LocalDeclarations);
			CsElement element = GetElementByName(document, "constructor Class1");
			List<LocalDeclarationItem> declarations = CodeHelper.GetLocalDeclarations(element);
			Assert.AreEqual(50, declarations.Count);
			AssertLocalDeclaration("a1", false, 15, declarations[0]);
			AssertLocalDeclaration("a2", false, 15, declarations[1]);
			AssertLocalDeclaration("a3", false, 15, declarations[2]);
			AssertLocalDeclaration("b1", true, 16, declarations[3]);
			AssertLocalDeclaration("b2", true, 16, declarations[4]);
			AssertLocalDeclaration("ex1", false, 20, declarations[5]);
			AssertLocalDeclaration("ex2", false, 24, declarations[6]);
			AssertLocalDeclaration("i1", false, 30, declarations[7]);
			AssertLocalDeclaration("i2", false, 31, declarations[8]);
			AssertLocalDeclaration("i3", false, 32, declarations[9]);
			AssertLocalDeclaration("j1", false, 35, declarations[10]);
			AssertLocalDeclaration("j2", false, 35, declarations[11]);
			AssertLocalDeclaration("j3", false, 36, declarations[12]);
			AssertLocalDeclaration("a1", false, 40, declarations[13]);
			AssertLocalDeclaration("a2", false, 40, declarations[14]);
			AssertLocalDeclaration("a3", false, 40, declarations[15]);
			AssertLocalDeclaration("b1", true, 41, declarations[16]);
			AssertLocalDeclaration("b2", true, 41, declarations[17]);
			AssertLocalDeclaration("s1", false, 46, declarations[18]);
			AssertLocalDeclaration("s2", false, 47, declarations[19]);
			AssertLocalDeclaration("a1", false, 49, declarations[20]);
			AssertLocalDeclaration("a2", false, 49, declarations[21]);
			AssertLocalDeclaration("a3", false, 49, declarations[22]);
			AssertLocalDeclaration("b1", true, 50, declarations[23]);
			AssertLocalDeclaration("b2", true, 50, declarations[24]);
			AssertLocalDeclaration("ms1", false, 55, declarations[25]);
			AssertLocalDeclaration("ms2", false, 56, declarations[26]);
			AssertLocalDeclaration("ms3", false, 57, declarations[27]);
			AssertLocalDeclaration("a1", false, 59, declarations[28]);
			AssertLocalDeclaration("a2", false, 59, declarations[29]);
			AssertLocalDeclaration("a3", false, 59, declarations[30]);
			AssertLocalDeclaration("b1", true, 60, declarations[31]);
			AssertLocalDeclaration("b2", true, 60, declarations[32]);
			AssertLocalDeclaration("c1", false, 66, declarations[33]);
			AssertLocalDeclaration("c2", false, 66, declarations[34]);
			AssertLocalDeclaration("c3", false, 67, declarations[35]);
			AssertLocalDeclaration("d1", true, 69, declarations[36]);
			AssertLocalDeclaration("d2", true, 70, declarations[37]);
			AssertLocalDeclaration("thread1", false, 74, declarations[38]);
			AssertLocalDeclaration("a1", false, 77, declarations[39]);
			AssertLocalDeclaration("a2", false, 78, declarations[40]);
			AssertLocalDeclaration("a3", false, 79, declarations[41]);
			AssertLocalDeclaration("b1", true, 81, declarations[42]);
			AssertLocalDeclaration("b2", true, 82, declarations[43]);
			AssertLocalDeclaration("thread2", false, 87, declarations[44]);
			AssertLocalDeclaration("a1", false, 89, declarations[45]);
			AssertLocalDeclaration("a2", false, 89, declarations[46]);
			AssertLocalDeclaration("a3", false, 90, declarations[47]);
			AssertLocalDeclaration("b1", true, 91, declarations[48]);
			AssertLocalDeclaration("b2", true, 92, declarations[49]);
		}

		[TestMethod]
		public void Get_Labels()
		{
			CsDocument document = BuildCodeDocument(Source.Labels);
			CsElement element = GetElementByName(document, "constructor Class1");
			List<LabelItem> labels = CodeHelper.GetLabels(element);
			Assert.AreEqual(10, labels.Count);
			AssertLabel("lab1", 15, labels[0]);
			AssertLabel("lab2", 24, labels[1]);
			AssertLabel("lab3", 29, labels[2]);
			AssertLabel("lab4", 34, labels[3]);
			AssertLabel("lab5", 38, labels[4]);
			AssertLabel("lab6", 40, labels[5]);
			AssertLabel("lab7", 41, labels[6]);
			AssertLabel("lab8", 44, labels[7]);
			AssertLabel("lab9", 48, labels[8]);
			AssertLabel("lab10", 53, labels[9]);
		}

		#endregion

		#region Working with code tree

		[TestMethod]
		public void Get_Node_By_Line()
		{
			Node<CsToken> node;
			CsDocument document = BuildCodeDocument(Source.GetByLine);

			node = CodeHelper.GetNodeByLine(document, 1);
			Assert.IsTrue(node.Value.CsTokenType == CsTokenType.Namespace);
			Assert.IsTrue(node.Value.Text == "namespace");

			node = CodeHelper.GetNodeByLine(document, 2);
			Assert.IsTrue(node.Value.CsTokenType == CsTokenType.OpenCurlyBracket);
			Assert.IsTrue(node.Value.Text == "{");

			node = CodeHelper.GetNodeByLine(document, 9);
			Assert.IsTrue(node.Value.CsTokenType == CsTokenType.WhiteSpace);
			Assert.IsTrue(node.Value.Text == "\t\t\t");

			node = node.Next;
			Assert.IsTrue(node.Value.CsTokenClass == CsTokenClass.Type);
			Assert.IsTrue(node.Value.Text == "int");

			Assert.IsNull(CodeHelper.GetNodeByLine(document, 0));
			Assert.IsNull(CodeHelper.GetNodeByLine(document, 1000));
		}

		[TestMethod]
		public void Find_Next_Or_Previous_Valueable_Node()
		{
			Node<CsToken> node;
			CsDocument document = BuildCodeDocument(Source.GetByLine);

			node = CodeHelper.GetNodeByLine(document, 1);
			node = CodeHelper.FindPreviousValueableNode(node);
			Assert.IsNull(node);

			node = CodeHelper.GetNodeByLine(document, 1);
			node = CodeHelper.FindNextValueableNode(node);
			Assert.IsTrue(node.Value.CsTokenClass == CsTokenClass.Type);
			Assert.IsTrue(node.Value.Text == "StyleCopPlus.Tests");

			node = CodeHelper.GetNodeByLine(document, 9);
			node = CodeHelper.FindPreviousValueableNode(node);
			Assert.IsTrue(node.Value.CsTokenType == CsTokenType.OpenCurlyBracket);
			Assert.IsTrue(node.Value.Text == "{");

			node = CodeHelper.GetNodeByLine(document, 9);
			node = CodeHelper.FindNextValueableNode(node);
			Assert.IsTrue(node.Value.CsTokenClass == CsTokenClass.Type);
			Assert.IsTrue(node.Value.Text == "int");

			node = CodeHelper.GetNodeByLine(document, 15);
			node = CodeHelper.FindPreviousValueableNode(node);
			Assert.IsTrue(node.Value.CsTokenType == CsTokenType.CloseCurlyBracket);
			Assert.IsTrue(node.Value.Text == "}");

			node = CodeHelper.GetNodeByLine(document, 15);
			node = CodeHelper.FindNextValueableNode(node);
			Assert.IsNull(node);

			TestHelper.Throws(() => CodeHelper.FindPreviousValueableNode(null));
			TestHelper.Throws(() => CodeHelper.FindNextValueableNode(null));
		}

		[TestMethod]
		public void Get_Element_By_Line()
		{
			CsDocument document = BuildCodeDocument(Source.GetByLine);

			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 5));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 6));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 7));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 8));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 9));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 10));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 11));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 12));
			Assert.AreEqual(GetElementByName(document, "method Method1"), CodeHelper.GetElementByLine(document, 13));

			Assert.IsNull(CodeHelper.GetElementByLine(document, 0));
			Assert.IsNull(CodeHelper.GetElementByLine(document, 1000));
		}

		[TestMethod]
		public void Get_Expression_By_Line()
		{
			Expression expr;
			CsDocument document = BuildCodeDocument(Source.GetByLine);

			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 5));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 6));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 7));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 8));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 13));

			expr = CodeHelper.GetExpressionByLine(document, 9);
			Assert.IsTrue(expr.ExpressionType == ExpressionType.Literal);
			Assert.IsTrue(expr.Text == "10");

			expr = CodeHelper.GetExpressionByLine(document, 10);
			Assert.IsTrue(expr.ExpressionType == ExpressionType.Literal);
			Assert.IsTrue(expr.Text == "10");

			expr = CodeHelper.GetExpressionByLine(document, 11);
			Assert.IsTrue(expr.ExpressionType == ExpressionType.Literal);
			Assert.IsTrue(expr.Text == "30");

			expr = CodeHelper.GetExpressionByLine(document, 12);
			Assert.IsTrue(expr.ExpressionType == ExpressionType.Literal);
			Assert.IsTrue(expr.Text == "40");

			Assert.IsNull(CodeHelper.GetElementByLine(document, 0));
			Assert.IsNull(CodeHelper.GetElementByLine(document, 1000));
		}

		[TestMethod]
		public void Get_Root_Expression()
		{
			Expression expr;
			CsDocument document = BuildCodeDocument(Source.GetByLine);

			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 5));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 6));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 7));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 8));
			Assert.IsNull(CodeHelper.GetExpressionByLine(document, 13));

			expr = CodeHelper.GetExpressionByLine(document, 9);
			expr = CodeHelper.GetRootExpression(expr);
			Assert.IsTrue(expr.ExpressionType == ExpressionType.VariableDeclaration);
			Assert.IsTrue(expr.Text == "int a = 10");

			for (int i = 10; i <= 12; i++)
			{
				expr = CodeHelper.GetExpressionByLine(document, i);
				expr = CodeHelper.GetRootExpression(expr);
				Assert.IsTrue(expr.ExpressionType == ExpressionType.VariableDeclaration);
				Assert.IsTrue(expr.Text == "int b = 10\n\t\t\t\t+ (20 + 30\n\t\t\t\t\t- 40)");
			}
		}

		#endregion

		#region Working with elements size

		[TestMethod]
		public void Get_Element_Size_By_Declaration()
		{
			int size;
			CsDocument document = BuildCodeDocument(Source.ElementsSize);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.Class1"));
			Assert.AreEqual(3, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.Class1%int%int"));
			Assert.AreEqual(4, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.~Class1"));
			Assert.AreEqual(1, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.Property.get"));
			Assert.AreEqual(1, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.Property.set"));
			Assert.AreEqual(6, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.this%int.get"));
			Assert.AreEqual(2, size);

			size = CodeHelper.GetElementSizeByDeclaration(
				GetElementByQualifiedName(document, "Root.StyleCopPlus.Tests.Class1.this%int.set"));
			Assert.AreEqual(2, size);

			size = CodeHelper.GetElementSizeByDeclaration(GetElementByName(document, "method Method1"));
			Assert.AreEqual(3, size);

			size = CodeHelper.GetElementSizeByDeclaration(GetElementByName(document, "method Method2<T>"));
			Assert.AreEqual(4, size);

			size = CodeHelper.GetElementSizeByDeclaration(GetElementByName(document, "method operator +"));
			Assert.AreEqual(3, size);
		}

		#endregion
	}
}
