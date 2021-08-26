# .NET Core GraphQL fagdag

## For å kjøre
`$ dotnet build`

`$ dotnet run --project ./StarWarsApi`

## For å teste
Åpen GraphQL playground i nettleser:

https://localhost:5001/ui/playground

En grafisk oversikt av skjema finner du på https://localhost:5001/ui/voyager

# Oppgaver
## Del 1 – Spørringer

Vi skal spørre mot serveren med GrahQL. 

1. Spør om alle filmer med feltene tittel og producer
2. Spør om alle filmer med feltene tittel, openingcrawl og releaseDate
3. Spør om alle filmer med feltene tittel og vehicles, og vehicles skal minst ha med feltene model og manufacturer
4. Spør om alle reviews
5. Spør om film med id 3
6. Gi navn til query fra oppgave 5
7. Bytt verdien 3 med en variabel


## Del 2 – Implementere backend

Vi skal fylle inn det som mangler i backend for å få den til å virke som den gjorde i Del 1.

Før du begynner må du bytte til greinen "del-2" i git.


1. Endre description på *title* til "The super title of the film" i schema.

```
# For å sjekke trykk på schema i playground of se at det har endret seg
```

2. Rette navnet på feltet "Produzer" til "Producer" i schema
```
# For å sjekke kan du kjøre denne spørringen
{
  films {
    title
    producer
  }
}
```

3. Legg til feltet *releaseDate* på film-typen.
```
# For å sjekke kan du kjøre denne spørringen
{
  films {
    title
    releaseDate
  }
}
```

4. Finn feltet *reviews* på film og implementer en resolver. 
Det er lov å bruke servicene som allerede er laget.

FOR JAVA: Finn filmResolvers og fiks getReviews
```
# For å sjekke kan du kjøre denne spørringen
{
  films {
    title
    producer
    reviews {
      username
      diceThrow
    }
  }
}
```

5. Legg til feltet *vehicles* på film og implement resolver.
Det er lov å bruke servicene som allerede er laget.

FOR JAVA: Legg til feltet *vehicles* på *film* i skjema og fiks getVehicles i FilmResolver

```
# For å sjekke kan du kjøre denne spørringen
{
  films {
    title
    producer
    vehicles {
      name
      manufacturer
    }
  }
}
```

6. Legge til reviews til schema sånn at det går an å spørre etter alle reviews (uten å bruke films).
```
# For å sjekke kan du kjøre denne spørringen
{
  reviews {
    episodeId
    username
    diceThrow
  }
}
```

7. (Ekstra oppgave) Utvid reviews til å ha kommentarer. Her må du endre i services/data også.
```
# For å sjekke kan du kjøre denne spørringen
{
  reviews {
    episodeId
    username
    diceThrow
    comment
  }
}
```



## Eksempel på spørring:

```
# Films with vehicles
{
  films {
    title
    director
    vehicles {
      name
      model
    }
  }
}
```


```
# Specific film
{
  film (id: 1) {
    title
    episodeId
    director
  }
}
```

```
# Named query
query costInCredits {
  film(id: 3) {
    title
    producer
    openingCrawl
    releaseDate
  }
}
```

```
# Named query with variable
query costInCredits($id:ID!) {
  film(id: $id) {
    title
    producer
    openingCrawl
    releaseDate
  }
}

--- in query variables window ---
{
  "id": 3
}
```

```
# Named query with variable and directive
query costInCredits($id:ID!, $includeProducer: Boolean!) {
  film(id: $id) {
    title
    producer @include(if: $includeProducer)
    openingCrawl
    releaseDate
  }
}

--- in query variables window ---
{
  "id": 4,
  "includeProducer": false
}
```
