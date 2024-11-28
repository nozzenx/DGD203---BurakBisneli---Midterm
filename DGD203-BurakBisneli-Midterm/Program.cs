using System;
using System.Threading;
Console.WriteLine("Oyun Yükleniyor...");

// Yükleme çubuğu oluştur
int progressBarLength = 30; // Çubuğun uzunluğu
for (int i = 0; i <= progressBarLength; i++)
{
    // Yükleme çubuğunu güncelle
    Console.Write("\r[");
    Console.Write(new string('#', i)); // Doldurulan kısım
    Console.Write(new string('.', progressBarLength - i)); // Kalan kısım
    Console.Write($"] {i * 100 / progressBarLength}%"); // Yüzde bilgisi

    Thread.Sleep(200); // Her adımda bekleme (200ms)
}

// Yükleme tamamlandığında mesaj göster
Console.WriteLine("\nOyun Başlatılıyor!");
Thread.Sleep(2000); // 2 saniye bekle
Console.Clear(); // Ekranı temizle
Console.WriteLine("Oyun Başladı! İyi eğlenceler!"); 