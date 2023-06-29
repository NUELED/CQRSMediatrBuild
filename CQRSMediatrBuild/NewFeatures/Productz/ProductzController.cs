using CQRSMediatrBuild.NewFeatures.Productz.Commands;
using CQRSMediatrBuild.NewFeatures.Productz.Queries;
using CQRSMediatrBuild.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatrBuild.NewFeatures.Productz
{
    [Route("api/productz")]
    [ApiController]
    public class ProductzController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductzController(IMediator mediator)
        {
            _mediator = mediator;
        }
       

        [HttpGet("Testing")]
        public IActionResult Get()
        {
            return Ok("Enjoy the Cqrs Journey! Quite a nice concept yeah?");
        }



        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery()); // We are sending a request to the Mediator to get our 
            return Ok(products);                                         // products, using the "GetProductsQuery" instance as an argument.
        }


        //[HttpGet("{id:int}", Name = "Get_ProductById")]
        [HttpGet]
        [Route("getproductbyid")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }



        [HttpPost]
        [Route("create_ef")]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
            //  await _publisher.Publish(new ProductAddedNotification(productToReturn));
            //return CreatedAtAction("GetProductById", new { id = productToReturn.Id }, productToReturn);
            return Ok(productToReturn);
        }




    }
}
