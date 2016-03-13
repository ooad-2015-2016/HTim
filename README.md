# HTim
Clanovi tima:
	1. Belma Homarac
	2. Delila Halilovic
	3. Sumejja Halilovic
	4. Selmir Hasanovic

## Opis teme
Sistem za iznajmljivanje automobila i sli�nih prevoznih sredstava, uz mogucnost odredenih popusta.
Provjera se vrsi pomocu jedinstvenog koda koji se pri rezervaciji salje na korisnikov mail.
Korisnicima se nudi mogucnost pregled detaljnog opisa svakog vozila u ponudi.
Sistem je veoma pogodan za turiste kojima je potrebno prevozno sredstvo tokom njihovog boravka ovdje. 
Svojom kvalitetom i odabranom ponudom pomaze se uglavnom poslovnim i porodi�nim ljudima 
sa manjkom vremena i vi�kom obaveza, kao i turistima sa istancanim ukusom.

##Procesi
Agencija se sastoji od dvije organizacione jedinice, to su **salter**, koji je zaduzen za rad sa klijentima i 
**administracija**, koja je zaduzena za posao unutar same agencije. 
Administracija vrsi provjeru dokumentacije kao i pripremu ugovora, upravlja bazom podataka, gdje se pamte 
podaci o vozilima i ljudima koji su ih iznajmljivali i u kom periodu kao i samih vozila. Vr�i provjeru 
slobodnih vozila, zauzetih vozila kao i tehnickih sluzbi koje rade provjeru vozila.

######Salter
Klijent dolazi licno u agenciju i na salteru se registruje te (pomocu internet kataloga) izabere vozilo koje hoce 
da iznajmi, provjerava se sa administracijom da li je vozilo dostupno. Zatim se vrsi uplata na ziro racun agencije. 
Klijent donosi svu dokumentaciju i potvrdu o uplati na salter agencije. 

######Administracija 
Provjerava se prilozena dokumentacija, ispravnost automobila te se osiguravaju automobili (u slucaju kradje,
udesa i sl.), zatim vrsi upis podataka o klijentu, periodu iznajmljivanja i automobilu u bazi podataka i izdaje 
automobil. Kada klijent vraca automobil, agencija prvo vrsi provjeru automobila (i ukoliko ima ostecenja vrsi 
naplatu od osiguravajuce kuce) i upisuje podatke o tome da je automobil vracen u bazu podataka te na salteru 
izdaje potvrdu klijentu da je automobil vracen.