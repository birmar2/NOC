NOC
Az sql f�jlt import�lni sz�ks�ges egy mysql szerverre.
Majd a szerver adatait sz�ks�ges megadni a Connection oszt�ly konstruktor�ban:
server   = "hosztn�v";
database = "adatb�zisn�v";
user     = "felhaszn�l�";
password = "jelsz�";

Tesztel�shez user:
username:admin
password:admin

Rendszerv�ltoz�k h�v�sa:
pl.: Button h�tt�rsz�n�nek h�v�sa: Framework.Systemparam("gombHatterszin")

Log:
insertLog met�dust kell megh�vni hozz� 3 param�terrel:
Saj�t UserId, M�veletId (l�sd lejjebb), Felhaszn�ltRekordId
pl.:Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres bejelentkez�s"), Framework.MyUserId);

M�veletId lek�r�se:
Operation met�dusnak kell �tadni param�terk�nt a m�velet nev�t
pl.:Framework.Operation("Sikeres bejelentkez�s")

Ami m�g h�tra van:
-log bek�t�se az �sszes funcki�hoz. Egyel�re a loginba van csak
-m�g nincs lekezelve, hogy a formok input mez�it ne lehessen �resen elk�ldeni
-Bug:{egy form elment�se ut�n a main formot valami�rt a t�lc�ra helyezi}
-Tesztel�s
