# .NET 8 API Projesi İçin Gelişmiş README.md Dosyası

## Giriş
TodoApp API, kullanıcıların günlük görevlerini yönetebilmeleri için tasarlanmış, güvenli ve ölçeklenebilir bir backend uygulamasıdır. Proje, .NET 8, Entity Framework Core, SQL Server, JWT token, IdentityUser ve AutoMapper gibi teknolojiler kullanılarak geliştirilmiştir.

## Özellikler
- **Kullanıcı Yönetimi:** JWT token tabanlı güvenli kullanıcı kimlik doğrulaması (kayıt, giriş, şifre sıfırlama).
- **Görev Yönetimi:** Görev ekleme, güncelleme, silme ve listeleme işlemleri.
- **Görev Kategorileri:** Görevleri kategorilere ayırarak daha iyi organizasyon.
- **Görev Öncelikleri:** Görevlerin önemlerini belirlemek için önceliklendirme sistemi.
- **Hatırlatmalar:** Görevlerin belirli tarihlerde hatırlatılması.
- **Dosya Yükleme:** Görevlere dosya ekleme özelliği (örneğin, belgeler, resimler).
- **Middleware Kullanımı:** HTTP isteklerini ve yanıtlarını özelleştirmek için middleware kullanımı.

## Teknolojiler
- **.NET 8:** En son .NET sürümü ile geliştirilmiştir.
- **Entity Framework Core:** Veritabanı etkileşimleri için ORM.
- **SQL Server:** Veritabanı olarak SQL Server kullanılmıştır.
- **JWT:** Kullanıcı kimlik doğrulaması için JSON Web Token.
- **IdentityUser:** ASP.NET Identity ile kullanıcı yönetimi.
- **AutoMapper:** Nesneler arasında haritalama için AutoMapper.

## Kurulum

1. **.NET 8 SDK'sini yüklemek:**
   [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
   
2. **Proje kopyalama:**
   ```bash
   git clone https://github.com/muhammedsafatur/TodoApp.git

3.**Bağımlılıkları yükleme:**

   ```bash
cd TodoApp
dotnet restore

Veritabanı oluşturma: Proje dizinindeki appsettings.json dosyasındaki bağlantı bilgilerini kontrol edin.
Veritabanı göçleri için aşağıdaki komutu kullanın:

  ```bash

dotnet ef database update

4.**Projeyi çalıştırma:**

```bash
  dotnet run

***API EndPoints***
Kullanıcı
Kayıt: POST /api/auth/register
Giriş: POST /api/auth/login
Profil: GET /api/users/me

***Görev***
Tüm görevleri listeleme: GET /api/todos
Görev ekleme: POST /api/todos
Görev güncelleme: PUT /api/todos/{id}
Görev silme: DELETE /api/todos/{id}
... (Diğer API son noktaları)

***Katkıda Bulunma***
Proje açık kaynaklıdır ve katkılara açıktır. Katkıda bulunmak için:

Forklayın: Projenin bir kopyasını oluşturun.
Değişiklikler Yapın: İstediğiniz değişiklikleri yapın.
Pull Request Oluşturun: Değişikliklerinizi ana projeye eklemek için bir pull request oluşturun.

***Lisans***
Bu proje MIT lisansı altında lisanslanmıştır. Lisans metnine LICENSE dosyasından ulaşabilirsiniz.

***Testler***
Proje için NUnit kullanılarak kapsamlı unit testler yazılmıştır. Bu testler, kod kalitesini sağlamak ve olası hataları önlemek için düzenli olarak çalıştırılmaktadır.

***Dosya Yükleme***
Modelde Tanımlama: IFormFile tipinde bir özellik eklenerek dosya yükleme işlemi için model hazır hale getirilmiştir.
Controller'da İşleme: HttpPost metodunda gelen dosya, belirlenen bir dizine kaydedilir ve dosya yolu veritabanına kaydedilir.
Güvenlik: Dosya yükleme işlemleri sırasında güvenlik açıklarından kaçınmak için gerekli önlemler alınmıştır (dosya türü kontrolü, dosya boyutu kontrolü, dosya yolunu güvenli hale getirme).
