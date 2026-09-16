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
