using MediatR;

namespace CQRSMediatrBuild.NewFeatures.Productz.Queries
{
    //The IRequest interface is responsible for making the request to the db to return the list of products.
    //That is why we are passing "IEnumerable<Product>" as a parameter. i.e IRequest returns a list of products in this case.
    //This request will then be handled by a handler in the  handler class. //We are using a record here in place of a class.
    public record GetProductsQuery : IRequest<IEnumerable<Product>>; 
    
}
