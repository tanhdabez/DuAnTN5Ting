using Controller.DTO;
using DemoBanQuanAo.Models;
using DemoBanQuanAo.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Controller.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        //Material

        [HttpGet("GetMaterials")]
        public ActionResult<List<MaterialDto>> GetMaterials()
        {
            try
            {
                var materialDtos = _productService.GetMaterials();
                return Ok(materialDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
        [HttpPost("SetMaterial")]
        public async Task<ActionResult<MaterialDto>> SetMaterial([FromBody] MaterialDto materialDto)
        {
            // Tạo hoặc cập nhật material
            var material = new Material
            {
                Id = materialDto.Id,
                Ma = materialDto.Ma,
                Ten = materialDto.Ten,
                TrangThai = materialDto.TrangThai,
                NgayTao = materialDto.NgayTao,
                NgayCapNhat = materialDto.NgayCapNhat,
            };

            var result = _productService.SetMaterial(material);

            // Chuyển đổi lại Material sang MaterialDto
            return Ok(result);
        }

        [HttpPost("DeleteMaterial")]
        public async Task<IActionResult> DeleteMaterial([FromBody] List<string> id)
        {
            var result = _productService.DeleteMaterial(id);
            return Ok(result);
        }

        //ProductType

        [HttpGet("GetProductTypes")]
        public ActionResult<List<ProductTypeDto>> GetProductTypes()
        {
            try
            {
                var ProductTypeDtos = _productService.GetProductTypes();
                return Ok(ProductTypeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
        [HttpPost("SetProductType")]
        public async Task<ActionResult<ProductTypeDto>> SetProductType([FromBody] ProductTypeDto ProductTypeDto)
        {
            // Tạo hoặc cập nhật ProductType
            var ProductType = new ProductType
            {
                Id = ProductTypeDto.Id, // Nếu Id là rỗng, tạo ID mới
                Ma = ProductTypeDto.Ma,
                Ten = ProductTypeDto.Ten,
                TrangThai = ProductTypeDto.TrangThai,
                NgayTao = ProductTypeDto.NgayTao,
                NgayCapNhat = ProductTypeDto.NgayCapNhat,
            };

            var result = _productService.SetProductType(ProductType);

            // Chuyển đổi lại ProductType sang ProductTypeDto
            return Ok(result);
        }

        [HttpPost("DeleteProductType")]
        public async Task<IActionResult> DeleteProductType([FromBody] List<string> id)
        {
            var result = _productService.DeleteProductType(id);
            return Ok(result);
        }

        //Brand

        [HttpGet("GetBrands")]
        public ActionResult<List<BrandDto>> GetBrands()
        {
            try
            {
                var BrandDtos = _productService.GetBrands();
                return Ok(BrandDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
        [HttpPost("SetBrand")]
        public async Task<ActionResult<BrandDto>> SetBrand([FromBody] BrandDto BrandDto)
        {
            // Tạo hoặc cập nhật Brand
            var Brand = new Brand
            {
                Id = BrandDto.Id, // Nếu Id là rỗng, tạo ID mới
                Ma = BrandDto.Ma,
                Ten = BrandDto.Ten,
                TrangThai = BrandDto.TrangThai,
                NgayTao = BrandDto.NgayTao,
                NgayCapNhat = BrandDto.NgayCapNhat,
            };

            var result = _productService.SetBrand(Brand);

            // Chuyển đổi lại Brand sang BrandDto
            return Ok(result);
        }

        [HttpPost("DeleteBrand")]
        public async Task<IActionResult> DeleteBrand([FromBody] List<string> id)
        {
            var result = _productService.DeleteBrand(id);
            return Ok(result);
        }

        //Manufacturer

        [HttpGet("GetManufacturers")]
        public ActionResult<List<ManufacturerDto>> GetManufacturers()
        {
            try
            {
                var ManufacturerDtos = _productService.GetManufacturers();
                return Ok(ManufacturerDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
        [HttpPost("SetManufacturer")]
        public async Task<ActionResult<ManufacturerDto>> SetManufacturer([FromBody] ManufacturerDto ManufacturerDto)
        {
            // Tạo hoặc cập nhật Manufacturer
            var Manufacturer = new Manufacturer
            {
                Id = ManufacturerDto.Id, // Nếu Id là rỗng, tạo ID mới
                Ma = ManufacturerDto.Ma,
                Ten = ManufacturerDto.Ten,
                TrangThai = ManufacturerDto.TrangThai,
                NgayTao = ManufacturerDto.NgayTao,
                NgayCapNhat = ManufacturerDto.NgayCapNhat,
            };

            var result = _productService.SetManufacturer(Manufacturer);

            // Chuyển đổi lại Manufacturer sang ManufacturerDto
            return Ok(result);
        }

        [HttpPost("DeleteManufacturer")]
        public async Task<IActionResult> DeleteManufacturer([FromBody] List<string> id)
        {
            var result = _productService.DeleteManufacturer(id);
            return Ok(result);
        }

        //Product

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _productService.GetProducts();
                if (!products.Any())
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetProductsById")]
        public IActionResult GetProductsById(string id)
        {
            try
            {
                var products = _productService.GetProductsById(id);
                if (!products.Any())
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("SetProduct")]
        public async Task<ActionResult<ProductDto>> SetProduct([FromBody] ProductDto ProductDto)
        {
            // Tạo hoặc cập nhật Product
            var product = new Product
            {
                Id = ProductDto.Id, // Nếu IdSanPham trống, tạo ID mới
                Ma = ProductDto.MaSanPham,
                Ten = ProductDto.TenSanPham,
                Gia = ProductDto.GiaSanPham,
                NamSX = ProductDto.NamSanXuat,
                MoTa = ProductDto.MoTa,
                ProductTypeId = ProductDto.IdLoaiSanPham ?? null,
                BrandId = ProductDto.IdBrand ?? null,
                ManufacturerId = ProductDto.IdNhaSanXuat ?? null,
                MaterialId = ProductDto.IdVatLieu ?? null
            };

            var result = _productService.SetProduct(product, ProductDto.HinhAnh, ProductDto.SoLuong, ProductDto.ColorId, ProductDto.SizeId );
            return Ok(result);
        }

        [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] List<string> id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }

        //Color
        [HttpPost("SetColor")]
        public async Task<ActionResult<ColorDto>> SetColor([FromBody] ColorDto ColorDto)
        {
            // Tạo hoặc cập nhật Color
            var Color = new Color
            {
                Id = ColorDto.Id, // Nếu Id là rỗng, tạo ID mới
                Ma = ColorDto.Ma,
                Ten = ColorDto.Ten,

            };

            var result = _productService.SetColor(Color);

            // Chuyển đổi lại Color sang ColorDto
            return Ok(result);
        }
        [HttpGet("GetColors")]
        public ActionResult<List<ColorDto>> GetColors()
        {
            try
            {
                var ColorDtos = _productService.GetColors();
                return Ok(ColorDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
        //Size
        [HttpPost("SetSize")]
        public async Task<ActionResult<SizeDto>> SetSize([FromBody] SizeDto SizeDto)
        {
            // Tạo hoặc cập nhật Size
            var Size = new Size
            {
                Id = SizeDto.Id, // Nếu Id là rỗng, tạo ID mới
                Ma = SizeDto.Ma,
                Ten = SizeDto.Ten,

            };

            var result = _productService.SetSize(Size);

            // Chuyển đổi lại Size sang SizeDto
            return Ok(result);
        }
        [HttpGet("GetSizes")]
        public ActionResult<List<SizeDto>> GetSizes()
        {
            try
            {
                var SizeDtos = _productService.GetSizes();
                return Ok(SizeDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi xảy ra: {ex.Message}");
            }
        }
    }
}
