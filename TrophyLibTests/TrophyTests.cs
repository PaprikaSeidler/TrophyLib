using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        [TestMethod()]
        public void TrophyCompetitionTest()
        {
            Trophy trophy = new Trophy();
            trophy.Competition = "World Cup";
            Assert.AreEqual("World Cup", trophy.Competition);
            Assert.ThrowsException<ArgumentNullException>(() => trophy.Competition = null);
            Assert.ThrowsException<ArgumentException>(() => trophy.Competition = "ab");
        }

        [TestMethod()]
        public void TrophyYearTest()
        {
            Trophy trophy = new Trophy();
            trophy.Year = 2025;
            Assert.AreEqual(2025, trophy.Year);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 1969);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophy.Year = 2026);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Trophy trophy = new Trophy();
            trophy.Competition = "World Cup";
            trophy.Year = 2022;
            Assert.AreEqual("World Cup 2022", trophy.ToString());
        }
    }
}