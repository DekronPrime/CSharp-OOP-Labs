using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab5
{
    public enum FinalControlType
    {
        Exam,
        Test,
        None
    }

    public struct Subject
    {
        public string? Name { get; set; }
        public string? Lecturer { get; set; }
        public string? GroupName { get; set; }
        public int StudentsCount { get; set; }
        public FinalControlType FinalControl { get; set; }
        public bool HasCourseWork { get; set; }
        public string? Specialty { get; set; }
        public int Semester { get; set; }

        public override string ToString()
        {
            return $"Дисципліна: {Name},\nВикладач: {Lecturer},\nГрупа: {GroupName},\n" +
                   $"Кількість студентів: {StudentsCount},\nТип контролю: {FinalControl},\n" +
                   $"Курсова робота: {(HasCourseWork ? "є" : "немає")},\nСпеціальність: {Specialty},\n" +
                   $"Семестр: {Semester}";
        }
    }
}
