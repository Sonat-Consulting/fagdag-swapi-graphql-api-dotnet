using GraphQL.Types;
using StarWarsApi.Models;

namespace StarWarsApi.SchemaDefinition.Types
{
    public sealed class FilmType : ObjectGraphType<Film>
    {
        public FilmType()
        {
            Field(t => t.Title).Description("The title of the film");
            Field(t => t.EpisodeId)
                .Description("The Id of the episode in chronological order of the original star wars books");
            Field(t => t.OpeningCrawl).Description("The opening paragraphs at the beginning of this film");
            Field(t => t.Director).Description("The director of the film");
            Field(t => t.Producer).Description("A comma separated list of the producers");
            Field(t => t.ReleaseDate).Description("The ISO 8601 date format of film release at original creator country");
            Field(t => t.Created).Description("The ISO 8601 date format of the time that this resource was created");
            Field(t => t.Edited).Description("The ISO 8601 date format of the time that this resource was edited");
            Field(t => t.Url).Description("the hypermedia URL of this resource");
            Field(t => t.Species).Description("An array of species resource URLs that are in this film");
            Field(t => t.Starships).Description("An array of starship resource URLs that are in this film");
            Field(t => t.Vehicles).Description("An array of vehicle resource URLs that are in this film");
            Field(t => t.Characters).Description("An array of people resource URLs that are in this film");
            Field(t => t.Planets).Description("An array of planet resource URLs that are in this film");
        }
    }
}