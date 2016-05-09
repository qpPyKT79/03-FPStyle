using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUI;

namespace UI
{
    public class CUI
    {
        private static readonly HashSet<string> Algs =new HashSet<string> { "arevalo", "simple" };
        private static readonly HashSet<string> Filters = new HashSet<string> { "Normalizer", "BoringWords" };
        public string GetCloudMakerAlg()
        {
            Console.WriteLine();
            Console.WriteLine("Set algorithm of making cloud, members are:");
            Console.WriteLine(string.Join(" ", Algs));
            Console.WriteLine("if u dont want to set up this field. just set an empty string");
            var cloudMakerAlg = Console.ReadLine();
            if (Algs.Contains(cloudMakerAlg))
                return cloudMakerAlg;
            else
                ErrorMsg("Errors in input, simple alg were choosen");
            return "simple";
        }

        public List<string> GetFilters()
        {
            Console.WriteLine();
            Console.WriteLine("Choose filters (u can choose many of them, separate filters with space), members are:");
            Console.WriteLine(string.Join(" ", Filters));
            Console.WriteLine("if u dont want to set up this field. just set an empty string");
            var input = Console.ReadLine().Split(' ').ToList();
            if (input.Select(f => Filters.Contains(f)).All(x => x))
                return input;
            else
                ErrorMsg("Errors in input, no filters were choosen");
            return new List<string>();
        }

        private void ErrorMsg(string errMsg)
        {
            Console.WriteLine(errMsg);
        }

        public string GetName()
        {
            Console.WriteLine("Plese type Filename");
            return Console.ReadLine();
        }

        public Tuple<int, int> GetSize()
        {
            var minSize = 5;
            var maxSize = 25;
            Console.WriteLine();
            Console.WriteLine("Font size is not set or minSize > maxSize");
            Console.WriteLine("Note! minSIze must be >= 5 and maxSize <= 25");
            Console.WriteLine("Write u min and max size separated with whitespace");
            Console.WriteLine();
            Console.WriteLine("if u dont want to set up font size, just set an empty string");
            var sizeString = Console.ReadLine();
            var sizeNums = string.IsNullOrEmpty(sizeString) ? null : sizeString.Split(' ').Select(int.Parse).ToArray();
            if (sizeNums?.Length < 2)
                GetSize();
            else
            {
                if (sizeNums == null)
                    return new Tuple<int, int>(5, 25);
                minSize = sizeNums[0];
                maxSize = sizeNums[1];
            }
            return minSize >= 5 && maxSize <= 25 && minSize != maxSize ? new Tuple<int, int>(minSize, maxSize) : GetSize();
        }

        public Color[] GetColors()
        {
            Console.WriteLine();
            Console.WriteLine("Write colors separated with whitespase (if u dont want to set up colors, just set an empty string)");
            var stringColors = Console.ReadLine();
            return string.IsNullOrWhiteSpace(stringColors) ? null : stringColors.Split(' ').Select(Color.FromName).ToArray();
        }

        public UiSettings GetSettings() => new UiSettings(GetName(), GetFilters(), GetCloudMakerAlg(), GetSize(), GetColors());
    }
}
