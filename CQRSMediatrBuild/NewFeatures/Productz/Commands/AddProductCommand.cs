using MediatR;
namespace CQRSMediatrBuild.NewFeatures.Productz.Commands
{
    //Using "Product" is just for testing.In real world scenerios we'll use DTOs instead.
    public record AddProductCommand(Product Prod) : IRequest<Product>;
    
}
