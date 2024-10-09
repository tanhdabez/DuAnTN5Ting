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

        public string SetProduct(Product product, List<string> imageUrls, List<int> quantities, List<string> colorIds, List<string> sizeIds)
        {
            try
            {
                // Kiểm tra nếu kích thước của quantities, colorIds và sizeIds không khớp
                if (quantities.Count != colorIds.Count || quantities.Count != sizeIds.Count)
                {
                    return "Số lượng không khớp với số sự kết hợp màu sắc và kích thước.";
                }

                var findProduct = _dbContext.Product.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);

                if (findProduct == null)
                {
                    var findMa = _dbContext.Product.FirstOrDefault(x => x.Ma == product.Ma);

                    if (findMa == null)
                    {
                        // Thêm mới sản phẩm nếu không tìm thấy sản phẩm có Id và mã
                        product.Id = Guid.NewGuid().ToString();
                        product.BrandId = string.IsNullOrEmpty(product.BrandId) ? null : product.BrandId;
                        product.ProductTypeId = string.IsNullOrEmpty(product.ProductTypeId) ? null : product.ProductTypeId;
                        product.ManufacturerId = string.IsNullOrEmpty(product.ManufacturerId) ? null : product.ManufacturerId;

                        _dbContext.Product.Add(product);
                        SetProductImages(product.Id, imageUrls);

                        // Thêm ProductDetails cho các màu sắc, kích thước và số lượng
                        for (int i = 0; i < quantities.Count; i++)
                        {
                            var productDetail = new ProductDetail
                            {
                                Id = Guid.NewGuid().ToString(),
                                ProductId = product.Id,
                                SoLuong = quantities[i], // Số lượng tương ứng
                                NgayTao = DateTime.Now,
                                NgayCapNhat = DateTime.Now,
                                TrangThai = quantities[i] > 0 ? "Còn hàng" : "Hết hàng"
                            };

                            _dbContext.ProductDetail.Add(productDetail);

                            // Thêm màu sắc cho ProductDetail
                            var productDetailColor = new ProductDetailColor
                            {
                                Id = Guid.NewGuid().ToString(),
                                ProductDetailId = productDetail.Id,
                                ColorId = colorIds[i] // Màu sắc tương ứng
                            };
                            _dbContext.ProductDetailColor.Add(productDetailColor);

                            // Thêm kích thước cho ProductDetail
                            var productDetailSize = new ProductDetailSize
                            {
                                Id = Guid.NewGuid().ToString(),
                                ProductDetailId = productDetail.Id,
                                SizeId = sizeIds[i] // Kích thước tương ứng
                            };
                            _dbContext.ProductDetailSize.Add(productDetailSize);
                        }
                    }
                    else
                    {
                        return "Trùng mã sản phẩm!";
                    }
                }
                else
                {
                    // Cập nhật sản phẩm nếu đã tồn tại
                    findProduct.Ten = product.Ten;
                    findProduct.Gia = product.Gia;
                    findProduct.NamSX = product.NamSX;
                    findProduct.MoTa = product.MoTa;
                    findProduct.ProductTypeId = string.IsNullOrEmpty(product.ProductTypeId) ? null : product.ProductTypeId;
                    findProduct.BrandId = string.IsNullOrEmpty(product.BrandId) ? null : product.BrandId;
                    findProduct.ManufacturerId = string.IsNullOrEmpty(product.ManufacturerId) ? null : product.ManufacturerId;
                    findProduct.MaterialId = product.MaterialId;

                    SetProductImages(findProduct.Id, imageUrls);

                    // Cập nhật hoặc thêm ProductDetails
                    var existingDetails = _dbContext.ProductDetail.Where(pd => pd.ProductId == findProduct.Id).ToList();
                    var existingDetailIds = existingDetails.Select(ed => ed.Id).ToList();

                    for (int i = 0; i < quantities.Count; i++)
                    {
                        // Tìm ProductDetail dựa trên ProductId, ColorId và SizeId
                        var existingDetail = existingDetails.FirstOrDefault(pd =>
                            pd.ProductId == product.Id &&
                            _dbContext.ProductDetailColor.Any(pdc => pdc.ProductDetailId == pd.Id && pdc.ColorId == colorIds[i]) &&
                            _dbContext.ProductDetailSize.Any(pds => pds.ProductDetailId == pd.Id && pds.SizeId == sizeIds[i])
                        );

                        if (existingDetail != null)
                        {
                            // Cập nhật số lượng và trạng thái cho ProductDetail đã tồn tại
                            existingDetail.NgayCapNhat = DateTime.Now;
                            existingDetail.SoLuong = quantities[i];
                            existingDetail.TrangThai = quantities[i] > 0 ? "Còn hàng" : "Hết hàng";

                            _dbContext.ProductDetail.Update(existingDetail);
                        }
                        else
                        {
                            // Thêm ProductDetail mới nếu không tìm thấy
                            var productDetail = new ProductDetail
                            {
                                Id = Guid.NewGuid().ToString(),
                                ProductId = findProduct.Id,
                                SoLuong = quantities[i],
                                NgayTao = DateTime.Now,
                                NgayCapNhat = DateTime.Now,
                                TrangThai = quantities[i] > 0 ? "Còn hàng" : "Hết hàng"
                            };

                            _dbContext.ProductDetail.Add(productDetail);
                            _dbContext.SaveChanges(); // Lưu trước khi thêm màu sắc và kích thước

                            // Thêm màu sắc và kích thước mới
                            AddProductDetailColor(productDetail.Id, colorIds[i]);
                            AddProductDetailSize(productDetail.Id, sizeIds[i]);
                        }
                    }

                }
                _dbContext.SaveChanges();

                return findProduct == null ? "Thêm sản phẩm thành công!" : "Cập nhật sản phẩm thành công!";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        // Hàm để cập nhật màu sắc cho ProductDetail
        private void UpdateProductDetailColor(string productDetailId, string colorId)
        {
            var existingColor = _dbContext.ProductDetailColor.FirstOrDefault(pdc => pdc.ProductDetailId == productDetailId && pdc.ColorId == colorId);
            if (existingColor == null)
            {
                _dbContext.ProductDetailColor.Add(new ProductDetailColor
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductDetailId = productDetailId,
                    ColorId = colorId
                });
            }
        }

        // Hàm để cập nhật kích thước cho ProductDetail
        private void UpdateProductDetailSize(string productDetailId, string sizeId)
        {
            var existingSize = _dbContext.ProductDetailSize.FirstOrDefault(pds => pds.ProductDetailId == productDetailId && pds.SizeId == sizeId);
            if (existingSize == null)
            {
                _dbContext.ProductDetailSize.Add(new ProductDetailSize
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductDetailId = productDetailId,
                    SizeId = sizeId
                });
            }
        }

        // Hàm để thêm màu sắc cho ProductDetail
        private void AddProductDetailColor(string productDetailId, string colorId)
        {
            _dbContext.ProductDetailColor.Add(new ProductDetailColor
            {
                Id = Guid.NewGuid().ToString(),
                ProductDetailId = productDetailId,
                ColorId = colorId
            });
        }

        // Hàm để thêm kích thước cho ProductDetail
        private void AddProductDetailSize(string productDetailId, string sizeId)
        {
            _dbContext.ProductDetailSize.Add(new ProductDetailSize
            {
                Id = Guid.NewGuid().ToString(),
                ProductDetailId = productDetailId,
                SizeId = sizeId
            });
        }
        public bool DeleteProduct(List<string> id)
        {
            try
            {
                foreach (var item in id)
                {
                    var findProduct = _dbContext.Product.Where(x=>x.Id == item).ToList();
                    var image = _dbContext.ProductImage.Where(x=> x.ProductId == item).ToList();
                    var productdetail = _dbContext.ProductDetail.Where(x=>x.ProductId==item).ToList();
                    foreach (var pdt in productdetail)
                    {
                        var productdetailcolor = _dbContext.ProductDetailColor.Where(x => x.ProductDetailId == pdt.Id).ToList();
                        var productdetailsize = _dbContext.ProductDetailSize.Where(x => x.ProductDetailId == pdt.Id).ToList();
                        _dbContext.RemoveRange(productdetailcolor);
                        _dbContext.RemoveRange(productdetailsize);
                    }
                    _dbContext.RemoveRange(findProduct);
                    _dbContext.RemoveRange(image);
                    _dbContext.RemoveRange(productdetail);
                    _dbContext.SaveChanges();

                }
                _dbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }

        public bool SetProductDetail(ProductDetail productDetail, List<string> colorIds, List<string> sizeIds)
        {
            try
            {
                var findProductDetail = _dbContext.ProductDetail.FirstOrDefault(x => x.Id == productDetail.Id);
                var existingDetailColors = _dbContext.ProductDetailColor
                                                        .Where(x => x.ProductDetailId == productDetail.Id)
                                                        .ToList();
                var existingDetailSizes = _dbContext.ProductDetailSize
                                                       .Where(x => x.ProductDetailId == productDetail.Id)
                                                       .ToList();

                if (findProductDetail == null)
                {
                    // Nếu chưa tồn tại, thêm ProductDetail mới
                    productDetail.Id = Guid.NewGuid().ToString();
                    productDetail.NgayTao = DateTime.Now;
                    productDetail.NgayCapNhat = DateTime.Now;

                    _dbContext.ProductDetail.Add(productDetail);

                    // Thêm mới mối quan hệ giữa ProductDetail và Color
                    foreach (var colorId in colorIds)
                    {
                        var productDetailColor = new ProductDetailColor
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductDetailId = productDetail.Id,
                            ColorId = colorId
                        };
                        _dbContext.ProductDetailColor.Add(productDetailColor);
                    }

                    // Thêm mới mối quan hệ giữa ProductDetail và Size
                    foreach (var sizeId in sizeIds)
                    {
                        var productDetailSize = new ProductDetailSize
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductDetailId = productDetail.Id,
                            SizeId = sizeId
                        };
                        _dbContext.ProductDetailSize.Add(productDetailSize);
                    }
                }
                else
                {
                    // Nếu ProductDetail đã tồn tại, cập nhật thông tin
                    findProductDetail.SoLuong = productDetail.SoLuong;
                    findProductDetail.NgayCapNhat = DateTime.Now;

                    // Cập nhật trạng thái dựa trên số lượng sản phẩm
                    findProductDetail.TrangThai = findProductDetail.SoLuong > 0 ? "Còn hàng" : "Hết hàng";

                    // Cập nhật màu sắc
                    var colorsToAdd = colorIds.Except(existingDetailColors.Select(x => x.ColorId)).ToList();
                    var colorsToRemove = existingDetailColors.Where(x => !colorIds.Contains(x.ColorId)).ToList();

                    _dbContext.ProductDetailColor.RemoveRange(colorsToRemove);
                    foreach (var colorId in colorsToAdd)
                    {
                        var productDetailColor = new ProductDetailColor
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductDetailId = findProductDetail.Id,
                            ColorId = colorId
                        };
                        _dbContext.ProductDetailColor.Add(productDetailColor);
                    }

                    // Cập nhật kích thước
                    var sizesToAdd = sizeIds.Except(existingDetailSizes.Select(x => x.SizeId)).ToList();
                    var sizesToRemove = existingDetailSizes.Where(x => !sizeIds.Contains(x.SizeId)).ToList();

                    _dbContext.ProductDetailSize.RemoveRange(sizesToRemove);
                    foreach (var sizeId in sizesToAdd)
                    {
                        var productDetailSize = new ProductDetailSize
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductDetailId = findProductDetail.Id,
                            SizeId = sizeId
                        };
                        _dbContext.ProductDetailSize.Add(productDetailSize);
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

        //Màu
        public bool SetColor(Color color)
        {
            try
            {
                var findColor = _dbContext.Color.FirstOrDefault(x => x.Id == color.Id);
                if (findColor == null)
                {
                    color.Id = Guid.NewGuid().ToString();
                    _dbContext.Color.Add(color);
                    _dbContext.SaveChanges();

                }
                else
                {
                    findColor.Ten = color.Ten;
                    _dbContext.Color.Update(color);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public List<ColorDto> GetColors()
        {
            var Colors = _dbContext.Color.ToList();
            var ColorDtos = Colors.Select(m => new ColorDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
            }).ToList();
            return ColorDtos;
        }
        //Size
        public bool SetSize(Size Size)
        {
            try
            {
                var findSize = _dbContext.Size.FirstOrDefault(x => x.Id == Size.Id);
                if (findSize == null)
                {
                    Size.Id = Guid.NewGuid().ToString();
                    _dbContext.Size.Add(Size);
                    _dbContext.SaveChanges();

                }
                else
                {
                    findSize.Ten = Size.Ten;
                    _dbContext.Size.Update(Size);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xảy ra: {ex.Message}", ex);
            }
        }
        public List<SizeDto> GetSizes()
        {
            var Sizes = _dbContext.Size.ToList();
            var SizeDtos = Sizes.Select(m => new SizeDto
            {
                Id = m.Id.ToString(),
                Ma = m.Ma,
                Ten = m.Ten,
            }).ToList();
            return SizeDtos;
        }
    }
}
