namespace AdventOfCode
{
    internal class LineReader
    {
        public static IEnumerable<string> Read(string FileName)
        {
            using (var fileStream = File.OpenRead(FileName))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string? line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
    }
}
