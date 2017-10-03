using System.Collections.Generic;
using System.Linq;

namespace SeleniumProject.Helpers
{
    public class Compare
    {
        public static bool CompareLists<T>(List<T> list)
        {
            var sortList = list.GetRange(0, list.Count);
            sortList.Sort();
            return sortList.SequenceEqual(sortList);
        }
        
        // Вернуть больший размер в пикселях
        public static string CompareSizeinPix(string first, string second)
        {
            return Parse.ParseSizeInPix(first) > Parse.ParseSizeInPix(second) ? first : second;
        }
    }
}