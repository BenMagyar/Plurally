using System;

namespace Plurally.Globalization
{
	public interface ICulture
	{
		bool IsPlural(string word);
	}
}

