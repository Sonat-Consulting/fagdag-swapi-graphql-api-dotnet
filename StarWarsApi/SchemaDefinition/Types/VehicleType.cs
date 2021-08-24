using StarWarsApi.Models;
using GraphQL.Types;

namespace StarWarsApi.SchemaDefinition.Types
{
    public class VehicleType : ObjectGraphType<Vehicle>
    {
        public VehicleType()
        {
            Field(t => t.Name).Description("The name of this vehicle");
            Field(t => t.Model).Description("The model or official name of this vehicle");
        }
    }
}