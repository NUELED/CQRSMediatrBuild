using MediatR;

namespace CQRSMediatrBuild.Queries
{
    public record GetProductsQuery :  IRequest<IEnumerable<Product>>;
   
}
