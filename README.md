# 🚀 ASP.NET Core 9.0 ve CQRS ile Cental Rent A Car Sitesi
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım onuncu proje olan ASP.NET Core Web App ile ental Rent A Car Sitesi projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu proje, ASP.NET Core 9.0 ve CQRS (Command Query Responsibility Segregation) mimarisi kullanılarak geliştirilmiş bir araç kiralama destek ve öneri sistemidir. Tek katmanlı bir yapı tercih edilmiştir, fakat iş mantığı CQRS sayesinde sorgu (query) ve komut (command) işlemleri ayrıştırılarak düzenli bir yapı sağlanmıştır. MS SQL Server üzerinde ilişkili tablolarla beraber rezervasyonlar, araçlar, gibi çeşitli entity'ler için tablolar oluşturulmuş ve dinamik bir yapı sağlanmıştır. Tek katman olsa da Foler Structure'a uygun bir şekilde dosyalar oluşturulmuştur. 

### 🔹 Ana Özellikler
1. ViewComponent Yapısı
- Projede, farklı kısımlar için ViewComponent’ler kullanılmıştır.
- Böylece tekrarlanan UI parçaları (ör. araç önerileri, yakıt fiyatları, chatbot alanı) yeniden kullanılabilir hale getirilmiştir.

2. Yapay Zekâ ile Çeviri (Hugging Face – Helsinki NPL)
- Kullanıcılar, Türkçe metinleri İngilizceye veya İngilizce metinleri Türkçeye çevirebilmektedir.
- Hugging Face’in Helsinki NLP modeli kullanılarak gerçek zamanlı dil çevirisi yapılır.

3. RapidAPI Entegrasyonları
- Yakıt Fiyatları (Türkiye) → Kullanıcılar farklı şehirlerdeki benzin, motorin, LPG fiyatlarını öğrenebilir. Ana Sayfa'daki maliyet hesabında ve Admin Paneli'ndeki Dashboard'da kullanılır.
- Havalimanları (Türkiye’deki) → Türkiye’deki tüm havalimanlarının listesi çekilerek ana sayfada listelenir ve kullanıcıya sunulur.
- Havalimanları Arası Mesafe Hesaplama → Ana Sayfa'da seçilen iki havalimanı arasındaki uçuş mesafesi hesaplanır ve kullanıcıya sunulur.
- Chatbot → Müşteri'nin Bize Ulaşın bölümünden gönderdiği mesajları cevaplayan ve mail üzerinden cevap veren bir yapay zekâ destekli chatbot eklenmiştir.

4. Araç Öneri Asistanı
- Kullanıcı, tek bir soru sorarak (örn: “4 kişilik bir aile için uygun araç önerir misin?”) öneri alabilir.
- Asistan, ihtiyacı analiz eder ve mantıklı araç önerileri sunar.

Bu projeyi geliştirirken amacım, ASP.NET Core ve CQRS teknolojileriyle modern bir veri paneli geliştirme konusunda kendimi ilerletmek ve sektörel projelere hazır hale gelmekti. Bu sebeple projenin eksikleri olabilir.

### 🚀 Kullandığım Teknolojiler
- 💻 ASP.NET Core 9.0 → Projenin backend kısmı, modern .NET Core mimarisiyle geliştirildi.
- 🗂 CQRS (Command Query Responsibility Segregation) → Okuma (Query) ve yazma (Command) işlemleri ayrıştırıldı, temiz kod ve sürdürülebilirlik sağlandı.
- 📐 Tek Katmanlı Yapı → Tek katman üzerinde klasörler ile ayrılmış dosya düzeni sağlandı.
- 🗄️ MS SQL Server → Entity'ler ve İlişkili Tablolar MS SQL Server üzerinde düzenlendi.
- 🖼 ViewComponent → Tekrarlayan UI parçalarını yönetmek için kullanıldı.
- 🎨 HTML5, CSS3, JavaScript, Bootstrap
- 🌍 Hugging Face – Helsinki NLP → Türkçe ↔ İngilizce otomatik çeviri için kullanıldı.
- 🛢 RapidAPI Entegrasyonları:
- ⛽ Yakıt Fiyatları API → Türkiye’deki benzin, motorin ve LPG fiyatları.
- ✈️ Havalimanları API → Türkiye’deki havalimanlarının listelenmesi.
- 📏 Havalimanları Arası Mesafe API → İki havalimanı arasındaki mesafeyi hesaplama.
- 🤖 Chatbot API (Mesaja Karşılık Mail Oluşturma) → Müşterilerin sorularını cevaplayan basit yapay zekâ destekli sohbet botu.
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
