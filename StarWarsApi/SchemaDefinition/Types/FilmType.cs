using GraphQL.Types;
using StarWarsApi.Models;

namespace StarWarsApi.SchemaDefinition.Types
{
    public sealed class FilmType : ObjectGraphType<Film>
    {
        public FilmType()
        {
            Field(t => t.Id).Description("The internal ID of the film");
            Field(t => t.EpisodeId)
                .Description("The Id of the episode in chronological order of the original star wars books");
            Field(t => t.Title).Description("The title of the film");
            Field(t => t.Director).Description("The director of the film");
            Field(t => t.Producer).Description("A comma separated list of the producers");
        }
    }
}