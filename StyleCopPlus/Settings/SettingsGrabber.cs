using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using StyleCop;

namespace StyleCopPlus
{
	/// <summary>
	/// Allows to grab settings directly from UI.
	/// </summary>
	public static class SettingsGrabber
	{
		private static Dictionary<string, Dictionary<string, TreeNode>> s_ruleNodes;

		#region Properties

		/// <summary>
		/// Gets a value indicating whether settings grabber is initialized.
		/// </summary>
		public static bool Initialized
		{
			get
			{
				return s_ruleNodes != null;
			}
		}

		#endregion

		#region Initializing

		/// <summary>
		/// Analyzes rules tree directly from UI.
		/// </summary>
		public static void Initialize(PropertyControl tabControl)
		{
			IPropertyControlPage analyzersOptions = tabControl.Pages[0];
			TreeView tree = (TreeView)analyzersOptions.GetType().InvokeMember(
				"analyzeTree",
				BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
				null,
				analyzersOptions,
				null);

			s_ruleNodes = new Dictionary<string, Dictionary<string, TreeNode>>();

			foreach (TreeNode parserNode in tree.Nodes)
			{
				foreach (TreeNode analyzerNode in parserNode.Nodes)
				{
					SourceAnalyzer analyzer = (SourceAnalyzer)analyzerNode.Tag;
					s_ruleNodes[analyzer.Id] = new Dictionary<string, TreeNode>();
					AnalyzeRuleNodes(s_ruleNodes[analyzer.Id], analyzerNode);
				}
			}
		}

		/// <summary>
		/// Analyzes rule nodes.
		/// </summary>
		private static void AnalyzeRuleNodes(Dictionary<string, TreeNode> rulesMap, TreeNode parentNode)
		{
			foreach (TreeNode node in parentNode.Nodes)
			{
				if (node.Tag is Rule)
				{
					Rule rule = (Rule)node.Tag;
					rulesMap[rule.Name] = node;
				}
				else
				{
					AnalyzeRuleNodes(rulesMap, node);
				}
			}
		}

		#endregion

		#region Accessing foreign settings

		/// <summary>
		/// Checks whether specified analyzer is enabled.
		/// </summary>
		public static bool IsAnalyzerEnabled(string analyzerId)
		{
			foreach (TreeNode ruleNode in GetRuleNodes(analyzerId))
			{
				if (GetRuleEnabled(ruleNode))
					return true;
			}

			return false;
		}

		/// <summary>
		/// Checks whether specified rule is enabled.
		/// </summary>
		public static bool IsRuleEnabled(string analyzerId, string ruleName)
		{
			TreeNode ruleNode = GetRuleNode(analyzerId, ruleName);
			return GetRuleEnabled(ruleNode);
		}

		/// <summary>
		/// Enables specified rule.
		/// </summary>
		public static void EnableRule(string analyzerId, string ruleName)
		{
			TreeNode ruleNode = GetRuleNode(analyzerId, ruleName);
			SetRuleEnabled(ruleNode, true);
		}

		/// <summary>
		/// Disables specified rule.
		/// </summary>
		public static void DisableRule(string analyzerId, string ruleName)
		{
			TreeNode ruleNode = GetRuleNode(analyzerId, ruleName);
			SetRuleEnabled(ruleNode, false);
		}

		/// <summary>
		/// Checks whether specified rule is bold.
		/// </summary>
		public static bool IsRuleBold(string analyzerId, string ruleName)
		{
			TreeNode ruleNode = GetRuleNode(analyzerId, ruleName);
			return GetRuleBold(ruleNode);
		}

		#endregion

		#region Working with rules tree

		/// <summary>
		/// Gets tree node for specified rule.
		/// </summary>
		private static TreeNode GetRuleNode(string analyzerId, string ruleName)
		{
			Dictionary<string, TreeNode> rulesMap = s_ruleNodes[analyzerId];
			return rulesMap[ruleName];
		}

		/// <summary>
		/// Gets tree nodes for all rules of specified analyzer.
		/// </summary>
		private static IEnumerable<TreeNode> GetRuleNodes(string analyzerId)
		{
			Dictionary<string, TreeNode> rulesMap = s_ruleNodes[analyzerId];
			return rulesMap.Values;
		}

		/// <summary>
		/// Gets a value indicating whether specified rule is enabled.
		/// </summary>
		private static bool GetRuleEnabled(TreeNode ruleNode)
		{
			return ruleNode.Checked;
		}

		/// <summary>
		/// Sets a value indicating whether specified rule is enabled.
		/// </summary>
		private static void SetRuleEnabled(TreeNode ruleNode, bool enabled)
		{
			ruleNode.Checked = enabled;
		}

		/// <summary>
		/// Gets a value indicating whether specified rule is bold.
		/// </summary>
		private static bool GetRuleBold(TreeNode ruleNode)
		{
			if (ruleNode.NodeFont == null)
				return false;

			return ruleNode.NodeFont.Bold;
		}

		#endregion
	}
}
