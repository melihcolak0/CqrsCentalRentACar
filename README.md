# 🚗 ASP.NET Core 9.0 ve CQRS ile Cental Rent A Car Sitesi
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım onuncu proje olan ASP.NET Core Web App ile Cental Rent A Car Sitesi projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu proje, ASP.NET Core 9.0 ve CQRS (Command Query Responsibility Segregation) mimarisi kullanılarak geliştirilmiş modern bir araç kiralama destek ve öneri platformudur. Proje, tek katmanlı bir yapıda geliştirilmiş olsa da folder structure prensiplerine uygun bir dosya düzeni oluşturulmuş, böylece temiz kod, anlaşılabilirlik ve genişletilebilirlik sağlanmıştır.

Arka planda MS SQL Server üzerinde ilişkisel tablolar tasarlanmış ve Araçlar, Rezervasyonlar, Kullanıcılar gibi temel entity’ler için dinamik veri yapıları oluşturulmuştur. Bu sayede proje sadece bir demo değil, gerçek bir sektörel uygulamaya dönüştürülebilecek nitelikte güçlü bir temel kazanmıştır.

---

### 🔹 Ana Özellikler
1️⃣ ViewComponent Yapısı
- Proje içerisinde tekrar eden UI parçaları (araç önerileri, yakıt fiyatları, chatbot alanı vb.) ViewComponent kullanılarak geliştirildi.
- Bu sayede yeniden kullanılabilirlik sağlandı ve bakım kolaylaştırıldı.

2️⃣ Yapay Zekâ ile Çeviri (Hugging Face – Helsinki NLP)
- Kullanıcılar, Türkçe ↔ İngilizce çift yönlü otomatik çeviri yapabilmektedir.
- Hugging Face’in Helsinki NLP modeli entegre edilerek gerçek zamanlı çeviri desteği sağlandı.

3️⃣ RapidAPI Entegrasyonları
- ⛽ Yakıt Fiyatları (Türkiye) → Kullanıcılar farklı şehirlerdeki benzin, motorin ve LPG fiyatlarını görüntüleyebilir. Bu özellik:
Ana sayfadaki maliyet hesaplama modülünde
Admin panelindeki Dashboard ekranında kullanıldı.
- ✈️ Havalimanları Listesi (Türkiye) → Tüm havalimanları dinamik olarak çekilip ana sayfada listelendi.
- 📏 Havalimanları Arası Mesafe Hesaplama → Ana sayfada seçilen iki havalimanı arasındaki mesafe hesaplanarak kullanıcıya sunuldu.
- 🤖 Chatbot (Bize Ulaşın) → Müşterinin iletişim formundan gönderdiği mesajlar AI destekli chatbot tarafından işleniyor ve otomatik mail yanıtı oluşturuluyor.

4️⃣ Araç Öneri Asistanı
- Kullanıcılar, tek bir soru sorarak (ör. “4 kişilik aile için uygun araç önerir misin?”) kişiselleştirilmiş araç tavsiyesi alabiliyor.
- Asistan, kullanıcı ihtiyacını analiz ederek SUV, sedan, MPV veya ekonomik sınıf gibi uygun alternatifler öneriyor.

---

### 🎯 Projenin Amacı
Bu projeyi geliştirirken hedefim, ASP.NET Core ve CQRS mimarisi kullanarak modern, sürdürülebilir ve sektörel ihtiyaçlara uygun bir veri paneli geliştirme konusunda deneyim kazanmaktı.
- 🧩 CQRS yapısıyla okuma (query) ve yazma (command) işlemlerini ayırarak kodun okunabilirliğini ve yönetilebilirliğini artırdım.
- 📊 Gerçek API verileri (yakıt fiyatları, havalimanları, mesafe hesaplama) ile dinamik veri entegrasyonu sağladım.
- 🤖 Hugging Face ve RapidAPI chatbot servisleriyle AI destekli kullanıcı deneyimi geliştirdim.<br>
Projenin bazı eksikleri olsa da, bu süreçte edindiğim bilgi ve deneyimler sayesinde endüstriyel projelere daha hazırlıklı hale geldim.

Bu projeyi geliştirirken amacım, ASP.NET Core ve CQRS teknolojileriyle modern bir veri paneli geliştirme konusunda kendimi ilerletmek ve sektörel projelere hazır hale gelmekti. Bu sebeple projenin eksikleri olabilir.

---

### 🚀 Kullandığım Teknolojiler
- 💻 ASP.NET Core 9.0 → Projenin backend kısmı, modern .NET Core mimarisiyle geliştirildi.
- 🗂 CQRS (Command Query Responsibility Segregation) → Okuma (Query) ve yazma (Command) işlemleri ayrıştırıldı, temiz kod ve sürdürülebilirlik sağlandı.
- 📐 Tek Katmanlı Yapı → Tek katman üzerinde klasörler ile ayrılmış dosya düzeni sağlandı.
- 🗄️ MS SQL Server → Entity'ler ve İlişkili Tablolar MS SQL Server üzerinde düzenlendi.
- 🖼 ViewComponent → Tekrarlayan UI parçalarını yönetmek için kullanıldı.
- 🎨 HTML5, CSS3, JavaScript, Bootstrap → Arayüz tasarımı.
- 🌍 Hugging Face – Helsinki NLP → Türkçe ↔ İngilizce otomatik çeviri için kullanıldı.
- 🛢 RapidAPI Entegrasyonları:
- ⛽ Yakıt Fiyatları API → Türkiye’deki benzin, motorin ve LPG fiyatları.
- ✈️ Havalimanları API → Türkiye’deki havalimanlarının listelenmesi.
- 📏 Havalimanları Arası Mesafe API → İki havalimanı arasındaki mesafeyi hesaplama.
- 🤖 Chatbot API (Mesaj Yanıtı) → Müşterilerin sorularını cevaplayan basit yapay zekâ destekli sohbet botu.
- 🚗 Chatbot API (Araç Öneri Asistanı) → Müşterilere araç önerileri yapan araç öneri asistanı.

Projede genel anlamda 2 bölüm bulunmaktadır.<br>
- Ana Sayfa: Burada kullanıcı, araç kiralam sitesinin detaylarını görmektedir. İstediği takdirde uygun araç modeli ve tarihe göre rezervasyonunu yapabilir. Bize Ulaşın bölümünden de firmaya mesaj gönderebilir.
- Admin Paneli: Burada admin tarafından hakkında, rezervasyonlar, arabalar, hava limanları gibi bölümlerin CRUD işlemleri yapılmaktadır. Dashboard bölümünde ise bazı istatistikler yer almaktadır.

---

## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/d28c643325a2737151cc3c62637e55ecd0eafaac/ss2/screencapture-localhost-7100-Default-Index-2025-08-26-13_20_26.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Default-ListAvailableCars-2025-08-26-13_23_08.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Default-VehicleRecommendationAssistant-2025-08-26-13_23_52.png" alt="image alt">
</div>

---

### :triangular_flag_on_post: Yapay Zeka Kullanılan Bölümler
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-08-25%20195856.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-08-25%20231253.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/localhost_7100_Default.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-08-25%20214212.png" alt="image alt">
</div>

---

### :triangular_flag_on_post: Admin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Dashboard-Index-2025-08-26-13_18_24.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-About-Index-2025-08-26-12_50_34.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-About-CreateAbout-2025-08-26-12_52_04.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-About-UpdateAbout-4-2025-08-26-12_52_15.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Booking-Index-2025-08-26-13_08_47.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Car-Index-2025-08-26-13_09_19.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Employee-Index-2025-08-26-13_10_15.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Feature-Index-2025-08-26-13_10_24.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Location-Index-2025-08-26-13_10_40.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Service-Index-2025-08-26-13_10_49.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Slider-Index-2025-08-26-13_10_57.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Testimonial-Index-2025-08-26-13_11_04.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-Message-Index-2025-08-26-13_17_16.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/CqrsCentalRentACar/blob/bc3981f84807765f0a424dfc9dc6ebc0f6036e38/ss/screencapture-localhost-7100-AI-ChatBot-2025-08-26-13_26_42.png" alt="image alt">
</div>
