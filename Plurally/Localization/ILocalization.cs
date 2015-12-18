using System;

namespace Plurally.Localization
{
    public interface ILocalization
    {
        /// <summary>
        /// If word is plural
        /// </summary>
        /// <returns><c>true</c>, if word is plural, <c>false</c> otherwise.</returns>
        /// <param name="word">A Word.</param>
        bool IsPlural(string word);
    }
}

