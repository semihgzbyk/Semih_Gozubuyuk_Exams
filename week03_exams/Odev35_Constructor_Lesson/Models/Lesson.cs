namespace Odev35_Constructor_Lesson.Models
{
    public class Lesson
    {
        // Auto-property'ler
        public string LessonCode { get; set; }
        public string LessonName { get; set; }
        public string Instructor { get; set; }
        public int Credit { get; set; }
        public bool IsMandatory { get; set; }

        // 1. Constructor: Ders Kodu, Adı ve Öğretmen zorunlu. Kredi varsayılan 3.
        public Lesson(string lessonCode, string lessonName, string instructor)
        {
            LessonCode = lessonCode;
            LessonName = lessonName;
            Instructor = instructor;
            Credit = 3; // Varsayılan kredi
        }

        // 2. Constructor Overloading: Tüm parametreler birlikte alınır (this kullanılmıyor)
        public Lesson(string lessonCode, string lessonName, string instructor, int credit, bool isMandatory)
        {
            LessonCode = lessonCode;
            LessonName = lessonName;
            Instructor = instructor;
            Credit = credit;
            IsMandatory = isMandatory;
        }
    }
}