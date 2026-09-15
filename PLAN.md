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

