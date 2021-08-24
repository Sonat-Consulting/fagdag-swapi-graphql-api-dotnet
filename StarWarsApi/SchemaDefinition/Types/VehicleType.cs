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
            Field(t => t.CargoCapacity).Description("The maximum number of kilograms that this starship can transport");
            Field(t => t.Consumables).Description("The maximum length of time that this vehicle can provide consumables for its entire crew without having to resupply");
            Field(t => t.CostInCredits).Description("The cost of this starship new, in galactic credits");
            Field(t => t.Created).Description("he ISO 8601 date format of the time that this resource was created.");
            Field(t => t.Crew).Description("The number of personnel needed to run or pilot this vehicle");
            Field(t => t.MaxAtmospheringSpeed).Description("The maximum speed of this vehicle in the atmosphere");
            Field(t => t.CargoCapacity).Description("The maximum number of kilograms that this vehicle can transport");
            Field(t => t.Passengers).Description("The number of non-essential people this vehicle can transport");
            Field(t => t.Length).Description("The length of this vehicle in meters");
            Field(t => t.Manufacturer).Description("The manufacturer of this vehicle. Comma separated if more than one");
        }
    }
}