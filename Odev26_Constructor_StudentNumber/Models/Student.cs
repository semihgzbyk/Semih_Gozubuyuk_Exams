namespace Odev26_Constructor_StudentNumber.Models
{
    public class Student
    {
        // Auto-property'ler
        public int StudentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Gpa { get; set; }

        // 1. Constructor: Okul numarası henüz tanımlanmamış öğrenciler için
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = 0; // Henüz numara verilmediğini temsil eder
        }

        // 2. Constructor Overloading: Okul numarası ile birlikte kayıt
        public Student(int studentNumber, string firstName, string lastName)
        {
            StudentNumber = studentNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}