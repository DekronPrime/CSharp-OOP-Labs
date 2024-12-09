using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Journal : IComparable<Journal>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Pages { get; set; }
        public int SalesRating { get; set; }

        public Journal(string name, double price, int pages, int salesRating)
        {
            Name = name;
            Price = price;
            Pages = pages;
            SalesRating = salesRating;
        }

        public int CompareTo(Journal? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name}: Ціна = {Price}, Сторінок = {Pages}, Рейтинг = {SalesRating}";
        }
    }
}
