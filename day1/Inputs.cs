namespace day1
{
    internal class Inputs
    {
        public int[] LeftColumn = new int[1000];
        public int[] RightColumn = new int[1000];
        public static Inputs ReadAndSort(string FileName)
        {
            Inputs inputs = new Inputs();
            uint index = 0;
            using (var fileStream = File.OpenRead(FileName))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string? line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        int firstSpaceLocation = line.IndexOf(' ');
                        inputs.LeftColumn[index] = int.Parse(line.Substring(0, firstSpaceLocation));
                        inputs.RightColumn[index] = int.Parse(line.Substring(firstSpaceLocation + 2));
                        index++;
                    }
                }
            }

            Array.Sort(inputs.LeftColumn);
            Array.Sort(inputs.RightColumn);

            return inputs;
        }
    }
}
