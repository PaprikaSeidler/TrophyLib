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

        public List<Trophy> Get(int? FilterByYear = null, string? SortByCompetition = null) //Hvad er en comy constructor? Og hvordan bruges den her?
        {
            var result = new List<Trophy>(trophies);
            if (FilterByYear != null)
            {
                result = result.FindAll(t => t.Year == FilterByYear);
            }
            if (SortByCompetition != null)
            {
                result = result.OrderBy(t => t.Competition).ToList(); //Måske IComparer??
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
