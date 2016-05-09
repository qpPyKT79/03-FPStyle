using System;
using System.Collections.Generic;
using System.Linq;
using CloudMaker.Extensions;
using Microsoft.Xna.Framework;
using Nuclex.Game.Packing;

namespace CloudMaker.CloudMaker
{
    public class CloudMaker
    {
        public List<CloudTag> CreateCloud(List<string> inputWords, int minFontSize, int maxFontSize,
            Func<int, int, RectanglePacker> packer)
            =>
                SetLocatons(inputWords.SetFrequences().SetSize(minFontSize, maxFontSize), packer);

        private List<CloudTag> SetLocatons(List<CloudTag> tags, Func<int, int, RectanglePacker> packer)
        {
            var maxWidth = getMaxWidth(tags);
            var retangleField = packer((int)maxWidth, (int)maxWidth);
            Point placement;
            return tags.Select(tag =>
            {
                placement = retangleField.Pack((int)tag.TagSize.Width, (int)tag.TagSize.Height);
                return tag.SetLocation(placement.X, placement.Y);
            }).ToList();
        }

        private float getMaxWidth(List<CloudTag> tags)
            => (float) Math.Log(tags.Count, 2)*tags.Max(tag => tag.TagSize.Width);
    }
}