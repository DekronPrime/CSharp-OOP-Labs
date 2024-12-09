using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class JournalList : IEnumerable<Journal>
    {
        private List<Journal> journals = new List<Journal>();

        public void Add(Journal journal)
        {
            journals.Add(journal);
        }

        public IEnumerator<Journal> GetEnumerator()
        {
            return journals.OrderByDescending(j => j.SalesRating).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
