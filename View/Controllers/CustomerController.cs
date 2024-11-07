using Controller.DTO;
using Microsoft.AspNetCore.Mvc;

namespace View.Controllers
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerController(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        [Route("Customer")]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:44370/api/Customer/all");
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadFromJsonAsync<List<CustomerDto>>();
                return View(customers);
            }

            return View(new List<CustomerDto>());
        }
        public IActionResult AddCustomer()
        {
            return View();
        }

        // Xử lý post dữ liệu để thêm khách hàng qua API
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDto model)
        {
            if (model == null)
            {
                return BadRequest("Customer data is null.");
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44370/api/Customer/add", model);
                if (response.IsSuccessStatusCode)
                {
                    return Ok("Khách hàng đã được thêm thành công");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return StatusCode(500, $"API error: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
        public async Task<IActionResult> EditCustomer(string id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44370/api/Customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();
                return View(customer);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> EditCustomer(CustomerDto model)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44370/api/Customer/{model.Id}/update-addresses", model.Address);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Cập nhật khách hàng thất bại!!!");
            return View(model);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:44370/api/Customer/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
