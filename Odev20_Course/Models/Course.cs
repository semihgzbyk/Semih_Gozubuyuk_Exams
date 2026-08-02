namespace Odev20_Course.Models
{
    public class Course
    {
        // Auto-property'ler
        public string CourseCode { get; set; } = "";
        public string CourseName { get; set; } = "";
        public string Instructor { get; set; } = "";
        public int Credit { get; set; }
        public bool IsOnline { get; set; }
    }
}