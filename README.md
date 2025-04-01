# BabyCare MongoDB Projesi

M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde, Erhan Gündüz hocamızın  verdiği eğitim kapsamında MongoDB veritabanı ile geliştirilmiştir. Projenin %80'lik kısmı case olarak atanmıştır. Caseler başarıyla tamamlanmıştır. Proje UI ve Admin Paneli olmak üzere iki katmandan oluşmaktadır. UI tarafı kreş sitesi olarak tasarlanmıştır. Burada kreş ile ilgili detayları görebilir. Admin tarafında ise Admin sitenin bir çok kısmını dinamik bir şekilde yönetebilir. Proje de katmanlı mimari yapısı kullanılmamıştır. Solid prensiplerine özen gösterilerek kodlanmaya çalışılmıştır.

## Proje Detayları

📃 DataAcces: Veritabanı tablolarını temsil eden entity sınıflarını içerir. Ayrıca MongoDb ayarlarını içermektedir. 

🔎 DTos: İçerisinde DTO'ları barındırır.

⚙️ Mappings: Bu klasörde DTO'ların mappleme işlemleri yapılmaktadır.

🌐 Services: Servis katmanında her entity'e ait servis sınıflarımız ve interfacelerimiz yer almakta. 

📚 WebUI: Kullanıcı dostu bir arayüz sunarak kitap yönetim işlemlerini kolaylaştırır.

📚 Area: Ayrıca admin paneli ayrı bir area içerisine taşınmış, bu saye de daha düzenli bir yapı elde edilmiştir. 

📚 Components: Admin paneli ve UI componentlere bölünerek daha kolay yönetilebilir bir yapıya çevrilmiştir.

## Proje Özellikleri - Kısaca

🔐 Asp Core 8.0 ile geliştirildi.

🗄️ Veritabanı olarak MongoDB tercih edildi.

🛠️ Entity Framework ile Code First yaklaşımı kullanıldı.

🛠️ AutoMapper kullanıldı.

🛠️ Ayrıca kullanıcının doğru veri girmesini sağlamak amacıyla FluentValidation kullanıldı.

🗽Admin panelinde site ile alakalı tüm yönetimi gerçekleştirebilir.

## UI - Anasayfa
![Kayıt 2025-04-01 172138 (1)](https://github.com/user-attachments/assets/285bdb32-4116-4674-bc6b-397b02fd7804)

## Admin Paneli

![admin](https://github.com/user-attachments/assets/9c27edc5-25f0-4c3f-89eb-8845fecd03f0)
![admin1](https://github.com/user-attachments/assets/c02f3861-a57f-45b7-8fc7-d6ee8ac6b867)
![admin2](https://github.com/user-attachments/assets/7a27978a-809a-41df-8c1b-df58f4a4c584)
![admin3](https://github.com/user-attachments/assets/f422d38a-2b6d-4a8e-8394-8f97e16961d1)
![admin4](https://github.com/user-attachments/assets/6c9f1198-8a1a-4d65-8dae-2a9bd176740e)
![admin5](https://github.com/user-attachments/assets/13ec4a4c-ee51-4337-bb7a-b94bd52d47cc)
![admin6](https://github.com/user-attachments/assets/17d211e9-8d70-41e6-a1f1-dcc6d13806ff)
![admin7](https://github.com/user-attachments/assets/c95d5b7f-c3fc-415d-a33e-4dddfe952c89)
![admin8](https://github.com/user-attachments/assets/19c4572e-848a-4055-a703-b3f76c9a31aa)
![admin9](https://github.com/user-attachments/assets/ad6d88c0-6adb-4fb5-aef8-12372e272780)





