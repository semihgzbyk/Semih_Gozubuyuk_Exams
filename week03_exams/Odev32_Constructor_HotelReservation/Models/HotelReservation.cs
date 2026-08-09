using System;

namespace Odev32_Constructor_HotelReservation.Models
{
    public class HotelReservation
    {
        // Auto-property'ler
        public string GuestName { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public int NightCount { get; set; }
        public decimal TotalPrice { get; set; }

        // 1. Constructor: Misafir Adı, Oda No ve Giriş Tarihi zorunlu, Gece Sayısı varsayılan 1
        public HotelReservation(string guestName, int roomNumber, DateTime checkInDate)
        {
            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            NightCount = 1; // Varsayılan gece sayısı
        }

        // 2. Constructor Overloading: Zorunlu parametrelere ek olarak Gece Sayısı birlikte alınır
        public HotelReservation(string guestName, int roomNumber, DateTime checkInDate, int nightCount)
        {
            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkInDate;
            NightCount = nightCount;
        }
    }
}