# Proje Yansıtma Raporu

1. **Encapsulation (Kapsülleme):** 
   `Book` sınıfındaki stok kopyaları (`_availableCopies`) ve `Member` sınıfındaki ödünç alınan kitap sayısı doğrudan dışarıdan değiştirilemez. Değişiklikler yalnızca `BorrowOne`, `ReturnOne`, `AddBorrowedBook` ve `RemoveBorrowedBook` gibi kontroller içeren metotlar üzerinden sağlanmıştır.

2. **Polymorphism (Çok Biçimlilik):** 
   `LibraryService` içerisinde üyelerin maksimum kitap alma limitleri veya gecikme cezaları hesaplanırken `if (member is StudentMember)` gibi tip kontrolleri yapılmamıştır. `member.CalculateLateFee(...)` ve `member.MaxBooks` polimorfik olarak çağrılmıştır.

3. **Interface Kullanımının Kazancı:** 
   `LibraryService` doğrudan somut depo veya log sınıflarına değil `IRepository`, `ILoanLogger` ve `ILateFeeCalculator` arayüzlerine bağlıdır. Veri depolama mantığı veya ceza stratejisi değiştiğinde servis kodu etkilenmez.

4. **GuestMember Eklerken Değişen/Değişmeyen Dosyalar:** 
   `GuestMember` eklenirken yalnızca yeni `GuestMember.cs` dosyası oluşturulmuş ve `Program.cs` güncellenmiştir. `LibraryService.cs` dosyasına dokunulmamıştır. Çünkü servis somut üye tiplerine değil, soyut `Member` sınıfına bağlıdır (Open/Closed Principle).