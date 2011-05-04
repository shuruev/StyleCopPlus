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
		private readonly Dictionary<string, string> m_names;
		private readonly Dictionary<string, string> m_examples;
		private readonly Dictionary<string, Regex> m_regulars;
		private readonly List<string> m_derivings;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public CurrentNamingSettings()
		{
			m_names = new Dictionary<string, string>();
			m_examples = new Dictionary<string, string>();
			m_regulars = new Dictionary<string, Regex>();
			m_derivings = new List<string>();
		}

		/// <summary>
		/// Initializes settings from specified document.
		/// </summary>
		public void Initialize(SourceAnalyzer analyzer, CodeDocument document)
		{
			m_names.Clear();
			m_examples.Clear();
			m_regulars.Clear();
			m_derivings.Clear();

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
	}
}
