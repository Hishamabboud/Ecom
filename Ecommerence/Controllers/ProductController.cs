using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ecommerence.Controllers.Common;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Commands.Product;
using Ecommerence.Domain.Interfaces.Repositories;
using Ecommerence.Domain.Notifications;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerence.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository productRepository;

        public ProductController(
            IMediatorHandler mediator, 
            IMediatorHandler bus, 
            INotificationHandler<DomainNotification> notifications,
            IProductRepository productRepository
        ) : base(mediator, bus, notifications)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(productRepository.Query());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Response(await productRepository.GetAsync(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateProductCommand command)
        {
            var result = await bus.RequestAsync(command);
            return Response(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]UpdateProductCommand command)
        {
            await bus.SendAsync(command);
            return Response();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await bus.SendAsync(new DeleteProductCommand(id));
            return Response();
        }
    }
}
