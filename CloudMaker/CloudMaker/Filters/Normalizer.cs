using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace CloudMaker.Filters
{
    public class Normalizer
    {
        public List<string> FilterWords(IEnumerable<string> words) => Normalize(words).Where(word => !string.IsNullOrEmpty(word)).ToList();

        private IEnumerable<string> Normalize(IEnumerable<string> words)
        {
            var newWords = new List<string>();
            using (Hunspell hunspell = new Hunspell("en_us.aff", "en_us.dic"))
                foreach (var word in words)
                    newWords.Add(hunspell.Stem(word).FirstOrDefault());
            return newWords;
        }
    }
}
