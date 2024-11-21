using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab6
{
    internal class Student
    {
        private string fullName;
        private string group;
        private int courseNumber;
        private Result[] results;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public int CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value > 0 ? value : throw new ArgumentException("Номер курсу має бути позитивним."); }
        }

        public Result[] Results
        {
            get { return results; }
            set { results = value; }
        }

        public Student() { 
            FullName = string.Empty;
            Group = string.Empty;
            CourseNumber = 1;
            Results = [];
        }

        public Student(string fullName, string group)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = 1;
            Results = [];
        }

        public Student(string fullName, string group, Result[] results)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = 1;
            Results = results;
        }

        public Student(string fullName, string group, int courseNumber)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = [];
        }

        public Student(string fullName, string group, int courseNumber, Result[] results)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = results;
        }

        public Student(Student other)
        {
            FullName = other.FullName;
            Group = other.Group;
            CourseNumber = other.CourseNumber;
            Results = other.Results.Select(r => new Result(r)).ToArray();
        }

        public double GetAveragePoint()
        {
            return Results.Average(r => r.Points);
        }

        public string GetWorstSubject()
        {
            return Results.OrderBy(r => r.Points).First().SubjectName;
        }

        public override string ToString()
        {
            return $"Студент: {FullName},\nГрупа: {Group},\nКурс: {CourseNumber},\nРезультати: [{string.Join(";\n", Results.Select(r => r.ToString()))}]";
        }
    }
}
