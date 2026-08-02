namespace Odev28_Constructor_Apartment.Models
{
    public class Apartment
    {
        // Auto-property'ler
        public int ApartmentNo { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public decimal RentPrice { get; set; }

        // 1. Constructor: Daire No ve Kat zorunlu, Oda Sayısı varsayılan 2
        public Apartment(int apartmentNo, int floor)
        {
            ApartmentNo = apartmentNo;
            Floor = floor;
            RoomCount = 2; // Varsayılan oda sayısı
        }

        // 2. Constructor Overloading: Daire No, Kat ve Oda Sayısı birlikte alınır 
        public Apartment(int apartmentNo, int floor, int roomCount)
        {
            ApartmentNo = apartmentNo;
            Floor = floor;
            RoomCount = roomCount;
        }
    }
}