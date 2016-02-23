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
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsPlural("Tests"));
            Assert.AreEqual(false, plurally.IsPlural("Test"));
        }           

        [Test]
        public void IsPluralShouldCheckSpecialSuffix()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsPlural("elves"));
        }           

        [Test]
        public void IsPluralShouldCheckSpecialWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsPlural("brothers"));
            Assert.AreEqual(true, plurally.IsPlural("brethren"));
            Assert.AreEqual(false, plurally.IsPlural("brother"));
        }

        [Test]
        public void IsPluralShouldCheckUnusualWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsPlural("homework"));
        }

        [Test]
        public void IsSingularShouldCheckNormalWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsSingular("test"));
            Assert.AreEqual(false, plurally.IsSingular("tests"));
        }

        [Test]
        public void IsSingularShouldCheckSpecialSuffix()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsSingular("chess"));
        }

        [Test]
        public void IsSingularShouldCheckSpecialWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual(true, plurally.IsSingular("Brother"));
            Assert.AreEqual(false, plurally.IsSingular("brethren"));
            Assert.AreEqual(false, plurally.IsSingular("brothers"));
        }

        [Test]
        public void PluralizeShouldCheckSuffixes()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("Companies", plurally.Pluralize("Company"));
        }

        [Test]
        public void PluralizeShouldAddSToNormalWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("Tests", plurally.Pluralize("Test"));
        }

        [Test]
        public void PluralizeShouldCheckUnusualWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("Homework", plurally.Pluralize("Homework"));
        }

        [Test]
        public void PluralizeShouldCheckSpecialWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("BROTHERS", plurally.Pluralize("BROTHER"));
        }

        [Test]
        public void SingularizeShouldRemoveSFromNormalWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("Test", plurally.Singularize("Tests"));
            Assert.AreEqual("test", plurally.Singularize("testS"));
        }

        [Test]
        public void SingularizeShouldCheckUnusualWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("homework", plurally.Singularize("homework"));
        }

        [Test]
        public void SingularizeShouldCheckSuffixes()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("Company", plurally.Singularize("Companies"));
        }           

        [Test]
        public void SingularizeShouldCheckSpecialWords()
        {
            var plurally = new Pluralizer();
            Assert.AreEqual("brother", plurally.Singularize("brothers"));
            Assert.AreEqual("brother", plurally.Singularize("brethren"));
        }            
    }
}

