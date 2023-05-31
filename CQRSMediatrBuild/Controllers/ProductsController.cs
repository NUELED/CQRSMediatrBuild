using CQRSMediatrBuild.Commands;
using CQRSMediatrBuild.Notifications;
using CQRSMediatrBuild.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatrBuild.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // I need to add commands and handlers for delete!! Don't forget.
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)  // lets make the constructor a one liner here
        {
            _sender = sender;
            _publisher = publisher; 
        }


        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery()); // We are sending a request to the Mediator
            return Ok(products);
        }



        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }




        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
           var productToReturn =  await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn)); 
           return CreatedAtAction("GetProductById", new { id = productToReturn.Id }, productToReturn);   
        }





    }
}