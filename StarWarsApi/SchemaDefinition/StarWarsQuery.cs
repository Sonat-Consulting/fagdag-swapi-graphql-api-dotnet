using System.IO;
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
        }
    }
}
