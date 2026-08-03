namespace Odev39_Constructor_FlightTicket.Models
{
    public class FlightTicket
    {
        // Auto-property'ler
        public string PassengerName { get; set; }
        public string FlightCode { get; set; }
        public string SeatClass { get; set; }
        public decimal Price { get; set; }

        // 1. Constructor: Yolcu Adı, Uçuş Kodu ve Fiyat zorunlu. Kabin sınıfı varsayılan "Economy"
        public FlightTicket(string passengerName, string flightCode, decimal price)
        {
            PassengerName = passengerName;
            FlightCode = flightCode;
            Price = price;
            SeatClass = "Economy"; // Varsayılan sınıf
        }

        // 2. Constructor Overloading: Tüm parametreler (Kabin sınıfı dahil) birlikte alınır 
        public FlightTicket(string passengerName, string flightCode, decimal price, string seatClass)
        {
            PassengerName = passengerName;
            FlightCode = flightCode;
            Price = price;
            SeatClass = seatClass;
        }
    }
}