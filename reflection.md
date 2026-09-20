## Del A – Thread + Join

### Hva skjedde da alle fire Thread-ene ble startet?

De begynte å arbeide samtidig på forskjellige tråder. Derfor ble utskriften fra dronene blandet sammen i konsollen.

### Var startrekkefølgen den samme hver gang?

Nei. Rekkefølgen var forskjellig mellom kjøringene. Operativsystemets scheduler bestemmer hvilke tråder som får kjøretid, så jeg kan ikke vite nøyaktig hvilken rekkefølge utskriften kommer i.

### Hva gjorde Join()?

`Join()` gjorde at hovedtråden ventet på at trådene skulle bli ferdige før den gikk videre. Dronene kunne fortsatt arbeide samtidig siden alle trådene ble startet før `Join()` ble kalt.

### Hva skjedde da jeg fjernet Join()?

Da ble teksten "Alle droner er ferdige!" skrevet ut nesten med en gang, før dronene i det hele tatt hadde kommet til første checkpoint.

### Hvorfor ble "Alle droner er ferdige!" skrevet for tidlig?

Fordi det ikke var noe som ba hovedtråden vente til de andre trådene var ferdige. Den startet trådene og gikk deretter direkte videre til neste linje i koden.

## Del B – Task og TaskCompletionSource

I denne delen brukte jeg `Task`, `Task.Run` og `TaskCompletionSource` for å kjøre flere droner samtidig. `Task.Run` starter arbeidet som skal gjøres, mens `TaskCompletionSource` brukes til å kontrollere når Task-en skal regnes som fullført eller feilet.

Jeg brukte `SetResult()` når en drone ble ferdig uten feil, og `SetException()` dersom en drone fikk en exception. På denne måten kunne `Task.WhenAll` vente på Task-ene til alle dronene hadde nådd en sluttilstand.

Jeg testet også hva som skjedde dersom Alpha feilet ved checkpoint 3. De andre dronene fortsatte å kjøre til de var ferdige. Når alle Task-ene hadde nådd en sluttilstand, ble feilen fra Alpha kastet videre fra `await Task.WhenAll` og fanget med `try/catch`.

Jeg startet først med separat `TaskCompletionSource` og `Task.Run` for hver drone. Dette førte til mye gjentatt kode. Jeg refaktorerte derfor dette til `RunDroneTask(DroneModel drone)`, slik at samme metode kunne brukes for alle dronene.

Sammenlignet med `Thread` opplevde jeg `Task` som en høyere abstraksjon. Med `Thread` jobbet jeg direkte med trådene og måtte bruke `Join()` for å vente. Med Task kunne jeg i stedet representere arbeidet som Task-er og bruke `Task.WhenAll` for å vente på dem samlet.

## Del C – async/await

I denne delen brukte jeg `async` og `await` for å kjøre dronene asynkront. `FlyDroneAsync()` returnerer en `Task`, så jeg trengte ikke å bruke `Task.Run` og `TaskCompletionSource` slik jeg gjorde i Del B.

Den viktigste forskjellen jeg lærte var forskjellen mellom `Thread.Sleep()` og `await Task.Delay()`. `Thread.Sleep()` blokkerer tråden mens den venter. Med `await Task.Delay()` blokkeres ikke tråden på samme måte, og tråden kan brukes til annet arbeid mens Task-en venter.

Jeg startet `FlyDroneAsync()` for alle fire dronene og lagret Task-en som hver metode returnerte. Deretter brukte jeg `await Task.WhenAll` for å vente på at alle skulle bli ferdige.

Jeg testet også feil ved å la Alpha kaste en exception ved checkpoint 3. I motsetning til løsningen med `TaskCompletionSource` trengte jeg ikke å bruke `SetException()`. Når en exception blir kastet i en `async Task`-metode, blir Task-en automatisk markert som feilet. Feilen kunne deretter håndteres av `try/catch` rundt `await Task.WhenAll`.

Jeg synes denne løsningen ble enklere å lese enn løsningen med `TaskCompletionSource`, fordi det var mindre kode og færre ting jeg måtte kontrollere manuelt. Dette gjør også løsningen enklere å vedlikeholde, fordi det er mindre boilerplate og færre steder der fullføring og feil må håndteres manuelt.

## Sammenligning

De tre løsningene utfører lignende arbeid, men håndterer venting og fullføring på forskjellige måter.

Med `Thread` jobbet jeg direkte med trådene. Jeg startet hver tråd med `Start()` og brukte `Join()` for å blokkere den kallende tråden til den aktuelle tråden var ferdig. Da jeg testet uten `Join()`, skrev hovedprogrammet at alle dronene var ferdige før dronearbeidet faktisk var fullført.

Med `Task` og `TaskCompletionSource` jobbet jeg på et høyere abstraksjonsnivå. `Task.Run` startet arbeidet, mens `TaskCompletionSource` lot meg kontrollere om Task-en skulle fullføres med `SetResult()` eller feile med `SetException()`. `Task.WhenAll` gjorde det mulig å vente på alle Task-ene samlet.

Med `async/await` kunne `FlyDroneAsync()` selv returnere en `Task`. `await Task.Delay()` blokkerte ikke tråden mens programmet ventet, og exceptions i async-metoden gjorde Task-en automatisk feilet. Derfor trengte denne løsningen mindre kode enn løsningen med `TaskCompletionSource`.

Etter å ha jobbet med alle tre løsningene forstår jeg bedre forskjellen mellom å blokkere en tråd og å vente asynkront. Jeg forstår også bedre hvordan `Task` representerer arbeid som kan bli ferdig senere, og hvordan `await` brukes for å vente på dette arbeidet uten å blokkere på samme måte som `Thread.Join()` eller `Thread.Sleep()`.

### Når ville jeg brukt TaskCompletionSource?

I et vanlig async-scenario ville jeg foretrukket `async/await` fordi løsningen blir enklere å lese og vedlikeholde.

`TaskCompletionSource` kan være nyttig når jeg må gjøre noe som ikke allerede returnerer en Task om til en Task-basert operasjon, for eksempel når jeg venter på en callback, event eller et eksternt signal. Da kan jeg selv kontrollere når Task-en skal fullføres eller feile.

### Blokkering i asynkron kode

Blokkering kan skape problemer dersom jeg bruker `.Result` eller `.Wait()` på en Task i en asynkron flyt, fordi tråden da blir blokkert mens den venter på resultatet. Det kan blant annet føre til dårligere ressursutnyttelse og i enkelte miljøer deadlock.

Et annet eksempel er å bruke `Thread.Sleep()` inne i en async-metode når jeg egentlig bare skal vente. Da blir tråden blokkert under ventingen. Med `await Task.Delay()` kan Task-en vente uten å blokkere tråden på samme måte.
