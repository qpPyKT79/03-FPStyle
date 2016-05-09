using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudMaker.Filters
{
    public class BoringWordsFilter
    {
        private HashSet<string> BoringWords { get; }
        public List<string> FilterWords(IEnumerable<string> words) => words.Where(NotBoring).ToList();

        public BoringWordsFilter()
        {
            BoringWords = new HashSet<string>(File.ReadAllText("BoringWords.txt").Split('\n').Select(word => word.Replace("\r", "")));
        }

        private bool NotBoring(string word) => !BoringWords.Contains(word);
    }
}