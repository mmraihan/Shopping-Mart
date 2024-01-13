using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMart.API.Dtos;
using ShoppingMart.Core.Entities;
using ShoppingMart.Core.Interfaces;

namespace ShoppingMart.API.Controllers
{
  
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketId(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var updatedData = await _basketRepository.UpdateBasketAsync(customerBasket);
            return Ok(updatedData);

        }

        [HttpDelete]

        public async Task DeleteBasket(string id)
        {  
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
