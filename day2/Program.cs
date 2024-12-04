using AdventOfCode;

namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SolveProblem();
        }
        static void SolveProblem()
        {
            uint count = 0;
            foreach (var line in LineReader.Read("input.txt"))
            {
                var report = Report.FromString(line);
                if (report.IsSafe)
                {
                    count++;
                }
                else
                {
                    if (ProblemDampener(report))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"Total safe report count: {count}");
        }
        static bool ProblemDampener(Report report)
        {
            for (int tryCount = 0; tryCount < report.Levels.Count; tryCount++)
            {
                var newReport = Report.Copy(report);
                newReport.Levels.RemoveAt(tryCount);
                if(newReport.IsSafe)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
