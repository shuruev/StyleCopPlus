using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using StyleCop;

namespace StyleCopPlus.Plugin.AdvancedNaming
{
	/// <summary>
	/// Naming settings in current analyzer session.
	/// </summary>
	public class CurrentNamingSettings
	{
		private static readonly Regex s_englishOnlyRegex = new Regex("^[0-9A-Za-z_]+$");

		private Dictionary<string, string> m_names;
		private Dictionary<string, string> m_examples;
		private Dictionary<string, Regex> m_regulars;

		private List<string> m_derivings;
		private EntityType m_blockAt;
		private EntityType m_englishOnly;
		private EntityType m_checkLength;
		private HashSet<string> m_checkLengthExceptions;

		/// <summary>
		/// Initializes settings from specified document.
		/// </summary>
		public void Initialize(SourceAnalyzer analyzer, CodeDocument document)
		{
			InitializeCommon(analyzer, document);
			InitializeDerivings(analyzer, document);
			InitializeBlockAt(analyzer, document);
			InitializeEnglishOnly(analyzer, document);
			InitializeCheckLength(analyzer, document);
		}

		/// <summary>
		/// Resolves entity type for specified setting name.
		/// </summary>
		private static EntityType ResolveEntity(string settingName)
		{
			switch (settingName)
			{
				case NamingSettings.Namespace:
				case NamingSettings.ClassNotInternal:
				case NamingSettings.ClassInternal:
				case NamingSettings.StructNotInternal:
				case NamingSettings.StructInternal:
				case NamingSettings.Interface:
				case NamingSettings.Enum:
				case NamingSettings.TypeParameter:
					return EntityType.Types;

				case NamingSettings.PublicInstanceField:
				case NamingSettings.ProtectedInstanceField:
				case NamingSettings.PrivateInstanceField:
				case NamingSettings.InternalInstanceField:
				case NamingSettings.PublicStaticField:
				case NamingSettings.ProtectedStaticField:
				case NamingSettings.PrivateStaticField:
				case NamingSettings.InternalStaticField:
				case NamingSettings.PublicConst:
				case NamingSettings.ProtectedConst:
				case NamingSettings.PrivateConst:
				case NamingSettings.InternalConst:
				case NamingSettings.Property:
				case NamingSettings.EnumItem:
					return EntityType.Fields;

				case NamingSettings.MethodGeneral:
				case NamingSettings.MethodPrivateEventHandler:
				case NamingSettings.MethodTest:
				case NamingSettings.Event:
				case NamingSettings.Delegate:
					return EntityType.Methods;

				case NamingSettings.Parameter:
					return EntityType.Parameters;

				case NamingSettings.LocalVariable:
				case NamingSettings.LocalConstant:
				case NamingSettings.Label:
					return EntityType.Variables;

				default:
					return EntityType.None;
			}
		}

		#region Common settings

		/// <summary>
		/// Initializes common settings.
		/// </summary>
		private void InitializeCommon(SourceAnalyzer analyzer, CodeDocument document)
		{
			m_names = new Dictionary<string, string>();
			m_examples = new Dictionary<string, string>();
			m_regulars = new Dictionary<string, Regex>();

			string abbreviations = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.Abbreviations);

			string words = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.Words);

			foreach (string setting in NamingSettings.GetCommon())
			{
				string name = SettingsManager.GetFriendlyName(analyzer, setting);
				m_names.Add(setting, name);

				string value = SettingsManager.GetValue<string>(analyzer, document.Settings, setting);
				if (String.IsNullOrEmpty(value))
				{
					m_examples.Add(setting, null);
					m_regulars.Add(setting, null);
				}
				else
				{
					string example = NamingMacro.BuildExample(value);
					m_examples.Add(setting, example);

					Regex regex = NamingMacro.BuildRegex(value, abbreviations, words);
					m_regulars.Add(setting, regex);
				}
			}
		}

		/// <summary>
		/// Gets friendly name for specified setting.
		/// </summary>
		public string GetFriendlyName(string settingName)
		{
			return m_names[settingName];
		}

		/// <summary>
		/// Gets example text for specified setting.
		/// </summary>
		public string GetExample(string settingName)
		{
			return m_examples[settingName];
		}

		/// <summary>
		/// Checks naming rule for specified setting.
		/// </summary>
		public bool CheckNamingRule(string settingName, string nameToCheck)
		{
			Regex regex = m_regulars[settingName];
			if (regex == null)
				return true;

			return regex.IsMatch(nameToCheck);
		}

		#endregion

		#region Checking derived classes

		/// <summary>
		/// Initializes setting for checking derived classes.
		/// </summary>
		private void InitializeDerivings(SourceAnalyzer analyzer, CodeDocument document)
		{
			m_derivings = new List<string>();

			string derivings = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.Derivings);

			m_derivings.AddRange(
				derivings.Split(
					new[] { ' ' },
					StringSplitOptions.RemoveEmptyEntries));
		}

		/// <summary>
		/// Checks whether derived name is correct.
		/// </summary>
		public bool CheckDerivedName(string baseName, string derivedName, out string failedDeriving)
		{
			failedDeriving = null;

			foreach (string deriving in m_derivings)
			{
				if (baseName.EndsWith(deriving))
				{
					if (!derivedName.EndsWith(deriving))
					{
						failedDeriving = deriving;
						return false;
					}
				}
			}

			return true;
		}

		#endregion

		#region Blocking @ character

		/// <summary>
		/// Initializes setting for blocking @ character.
		/// </summary>
		private void InitializeBlockAt(SourceAnalyzer analyzer, CodeDocument document)
		{
			string definition = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.BlockAt);

			m_blockAt = new BlockAt().ConvertTo(definition);
		}

		/// <summary>
		/// Checks whether specified entity should be checked for @ character usage.
		/// </summary>
		public bool IsEnabledBlockAt(string settingName)
		{
			EntityType entityToCheck = ResolveEntity(settingName);
			return m_blockAt.Contains(entityToCheck);
		}

		/// <summary>
		/// Checks whether specified name with @ character is correct.
		/// </summary>
		public bool CheckBlockAt(string settingName, string nameToCheck)
		{
			if (!IsEnabledBlockAt(settingName))
				return true;

			return !nameToCheck.StartsWith("@");
		}

		#endregion

		#region Using English characters only.

		/// <summary>
		/// Initializes setting for using English characters only.
		/// </summary>
		private void InitializeEnglishOnly(SourceAnalyzer analyzer, CodeDocument document)
		{
			string definition = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.EnglishOnly);

			m_englishOnly = new EnglishOnly().ConvertTo(definition);
		}

		/// <summary>
		/// Checks whether specified entity should be checked for using English characters only.
		/// </summary>
		public bool IsEnabledEnglishOnly(string settingName)
		{
			EntityType entityToCheck = ResolveEntity(settingName);
			return m_englishOnly.Contains(entityToCheck);
		}

		/// <summary>
		/// Checks whether specified name with non-English characters is correct.
		/// </summary>
		public bool CheckEnglishOnly(string settingName, string nameToCheck)
		{
			if (!IsEnabledEnglishOnly(settingName))
				return true;

			return s_englishOnlyRegex.IsMatch(nameToCheck);
		}

		#endregion

		#region Checking name length

		/// <summary>
		/// Initializes setting for checking name length.
		/// </summary>
		private void InitializeCheckLength(SourceAnalyzer analyzer, CodeDocument document)
		{
			string definition = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.CheckLength);

			m_checkLength = new CheckLength().ConvertTo(definition);

			string exceptions = SettingsManager.GetValue<string>(
				analyzer,
				document.Settings,
				NamingSettings.CheckLengthExceptions);

			m_checkLengthExceptions = new HashSet<string>(
				exceptions
					.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(word => word.ToLowerInvariant()));
		}

		/// <summary>
		/// Checks whether specified entity should be checked for name length.
		/// </summary>
		public bool IsEnabledCheckLength(string settingName)
		{
			EntityType entityToCheck = ResolveEntity(settingName);
			return m_checkLength.Contains(entityToCheck);
		}

		/// <summary>
		/// Checks whether specified name follows length agreement.
		/// </summary>
		public bool CheckNameLength(string settingName, string nameToCheck)
		{
			if (!IsEnabledCheckLength(settingName))
				return true;

			if (m_checkLengthExceptions.Contains(nameToCheck.ToLowerInvariant()))
				return true;

			return nameToCheck.Length >= 4;
		}

		#endregion
	}
}
