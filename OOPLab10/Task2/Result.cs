using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Result
    {
        public string SubjectName { get; set; }
        public string TeacherFullName { get; set; }
        public bool IsExam { get; set; }
        public int Points { get; set; }

        public Result(string subjectName, string teacherFullName, bool isExam, int points)
        {
            SubjectName = subjectName;
            TeacherFullName = teacherFullName;
            IsExam = isExam;
            Points = points;
        }

        public override string ToString()
        {
            return $"Предмет: {SubjectName}, Викладач: {TeacherFullName}, Екзамен: {IsExam}, Оцінка: {Points}/100";
        }
    }
}
