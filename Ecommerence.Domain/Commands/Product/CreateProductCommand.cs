using Ecommerence.Domain.Commands.Common;

namespace Ecommerence.Domain.Commands.Product
{
    public class CreateProductCommand : RequestCommand<Models.Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string[] PicturesUrls { get; set; }
    }
}
