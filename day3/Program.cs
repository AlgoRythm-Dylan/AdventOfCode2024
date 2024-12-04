using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
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
        static void PartTwo()
        {
            var mulRegex = new Regex("mul\\([0-9]+,[0-9]+\\)");
            var doRegex = new Regex("do\\(\\)");
            var dontRegex = new Regex("don't\\(\\)");
            List<Instruction> instructions = new();
            var text = File.ReadAllText("input.txt");
            foreach (var match in mulRegex.EnumerateMatches(text))
            {
                instructions.Add(new Instruction(InstructionType.Mul,
                                 (uint)match.Index,
                                 (uint)match.Length));
            }
            foreach (var match in doRegex.EnumerateMatches(text))
            {
                instructions.Add(new Instruction(InstructionType.Do,
                                 (uint)match.Index,
                                 (uint)match.Length));
            }
            foreach (var match in dontRegex.EnumerateMatches(text))
            {
                instructions.Add(new Instruction(InstructionType.Dont,
                                 (uint)match.Index,
                                 (uint)match.Length));
            }
            var orderedInstructions = instructions.OrderBy(item => item.Index).ToList();
            bool countingEnabled = true;
            uint total = 0;
            foreach(var instruction in orderedInstructions)
            {
                if (instruction.Type == InstructionType.Do)
                {
                    countingEnabled = true;
                }
                else if (instruction.Type == InstructionType.Dont)
                {
                    countingEnabled = false;
                }
                else if(instruction.Type == InstructionType.Mul && countingEnabled)
                {
                    var math = text.Substring((int)instruction.Index, (int)instruction.Length);
                    var split = math.Split(',');
                    var lhs = int.Parse(split[0].Replace("mul(", ""));
                    var rhs = int.Parse(split[1].Replace(")", ""));
                    total += (uint)lhs * (uint)rhs;
                }
            }
            Console.WriteLine($"Total of muls with enable/disable: {total}");
        }
    }
}
