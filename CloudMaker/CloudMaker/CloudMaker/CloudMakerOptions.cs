using System;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class CloudMakerOptions
    {
        public Func<int, int, RectanglePacker> PackerAlg { get; }
        public int MinFontSize { get; }
        public int MaxFontSize { get; }

        public CloudMakerOptions(int minSize, int maxSize, Func<int, int, RectanglePacker> packerAlg)
        {
            MinFontSize = minSize;
            MaxFontSize = maxSize;
            PackerAlg = packerAlg;
        }
    }
}
