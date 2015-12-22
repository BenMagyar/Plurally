using NUnit.Framework;
using System;
using System.Globalization;

namespace Plurally.Tests
{
    [TestFixture]
    public class PluralizerTests
    {
        [Test]
        public void PlurallyShouldThrowNotSupportedForUnassignedLocales()
        {
            Assert.Catch(() =>
            {
                new Pluralizer(new CultureInfo(23));
            });
        }

        [Test]
        public void PlurallyShouldUseSameEnglishLocaleForAll()
        {
            var plurallyGB = new Pluralizer(new CultureInfo(2057));
            var plurallyUS = new Pluralizer(new CultureInfo(1033));

            // Assert the results are the same on the pluralization
            var pluralGB = plurallyGB.Pluralize("test");
            var pluralUS = plurallyUS.Pluralize("test");

            // Same results for English
            Assert.AreEqual(pluralGB, pluralUS);
        }
    }
}

