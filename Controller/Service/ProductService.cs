using Controller.DTO;
using Controller.Models;
using DemoBanQuanAo.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBanQuanAo.Service
{
    public class ProductService
    {
        private readonly DbContextShop _dbContext;

        public ProductService(DbContextShop context)
        {
            _dbContext = context;
        }
        public List<MaterialDto> GetMaterials()
        {
            var materials = _dbContext.Material.ToList();
            var materialDtos = materials.Select(m => new MaterialDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
                TrangThai = m.TrangThai,
                NgayTao = m.NgayTao,
                NgayCapNhat = m.NgayCapNhat
            }).ToList();
            return materialDtos;
        }
        public bool SetMaterial(Material material)
        {
            try
            {
                if (string.IsNullOrEmpty(material.Id))
                {
                    // Kiểm tra mã sản phẩm có trùng không
                    var findMa = _dbContext.Material.FirstOrDefault(x => x.Ma == material.Ma);
                    if (findMa == null)
                    {
                        // Tạo mới Material
                        material.Id = Guid.NewGuid().ToString(); // Sinh ID mới
                        material.NgayTao = DateTime.Now;
                        material.NgayCapNhat = DateTime.Now;
                        _dbContext.Material.Add(material);
                    }
                    else
                    {
                        // Nếu trùng mã, trả về false
                        return false;
                    }
                }
                else
                {
                    // Nếu có Id, tìm kiếm Material và cập nhật
                    var findMaterial = _dbContext.Material.FirstOrDefault(x => x.Id == material.Id);
                    if (findMaterial != null)
                    {
                        // Cập nhật các trường
                        findMaterial.Ten = material.Ten;
                        findMaterial.NgayCapNhat = DateTime.Now;
                        findMaterial.TrangThai = material.TrangThai;
                        _dbContext.Material.Update(findMaterial);
                    }
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public bool DeleteMaterial(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findMaterial = _dbContext.Material.Find(item);
                    if (findMaterial != null)
                    {
                        _dbContext.Material.Remove(findMaterial); // Xóa mục nếu tìm thấy
                    }
                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }

        public List<ProductTypeDto> GetProductTypes()
        {
            var ProductTypes = _dbContext.ProductType.ToList();
            var ProductTypeDtos = ProductTypes.Select(m => new ProductTypeDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
                TrangThai = m.TrangThai,
                NgayTao = m.NgayTao,
                NgayCapNhat = m.NgayCapNhat
            }).ToList();
            return ProductTypeDtos;
        }
        public bool SetProductType(ProductType ProductType)
        {
            try
            {

                var findProductType = _dbContext.ProductType.FirstOrDefault(x => x.Id == ProductType.Id);
                if (findProductType == null)
                {
                    var findMa = _dbContext.ProductType.FirstOrDefault(x => x.Ma == ProductType.Ma);
                    if (findMa == null)
                    {
                        ProductType.Id = Guid.NewGuid().ToString();
                        ProductType.NgayTao = DateTime.Now;
                        ProductType.NgayCapNhat = DateTime.Now;
                        _dbContext.ProductType.Add(ProductType);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    findProductType.Ten = ProductType.Ten;
                    findProductType.NgayCapNhat = DateTime.Now;
                    findProductType.TrangThai = ProductType.TrangThai;
                    _dbContext.ProductType.Update(findProductType);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public bool DeleteProductType(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findProductType = _dbContext.ProductType.Find(item);
                    if (findProductType != null)
                    {
                        _dbContext.ProductType.Remove(findProductType); // Xóa mục nếu tìm thấy
                    }
                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }

        public List<BrandDto> GetBrands()
        {
            var Brands = _dbContext.Brand.ToList();
            var BrandDtos = Brands.Select(m => new BrandDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
                TrangThai = m.TrangThai,
                NgayTao = m.NgayTao,
                NgayCapNhat = m.NgayCapNhat
            }).ToList();
            return BrandDtos;
        }
        public bool SetBrand(Brand Brand)
        {
            try
            {

                var findBrand = _dbContext.Brand.FirstOrDefault(x => x.Id == Brand.Id);
                if (findBrand == null)
                {
                    var findMa = _dbContext.Brand.FirstOrDefault(x => x.Ma == Brand.Ma);
                    if (findMa == null)
                    {
                        Brand.Id = Guid.NewGuid().ToString();
                        Brand.NgayTao = DateTime.Now;
                        Brand.NgayCapNhat = DateTime.Now;
                        _dbContext.Brand.Add(Brand);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    findBrand.Ten = Brand.Ten;
                    findBrand.NgayCapNhat = DateTime.Now;
                    findBrand.TrangThai = Brand.TrangThai;
                    _dbContext.Brand.Update(findBrand);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public bool DeleteBrand(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findBrand = _dbContext.Brand.Find(item);
                    if (findBrand != null)
                    {
                        _dbContext.Brand.Remove(findBrand); // Xóa mục nếu tìm thấy
                    }
                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }

        public List<ManufacturerDto> GetManufacturers()
        {
            var Manufacturers = _dbContext.Manufacturer.ToList();
            var ManufacturerDtos = Manufacturers.Select(m => new ManufacturerDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
                TrangThai = m.TrangThai,
                NgayTao = m.NgayTao,
                NgayCapNhat = m.NgayCapNhat
            }).ToList();
            return ManufacturerDtos;
        }
        public bool SetManufacturer(Manufacturer Manufacturer)
        {
            try
            {

                var findManufacturer = _dbContext.Manufacturer.FirstOrDefault(x => x.Id == Manufacturer.Id);
                if (findManufacturer == null)
                {
                    var findMa = _dbContext.Manufacturer.FirstOrDefault(x => x.Ma == Manufacturer.Ma);
                    if (findMa == null)
                    {
                        Manufacturer.Id = Guid.NewGuid().ToString();
                        Manufacturer.NgayTao = DateTime.Now;
                        Manufacturer.NgayCapNhat = DateTime.Now;
                        _dbContext.Manufacturer.Add(Manufacturer);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    findManufacturer.Ten = Manufacturer.Ten;
                    findManufacturer.NgayCapNhat = DateTime.Now;
                    findManufacturer.TrangThai = Manufacturer.TrangThai;
                    _dbContext.Manufacturer.Update(findManufacturer);
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public bool DeleteManufacturer(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findManufacturer = _dbContext.Manufacturer.Find(item);
                    if (findManufacturer != null)
                    {
                        _dbContext.Manufacturer.Remove(findManufacturer); // Xóa mục nếu tìm thấy
                    }
                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _dbContext.Product
                .Include(p => p.ProductType)          // Bao gồm ProductType
                .Include(p => p.Brand)                 // Bao gồm Brand
                .Include(p => p.Manufacturer)          // Bao gồm Manufacturer
                .Include(p => p.Material)              // Bao gồm Material
                .Include(p => p.ProductImages)         // Bao gồm ProductImages
                .ToList();

            var result = products.Select(p => new ProductDto
            {
                Id = p.Id.ToString(),
                MaSanPham = p.Ma,
                TenSanPham = p.Ten,
                GiaSanPham = p.Gia,
                NamSanXuat = p.NamSX,
                MoTa = p.MoTa,
                LoaiSanPham = p.ProductType != null ? p.ProductType.Ten : null,
                Brand = p.Brand != null ? p.Brand.Ten : null,
                NhaSanXuat = p.Manufacturer != null ? p.Manufacturer.Ten : null,
                TenVatLieu = p.Material != null ? p.Material.Ten : null,
                IdLoaiSanPham = p.ProductType != null ? p.ProductType.Id.ToString() : null,
                IdBrand = p.Brand != null ? p.Brand.Id.ToString() : null,
                IdNhaSanXuat = p.Manufacturer != null ? p.Manufacturer.Id.ToString() : null,
                IdVatLieu = p.Material != null ? p.Material.Id.ToString() : null,
                HinhAnh = p.ProductImages != null ? p.ProductImages.Select(pi => pi.ImageUrl).ToList() : new List<string>()
            }).ToList();

            return result;
        }
        public IEnumerable<ProductDto> GetProductsById(string productId)
        {
            var result = _dbContext.Product
                .Where(p => p.Id.Contains(productId))
                .Select(p => new ProductDto
                {
                    Id = p.Id.ToString(),
                    MaSanPham = p.Ma,
                    TenSanPham = p.Ten,
                    GiaSanPham = p.Gia,
                    NamSanXuat = p.NamSX,
                    MoTa = p.MoTa,
                    LoaiSanPham = p.ProductType.Ten,
                    Brand = p.Brand.Ten,
                    NhaSanXuat = p.Manufacturer.Ten,
                    TenVatLieu = p.Material.Ten,
                    IdLoaiSanPham = p.ProductType.Id.ToString(),
                    IdBrand = p.Brand.Id.ToString(),
                    IdNhaSanXuat = p.Manufacturer.Id.ToString(),
                    IdVatLieu = p.Material.Id.ToString(),
                })
                .ToList();

            return result;
        }
        public void SetProductImages(string productId, List<string> imageUrls)
        {
            // Lấy danh sách ảnh hiện tại của sản phẩm
            var existingImages = _dbContext.ProductImage.Where(img => img.ProductId == productId).ToList();

            // Xóa các ảnh không còn trong danh sách mới
            foreach (var existingImage in existingImages)
            {
                if (!imageUrls.Contains(existingImage.ImageUrl))
                {
                    _dbContext.ProductImage.Remove(existingImage);
                }
            }

            // Thêm các ảnh mới chưa có trong danh sách hiện tại
            foreach (var imageUrl in imageUrls)
            {
                // Nếu ảnh không tồn tại, thêm mới
                if (!existingImages.Any(img => img.ImageUrl == imageUrl))
                {
                    var productImage = new ProductImage
                    {
                        Id = Guid.NewGuid().ToString(), // Tạo ID cho ảnh mới
                        ImageUrl = imageUrl,
                        ProductId = productId // Gán ProductId cho ảnh
                    };
                    _dbContext.ProductImage.Add(productImage);
                }
                else
                {
                    // Nếu cần, cập nhật ảnh hiện tại (nếu có thuộc tính nào cần cập nhật)
                    var existingImage = existingImages.First(img => img.ImageUrl == imageUrl);
                    // Ở đây bạn có thể thêm logic cập nhật nếu cần thiết
                    // Ví dụ: existingImage.PropertyName = newValue;
                }
            }

            _dbContext.SaveChanges(); // Lưu tất cả thay đổi vào cơ sở dữ liệu
        }

        public string SetProduct(Product Product, List<string> imageUrls)
        {
            try
            {
                // Kiểm tra xem có bất kỳ giá trị nào là chuỗi rỗng và gán giá trị null nếu cần
                var findProduct = _dbContext.Product.FirstOrDefault(x => x.Id == Product.Id);
                if (findProduct == null)
                {
                    var findMa = _dbContext.Product.FirstOrDefault(x => x.Ma == Product.Ma);
                    if (findMa == null)
                    {
                        Product.Id = Guid.NewGuid().ToString();
                        Product.BrandId = string.IsNullOrEmpty(Product.BrandId) ? null : Product.BrandId;
                        Product.ProductTypeId = string.IsNullOrEmpty(Product.ProductTypeId) ? null : Product.ProductTypeId;
                        Product.ManufacturerId = string.IsNullOrEmpty(Product.ManufacturerId) ? null : Product.ManufacturerId;
                        _dbContext.Product.Add(Product);
                        // Gọi hàm thêm ảnh sau khi thêm sản phẩm
                        SetProductImages(Product.Id, imageUrls);
                        return "Thêm sản phẩm thành công!";
                    }
                    else
                    {
                        // Nếu trùng mã, trả về thông báo
                        return "Trùng mã sản phẩm!";
                    }
                }
                else
                {

                    findProduct.Ten = Product.Ten;
                    findProduct.Gia = Product.Gia;
                    findProduct.NamSX = Product.NamSX;
                    findProduct.MoTa = Product.MoTa;
                    //findProduct.ProductTypeId = Product.ProductTypeId;
                    //findProduct.BrandId = Product.BrandId;
                    //findProduct.ManufacturerId = Product.ManufacturerId;
                    // Chỉ cập nhật khi không null hoặc không rỗng
                    if (!string.IsNullOrEmpty(Product.ProductTypeId))
                    {
                        findProduct.ProductTypeId = Product.ProductTypeId;
                    }
                    else
                    {
                        findProduct.ProductTypeId = null; // Hoặc không làm gì nếu bạn muốn giữ giá trị cũ
                    }

                    if (!string.IsNullOrEmpty(Product.BrandId))
                    {
                        findProduct.BrandId = Product.BrandId;
                    }
                    else
                    {
                        findProduct.BrandId = null; // Hoặc không làm gì nếu bạn muốn giữ giá trị cũ
                    }

                    if (!string.IsNullOrEmpty(Product.ManufacturerId))
                    {
                        findProduct.ManufacturerId = Product.ManufacturerId;
                    }
                    else
                    {
                        findProduct.ManufacturerId = null; // Hoặc không làm gì nếu bạn muốn giữ giá trị cũ
                    }
                    findProduct.MaterialId = Product.MaterialId;
                    // Cập nhật ảnh
                    SetProductImages(findProduct.Id, imageUrls);
                    _dbContext.Product.Update(findProduct);
                    return "Thêm sản phẩm thành công!";
                }
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public bool DeleteProduct(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findProduct = _dbContext.Product.Find(item);
                    if (findProduct != null)
                    {
                        _dbContext.Product.Remove(findProduct); // Xóa mục nếu tìm thấy
                    }
                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }


    }
}
