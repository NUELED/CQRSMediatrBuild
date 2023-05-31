using MediatR;

namespace CQRSMediatrBuild.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;

}
