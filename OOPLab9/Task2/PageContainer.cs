using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PageComparer : IComparer<Journal>
    {
        public int Compare(Journal? x, Journal? y)
        {
            if (x == null || y == null) return 0;
            return x.Pages.CompareTo(y.Pages);
        }
    }
}
