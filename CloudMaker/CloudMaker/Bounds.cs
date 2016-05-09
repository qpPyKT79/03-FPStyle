using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMaker
{
    public class Bounds
    {
        public float Width { get; }
        public float Height { get; }

        public Bounds(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}
