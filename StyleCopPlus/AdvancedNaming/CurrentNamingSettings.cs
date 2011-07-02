using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using StyleCop;

namespace StyleCopPlus
{
	/// <summary>
	/// Naming settings in current analyzer session.
	/// </summary>
	public class CurrentNamingSettings
	{
		private Dictionary<string, string> m_names;
		private Dictionary<string, string> m_examples;
		private Dictionary<string, Regex> m_regulars;

		private List<string> m_derivings;
		private EntityType m_blockAt;

		/// <summary>
		/// Initializes settings from specified document.
		/// </summary>
		public void Initialize(SourceAnalyzer analyzer, CodeDocument document)
		{
			InitializeCommon(analyzer, document);
			InitializeDerivings(analyzer, document);
			InitializeBlockAt(analyzer, document);
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
		/// Gets regular expression for specified setting.
		/// </summary>
		public Regex GetRegex(string settingName)
		{
			return m_regulars[settingName];
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

			m_blockAt = new BlockAtEntitySetting().ConvertTo(definition);
		}

		/// <summary>
		/// Resolves entity type for specified setting name.
		/// </summary>
		private static EntityType ResolveEntity(string settingName)
		{
			switch (settingName)
			{
				case NamingSettings.Namespace:
					return EntityType.Types;
				default:
					return EntityType.None;
			}
		}

		/// <summary>
		/// Checks whether name with @ character is correct.
		/// </summary>
		public bool CheckBlockAt(string settingName, string nameToCheck)
		{
			if (!nameToCheck.StartsWith("@"))
				return true;

			EntityType entityToCheck = ResolveEntity(settingName);
			if ((m_blockAt & entityToCheck) == entityToCheck)
				return true;

			return false;
		}

		#endregion
	}
}
