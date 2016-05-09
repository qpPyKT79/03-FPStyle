using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.Readers
{
    public class TextFileReader
    {
        private readonly static HashSet<char> Symbols = new HashSet<char>
        {
            ',','.','!','&','?','\"','\\','/','<','>',':',';','-','+','*','`','^','~','%','#','@',' '
        };
        public List<string> ReadFromFile(string sourceName) =>
            File.Exists(sourceName)
                ? File.ReadAllText(sourceName)
                    .Split(' ', '\n')
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .Select(word => word.Replace("\r", "").TrimStart(Symbols.ToArray()).TrimEnd(Symbols.ToArray()).ToLower())
                    .ToList()
                : new List<string>();
    }
}
