using System.IO;
using GraphQL.Types;
using StarWarsApi.Data;
using StarWarsApi.SchemaDefinition.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(IFilmsReposity filmsReposity)
        {
            Field<ListGraphType<FilmType>>("films", resolve: _ => filmsReposity.GetAll());
        }
    }
}