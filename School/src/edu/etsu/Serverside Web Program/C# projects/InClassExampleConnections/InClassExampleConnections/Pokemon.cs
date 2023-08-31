

namespace InClassExampleConnections
{

    public class Pokemon
    {

        public int? DexNum { get; set; }
        public string? Name { get; set; } = string.Empty;
        public int? Level { get; set; }
        public string? PrimaryType { get; set; } = string.Empty;
        public string? SecondaryType { get; set; }
        public Pokemon(int dexnum, string name, int level, string primarytype, string? secondarytype)
        {
           
            DexNum = dexnum;
            Name = name;
            Level = level;
            PrimaryType = primarytype;
            SecondaryType = secondarytype;
        }

        public override string ToString()
        {
            return 
                $"DexNumber: {DexNum}\n" +
                $"Name: {Name}\n" +
                $"Level: {Level}\n" +
                $"PrimaryType: {PrimaryType}\n" +
                $"SecondaryType: {SecondaryType}";
        }
    }
}
