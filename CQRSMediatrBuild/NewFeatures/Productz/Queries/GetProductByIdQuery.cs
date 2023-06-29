using MediatR;

namespace CQRSMediatrBuild.NewFeatures.Productz.Queries
{
    //In this case the  GetProductByIdQuery takes in an int parameter and makes a request to the db using the IRequest Interface,
    // Which then returns a Product.
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
    

}
