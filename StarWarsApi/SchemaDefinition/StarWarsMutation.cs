using GraphQL;
using GraphQL.Types;
using StarWarsApi.Data;
using StarWarsApi.Models;
using StarWarsApi.SchemaDefinition.Types;

namespace StarWarsApi.SchemaDefinition
{
    public class StarWarsMutation : ObjectGraphType
    {
        public StarWarsMutation(IReviewService reviewService)
        {
            Field<ReviewType>("createReview",
                arguments: new QueryArguments(new QueryArgument<ReviewInputType> { Name = "review" }),
                resolve: context =>
                {
                    var review = context.GetArgument<Review>("review");
                    return reviewService.AddReview(review);
                });
        }
    }
}