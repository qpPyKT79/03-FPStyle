using System;
using System.Drawing;

namespace CloudMaker
{
    public class CloudTag : IComparable
    {
        public SizeF TagSize { get; }
        public float Frequency { get; }
        public float X { get; }
        public float Y { get; }
        public string Word { get; }

        private CloudTag(SizeF size, float frequency, string word, float x, float y)
        {
            TagSize = size;
            Frequency = frequency;
            Word = word;
            X = x;
            Y = y;
        }

        public CloudTag(string word)
        {
            Word = word;
        }

        public CloudTag SetSize(SizeF newSize) => new CloudTag(newSize, Frequency, Word, X, Y);
        public CloudTag SetFrequency(float newFrequency) => new CloudTag(TagSize, newFrequency, Word, X, Y);
        public CloudTag SetLocation(float x, float y) => new CloudTag(TagSize, Frequency, Word, x, y);
        public override bool Equals(object obj)
        {
            var tagObj = obj as CloudTag;
            if (tagObj == null)
                return false;
            return Frequency.Equals(tagObj.Frequency) && TagSize.Equals(tagObj.TagSize) && Word.Equals(tagObj.Word);
        }

        public override int GetHashCode() => (X + Y).GetHashCode() + Word.GetHashCode() + TagSize.GetHashCode() + Frequency.GetHashCode();

        public int CompareTo(object obj)
        {
            if (Frequency > ((CloudTag)obj).Frequency) return 1;
            if (Frequency < ((CloudTag)obj).Frequency) return -1;
            return 0;
        }
    }
}
