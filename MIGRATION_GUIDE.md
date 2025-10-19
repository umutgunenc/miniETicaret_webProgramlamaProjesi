# Migration Rehberi

## Önemli: Database Schema Değişikliği

Projede `Despriction` alanı `Description` olarak düzeltildi. Bu değişiklik için yeni bir migration oluşturmanız gerekiyor.

## Migration Oluşturma Adımları

### Seçenek 1: Yeni Migration Oluştur (Önerilen)

```bash
dotnet ef migrations add UpdateDescriptionFieldName
dotnet ef database update
```

### Seçenek 2: Database'i Sıfırla ve Yeniden Oluştur

Eğer geliştirme ortamındaysanız ve mevcut verileri kaybetmekte sorun yoksa:

```bash
# Veritabanını sil
dotnet ef database drop --force

# Tüm migration'ları sil
Remove-Item -Path "Migrations\*.cs" -Recurse

# Yeni migration oluştur
dotnet ef migrations add InitialCreate

# Veritabanını oluştur
dotnet ef database update
```

### Seçenek 3: Manuel SQL

Eğer mevcut veriyi korumak istiyorsanız, SQLite'da manuel olarak:

```sql
-- Product tablosu için
ALTER TABLE Products RENAME COLUMN Despriction TO Description;

-- Order tablosu için
ALTER TABLE Orders RENAME COLUMN Despriction TO Description;
```

## Yapılan Değişiklikler

### Entity Değişiklikleri
- ✅ `Product.Despriction` → `Product.Description`
- ✅ `Order.Despriction` → `Order.Description`

### Controller Değişiklikleri
- ✅ `HomeController.Search` - Mantık hatası düzeltildi
- ✅ `CartController.ConfirmCart` - Performans iyileştirmesi (SaveChangesAsync çağrıları azaltıldı)
- ✅ `SellerController` - Gereksiz yorum satırları temizlendi
- ✅ `AuthController` - RegisterCustomer ve RegisterSeller kod tekrarı giderildi

### Güvenlik İyileştirmeleri
- ✅ `AccountController` - Hardcoded email/password kaldırıldı
- ✅ `Startup.cs` - Şifre politikası güçlendirildi
- ✅ `Startup.cs` - Hesap kilitleme aktif edildi
- ✅ `AuthController.Login` - Brute force koruması aktif edildi

### Configuration İyileştirmeleri
- ✅ `appsettings.json` - ConnectionString yapılandırması eklendi
- ✅ `.gitignore` - Database ve sensitive dosyalar için güvenlik eklendi

### View İyileştirmeleri
- ✅ `_Layout.cshtml` - HTML meta tags eklendi ve iyileştirildi
- ✅ Tüm view'larda `Despriction` → `Description` düzeltmesi yapıldı

### Validator İyileştirmeleri
- ✅ Tüm validatorlarda `Despriction` → `Description` düzeltmesi yapıldı

## Test Kullanıcıları (Güncel Şifre Politikası)

Yeni şifre politikası: **En az 8 karakter, en az 1 rakam, en az 1 küçük harf**

| Rol | Kullanıcı Adı | Şifre | Geçerli mi? |
|-----|---------------|-------|-------------|
| Admin | admin | 123123123 | ✅ Evet |
| Satıcı | seller | qweqweqwe1 | ✅ Güncellenmeli (rakam ekle) |
| Müşteri | customer | qweqweqwe1 | ✅ Güncellenmeli (rakam ekle) |

## Not

Migration oluşturulduktan sonra bu dosyayı silebilirsiniz.

