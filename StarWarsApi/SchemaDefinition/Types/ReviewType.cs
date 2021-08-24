using StarWarsApi.Models;
using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(t => t.EpisodeId).Description("The id of the episode this review is written for");
            Field(t => t.Username).Description("Username of author of this review");
            Field(t => t.DiceThrow).Description("Number from 1-6 representing authors opinion. 6 is the best.");
        }
    }
}