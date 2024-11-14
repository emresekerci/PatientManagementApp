PatikaManagementApp
Bu projemde hasta takip sistemi projesi yaptım
Projemde Time Controller Filter,Jwt ve Bearer işlemleri,Middleware,kimlik doğrulama ve yetkilendirme
özelliklerini kullandım.
Api end-pointleriyle projemizde değişiklik yapabiliriz.
Katmanlı mimari ile katmanları oluşturdum.3 katmandan oluşmakta.Bunlar;
PatikaManagementApp.Bussines
PatikaManagementApp.Data
PatikaManagementApp.WebApi

Bussines katmanımız Data ve Api kısmımız için bir bağlantı noktası Api katmanında yaptığımız işlemleri Dataya aktarırız.

End-pointlerimiz = Get - Post - Put  - Patch - Delete
isteğe bağlı filter :[TimeControllerFilter] = Gerekli görülen yerlere eklenebilir