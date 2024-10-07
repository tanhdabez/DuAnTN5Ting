using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using View.Models;

namespace View.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        // Inject HttpClient vào controller
        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Action để lấy danh sách sản phẩm
        public async Task<IActionResult> ListProduct()
        {
            // API URL của bạn
            string apiUrl = "https://localhost:44370/Product/GetProducts";

            // Biến để chứa danh sách sản phẩm
            List<ProductViewModel> products = new List<ProductViewModel>();

            // Gọi API lấy dữ liệu
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);
            }

            // Truyền dữ liệu sản phẩm đến View
            return View(products);
        }

        public async Task<IActionResult> GetProductsById(string productId)
        {
            // API URL của bạn
            string apiUrl = $"https://localhost:44370/Product/GetProductsById/{productId}";

            // Biến để chứa danh sách sản phẩm  
            ProductViewModel products = new ProductViewModel();

            // Gọi API lấy dữ liệu
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<ProductViewModel>(json);
            }

            // Truyền dữ liệu sản phẩm đến View
            return View(products);
        }

        public async Task<IActionResult> SetProduct(ProductViewModel product)
        {
            // API URL của bạn
            string apiUrl = $"https://localhost:44370/Product/SetProduct";

            // Biến để chứa danh sách sản phẩm  
            ProductViewModel products = new ProductViewModel();

            // Gọi API lấy dữ liệu
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<ProductViewModel>(json);
            }

            // Truyền dữ liệu sản phẩm đến View
            return View(products);
        }
        public async Task<IActionResult> DeleteProduct()
        {
            // API URL của bạn
            string apiUrl = "https://localhost:44370/Product/DeleteProduct";

            // Biến để chứa danh sách sản phẩm
            List<ProductViewModel> products = new List<ProductViewModel>();

            // Gọi API lấy dữ liệu
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);
            }

            // Truyền dữ liệu sản phẩm đến View
            return View(products);
        }
    }
}
