using Controller.DTO;
using Controller.Service;
using DemoBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("Thông tin khách hàng không hợp lệ");
            }
            try
            {
                customerDto.Id = Guid.NewGuid().ToString();
                await _customerService.AddCustomer(customerDto);

                return Ok("Khách hàng đã được thêm thành công");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Có lỗi xảy ra: {ex.Message}");
            }
        }
        [HttpPut]
        [Route("update/{Id}")]
        public async Task<ActionResult> UpdateCustomer(string Id, [FromBody] CustomerDto updatedCustomer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _customerService.UpdateCustomer(Id, updatedCustomer);
            if (result)
                return Ok("Cập nhật khách hàng thành công.");
            else
                return StatusCode(500, "Cập nhật khách hàng thất bại!!!");
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> DeleteCustomer(string Id)
        {
            var result = await _customerService.DeleteCustomer(Id);
            if (result)
                return Ok("Xoá khách hàng thành công");
            else
                return NotFound("Xoá khách hàng thất bại!!!");
        }
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllCustomer()
        {
            var customer = await _customerService.GetAllCustomer();
            return Ok(customer);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult> GetCustomerById(string Id)
        {
            var customer = await _customerService.GetCustomerById(Id);
            if (customer == null)
                return NotFound("Customer not found");
            return Ok(customer);
        }
    }
}
