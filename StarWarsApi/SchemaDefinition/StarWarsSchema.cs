using System;
using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IServiceProvider serviceProvider, StarWarsQuery starWarsQuery) : base(serviceProvider)
        {
            Query = starWarsQuery;
        }
    }
}