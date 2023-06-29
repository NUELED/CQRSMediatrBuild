using CQRSMediatrBuild.DataContext;
using CQRSMediatrBuild.NewFeatures.Productz.Queries;
using MediatR;

namespace CQRSMediatrBuild.NewFeatures.Productz.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext _context;
        public GetProductByIdHandler( ApplicationDbContext context) => _context = context;  
       
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var prodduct = await _context.Products.FindAsync(request.Id);
            return prodduct;

        }
    }
}
