using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(StarWarsQuery starWarsQuery)
        {
            Query = starWarsQuery;
        }
    }
}