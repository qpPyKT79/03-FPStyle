using System.Collections.Generic;
using System.Linq;

namespace CloudMaker.Extensions
{
    public static class FrequenciesSetter
    {
        public static List<CloudTag> SetFrequences(this List<string> source) => source.GroupBy(word => word)
            .OrderByDescending(word => word.Count())
            .Select(words => new CloudTag(words.First()).SetFrequency(words.Count())).Take(100).ToList();
    }
}