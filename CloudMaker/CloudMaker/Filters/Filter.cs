using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker.Filters
{
    public class Filter
    {
        public List<string> ReadAndFilterInputData(
            Func<string, List<string>> readFunc,
            List<Func<List<string>, List<string>>> filters,
            string sourceName)
        {
            var filteredWords = readFunc(sourceName);
            return filters.Aggregate(filteredWords, (current, filter) => filter(current));
        }
    }
}
