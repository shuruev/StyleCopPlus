using System;
using System.Collections.Generic;
using StyleCopPlus.Properties;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// All naming settings.
	/// </summary>
	internal static class NamingSettings
	{
		internal const string Abbreviations = "AdvancedNaming_Abbreviations";
		internal const string Words = "AdvancedNaming_Words";
		internal const string Derivings = "AdvancedNaming_Derivings";
		internal const string BlockAt = "AdvancedNaming_BlockAt";
		internal const string EnglishOnly = "AdvancedNaming_EnglishOnly";
		internal const string CheckLength = "AdvancedNaming_CheckLength";
		internal const string CheckLengthExceptions = "AdvancedNaming_CheckLengthExceptions";

		internal const string Namespace = "AdvancedNaming_Namespace";
		internal const string ClassNotInternal = "AdvancedNaming_ClassNotInternal";
		internal const string ClassInternal = "AdvancedNaming_ClassInternal";
		internal const string StructNotInternal = "AdvancedNaming_StructNotInternal";
		internal const string StructInternal = "AdvancedNaming_StructInternal";
		internal const string Interface = "AdvancedNaming_Interface";
		internal const string Enum = "AdvancedNaming_Enum";
		internal const string EnumItem = "AdvancedNaming_EnumItem";

		internal const string PublicInstanceField = "AdvancedNaming_PublicInstanceField";
		internal const string ProtectedInstanceField = "AdvancedNaming_ProtectedInstanceField";
		internal const string PrivateInstanceField = "AdvancedNaming_PrivateInstanceField";
		internal const string InternalInstanceField = "AdvancedNaming_InternalInstanceField";
		internal const string PublicStaticField = "AdvancedNaming_PublicStaticField";
		internal const string ProtectedStaticField = "AdvancedNaming_ProtectedStaticField";
		internal const string PrivateStaticField = "AdvancedNaming_PrivateStaticField";
		internal const string InternalStaticField = "AdvancedNaming_InternalStaticField";
		internal const string PublicConst = "AdvancedNaming_PublicConst";
		internal const string ProtectedConst = "AdvancedNaming_ProtectedConst";
		internal const string PrivateConst = "AdvancedNaming_PrivateConst";
		internal const string InternalConst = "AdvancedNaming_InternalConst";
		internal const string Property = "AdvancedNaming_Property";

		internal const string MethodGeneral = "AdvancedNaming_MethodGeneral";
		internal const string MethodPrivateEventHandler = "AdvancedNaming_MethodPrivateEventHandler";
		internal const string MethodTest = "AdvancedNaming_MethodTest";
		internal const string Event = "AdvancedNaming_Event";
		internal const string Delegate = "AdvancedNaming_Delegate";

		internal const string Parameter = "AdvancedNaming_Parameter";
		internal const string TypeParameter = "AdvancedNaming_TypeParameter";
		internal const string LocalVariable = "AdvancedNaming_LocalVariable";
		internal const string LocalConstant = "AdvancedNaming_LocalConstant";
		internal const string Label = "AdvancedNaming_Label";

		private static readonly List<string> s_groups;
		private static readonly Dictionary<string, bool> s_commons;
		private static readonly Dictionary<string, List<string>> s_all;

		static NamingSettings()
		{
			s_groups = new List<string>();
			s_commons = new Dictionary<string, bool>();
			s_all = new Dictionary<string, List<string>>();

			Add(Abbreviations, false, Resources.GroupSpecial);
			Add(Words, false, Resources.GroupSpecial);
			Add(Derivings, false, Resources.GroupSpecial);
			Add(BlockAt, false, Resources.GroupSpecial);
			Add(EnglishOnly, false, Resources.GroupSpecial);
			Add(CheckLength, false, Resources.GroupSpecial);
			Add(CheckLengthExceptions, false, Resources.GroupSpecial);

			Add(Namespace, true, Resources.GroupEntities);
			Add(ClassNotInternal, true, Resources.GroupEntities);
			Add(ClassInternal, true, Resources.GroupEntities);
			Add(StructNotInternal, true, Resources.GroupEntities);
			Add(StructInternal, true, Resources.GroupEntities);
			Add(Interface, true, Resources.GroupEntities);
			Add(Enum, true, Resources.GroupEntities);
			Add(EnumItem, true, Resources.GroupEntities);

			Add(PublicInstanceField, true, Resources.GroupFields);
			Add(ProtectedInstanceField, true, Resources.GroupFields);
			Add(PrivateInstanceField, true, Resources.GroupFields);
			Add(InternalInstanceField, true, Resources.GroupFields);
			Add(PublicStaticField, true, Resources.GroupFields);
			Add(ProtectedStaticField, true, Resources.GroupFields);
			Add(PrivateStaticField, true, Resources.GroupFields);
			Add(InternalStaticField, true, Resources.GroupFields);
			Add(PublicConst, true, Resources.GroupFields);
			Add(ProtectedConst, true, Resources.GroupFields);
			Add(PrivateConst, true, Resources.GroupFields);
			Add(InternalConst, true, Resources.GroupFields);
			Add(Property, true, Resources.GroupFields);

			Add(MethodGeneral, true, Resources.GroupMethods);
			Add(MethodPrivateEventHandler, true, Resources.GroupMethods);
			Add(MethodTest, true, Resources.GroupMethods);
			Add(Event, true, Resources.GroupMethods);
			Add(Delegate, true, Resources.GroupMethods);

			Add(Parameter, true, Resources.GroupParameters);
			Add(TypeParameter, true, Resources.GroupParameters);
			Add(LocalVariable, true, Resources.GroupParameters);
			Add(LocalConstant, true, Resources.GroupParameters);
			Add(Label, true, Resources.GroupParameters);
		}

		/// <summary>
		/// Adds specified setting to inner collection.
		/// </summary>
		private static void Add(string settingName, bool isCommon, string groupName)
		{
			if (!s_all.ContainsKey(groupName))
			{
				s_groups.Add(groupName);
				s_all[groupName] = new List<string>();
			}

			if (isCommon)
			{
				s_commons.Add(settingName, false);
			}

			s_all[groupName].Add(settingName);
		}

		/// <summary>
		/// Returns a list of common settings.
		/// </summary>
		public static List<string> GetCommon()
		{
			return new List<string>(s_commons.Keys);
		}

		/// <summary>
		/// Checks whether specified setting is a common one.
		/// </summary>
		public static bool IsCommon(string settingName)
		{
			return s_commons.ContainsKey(settingName);
		}

		/// <summary>
		/// Returns a list of groups.
		/// </summary>
		public static List<string> GetGroups()
		{
			return new List<string>(s_all.Keys);
		}

		/// <summary>
		/// Returns a list of settings for specified group.
		/// </summary>
		public static List<string> GetByGroup(string groupName)
		{
			return new List<string>(s_all[groupName]);
		}

		/// <summary>
		/// Gets an editor for specified setting.
		/// </summary>
		public static IAdvancedNamingEditor GetEditor(string settingName)
		{
			switch (settingName)
			{
				case Abbreviations:
					return new SpecialSettingEditor
					{
						SpecialSetting = new Abbreviations()
					};

				case Words:
					return new SpecialSettingEditor
					{
						SpecialSetting = new Words()
					};

				case Derivings:
					return new SpecialSettingEditor
					{
						SpecialSetting = new Derivings()
					};

				case BlockAt:
					return new EntitySettingEditor
					{
						EntitySetting = new BlockAt()
					};

				case EnglishOnly:
					return new EntitySettingEditor
					{
						EntitySetting = new EnglishOnly()
					};

				case CheckLength:
					return new EntitySettingEditor
					{
						EntitySetting = new CheckLength()
					};

				case CheckLengthExceptions:
					return new SpecialSettingEditor
					{
						SpecialSetting = new CheckLengthExceptions()
					};

				default:
					return new NamingRuleEditor();
			}
		}

		/// <summary>
		/// Gets image key for specified setting.
		/// </summary>
		public static string GetImageKey(string settingName, bool enabled)
		{
			switch (settingName)
			{
				case Abbreviations:
					return Pictures.CapitalLetter;

				case Words:
					return Pictures.TwoLetters;

				case Derivings:
					return Pictures.RightArrow;

				case BlockAt:
					return Pictures.AtSign;

				case EnglishOnly:
					return Pictures.English;

				case CheckLength:
				case CheckLengthExceptions:
					return Pictures.NameLength;

				default:
					return enabled ? Pictures.RuleEnabled : Pictures.RuleDisabled;
			}
		}

		/// <summary>
		/// Gets preview text for specified setting value.
		/// </summary>
		public static string GetPreviewText(string settingName, string settingValue)
		{
			if (String.IsNullOrEmpty(settingValue))
				return Resources.DoNotCheck;

			if (IsCommon(settingName))
				return NamingMacro.BuildExample(settingValue);

			switch (settingName)
			{
				case BlockAt:
					return new BlockAt().GetPreviewText(settingValue);

				case EnglishOnly:
					return new EnglishOnly().GetPreviewText(settingValue);

				case CheckLength:
					return new CheckLength().GetPreviewText(settingValue);

				default:
					return settingValue;
			}
		}
	}
}
