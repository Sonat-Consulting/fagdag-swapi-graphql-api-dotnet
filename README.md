﻿# .net core graphql eksempel

## for å kjøre
`$ dotnet build`

`$ dotnet run --project ./StarWarsApi`

## For å teste
Åpen GraphQL playground i nettleser:    

https://localhost:5001/ui/playground

## eksempel på spørring:

```
{
  films{
    id
    title
    producer
  }
}
```
