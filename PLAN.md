# Async Drone Dash - Plan

## Mål

Lage en kontrollapplikasjon som simulerer leveringsdroner og lære forskjellen mellom Thread/Join, Task/TaskCompletionSource og async/await.

## Drone

Hver drone skal ha:
- Navn
- Maks antall checkpoints
- Forsinkelse mellom checkpoints

## Del A - Thread Race

- Lage minst 2 droner
- Kjøre hver drone på en egen Thread
- Skrive fremdriften tli Console
- Bruke Join for å vente på begge.
- Teste uten Join og observere forskjellen

## Del B - Task + TaskCompletionSource

- Kjøre droneflyvning som Tasks
- Bruke en TaskCompletionSource per drone
- Bruke Task.WhenAll
- Simulere en feil.
- Observere hvordan feilen progageres. 

## Del C - async / await

- Lage async droneflyvning
- Bruke await Task.Delay
- Bruke await Task.WhenAll
- Håndtere feil med try/catch

## Del D - Control tower API

Valgfri. Vurderes etter at Del A-C er ferdig.

## Structur

### DroneModel
Lagrer informasjon om en drone

### MainMenu
Viser menyen og lar brukeren velge hvilke del som skal kjøres.

### ThreadRaceService
Inneholder logikken for Del A

### TaskRaceService
Inneholder logikken for Del B

### AsyncRaceService
Inneholder logikken for Del C

### Program.cs
Starter programmet og menyen

## Pseudokode

### Hovedprogram

START PROGRAM

Opprett tjeneste for Thread-løpet
Opprett tjeneste for Task-løpet
Opprett tjeneste for Async-løpet

Så lenge programmet kjører:
    Vis meny
    Les brukerens valg

    Hvis valg er 1:
        Kjør Thread-løpet

    Hvis valg er 2:
        Kjør Task-løpet

    Hvis valg er 3:
        Kjør Async-løpet

    Hvis valg er 0:
        Avslutt programmet

    Ellers:
        Vis feilmelding

SLUTT PROGRAM


### Del A - Thread + Join

Opprett dronene

Opprett en Thread for hver drone

Start alle Thread-ene

For hver drone:
    Fly gjennom alle checkpoints
    Vent mellom hvert checkpoint
    Skriv fremdrift til Console

Vent på hver Thread med Join

Når alle er ferdige:
    Skriv at alle dronene er ferdige


### Del B - Task + TaskCompletionSource

Opprett dronene

For hver drone:
    Opprett en TaskCompletionSource
    Start dronearbeidet med Task.Run

    Hvis dronearbeidet fullføres:
        Marker Task som fullført

    Hvis dronearbeidet feiler:
        Marker Task som feilet

Vent på alle Task-ene med Task.WhenAll

Hvis en Task feiler:
    Fang og skriv ut feilen

Ellers:
    Skriv at alle dronene er ferdige


### Del C - async/await

Opprett dronene

Start FlyDroneAsync for hver drone

For hver drone:
    Gå gjennom alle checkpoints
    Vent asynkront med Task.Delay
    Skriv fremdrift til Console

    Hvis simulert feil oppstår:
        Kast en exception

Vent asynkront på alle dronene med Task.WhenAll

Hvis en Task feiler:
    Fang og skriv ut feilen

Ellers:
    Skriv at alle dronene er ferdige