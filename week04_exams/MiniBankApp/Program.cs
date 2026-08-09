using MiniBankApp.Accounts;
using MiniBankApp.Infrastructure;
using MiniBankApp.Interfaces;
using MiniBankApp.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IRepository<Account> accountRepo = new InMemoryAccountRepository();
ITransactionLogger logger = new ConsoleTransactionLogger();

BankService bankService = new BankService(accountRepo, logger);

Console.WriteLine("=== MINIBANK UYGULAMASI BAŞLATILDI ===\n");

// 1. Hesap Açılışları (2 Vadesiz + 1 Vadeli + 1 Premium)
Console.WriteLine("--- 1. Hesap Açılışları ---");
bankService.OpenAccount(new CheckingAccount("ACC101", "Ahmet Yılmaz", initialBalance: 1500m, dailyLimit: 500m));
bankService.OpenAccount(new CheckingAccount("ACC102", "Ayşe Kaya", initialBalance: 2000m, dailyLimit: 1000m));
bankService.OpenAccount(new SavingsAccount("ACC201", "Mehmet Demir", initialBalance: 10000m, termMonths: 6));

// Genişletme A: BankService'e hiç dokunmadan PremiumAccount açıyoruz
bankService.OpenAccount(new PremiumAccount("ACC301", "Zeynep Şahin", initialBalance: 50000m));

// 2. Normal İşlemler
Console.WriteLine("\n--- 2. Para Yatırma ve Çekme İşlemleri ---");
bankService.Deposit("ACC101", 300m);
bankService.Withdraw("ACC101", 200m);

// Premium hesaptan yüksek tutarlı çekim (Limit: 50.000 TL)
bankService.Withdraw("ACC301", 5000m);

// 3. Kural İhlalleri
Console.WriteLine("\n--- 3. Kural İhlal Testleri (Reddedilen İşlemler) ---");
Console.WriteLine("> Test A: Vadesiz hesap günlük limit aşımı:");
bankService.Withdraw("ACC101", 400m);

Console.WriteLine("\n> Test B: Vadeli hesap vadeden önce çekim:");
bankService.Withdraw("ACC201", 1000m);

// 4. Genişletme B: Transfer İşlemleri
Console.WriteLine("\n--- 4. Transfer Testleri ---");
Console.WriteLine("> Başarılı Transfer:");
bankService.TransferFunds("ACC102", "ACC101", 400m);

Console.WriteLine("\n> Başarısız Transfer (Limit engeline takılan çekim):");
bankService.TransferFunds("ACC101", "ACC102", 800m);

// 5. Genişletme C: Faiz Stratejileri Testi
Console.WriteLine("\n--- 5. Faiz Stratejileri Testi (Harici Hesaplayıcılar) ---");
IInterestCalculator simpleCalc = new SimpleInterestCalculator(0.12m);
IInterestCalculator compoundCalc = new CompoundInterestCalculator(0.12m);

decimal testBalance = 10000m;
Console.WriteLine($"10.000 TL Bakiye için Aylık Basit Faiz: {simpleCalc.CalculateMonthly(testBalance):C2}");
Console.WriteLine($"10.000 TL Bakiye için Aylık Bileşik Faiz: {compoundCalc.CalculateMonthly(testBalance):C2}");

// 6. Raporlamalar
bankService.PrintAccountList();
bankService.PrintInterestReport();
bankService.PrintHistory("ACC101");

// 7. Exception Handling
Console.WriteLine("\n--- 6. Hata Yönetimi Testi ---");
try
{
    Console.WriteLine("> Var olmayan hesaptan para çekme:");
    bankService.Withdraw("ACC999", 100m);
}
catch (Exception ex)
{
    Console.WriteLine($"  ⚠️ YAKALANAN HATA: {ex.Message}");
}

Console.WriteLine("\n=== UYGULAMA SONLANDI ===");