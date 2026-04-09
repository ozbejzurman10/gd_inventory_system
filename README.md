# Godot Inventory System v C#

Projekt, ki prikazuje implementacijo inventory sistema v Godot 4.6.2.

[Tehnična dokumentacija](https://github.com/ozbejzurman10/gd_inventory_system/blob/main/Tehni%C4%8Dna%20dokumentacija.pdf)

[Poročilo testiranja]([https://github.com/ozbejzurman10/gd_inventory_system/blob/main/Tehni%C4%8Dna%20dokumentacija.pdf])

## Zahteve

- Godot 4.6.2 z **.NET / C# podporo**
- .NET SDK 8.0+

## Nameščanje in poganjanje

1. Kloniraj ta repozitorij.

2. Odpri **Godot 4.6.2 .NET**

3. Klikni **"Import"** in izberi mapo kloniranega projekta

4. Počakaj da Godot uvozi vse vire

5. Pritisni **F5** ali gumb **Play** za zagon

## Navodila za uporabo

### Glavni inventory (levo)
- Velika mreža slotov predstavlja **glavni inventory** igralca
- Klikni gumb **"Give Random Item"** da dobiš naključen predmet iz baze itemov
- Predmeti so različnih redkosti. Barva ozadja slota označuje redkost:

| Barva | Redkost |
|---|---|
| Siva | Common |
| Zelena | Uncommon |
| Modra | Rare |
| Vijolična | Epic |
| Oranžna | Legendary |
| Mavrična | Ultra Legendary |

### Premikanje predmetov
- Klikni na predmet v inventoryju da ga "dvigneš" (sledi miški)
- Klikni na prazen slot da ga odložiš tja
- Klikni na zaseden slot da **zamenjata** mesti

### Active slot (zgoraj desno)
- Premakni predmet v **active slot** (mali slot zgoraj desno)
- Na desni strani se prikažeta **ime** in **opis** predmeta ter njegova **redkost**
- Pritisni gumb **"Use Item"** za uporabo predmeta:
  - *Consumable:* izpiše koliko HP si prejel
  - *Weapon:* izpiše damage orožja
  - *Material:* izpiše da ta predmet ni uporaben
  - Po uporabi se consumable predmet izbriše iz slota

### Kombiniranje predmetov (spodaj desno)
- Premakni **dva predmeta** v combinable slota (levi in desni slot spodaj)
- Pritisni gumb **"Combine Items"**
- Če obstaja **recept** za to kombinacijo, se v izhodni slot pojavi nov predmet
- Če recept ne obstaja, se izpiše sporočilo da kombinacija ni mogoča
