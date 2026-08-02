namespace Odev25_Constructor_Student.Models
{
    public class Student
    {
        // Auto-property'ler
        public string StudentNumber { get; set; } = "";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; } = "";

        // Ad ve soyad parametrelerini zorunlu kılan Constructor
        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}