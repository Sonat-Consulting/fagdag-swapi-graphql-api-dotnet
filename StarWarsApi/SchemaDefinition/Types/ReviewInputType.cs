using System.IO;
using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition.Types
{
    public class ReviewInputType : InputObjectGraphType
    {
        public ReviewInputType()
        {
            Name = "ReviewInput";
            Field<NonNullGraphType<IntGraphType>>("episodeId");
            Field<NonNullGraphType<StringGraphType>>("username");
            Field<NonNullGraphType<IntGraphType>>("diceThrow");
        }
    }
}