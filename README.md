# RehberApplication

Bu uygulmama oluşturulurken microservice kavramı ele alınmıştır. Mikroservis kavramını anlatacak olursam küçük ve bir arada çalışabilen servislerdir diyebiliriz. Proler zamanla büyür, okuma, bakım ve test edilebilirliği azalır. Bunu önlemek için microserviceler tercih edilir.

![image](https://user-images.githubusercontent.com/35036327/185808857-ca41b581-cba3-4b86-81f8-a223e847011d.png)

Yukarıdaki resimden de anlaşılacağı gibi Monolitik yapıya sahip uygulamalarda tüm bileşenler tek bir yapıya sahip olur tek bir database ile iletişime geçmektedir. Mikroservislerde ise her servis kendi database ile iletişime geçmektedir. 

Mkroservislerin faydaları ise;
- Test edilebilirlik ve okunabilirlik açısından oldukça rahattır.
- Daha iyi bir performans gösterir.
- Ölçeklenebilirliği daha kolaydır.
- Daha kolay geliştirilebilir.

Rehber Uygulaması oluşturulurken Ocelot paketi kullanılmıştır. Bu paket açık kaynaklı bir Api Gateway' dir. 

Api Gateway: Mikroservisler arasındaki yönlendirme ve haberleşmeyi sağlar.

# Rehber Uygulaması nasıl çalışır?
Sistem oluşurulurken ilk önce 3 adet .net Core API projesi oluşturuldu. Bunlar; KisilerManagement, RaporManagement, Rehber Management dır. Uygulama RehberManagement projesi üzerinden ayağa kaldırılır.
RehberManagement içerisinde Ocelot paketi yüklenmiştir. RehberManagement içerisindeki Startup.cs dosyasına Ocelot servisi eklenmiştir. Daha sonrasında Ocelot.json dosyası oluşturularak Program.cs içerisine bu json dosyasının eklenmesi sağlanmıştır.

Uygulama da database toolu olarak PostgresSQL kullanılmıştır. Localde tanımlamış olduğum veritabanı ismi RehberAppDb' dir. Bu veri tabanı içerisindeki tablolar ise aşağıdaki gibidir.

![image](https://user-images.githubusercontent.com/35036327/185809392-1f6d4a91-74a9-4f05-bea2-4259907e54bb.png)

Uygulama içerisindeki gerekli olan servis istekleri aşağıdaki gibidir.

- Rehberde kişi oluşturma
![image](https://user-images.githubusercontent.com/35036327/185809770-809a281d-7447-4b02-a235-3f80571fe74f.png)

Resimdeki Postman de görünen adresten POST metodu kullanılarak kişi ekleme işlemi yapılır.

- Rehberde kişi kaldırma
![image](https://user-images.githubusercontent.com/35036327/185809838-00e35fc6-4d76-4823-8ca1-b059280ebed6.png)

Resimdeki Postman de görünen adresten DELETE metodu ve id belirtilerek kişi silme işlemi yapılır.

- Rehberdeki kişiye iletişim bilgisi ekleme
![image](https://user-images.githubusercontent.com/35036327/185809934-336f0947-f25f-41b8-be4d-4a87d8ab03f1.png)

Resimdeki Postman de görünen adresten POST metodu kullanılarak kişi idsi ve bilgitipi idsi belirtilerek kişiye iletişim bilgisi ekleme işlemi yapılır. 

**Bilgi Tiplerine ait kayıtlar aşağıdaki gibidir.

![image](https://user-images.githubusercontent.com/35036327/185810001-04aed7d6-055f-4a06-9863-cac1e9c090f3.png)

- Rehberdeki kişiden iletişim bilgisi kaldırma
![image](https://user-images.githubusercontent.com/35036327/185810046-82e823fe-c8f5-4dfd-8a70-5eb70b7fbe6d.png)

Resimdeki Postman de görünen adresten DELETE metodu ve id belirtilerek kişiye ait iletişim bilgisi silme işlemi yapılır.

- Rehberdeki kişilerin listelenmesi

![image](https://user-images.githubusercontent.com/35036327/185810081-275600e4-a7d5-49e0-9c68-451c51765883.png)

Resimdeki Postman de görünen adresten GET metodu kullanılarak kişiler listelenir.

- Rehberdeki bir kişiyle ilgili iletişim bilgilerinin de yer aldığı detay bilgilerin getirilmesi
![image](https://user-images.githubusercontent.com/35036327/185811037-e8a0466b-ae9d-441f-a3ae-c44ec48f3dbe.png)

Resimdeki Postman de görünen adresten GET metodu ve kisiId belirtilerek ilgili kişinin iletişim bilgileri listelenir.

**Diğer maddeler ile ilgili çalışmaları tamamlayamadım. Konulara tam hakimiyetimin olmaması ve öğrenme açısında zaman bulamadığım için yetiştiremedim. **
