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
Saját UserId, MûveletId (lásd lejjebb), FelhasználtRekordId
pl.:Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres bejelentkezés"), Framework.MyUserId);

MûveletId lekérése:
Operation metódusnak kell átadni paraméterként a mûvelet nevét
pl.:Framework.Operation("Sikeres bejelentkezés")

Ami még hátra van:
-log bekötése az összes funckióhoz. Egyelõre a loginba van csak
-még nincs lekezelve, hogy a formok input mezõit ne lehessen üresen elküldeni
-Bug:{egy form elmentése után a main formot valamiért a tálcára helyezi}
-Tesztelés
