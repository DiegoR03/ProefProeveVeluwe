# Veluwe Verkenner

Veluwe Verkenner is een proove of concept voor ons proef examen.

voor een uitgebreidere documentatie van dit project kun je terecht bij onze wiki: [wiki](https://github.com/erwinhenraat/VoorbeeldExamenRepo/wiki)

# Geproduceerde Game Onderdelen

Bob Hoogenboom:
  * [GPS System](https://github.com/DiegoR03/ProefProeveVeluwe/tree/main/ProefProeveVeluwe/Assets/Scripts/Runtime/GPS)


Student Y:
  * Water Shader
  * [Some textured and rigged model](https://github.com/erwinhenraat/VoorbeeldExamenRepo/tree/master/assets/monsters)

Student Z:
  * [Some beautifull script](https://github.com/erwinhenraat/VoorbeeldExamenRepo/tree/master/src/beautifull)
  * Some other Game object


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


## Some other Mechanic Y by Student X

Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

![example](https://user-images.githubusercontent.com/1262745/189135129-34d15823-0311-46b5-a041-f0bbfede9e78.png)

## Water Shader by Student Y

Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

![example](https://user-images.githubusercontent.com/1262745/189135129-34d15823-0311-46b5-a041-f0bbfede9e78.png)

## Some textured and rigged model by Student Y

Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

![example](https://user-images.githubusercontent.com/1262745/189135129-34d15823-0311-46b5-a041-f0bbfede9e78.png)

## Some beautifull script by Student Z

Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

![example](https://user-images.githubusercontent.com/1262745/189135129-34d15823-0311-46b5-a041-f0bbfede9e78.png)

## Some other Game object by Student Z

Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.

![example](https://user-images.githubusercontent.com/1262745/189135129-34d15823-0311-46b5-a041-f0bbfede9e78.png)
