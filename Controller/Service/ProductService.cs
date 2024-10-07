using Controller.DTO;
using DemoBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;

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

                var findMaterial = _dbContext.Material.FirstOrDefault(x => x.Id == material.Id);
                if (findMaterial == null)
                {
                    var findMa = _dbContext.Material.FirstOrDefault(x => x.Ma == material.Ma);
                    if (findMa == null)
                    {
                        material.Id = Guid.NewGuid().ToString();
                        material.NgayTao = DateTime.Now;
                        material.NgayCapNhat = DateTime.Now;
                        _dbContext.Material.Add(material);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    findMaterial.Ten = material.Ten;
                    findMaterial.NgayCapNhat = DateTime.Now;
                    findMaterial.TrangThai = material.TrangThai;
                    _dbContext.Material.Update(findMaterial);
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
            var result = _dbContext.Product
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
        public bool SetProduct(Product Product)
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
                    }
                    else
                    {
                        return false;
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
                    _dbContext.Product.Update(findProduct);
                }
                _dbContext.SaveChanges();
                return true;
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
