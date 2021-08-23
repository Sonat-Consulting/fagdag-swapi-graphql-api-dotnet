﻿# .NET Core GraphQL eksempel

## For å kjøre
`$ dotnet build`

`$ dotnet run --project ./StarWarsApi`

## For å teste
Åpen GraphQL playground i nettleser:

https://localhost:5001/ui/playground

## Eksempel på spørring:

```
{
  films{
    id
    title
    producer
  }
}
```

```
{
  film(id: 1) {
    title
    episodeId
    director
	}
}
```
