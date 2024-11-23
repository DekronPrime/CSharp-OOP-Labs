namespace ClassLibrary
{
    public class Result
    {
        private string subjectName;
        private string teacherFullName;
        private bool isExam;
        private int points;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        public string TeacherFullName
        {
            get { return teacherFullName; }
            set { teacherFullName = value; }
        }

        public bool IsExam
        {
            get { return isExam; }
            set { isExam = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value >= 0 && value <= 100 ? value : throw new ArgumentException("Оцінка має бути в діапазоні від 0 до 100."); }
        }

        public Result()
        {
            SubjectName = string.Empty;
            TeacherFullName = string.Empty;
            IsExam = false;
            Points = 0;
        }

        public Result(string subjectName, string teacherFullName)
        {
            SubjectName = subjectName;
            TeacherFullName = teacherFullName;
            IsExam = false;
            Points = 0;
        }

        public Result(string subjectName, string teacherFullName, int points)
        {
            SubjectName = subjectName;
            TeacherFullName = teacherFullName;
            IsExam = false;
            Points = points;
        }

        public Result(string subjectName, string teacherFullName, bool isExam)
        {
            SubjectName = subjectName;
            TeacherFullName = teacherFullName;
            IsExam = isExam;
            Points = 0;
        }

        public Result(string subjectName, string teacherFullName, bool isExam, int points)
        {
            SubjectName = subjectName;
            TeacherFullName = teacherFullName;
            IsExam = isExam;
            Points = points;
        }

        public Result(Result other)
        {
            SubjectName = other.SubjectName;
            TeacherFullName = other.TeacherFullName;
            IsExam = other.IsExam;
            Points = other.Points;
        }

        public override string ToString()
        {
            return $"Предмет: {SubjectName}, Викладач: {TeacherFullName}, Екзамен: {IsExam}, Оцінка: {Points}/100";
        }
    }
}
