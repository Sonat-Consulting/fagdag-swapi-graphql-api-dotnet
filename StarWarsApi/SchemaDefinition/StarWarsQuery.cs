using GraphQL;
using GraphQL.Types;
using StarWarsApi.Data;
using StarWarsApi.SchemaDefinition.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(IFilmService filmService, IReviewService reviewService)
        {
            Field<ListGraphType<FilmType>>("films", resolve: context => filmService.GetFilms());
            Field<FilmType>(
                "film",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var episodeId = context.GetArgument<int>("id");
                    return filmService.GetFilm(episodeId);
                });
            Field<ListGraphType<VehicleType>>("vehicles", resolve: context => filmService.GetVehicles());
            Field<VehicleType>(
                "vehicle",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var episodeId = context.GetArgument<int>("id");
                    return filmService.GetVehicle(episodeId);
                });
        }
    }
}
