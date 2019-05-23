NOC
Az sql fájlt importálni szükséges egy mysql szerverre.
Majd a szerver adatait szükséges megadni a Connection osztály konstruktorában:
server   = "hosztnév";
database = "adatbázisnév";
user     = "felhasználó";
password = "jelszó";

Teszteléshez user:
username:admin
password:admin

Rendszerváltozók hívása:
pl.: Button háttérszínének hívása: Framework.Systemparam("gombHatterszin")

Log:
insertLog metódust kell meghívni hozzá 3 paraméterrel:
Saját UserId, MűveletId (lásd lejjebb), FelhasználtRekordId
pl.:Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres bejelentkezés"), Framework.MyUserId);

MűveletId lekérése:
Operation metódusnak kell átadni paraméterként a művelet nevét
pl.:Framework.Operation("Sikeres bejelentkezés")

Ami még hátra van:
-log bekötése az összes funckióhoz. Egyelőre a loginba van csak
-még nincs lekezelve, hogy a formok input mezőit ne lehessen üresen elküldeni
-Tesztelés
