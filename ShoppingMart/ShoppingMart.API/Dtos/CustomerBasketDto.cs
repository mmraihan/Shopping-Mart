using ShoppingMart.Core.Entities;

namespace ShoppingMart.API.Dtos
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
