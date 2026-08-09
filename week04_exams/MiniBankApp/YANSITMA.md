# Proje Yansıtma Raporu

1. **Encapsulation (Kapsülleme):** 
   `Account` sınıfındaki bakiye bilgisi `private decimal _balance` alanında saklanmış ve dışarıya sadece okuma yetkisi veren `Balance` get özelliğine açılmıştır. Bakiye değişiklikleri yalnızca iş kurallarından geçen `Deposit` ve `Withdraw` metotları aracılığıyla gerçekleştirilir.

2. **Polymorphism (Çok Biçimlilik):** 
   `BankService.PrintInterestReport` içinde her hesap nesnesinin `CalculateInterest()` metodu çağrılmıştır. `if (acc is CheckingAccount)` gibi tip kontrolleri yazılmadan, her hesap nesnesi kendi faiz hesabını yürütmüştür.

3. **Interface Kullanımının Kazancı:** 
   `BankService`, doğrudan nesne örneklerine değil `IRepository` ve `ITransactionLogger` arayüzlerine bağlıdır. Veri saklama veya loglama yöntemi değiştiğinde servis koduna dokunulması gerekmez.

4. **Yeni Özellik Eklerken Yüzey Etkisi:** 
   Sisteme yeni bir hesap türü veya iş kuralı ekleneceğinde `BankService` soyut `Account` sınıfı üzerinden çalıştığı için ana servis kodunda hiçbir değişiklik yapılmaz.