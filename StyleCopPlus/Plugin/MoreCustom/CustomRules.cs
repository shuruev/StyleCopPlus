using System.Collections.Generic;
using StyleCopPlus.Properties;

namespace StyleCopPlus.Plugin.MoreCustom
{
	/// <summary>
	/// All custom rules.
	/// </summary>
	internal static class CustomRules
	{
		private static readonly List<string> s_groups;
		private static readonly Dictionary<string, List<CustomRule>> s_allByGroup;
		private static readonly Dictionary<Rules, CustomRule> s_allByRule;

		static CustomRules()
		{
			s_groups = new List<string>();
			s_allByGroup = new Dictionary<string, List<CustomRule>>();
			s_allByRule = new Dictionary<Rules, CustomRule>();

			Add(new SP2000(), Resources.GroupFormatting);
			Add(new SP2001(), Resources.GroupFormatting);
			Add(new SP2002(), Resources.GroupFormatting);

			Add(new SP2100(), Resources.GroupMaintainability);
			Add(new SP2101(), Resources.GroupMaintainability);
			Add(new SP2102(), Resources.GroupMaintainability);
			Add(new SP2103(), Resources.GroupMaintainability);
		}

		/// <summary>
		/// Adds specified rule to inner collection.
		/// </summary>
		private static void Add(CustomRule customRule, string groupName)
		{
			if (!s_allByGroup.ContainsKey(groupName))
			{
				s_groups.Add(groupName);
				s_allByGroup[groupName] = new List<CustomRule>();
			}

			s_allByGroup[groupName].Add(customRule);
			s_allByRule.Add(customRule.Rule, customRule);
		}

		/// <summary>
		/// Returns a list of groups.
		/// </summary>
		public static List<string> GetGroups()
		{
			return new List<string>(s_allByGroup.Keys);
		}

		/// <summary>
		/// Returns a list of settings for specified group.
		/// </summary>
		public static List<CustomRule> GetByGroup(string groupName)
		{
			return new List<CustomRule>(s_allByGroup[groupName]);
		}

		/// <summary>
		/// Returns specified rule.
		/// </summary>
		public static CustomRule Get(Rules rule)
		{
			return s_allByRule[rule];
		}
	}
}
