using System.Diagnostics;

namespace AdventOfCode
{
    public class Profiler
    {
        private static Stopwatch SW = new Stopwatch();
        private static uint Count = 0;
        public static void Start()
        {
            SW.Start();
        }
        public static void End()
        {
            Count++;
            SW.Stop();
            Console.WriteLine($"Action #{Count} took {SW.Elapsed.TotalMilliseconds}ms");
            SW.Reset();
        }
    }
}
