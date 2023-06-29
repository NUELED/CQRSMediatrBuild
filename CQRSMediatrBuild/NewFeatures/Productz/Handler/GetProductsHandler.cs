using CQRSMediatrBuild.DataContext;
using CQRSMediatrBuild.NewFeatures.Productz.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatrBuild.NewFeatures.Productz.Handler
{
    //Here the IRequestHandler takes as parameters, the GetProductsQuery and an IEnumerable of Products.
    //It returns an IEnumerable<Product>, after "Handling" / Processing the request.
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ApplicationDbContext _context;
        public GetProductsHandler(ApplicationDbContext context) => _context = context;



        //Here the "Handle" Function which is implemented from the IRequestHandler interface, is made to return a list of products
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync();
        }


    }
}
