namespace TrophyLib
{
    public class Trophy
    {
        private string? _competition;
        private int _year;

        public Trophy()
        {
        }

        public Trophy(Trophy t)
        {
            Id = t.Id;
            Competition = t.Competition;
            Year = t.Year;
        }

        public int Id { get; set; }
        public string Competition
        {
            get => _competition;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Competition name cannot be null.");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Competition name must be at least 3 characters long.");
                }
                _competition = value;
            }
        }
        public int Year
        {
            get => _year;
            set
            {
                if (value < 1970 || value > 2025)
                {
                    throw new ArgumentOutOfRangeException("Year must be after 1970 and before 2025");
                }
                _year = value;
            }
        }

        public override string ToString()
        {
            return $"{Competition} {Year}";
        }
    }
}
