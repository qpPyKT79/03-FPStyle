using System.Collections.Generic;

namespace CloudMaker.Extensions
{
    public static class BoundsGetter
    {
        public static Bounds GetBounds(this IEnumerable<CloudTag> tags)
        {
            var width = 0f;
            var height = 0f;
            foreach (var tag in tags)
            {
                if (width <= tag.X + tag.TagSize.Width)
                    width = tag.X + (int)tag.TagSize.Width + 1;
                if (height <= tag.Y + tag.TagSize.Height)
                    height = tag.Y + (int)tag.TagSize.Height + 1;
            }
            return new Bounds(width, height);
        }
    }
}