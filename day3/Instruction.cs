namespace day3
{
    public enum InstructionType
    {
        Mul,
        Do,
        Dont
    }
    internal class Instruction
    {
        public InstructionType Type;
        public uint Index, Length;
        public Instruction(InstructionType type, uint index, uint length)
        {
            Type = type;
            Index = index;
            Length = length;
        }
    }
}
