namespace day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartOne();
        }
        static void PartOne()
        {
            var board = new Board(File.ReadAllText("input.txt"));
            //var count = Regex.Count(board.Cells, "XMAS");
            Console.WriteLine($"Matches found: {Search(board, "XMAS") + Search(board, "SAMX")}");
        }
        static int Search(Board board, string term)
        {
            return SearchHorizontally(board, term) +
                   SearchVertically(board, term) +
                   SearchDiagonallyRight(board, term) +
                   SearchDiagonallyLeft(board, term);
        }
        static int SearchHorizontally(Board board, string term)
        {
            int matches = 0;
            for(int y = 0; y < board.Height; y++)
            {
                for(int x = 0; x < board.Width - (term.Length - 1); x++)
                {
                    int matchIndex = 0;
                    for(int i = 0; i < term.Length; i++)
                    {
                        if (board.At(x + i, y) == term[i])
                        {
                            matchIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if(matchIndex == term.Length)
                    {
                        matches++;
                    }
                }
            }
            return matches;
        }
        static int SearchVertically(Board board, string term)
        {
            int matches = 0;
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height - (term.Length - 1); y++)
                {
                    int matchIndex = 0;
                    for (int i = 0; i < term.Length; i++)
                    {
                        if (board.At(x + i, y) == term[i])
                        {
                            matchIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (matchIndex == term.Length)
                    {
                        matches++;
                    }
                }
            }
            return matches;
        }
        static int SearchDiagonallyRight(Board board, string term)
        {
            int matches = 0;
            for (int x = 0; x < board.Width - (term.Length - 1); x++)
            {
                for (int y = 0; y < board.Height - (term.Length - 1); y++)
                {
                    int matchIndex = 0;
                    for(int i = 0; i < term.Length; i++)
                    {
                        if (board.At(x + i, y + i) == term[i])
                        {
                            matchIndex++;
                        }
                    }
                    if(matchIndex == term.Length)
                    {
                        matches++;
                    }
                }
            }
            return matches;
        }
        static int SearchDiagonallyLeft(Board board, string term)
        {
            int matches = 0;
            for (int x = term.Length; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height - (term.Length - 1); y++)
                {
                    int matchIndex = 0;
                    for (int i = 0; i < term.Length; i++)
                    {
                        if (board.At(x - i, y + i) == term[i])
                        {
                            matchIndex++;
                        }
                    }
                    if (matchIndex == term.Length)
                    {
                        matches++;
                    }
                }
            }
            return matches;
        }
    }
}
