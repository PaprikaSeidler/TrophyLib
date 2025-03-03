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
    public class TrophiesRepositoryTests
    {
        [TestMethod()]
        public void GetTrophiesTest()
        {
            TrophiesRepository trophies = new TrophiesRepository();
            trophies.Add(new Trophy { Id = 1, Competition = "World cup", Year = 2025 });
            trophies.Add(new Trophy { Id = 2, Competition = "Best in show", Year = 2024 });
            trophies.Add(new Trophy { Id = 3, Competition = "Dog of the year", Year = 2021 });

            Assert.AreEqual(3, trophies.Get().Count);

            List<Trophy> filterByYear = trophies.Get(2025);
            Assert.AreEqual(1, filterByYear.Count);

            List<Trophy> sortBy = trophies.Get(null, "CompetitionString");
            Assert.AreEqual("Best in show", sortBy[0].Competition);
            Assert.AreEqual("Dog of the year", sortBy[1].Competition);
            Assert.AreEqual("World cup", sortBy[2].Competition);

            List<Trophy> filterAndSort = trophies.Get(2021, "CompetitionString");
            Assert.AreEqual(1, filterAndSort.Count);
            Assert.IsTrue(filterAndSort[0].Competition == "Dog of the year");
        }

        [TestMethod()]
        public void AddTest()
        {
            TrophiesRepository trophies = new TrophiesRepository();
            trophies.Add(new Trophy { Competition = "World cup", Year = 2025 });
            Assert.AreEqual(1, trophies.Get().Count);
            Assert.AreEqual(1, trophies.Get()[0].Id);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TrophiesRepository trophies = new TrophiesRepository();
            trophies.Add(new Trophy { Id = 1, Competition = "World cup", Year = 2025 });
            trophies.Update(1, new Trophy { Competition = "Best in show", Year = 2024 });
            Assert.AreEqual("Best in show", trophies.Get()[0].Competition);
            Assert.AreEqual(2024, trophies.Get()[0].Year);
            
            trophies.Update(2, new Trophy { Competition = "Dog of the year", Year = 2021 });
            Assert.IsNull(trophies.GetById(2));
        }
    }
}