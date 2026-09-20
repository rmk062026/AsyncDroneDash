# Async Drone Dash

Async Drone Dash er en konsollapplikasjon laget for å sammenligne forskjellige måter å håndtere samtidig og asynkront arbeid i C#.

Programmet simulerer et race mellom fire droner som beveger seg gjennom flere checkpoints.

## Implementasjoner

Prosjektet inneholder tre forskjellige implementasjoner:

1. **Thread + Join**

   * Hver drone kjører på en egen `Thread`.
   * `Thread.Sleep()` brukes mellom checkpoints.
   * `Join()` brukes for å vente på at trådene skal bli ferdige.

2. **Task + TaskCompletionSource**

   * Dronearbeidet startes med `Task.Run()`.
   * `TaskCompletionSource` brukes for å kontrollere når en Task er fullført eller har feilet.
   * `Task.WhenAll()` brukes for å vente på alle Task-ene.

3. **async/await**

   * Droneflyvningen kjøres gjennom en async-metode som returnerer `Task`.
   * `await Task.Delay()` brukes mellom checkpoints.
   * `await Task.WhenAll()` brukes for å vente asynkront på alle dronene.

Del D – Control Tower API er valgfri og er ikke implementert i denne versjonen.

## Feilhåndtering

I Task- og async/await-løsningene simuleres en feil på Alpha ved checkpoint 3.

Dette brukes for å demonstrere hvordan exceptions håndteres når flere Task-er kjører samtidig. De andre dronene får fortsette arbeidet selv om Alpha feiler.

## Kjøring

Fra rotmappen kan prosjektet kjøres med:

```powershell id="6o4d6y"
dotnet run --project AsyncDroneDash.App
```

Programmet viser en meny hvor implementasjon kan velges:

```text id="l41jrh"
**** Async Drone Dash ***

1. Thread + Join
2. Task + TaskCompletionSource
3. Async / await
0. Avslutt
```

Velg `1`, `2` eller `3` for å teste de forskjellige implementasjonene. Velg `0` for å avslutte programmet.

## Dokumentasjon

`PLAN.md` inneholder planlegging, prosjektstruktur og pseudokode for løsningene.

`reflection.md` inneholder refleksjon rundt implementasjonene, testene og forskjellene mellom `Thread`, `Task`, `TaskCompletionSource` og `async/await`.
