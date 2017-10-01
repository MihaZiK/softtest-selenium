using System.Collections.Generic;
using System.Linq;

namespace SeleniumProject.Helpers
{
    public class CompareHelper
    {
        public static bool CompareLists<T>(List<T> list)
        {
            var sortList = list.GetRange(0, list.Count);
            sortList.Sort();
            return sortList.SequenceEqual(sortList);
        }
    }
}