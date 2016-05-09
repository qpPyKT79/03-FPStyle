using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CloudMaker.Filters;
using CloudMaker.Readers;
using CloudMaker.Writers;
using CUI;
using Nuclex.Game.Packing;

namespace CloudMaker
{
    public class Provider
    {
        public static readonly Dictionary<string, Func<string, List<string>>> FileReader = new Dictionary
            <string, Func<string, List<string>>>
        {
            {"file", sourceName => new TextFileReader().ReadFromFile(sourceName)}
        };
        public static readonly Dictionary<string, Func<UiSettings>> UiType = new Dictionary<string, Func<UiSettings>>
        {
            {"CUI", () => new CUI.CUI(FilterTypes.Keys.ToList(),Packers.Keys.ToList()).GetSettings()}
        };

        public static readonly Dictionary<string, Action<List<CloudTag>, Color[]>> WriterType = new Dictionary
            <string, Action<List<CloudTag>, Color[]>>
        {
            {"png", (tags, colors) => new ImageWriter().WriteTo(tags, colors, System.Drawing.Imaging.ImageFormat.Png)},
            {"jpeg", (tags, colors) => new ImageWriter().WriteTo(tags, colors, System.Drawing.Imaging.ImageFormat.Jpeg)}
        };

        public static readonly Dictionary<string, Func<List<string>, List<string>>> FilterTypes = new Dictionary
            <string, Func<List<string>, List<string>>>
        {
             {"normalizer", words => new Normalizer().FilterWords(words)},
             {"boringWords", words => new BoringWordsFilter().FilterWords(words)}
        };

        public static readonly Dictionary<string, Func<int, int, RectanglePacker>> Packers = new Dictionary<string, Func<int, int, RectanglePacker>>
        {
            {"simple", (width, height) => new SimpleRectanglePacker(width, height) },
            {"arevalo", (width, height) => new ArevaloRectanglePacker(width, height) }
        };
    }
}
