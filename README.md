# Mini E-Ticaret Web Uygulaması 🛒

Modern ve kullanıcı dostu bir e-ticaret platformu. ASP.NET Core MVC ile geliştirilmiş, rol tabanlı yetkilendirme sistemi içeren tam özellikli bir web uygulaması.

## 📋 İçindekiler

- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Sistem Gereksinimleri](#-sistem-gereksinimleri)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [Kullanıcı Rolleri](#-kullanıcı-rolleri)
- [Test Kullanıcıları](#-test-kullanıcıları)
- [Proje Yapısı](#-proje-yapısı)
- [Veritabanı Şeması](#-veritabanı-şeması)
- [Katkıda Bulunma](#-katkıda-bulunma)

## ✨ Özellikler

### 👤 Müşteri Özellikleri
- ✅ Kullanıcı kayıt ve giriş sistemi
- ✅ Ürün arama ve filtreleme
- ✅ Detaylı ürün görüntüleme
- ✅ Sepete ürün ekleme/çıkarma
- ✅ Sipariş oluşturma ve takibi
- ✅ Profil yönetimi
- ✅ Şifre sıfırlama

### 🏪 Satıcı Özellikleri
- ✅ Ürün ekleme, düzenleme ve silme
- ✅ Stok yönetimi
- ✅ Ürün görseli yükleme
- ✅ Kategori seçimi
- ✅ Satış geçmişi görüntüleme
- ✅ Ürün aktif/pasif yapma

### 👨‍💼 Admin Özellikleri
- ✅ Kategori yönetimi (CRUD)
- ✅ Kategori aktif/pasif yapma
- ✅ Sistem geneli yönetim paneli

### 🔒 Güvenlik Özellikleri
- ✅ ASP.NET Core Identity ile kimlik doğrulama
- ✅ Rol tabanlı yetkilendirme
- ✅ Güvenli şifre saklama (Hash)
- ✅ CSRF koruması
- ✅ FluentValidation ile veri doğrulama

## 🛠 Teknolojiler

### Backend
- **Framework:** ASP.NET Core 5.0 MVC
- **ORM:** Entity Framework Core 5.0
- **Veritabanı:** SQLite
- **Kimlik Doğrulama:** ASP.NET Core Identity 2.2
- **Validation:** FluentValidation 11.0

### Frontend
- **View Engine:** Razor Pages
- **JavaScript:** jQuery 3.x
- **Validation:** jQuery Validation & Unobtrusive Validation
- **CSS:** Bootstrap (responsive tasarım)

### Diğer
- **Design Pattern:** MVC (Model-View-Controller)
- **Architecture:** Repository Pattern
- **Middleware:** Custom User Role Middleware

## 💻 Sistem Gereksinimleri

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) veya üzeri
- Visual Studio 2019/2022 veya VS Code
- Windows, Linux veya macOS

## 🚀 Kurulum

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/kullaniciadi/miniETicaret_webProgramlamaProjesi.git
cd miniETicaret_webProgramlamaProjesi
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Veritabanını Oluşturun
Proje ilk çalıştırıldığında SQLite veritabanı otomatik olarak oluşturulacaktır. Ancak manuel olarak migration çalıştırmak isterseniz:

```bash
dotnet ef database update
```

> **Not:** Veritabanı `eTicaret.db` dosyası olarak proje kök dizininde oluşturulacaktır.

### 4. Projeyi Çalıştırın
```bash
dotnet run
```

Veya Visual Studio kullanıyorsanız `F5` tuşuna basın.

### 5. Tarayıcıda Açın
```
http://localhost:5000
```
veya
```
https://localhost:5001
```

## 📖 Kullanım

### İlk Adımlar

1. **Kayıt Olma:** Ana sayfadan "Kayıt Ol" butonuna tıklayın
2. **Giriş Yapma:** Kullanıcı adı ve şifrenizi girerek giriş yapın
3. **Rol Seçimi:** Kayıt sırasında Müşteri veya Satıcı rolünü seçin

### Müşteri Olarak

1. Ana sayfadan ürünleri görüntüleyin
2. Ürün detayına tıklayarak bilgileri görün
3. "Sepete Ekle" butonu ile ürünleri sepetinize ekleyin
4. Sepet sayfasından siparişinizi tamamlayın
5. "Siparişlerim" menüsünden geçmiş siparişlerinizi görüntüleyin

### Satıcı Olarak

1. "Ürün Ekle" menüsünden yeni ürün ekleyin
2. Ürün görseli, fiyat, stok bilgilerini girin
3. "Ürünlerim" sayfasından ürünlerinizi yönetin
4. "Satılan Ürünler" menüsünden satış geçmişinizi görün

### Admin Olarak

1. "Kategori Ekle" menüsünden yeni kategori oluşturun
2. "Kategorileri Düzenle" sayfasından mevcut kategorileri yönetin
3. Kategorileri aktif/pasif yapın

## 👥 Kullanıcı Rolleri

### 🔴 Admin
- Sistem yöneticisi
- Kategori yönetimi yetkisi
- Tüm kategorileri görüntüleme/düzenleme

### 🟢 Seller (Satıcı)
- Ürün ekleme ve yönetme
- Kendi ürünlerini düzenleme
- Satış geçmişini görüntüleme
- Stok takibi

### 🔵 Customer (Müşteri)
- Ürün görüntüleme ve arama
- Sepete ürün ekleme
- Sipariş oluşturma
- Sipariş geçmişini görüntüleme

## 🔑 Test Kullanıcıları

Veritabanı ilk oluşturulduğunda aşağıdaki test kullanıcıları otomatik olarak eklenir:

| Rol | Kullanıcı Adı | E-posta | Şifre |
|-----|---------------|---------|-------|
| Admin | admin | admin@gmail.com | 123123123 |
| Satıcı | seller | seller@gmail.com | qweqweqwe |
| Müşteri | customer | customer@gmail.com | qweqweqwe |

## 📁 Proje Yapısı

```
miniETicaret_webProgramlamaProjesi/
│
├── Controllers/              # MVC Controller'lar
│   ├── AccountController.cs  # Hesap yönetimi
│   ├── AdminController.cs    # Admin işlemleri
│   ├── AuthController.cs     # Kimlik doğrulama
│   ├── CartController.cs     # Sepet işlemleri
│   ├── CustomerController.cs # Müşteri işlemleri
│   ├── HomeController.cs     # Ana sayfa
│   ├── ProductsController.cs # Ürün işlemleri
│   └── SellerController.cs   # Satıcı işlemleri
│
├── Models/                   # Veri modelleri
│   ├── Entity/              # Veritabanı entity'leri
│   │   ├── AppUser.cs       # Kullanıcı modeli
│   │   ├── AppRole.cs       # Rol modeli
│   │   ├── Product.cs       # Ürün modeli
│   │   ├── Category.cs      # Kategori modeli
│   │   ├── Order.cs         # Sipariş modeli
│   │   ├── Cart.cs          # Sepet modeli
│   │   └── ProductOrder.cs  # Sipariş-Ürün ilişkisi
│   └── ViewModel/           # View modelleri
│
├── Views/                   # Razor view'lar
│   ├── Admin/              # Admin görünümleri
│   ├── Auth/               # Giriş/Kayıt görünümleri
│   ├── Customer/           # Müşteri görünümleri
│   ├── Seller/             # Satıcı görünümleri
│   ├── Products/           # Ürün görünümleri
│   ├── Home/               # Ana sayfa görünümleri
│   └── Shared/             # Paylaşılan görünümler (Layout, Menu)
│
├── Data/                    # Veritabanı context
│   └── eTicaretDBContext.cs
│
├── Validators/              # FluentValidation doğrulayıcılar
│   ├── Admin/              # Admin validasyonları
│   ├── Auth/               # Auth validasyonları
│   ├── Cart/               # Sepet validasyonları
│   └── Seller/             # Satıcı validasyonları
│
├── Middleware/              # Custom middleware'ler
│   └── UserRoleMiddleware.cs
│
├── Migrations/              # EF Core migrations
├── wwwroot/                 # Static dosyalar (CSS, JS, Images)
├── Program.cs               # Uygulama giriş noktası
├── Startup.cs               # Servis ve middleware yapılandırması
└── eTicaret.db             # SQLite veritabanı dosyası
```

## 🗄 Veritabanı Şeması

### Ana Tablolar

#### AppUser (Kullanıcı)
- Id, UserName, Email, PasswordHash
- TCKN, Name, SurName, PhoneNumber
- Address, IsActive, TermOfUse

#### Product (Ürün)
- Id, Name, Description, Price
- StockCount, ImgUrl, IsActive
- SellerId (FK), CategoryId (FK)

#### Category (Kategori)
- Id, Name, IsActive

#### Order (Sipariş)
- Id, OrderTime, TotalPrice
- Name, Description
- CustomerId (FK)

#### Cart (Sepet)
- CustomerId (FK), ProductId (FK)
- Quantity

#### ProductOrder (Sipariş Detayı - Many-to-Many)
- ProductId (FK), OrderId (FK), SellerId (FK)
- Quantity, UnitPrice

### İlişkiler

- **Kullanıcı - Ürün:** Bir satıcı birden fazla ürün ekleyebilir (1:N)
- **Kategori - Ürün:** Bir kategoride birden fazla ürün olabilir (1:N)
- **Kullanıcı - Sipariş:** Bir müşteri birden fazla sipariş verebilir (1:N)
- **Sipariş - Ürün:** Bir siparişte birden fazla ürün olabilir (N:M)
- **Kullanıcı - Sepet:** Bir kullanıcının sepetinde birden fazla ürün olabilir (N:M)

## 🔧 Yapılandırma

### Şifre Politikası
`Startup.cs` dosyasında özelleştirilebilir:

```csharp
options.Password.RequireDigit = false;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequireUppercase = false;
options.Password.RequiredLength = 8;
options.Password.RequireLowercase = false;
```

### Veritabanı Bağlantısı
`appsettings.json` veya `Startup.cs` dosyasından değiştirilebilir:

```csharp
services.AddDbContext<eTicaretDBContext>(options =>
    options.UseSqlite("Data Source=eTicaret.db"));
```

## 🐛 Sorun Giderme

### Veritabanı Hatası
```bash
# Migrations'ı sıfırlama
dotnet ef database drop
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Port Çakışması
`launchSettings.json` dosyasından port numaralarını değiştirebilirsiniz.

## 📝 Notlar

- Ürün görselleri `wwwroot/Images/` klasöründe saklanır
- Decimal değerler için `en-US` kültür ayarı kullanılmaktadır
- Authentication cookie tabanlı çalışır
- Tüm sayfalar authentication gerektirir (Login/Register hariç)

## 🤝 Katkıda Bulunma

1. Bu repo'yu fork edin
2. Feature branch oluşturun (`git checkout -b feature/YeniOzellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/YeniOzellik`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## 👨‍💻 Geliştirici

Web Programlama Projesi

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

