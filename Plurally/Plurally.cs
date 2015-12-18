using System;
using System.Globalization;

namespace Plurally
{
    using Localization;

	public class Plurally
	{
		private readonly CultureInfo _cultureInfo;
        private readonly ILocalization _localization;

		/// <summary>
		/// Initializes a new instance of the <see cref="Plurally.PlurallyPlease"/> class.
		/// </summary>
		/// <param name="cultureInfo">Optional Culture Info. Defaults to the current culture</param>
        public Plurally(CultureInfo cultureInfo = null)
		{			
            _cultureInfo = cultureInfo ?? CultureInfo.CurrentCulture;
            // Get our localized setup... into a switch for now
            _localization = GetLocalizedLanguage();
		}          

        // Current support limited to English
        private ILocalization GetLocalizedLanguage()
        {
            return new LocaleEN();
        }

		/// <summary>
		/// Determines whether the word is plural.
		/// </summary>
		/// <returns><c>true</c> if the word is plural; otherwise, <c>false</c>.</returns>
		/// <param name="word">Word.</param>
		public bool IsPlural(String word)
		{
            return _localization.IsPlural(word);
		}
	}
}

