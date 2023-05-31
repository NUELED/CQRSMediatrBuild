using CQRSMediatrBuild.Queries;
using MediatR;

namespace CQRSMediatrBuild.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;
        public GetProductByIdHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore; 
        }
        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return _fakeDataStore.GetProductById(request.Id);
        }
    }
}
