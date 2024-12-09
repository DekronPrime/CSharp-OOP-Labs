using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Student
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public int CourseNumber { get; set; }
        public Result[] Results { get; set; }
        public double MonthlyFee { get; set; }

        public Student(string fullName, string group, int courseNumber, double monthlyFee)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = [];
            MonthlyFee = monthlyFee;
        }

        public Student(string fullName, string group, int courseNumber, Result[] results, double monthlyFee)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = results;
            MonthlyFee = monthlyFee;
        }

        public override string ToString()
        {
            return $"Студент: {FullName}, Група: {Group}, Курс: {CourseNumber}, Вартість: {MonthlyFee:F2} грн";
        }
    }
}
