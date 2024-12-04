using System.Text.RegularExpressions;

namespace day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartOne();
        }
        static void PartOne()
        {
            var regex = new Regex("mul\\([0-9]+,[0-9]+\\)");
            var text = File.ReadAllText("input.txt");
            uint total = 0;
            foreach (var match in regex.EnumerateMatches(text))
            {
                var instruction = text.Substring(match.Index, match.Length);
                var split = instruction.Split(',');
                var lhs = int.Parse(split[0].Replace("mul(", ""));
                var rhs = int.Parse(split[1].Replace(")", ""));
                total += (uint)lhs * (uint)rhs;
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}
