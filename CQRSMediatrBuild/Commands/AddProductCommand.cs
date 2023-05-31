using MediatR;

namespace CQRSMediatrBuild.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
    
}
