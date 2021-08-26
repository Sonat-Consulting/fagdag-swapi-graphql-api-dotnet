using System;
using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(IServiceProvider serviceProvider, StarWarsQuery starWarsQuery, StarWarsMutation starWarsMutation) : base(serviceProvider)
        {
            Query = starWarsQuery;
            Mutation = starWarsMutation;
        }
    }
}