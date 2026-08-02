namespace Odev34_Constructor_Invoice.Models
{
    public class Invoice
    {
        // Auto-property'ler
        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxRate { get; set; }

        // Toplam tutarı hesaplayan salt okunur (read-only) property
        public decimal TotalAmount
        {
            get
            {
                return Amount + (Amount * TaxRate);
            }
        }

        // 1. Constructor: Fatura No, Müşteri Adı ve Tutar zorunlu. KDV varsayılan 0.20 (%20)
        public Invoice(string invoiceNo, string customerName, decimal amount)
        {
            InvoiceNo = invoiceNo;
            CustomerName = customerName;
            Amount = amount;
            TaxRate = 0.20m; // Varsayılan %20 KDV
        }

        // 2. Constructor Overloading: Tüm parametreler (KDV dahil) birlikte alınır
        public Invoice(string invoiceNo, string customerName, decimal amount, decimal taxRate)
        {
            InvoiceNo = invoiceNo;
            CustomerName = customerName;
            Amount = amount;
            TaxRate = taxRate;
        }
    }
}