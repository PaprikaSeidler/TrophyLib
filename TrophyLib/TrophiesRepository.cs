using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophiesRepository
    {
        private List<Trophy> trophies = new List<Trophy>();
        private int _nextId = 0;

        public TrophiesRepository()
        {
            Add(new Trophy { Competition = "World cup", Year = 2025 });
            Add(new Trophy { Competition = "Best in show", Year = 2024 });
            Add(new Trophy { Competition = "Dog of the year", Year = 2021 });
            Add(new Trophy { Competition = "Best in show", Year = 2023 });
            Add(new Trophy { Competition = "Dog of the year", Year = 2022 });
        }

        public List<Trophy> Get(int? FilterByYear = null, string? SortByCompetition = null)
        {
            var result = trophies.Select(t => new Trophy(t)).ToList();

            if (FilterByYear != null)
            {
                result = result.FindAll(t => t.Year == FilterByYear);
            }
            if (SortByCompetition != null)
            {
                result = result.OrderBy(t => t.Competition).ToList();
            }
            return result;
        }

        public Trophy GetById(int id)
        {
            return trophies.Find(t => t.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = ++_nextId;
            trophies.Add(trophy);           
            return trophy;
        }

        public Trophy Remove(int id)
        {
            Trophy trophy = GetById(id);
            if (trophy != null)
            {
                trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy Update(int id, Trophy trophy)
        {
            Trophy UpdateTrophy = GetById(id);
            if (UpdateTrophy != null)
            {
                UpdateTrophy.Competition = trophy.Competition;
                UpdateTrophy.Year = trophy.Year;
            }
            return UpdateTrophy;
        }
    }
}
