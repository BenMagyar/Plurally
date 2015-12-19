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
            Assert.AreEqual(true, plurally.IsPlural("elves"));
        }           

        [Test]
        public void IsPluralShouldCheckSpecialWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsPlural("brothers"));
            Assert.AreEqual(true, plurally.IsPlural("brethren"));
            Assert.AreEqual(false, plurally.IsPlural("brother"));
        }

        [Test]
        public void IsPluralShouldCheckUnusualWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsPlural("homework"));
        }

        [Test]
        public void IsSingularShouldCheckNormalWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsSingular("test"));
            Assert.AreEqual(false, plurally.IsSingular("tests"));
        }

        [Test]
        public void IsSingularShouldCheckSpecialSuffix()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsSingular("chess"));
        }

        [Test]
        public void IsSingularShouldCheckSpecialWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual(true, plurally.IsSingular("Brother"));
            Assert.AreEqual(false, plurally.IsSingular("brethren"));
            Assert.AreEqual(false, plurally.IsSingular("brothers"));
        }

        [Test]
        public void PluralizeShouldAddSToNormalWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual("Tests", plurally.Pluralize("Test"));
        }

        [Test]
        public void PluralizeShouldCheckUnusualWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual("Homework", plurally.Pluralize("Homework"));
        }

        [Test]
        public void PluralizeShouldCheckSpecialWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual("BROTHERS", plurally.Pluralize("BROTHER"));
        }

        [Test]
        public void SingularizeShouldRemoveSFromNormalWords()
        {
            var plurally = new Plurally();
            Assert.AreEqual("Test", plurally.Singularize("Tests"));
        }
	}
}

