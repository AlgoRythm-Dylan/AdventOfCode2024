namespace day4
{
    internal class Board
    {
        public string Cells;
        public int Width { get; private set; } = 0;
        public int Height { get; private set; } = 0;
        public Board(string cells)
        {
            Cells = cells;
            ParseDimensions();
        }
        private void ParseDimensions()
        {
            Width = 0;
            Height = 0;

            foreach (var character in Cells)
            {
                if (character == '\n')
                {
                    Height++;
                }
                else if (Height == 0)
                {
                    // Count characters in the first row to determine Width
                    Width++;
                }
            }
        }
        public char At(int x, int y)
        {
            return Cells[x + ((Width + 1) * y)];
        }
    }
}
