using GraphQL;
using GraphQL.Types;
using StarWarsApi.Data;
using StarWarsApi.SchemaDefinition.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(IFilmService service)
        {
            Field<ListGraphType<FilmType>>("films", resolve: context => service.GetFilms());
            Field<FilmType>(
                "film",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var episodeId = context.GetArgument<int>("id");
                    return service.GetFilm(episodeId);
                });
        }
    }
}
