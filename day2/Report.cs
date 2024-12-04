namespace day2
{
    internal class Report
    {
        public List<int> Levels = new();
        public static Report Copy(Report otherReport)
        {
            var report = new Report();
            foreach (var number in otherReport.Levels)
            {
                report.Levels.Add(number);
            }
            return report;
        }
        public static Report FromString(string data)
        {
            var report = new Report();
            var numbers = data.Split(' ');
            foreach (var number in numbers)
            {
                report.Levels.Add(int.Parse(number));
            }
            return report;
        }
        public bool IsSafe
        {
            get
            {
                return IsSafeDesc || IsSafeAsc;
            }
        }

        private bool IsSafeDesc
        {
            get
            {
                for(int i = 1; i < Levels.Count; i++)
                {
                    int difference = Levels[i - 1] - Levels[i];
                    if(Levels[i] >= Levels[i - 1] || difference > 3)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private bool IsSafeAsc
        {
            get
            {
                for (int i = 1; i < Levels.Count; i++)
                {
                    int difference = Levels[i] - Levels[i - 1];
                    if (Levels[i] <= Levels[i - 1] || difference > 3)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
