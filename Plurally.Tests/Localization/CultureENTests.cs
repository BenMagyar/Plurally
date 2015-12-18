using NUnit.Framework;
using Plurally.Localization;
using System;
using System.Globalization;

namespace Plurally.Tests
{
	[TestFixture]
	public class PlurallyCulturesTests
	{
		[Test]
		public void IsPluralShouldCheckNormalWords()
		{
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsPlural("Tests"));
            Assert.AreEqual(false, plurally.IsPlural("Test"));
		}           

        [Test]
        public void IsPluralShouldCheckSpecialSuffix()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsPlural("fish"));
        }

        [Test]
        public void IsPluralShouldCheckSpecialWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsPlural("brothers"));
            Assert.AreEqual(true, plurally.IsPlural("brethren"));
        }
	}
}

