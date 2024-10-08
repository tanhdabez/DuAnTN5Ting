using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using View.Dto;
using View.Models;

namespace View.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        // Hàm chung để gọi các API và deserialize dữ liệu
        private async Task<T?> GetApiDataAsync<T>(string apiUrl)
        {
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    // Xử lý lỗi nếu API trả về trạng thái không thành công
                    ModelState.AddModelError("", $"Lỗi khi gọi API: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ngoại lệ
                ModelState.AddModelError("", $"Ngoại lệ khi gọi API: {ex.Message}");
            }
            return default;
        }

        // Hàm gọi API để tải các dropdown
        private async Task LoadDropdowns(ProductAddViewModel product)
        {
            ViewBag.Materials = new SelectList(await GetApiDataAsync<List<MaterialViewModel>>("https://localhost:44370/Product/GetMaterials") ?? new List<MaterialViewModel>(), "Id", "Ten");
            ViewBag.Brands = new SelectList(await GetApiDataAsync<List<BrandViewModel>>("https://localhost:44370/Product/GetBrands") ?? new List<BrandViewModel>(), "Id", "Ten");
            ViewBag.Manufacturers = new SelectList(await GetApiDataAsync<List<ManufacturerViewModel>>("https://localhost:44370/Product/GetManufacturers") ?? new List<ManufacturerViewModel>(), "Id", "Ten");
            ViewBag.ProductTypes = new SelectList(await GetApiDataAsync<List<ProductTypeViewModel>>("https://localhost:44370/Product/GetProductTypes") ?? new List<ProductTypeViewModel>(), "Id", "Ten");
        }

        // Danh sách sản phẩm
        public async Task<IActionResult> ListProduct()
        {
            var products = await GetApiDataAsync<List<ProductViewModel>>("https://localhost:44370/Product/GetProducts");
            return View(products);
        }

        // Lấy sản phẩm theo ID
        public async Task<IActionResult> GetProductsById(string productId)
        {
            var product = await GetApiDataAsync<ProductViewModel>($"https://localhost:44370/Product/GetProductsById/{productId}");
            return View(product);
        }

        // Thêm hoặc cập nhật sản phẩm
        public async Task<IActionResult> SetProduct(ProductAddViewModel product)
        {
            // Gán ID nếu chưa có
            product.Id ??= string.Empty;
            product.LoaiSanPham ??= string.Empty;
            product.Brand ??= string.Empty;
            product.NhaSanXuat ??= string.Empty;
            product.TenVatLieu ??= string.Empty;
            product.IdLoaiSanPham ??= string.Empty;
            product.IdNhaSanXuat ??= string.Empty;
            product.IdVatLieu ??= string.Empty;

            // Xử lý hình ảnh
            List<string> imagePaths = new List<string>();
            if (product.HinhAnh != null && product.HinhAnh.Length > 0)
            {
                foreach (var file in product.HinhAnh)
                {
                    if (file.Length > 0)
                    {
                        // Tạo đường dẫn lưu tệp hình ảnh
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        imagePaths.Add(file.FileName); // Thêm đường dẫn tệp vào danh sách
                    }
                }
            }

            // Gọi API để lưu sản phẩm
            string apiUrl = "https://localhost:44370/Product/SetProduct";

            // Tạo DTO cho sản phẩm
            var productDto = new ProductDto
            {
                Id = product.Id,
                MaSanPham = product.MaSanPham,
                TenSanPham = product.TenSanPham,
                GiaSanPham = product.GiaSanPham,
                NamSanXuat = product.NamSanXuat,
                MoTa = product.MoTa,
                IdLoaiSanPham = product.IdLoaiSanPham,
                IdBrand = product.IdBrand,
                IdNhaSanXuat = product.IdNhaSanXuat,
                IdVatLieu = product.IdVatLieu,
                HinhAnh = imagePaths // Gán đường dẫn hình ảnh vào DTO
            };

            // Chuyển đổi ProductDto thành JSON
            var jsonProduct = JsonConvert.SerializeObject(productDto);
            var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

            // Gọi API để lưu sản phẩm
            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(result))
                {
                    ModelState.AddModelError("", result);
                    await LoadDropdowns(product);
                    return View(product);
                }
                return RedirectToAction("ListProduct");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", errorMessage);
            }

            await LoadDropdowns(product);
            return View(product);
        }

        // Xóa sản phẩm (chỉ lấy danh sách sản phẩm cho ví dụ)
        public async Task<IActionResult> DeleteProduct()
        {
            var products = await GetApiDataAsync<List<ProductViewModel>>("https://localhost:44370/Product/DeleteProduct");
            return View(products);
        }

        // Danh sách vật liệu
        public async Task<IActionResult> ListMaterial()
        {
            var materials = await GetApiDataAsync<List<MaterialViewModel>>("https://localhost:44370/Product/GetMaterials");
            return View(materials);
        }

        // Thêm hoặc cập nhật vật liệu
        public async Task<IActionResult> SetMaterial(MaterialViewModel material)
        {
            material.Id ??= string.Empty; // Gán chuỗi rỗng nếu ID null
            string apiUrl = "https://localhost:44370/Product/SetMaterial";
            var jsonMaterial = JsonConvert.SerializeObject(material);
            var content = new StringContent(jsonMaterial, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (result.ToLower() == "false")
                {
                    ModelState.AddModelError("", "Mã vật liệu đã bị trùng.");
                    return View(material);
                }

                return RedirectToAction("ListMaterial");
            }

            ModelState.AddModelError("", "Lưu vật liệu không thành công.");
            return View(material);
        }

        // Danh sách thương hiệu
        public async Task<IActionResult> ListBrand()
        {
            var brands = await GetApiDataAsync<List<BrandViewModel>>("https://localhost:44370/Product/GetBrands");
            return View(brands);
        }

        // Danh sách nơi sản xuất
        public async Task<IActionResult> ListManufacturer()
        {
            var manufacturers = await GetApiDataAsync<List<ManufacturerViewModel>>("https://localhost:44370/Product/GetManufacturers");
            return View(manufacturers);
        }

        // Danh sách loại sản phẩm
        public async Task<IActionResult> ListProductType()
        {
            var productTypes = await GetApiDataAsync<List<ProductTypeViewModel>>("https://localhost:44370/Product/GetProductTypes");
            return View(productTypes);
        }
    }
}
