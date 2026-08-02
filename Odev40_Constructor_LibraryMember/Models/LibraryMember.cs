using System;

namespace Odev40_Constructor_LibraryMember.Models
{
    public class LibraryMember
    {
        // Auto-property'ler
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string MembershipType { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int BorrowedBookCount { get; set; }

        // 1. Constructor: Üye Id, Ad-Soyad ve Kayıt Tarihi zorunlu. Üyelik tipi varsayılan "Standard"
        public LibraryMember(int memberId, string fullName, DateTime registrationDate)
        {
            MemberId = memberId;
            FullName = fullName;
            RegistrationDate = registrationDate;
            MembershipType = "Standard"; // Varsayılan üyelik tipi
        }

        // 2. Constructor Overloading: Tüm parametreler (Üyelik tipi dahil) birlikte alınır
        public LibraryMember(int memberId, string fullName, DateTime registrationDate, string membershipType)
        {
            MemberId = memberId;
            FullName = fullName;
            RegistrationDate = registrationDate;
            MembershipType = membershipType;
        }
    }
}