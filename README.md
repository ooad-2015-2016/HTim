# HTim
Clanovi tima:<br />
1. Belma Homarac<br />
2. Delila Halilovic<br />
3. Sumejja Halilovic<br />
4. Selmir Hasanovic<br />

##Opis teme
Sistem za iznajmljivanje automobila i sliènih prevoznih sredstava, uz mogucnost odredenih popusta.
Provjera se vrsi pomocu jedinstvenog koda koji se pri rezervaciji salje na korisnikov mail.
Korisnicima se nudi mogucnost pregled detaljnog opisa svakog vozila u ponudi.
Sistem je veoma pogodan za turiste kojima je potrebno prevozno sredstvo tokom njihovog boravka ovdje. 
Svojom kvalitetom i odabranom ponudom pomaze se uglavnom poslovnim i porodiènim ljudima 
sa manjkom vremena i viškom obaveza, kao i turistima sa istancanim ukusom.

##Procesi
Agencija se sastoji od dvije organizacione jedinice, to su **salter**, koji je zaduzen za rad sa klijentima i 
**administracija**, koja je zaduzena za posao unutar same agencije. 
Administracija vrsi provjeru dokumentacije kao i pripremu ugovora, upravlja bazom podataka, gdje se pamte 
podaci o vozilima i ljudima koji su ih iznajmljivali i u kom periodu kao i samih vozila. Vrši provjeru 
slobodnih vozila, zauzetih vozila kao i tehnickih sluzbi koje rade provjeru vozila.

######Salter
1. Klijent, bilo da je registrovan ili ne, moze pregledati automobile u ponudi te procitati detaljnije opise. Osobe koje
nisu registrovane mogu samo vidjeti automobile u ponudi, ukoliko zele iznajmiti isti, moraju se registrovati.<br />
2. Klijent se registruje tako sto popuni potrebne licne podatke, te dobija kod (sifru). Registraciju moge izvrsiti osoba starija od 18 godina, bilo da je strani drzavljanin
 ili ne.  <br />
3. Prilikom registracije vrsi se fotografisanje klijenta te snimanje njegovog glasa. Ti podaci se mogu koristiti za identifikovanje korisnika,
 u slucaju da to bude potrebno.<br />
4. Prilikom odabira vozila, provjerava se njegova ispravnost i dostupnost u trazenom periodu. Ovaj dio se vrsi uz pomoc
 administracije koja je zaduzena za evidneciju i raspolozivost svih automobila. u zavisnosti od perioda na koji se zeli iznjamiti 
automobil obracunava se i odgovarajuci popust te se ta cijena saopcava klijentu. <br />
5. Uplata se vrsi odmah po rezervaciji vozila.<br />

######Administracija 
1. Zaduzena je za provjeru prilozene dokumentacije, ispravnosti automobila, te je zaduzenja za njihovo osiguranje(u slucaju kradje,
udesa i sl.)<br />
2. Ukoliko je klijent iznajmio vozilo, vodi se evidencija o tome te se potrebni podaci upisuju u bazu. <br />
3. Podatke o lokaciji svih svojih vozila evidentira pomocu GPS uredjaja, koje posjeduje svako vozilo ove agencije.<br />
4. Prilikom vracanja automobila agenciji, provjerava se stanje automobila(i ukoliko ima ostecenja vrsi se 
naplatu od osiguravajuce kuce) i upisuju se podaci o tome da je automobil vracen u bazu podataka te se na salteru 
izdaje potvrda klijentu da je automobil vracen. <br />

##Funkcionalnosti
- Mogucnost iznajmljivanja automobila u periodu od 24h do 6 mjeseci
- Dozvoljene valute uplate: EUR i BAM
- Iskusno osoblje pomaze pri odabiru najoptimalnijeg vozila
- Mogucnost prevoza sa/do aerodroma, autobuske ili zeljeznicke stanice do nase rent a car kuce
- Mogucnost doplate za GPS navigacijski uredjaj, sjedalicu za dijete itd..
- Mogucnost zamjene vozila u slucaju kvara
- Uplata neovisna o kilometrazi
- Mogucnost otkazivanja rezervacije

## Akteri

**Vlasnik** - osoba koja ima uvid u cjelokupan rad i finansijski status firme.<br />
**Supervizor** - ima zadatak da nadgleda rad uposlenika, primopredaju vozila te vrsi update kataloga kako bi u svakom trenutku korisnici imali informaciju o dostupnim automobilima.<br />
**Dezurni radnik** - osoba koja radi za firmu Rent-a-car na poslovima iznajmljivanja, rezervacije i naplacivanja.<br />
**Vozac** - ima zadatak da po zelji klijenta vrsi usluge voznje.<br />
**Majstor** - osoba koja je zaduzena za popravku eventualnih kvarova te procjenu materijalne stete na pokvarenom automobilu.<br />
**Korisnik** - osoba koja ima mogucnost iznajmljivanja i rezervacije automobila na licu mjesta ili putem online sistema (online korisnik).<br />