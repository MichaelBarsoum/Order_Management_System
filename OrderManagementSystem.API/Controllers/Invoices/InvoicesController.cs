using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order_Management_System.CORE.Contracts;
using Order_Management_System.Repositories.Models;
using OrderManagementSystem.API.DTOs.Invoice;
using OrderManagementSystem.API.Errors;

namespace OrderManagementSystem.API.Controllers.Invoices
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IGenericRepository<Invoice> _invoiceRepo;
        private readonly IMapper _mapper;

        public InvoicesController(IGenericRepository<Invoice> InvoiceRepo,IMapper mapper)
        {
            _invoiceRepo = InvoiceRepo;
            _mapper = mapper;
        }


        [Authorize(Roles = " Admin")]
        [HttpGet("{invoiceId}")]
        [ProducesResponseType(typeof(Invoice), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int invoiceId)
        {
            var invoice = await _invoiceRepo.GetByIdAsync(invoiceId);
            if (invoice is not Invoice) return NotFound(new ApiErrorResponse(404, $"Invoice with ID : {invoiceId}"));
            var MappedInvoice = _mapper.Map<InvoiceDTO>(invoice);
            return Ok(MappedInvoice);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(InvoiceDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllInvoices()
        {
            var invoices = await _invoiceRepo.GetAllAsync();
            if (invoices is null) return NotFound(new ApiErrorResponse(404, "No Invoices Found !"));
            var MappedInvoice = _mapper.Map<IEnumerable<InvoiceDTO>>(invoices);
            return Ok(MappedInvoice);
        }
    }
}
