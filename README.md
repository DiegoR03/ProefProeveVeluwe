# Veluwe Verkenner

Veluwe Verkenner is een proove of concept voor ons proef examen.

voor een uitgebreidere documentatie van dit project kun je terecht bij onze wiki: [wiki](https://github.com/erwinhenraat/VoorbeeldExamenRepo/wiki)

# Geproduceerde Game Onderdelen

Bob Hoogenboom:
  * [GPS System](https://github.com/DiegoR03/ProefProeveVeluwe/tree/main/ProefProeveVeluwe/Assets/Scripts/Runtime/GPS)


Robin Knol:
  * [Mini Games](https://github.com/DiegoR03/ProefProeveVeluwe/tree/main/ProefProeveVeluwe/Assets/Scripts/Runtime/Animal%20Interaction)

Diego Ramon:
  * [WaypointData](https://github.com/DiegoR03/ProefProeveVeluwe/tree/main/ProefProeveVeluwe/Assets/Scripts/Runtime/Data)
  * [UI](https://github.com/DiegoR03/ProefProeveVeluwe/tree/main/ProefProeveVeluwe/Assets/Scripts/Runtime/UI)


## GPS System

De GPS System is de core van de game. De speler moet weten waar hij/zij naartoe loopt door middel van de locatie input gegeven van je device.


### flowchart for the GPS-System:

```mermaid
flowchart TD

Device((Device))

GPS(GPS.cs)
GPSDebug(GPSDebug.cs)
CoordinateChecker(CoordinateChecker.cs)

CordToGPS{Check Coordinates to Waypoints}
DebugToGPS{Get Coordinates from GPS.cs}


CoordinateChecker --> CordToGPS
CordToGPS --> GPS

GPSDebug --> DebugToGPS
DebugToGPS --> GPS

GPS--> |Get Location Data| Device
```

### class diagram voor game entities:

```mermaid
classDiagram

Unit <|-- Tower:Is A
Unit <|-- Monster
Unit <|-- Boss
Unit : +int life
Unit : +int speed
Unit: +isMovable()
Unit: +Destroy()
class Tower{
+String turretType
+target()
+shoot()
}
class Monster{
-int reward
-regenerates()
}
class Boss{
+bool is_unique
+specialSkill()
}
```


## GPS-System door Bob Hoogenboom

Het basis GPS script pakt data van de device. Deze data sla ik express op in 1 script vanwege performance. ik wil niet dat alle 3 de scripts dit iedere frame 3 keer opvragen van de device, aangezien we ook zagen dat GPS veel batterij trekt. Nadat de GPS class je huidige GPS data vasthoud en vrij is om opgevraagd te worden door andere scripts. 
Een van die andere scripts is het CoordinateChecker script. dit script vraagt de GPS data op van het basis GPS script en rekent uit met de formule van Haversine of jou GPS data overeen komt met de uitkomst van de formule. Zo ja dan kan je een minigame spelen, zo niet dan moet je nog even verder lopen ;).

<img src=https://user-images.githubusercontent.com/55579218/224704790-e30880ed-8fa7-4c82-bf5c-fa818b06b75e.png width= 40% height = auto>
<p float="left">
  <img src=https://user-images.githubusercontent.com/55579218/226002138-180618f6-1968-4f05-bc9e-bf804b6f2dfb.png width= 30% height = auto/>
  <img src=https://user-images.githubusercontent.com/55579218/226004105-fdce8c59-5d97-4c3a-b511-958fac6d67c5.png width= 30% height = auto/>
 </p>


## Mini game door Robin Knol

De mini games is het leuke gedeelte van het spel. Waarneer de speler in de buurt komt van een dier kan hij/zij een mini game doen. Hier in kan je met het dier spelen.

## Waypoints Data door Diego Ramon

De waypoints systeem is één van de belangrijkste punten in de game, op deze manier kan de speler namelijk de mini-games spelen en weten waar hij/zij naartoe moet.
<br/>
De eerste script ```GPSWayPointData``` gebruikt drie verschillende data's die wij gebruiken om scriptable objects aan te maken. Op deze manier kunnen wij makkelijk en snel nieuwe waypoints toevoegen zonder wij allemaal losse scripts gebruiken binnen Unity. Binnen deze scriptable object kunnen wij de drie eerder genoemde data's aanpassen naar onze gewilde locatie, deze data wordt in de volgende drie values verdeelt; `WaypointName`, `LongitudeValue` en `LatitudeValue`

<img src="https://user-images.githubusercontent.com/54799111/224552192-eff3435f-db76-4805-9e82-4b5937f4a239.png" width=45% height=auto><br/>

Nadat wij al deze waypoints hebben aangemaakt stoppen wij al deze scriptable object in een lijst, dit wordt gedaan in de ```GPSRoutes``` script. Deze script vraagt alle scriptable object naar keuze aan en voegt ze samen tot één route die de speler dan kan volgen.

<img src= "https://user-images.githubusercontent.com/54799111/224552406-6c1885d9-8c3c-4bed-a6e0-1e9a48784d60.png" width=45% height=auto>
