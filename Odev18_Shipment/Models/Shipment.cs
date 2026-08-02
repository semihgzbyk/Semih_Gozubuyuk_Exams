using System;

namespace Odev18_Shipment.Models
{
    public class Shipment
    {
        // Auto-property'ler
        public string TrackingNumber { get; set; } = "";
        public string SenderName { get; set; } = "";
        public string ReceiverName { get; set; } = "";
        public DateTime ShipDate { get; set; }
        public double WeightKg { get; set; }
    }
}