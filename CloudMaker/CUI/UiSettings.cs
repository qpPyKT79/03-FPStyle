using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUI
{
    public class UiSettings
    {
        public string Filename { get; }
        public IEnumerable<Color> Colors { get; }
        public List<string> Filters { get; }
        public string PackerAlg { get; }
        public int MinFontSize { get; }
        public int MaxFontSize { get; }

        public UiSettings(string filename, List<string> filters, string alg, Tuple<int,int> fontSize, IEnumerable<Color> colors)
        {
            Filename = filename;
            Filters = filters;
            Colors = colors;
            PackerAlg = alg;
            MinFontSize = fontSize.Item1;
            MaxFontSize = fontSize.Item2;
        }
    }
}
