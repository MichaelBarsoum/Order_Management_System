using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Customer;
using OrderManagementSystem.API.DTOs.Order;
using OrderManagementSystem.API.Errors;

namespace OrderManagementSystem.API.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IMapper _mapper;

        public CustomersController(IGenericRepository<Customer> genericRepository , IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<ActionResult<Customer>> CreateNewCustomer([FromBody]CustomerDTO customer)
        {
            if (customer is null) return BadRequest(new ApiErrorResponse(400));
            var MappedCustomer = _mapper.Map<Customer>(customer);
            await _genericRepository.CreateAsync(MappedCustomer);
            return Ok(MappedCustomer);
        }
        [Authorize]
        [HttpGet("{Id}/orders")]
        [ProducesResponseType(typeof(CustomerOrderToReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerOrderToReturnDTO>> GetAllOrderByCustomerId([FromRoute] int Id)
        {             
            var result = await _genericRepository.GetByIdAsync(Id);
            if(result is null) return NotFound(new ApiErrorResponse(404));
            var CustomerOrderMapping = _mapper.Map<CustomerOrderToReturnDTO>(result);
            var MappedCustomer = _mapper.Map<CustomerOrderToReturnDTO>(CustomerOrderMapping);
            return Ok(MappedCustomer);
        }
    }
}

