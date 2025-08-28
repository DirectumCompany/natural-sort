using System.Collections.Generic;
using System.Globalization;

namespace NaturalSort
{
    public class NaturalStringComparer : IComparer<string>
    {
        private readonly CompareInfo _compareInfo;

        public NaturalStringComparer(CompareInfo compareInfo)
        {
            _compareInfo = compareInfo;
        }

        public int Compare(string a, string b)
        {
            int indexA = 0, indexB = 0;
            int lengthA = a.Length, lengthB = b.Length;

            while (indexA < lengthA && indexB < lengthB)
            {
                string chunkA = GetNextChunk(a, ref indexA);
                string chunkB = GetNextChunk(b, ref indexB);

                bool isNumericA = int.TryParse(chunkA, out int numA);
                bool isNumericB = int.TryParse(chunkB, out int numB);

                if (isNumericA && isNumericB)
                {
                    int cmp = numA.CompareTo(numB);
                    if (cmp != 0)
                        return cmp;
                }
                else
                {
                    int cmp = _compareInfo.Compare(chunkA, chunkB, CompareOptions.IgnoreCase);
                    if (cmp != 0)
                        return cmp;
                }
            }

            return lengthA - lengthB;
        }

        private static string GetNextChunk(string s, ref int index)
        {
            if (index >= s.Length)
                return "";

            char currentChar = s[index];
            bool isDigit = char.IsDigit(currentChar);
            int startIndex = index;

            while (index < s.Length && char.IsDigit(s[index]) == isDigit)
            {
                index++;
            }

            return s.Substring(startIndex, index - startIndex);
        }
    }
}