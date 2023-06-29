using CQRSMediatrBuild.DataContext;
using CQRSMediatrBuild.NewFeatures.Productz.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatrBuild.NewFeatures.Productz.Handler
{
    //Unit here replaces void. Since void is not a valid return type in C#
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ApplicationDbContext _context;
        public AddProductHandler(ApplicationDbContext context) =>  _context = context; 
       

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            await _context.AddAsync(request.Prod);
            await _context.SaveChangesAsync();
            return request.Prod;

        }
    }
}
