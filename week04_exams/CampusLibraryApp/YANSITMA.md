# Proje Yansıtma Raporu

1. **Encapsulation (Kapsülleme):** 
   `Book` sınıfındaki stok kopyaları (`_availableCopies`) ve `Member` sınıfındaki ödünç alınan kitap sayısı doğrudan dışarıdan değiştirilemez. Değişiklikler yalnızca `BorrowOne`, `ReturnOne`, `AddBorrowedBook` ve `RemoveBorrowedBook` gibi kontroller içeren metotlar üzerinden sağlanmıştır.

2. **Polymorphism (Çok Biçimlilik):** 
   `LibraryService` içerisinde üyelerin maksimum kitap alma limitleri veya gecikme cezaları hesaplanırken `if (member is StudentMember)` gibi tip kontrolleri yapılmamıştır. `member.CalculateLateFee(...)` ve `member.MaxBooks` polimorfik olarak çağrılmıştır.

3. **Interface Kullanımının Kazancı:** 
   `LibraryService` doğrudan somut depo veya log sınıflarına değil `IRepository` ve `ILoanLogger` arayüzlerine bağlıdır. Veri depolama mantığı (örneğin veritabanına geçiş) değiştiğinde servis kodu hiç etkilenmez.

4. **Yeni Özellik Eklerken Yüzey Etkisi:** 
   Sisteme yeni bir üye türü veya ceza hesabı ekleneceğinde `LibraryService` soyut `Member` sınıfı üzerinden çalıştığı için çekirdek kütüphane servisine dokunulması gerekmez.