using Controller.DTO;
using Controller.Models;
using DemoBanQuanAo.Models;
using Microsoft.EntityFrameworkCore;

namespace Controller.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContextShop _context;

        public CustomerService(DbContextShop context)
        {
            _context = context;
        }

        public async Task<bool> AddCustomer(CustomerDto customerDto)
        {
            customerDto.Id = Guid.NewGuid().ToString();
            var customer = new Customer
            {
                Id = customerDto.Id,
                Ma = customerDto.Ma,
                Ten = customerDto.Ten,
                Anh = customerDto.Anh,
                GioiTinh = customerDto.GioiTinh,
                NgaySinh = customerDto.NgaySinh,
                MatKhau = customerDto.MatKhau,
                SDT = customerDto.SDT,
                Email = customerDto.Email,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now,
                TrangThai = customerDto.TrangThai,

                Addresses = customerDto.Address.Select(a => new Address
                {
                    Id = Guid.NewGuid().ToString(),
                    TenPhuongXa = a.TenPhuongXa,
                    TenQuanHuyen = a.TenQuanHuyen,
                    TenTinh = a.TenTinh,
                    IsPrimary = a.IsPrimary
                }).ToList()
            };
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(string Id)
        {
            var customer = await _context.Customer.Include(c => c.Addresses)
                                       .FirstOrDefaultAsync(c => c.Id == Id);
            if (customer == null)
            {
                return false;
            }

            if (customer.Addresses != null && customer.Addresses.Any())
            {
                _context.Address.RemoveRange(customer.Addresses);
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<CustomerDto>> GetAllCustomer()
        {
            return await _context.Customer.Include(c => c.Addresses)
                                            .Select(c => new CustomerDto
                                            {
                                                Id = c.Id,
                                                Ma = c.Ma,
                                                Ten = c.Ten,
                                                Anh = c.Anh,
                                                GioiTinh = c.GioiTinh,
                                                NgaySinh = c.NgaySinh,
                                                MatKhau = c.MatKhau,
                                                SDT = c.SDT,
                                                Email = c.Email,
                                                TrangThai = c.TrangThai,

                                                Address = c.Addresses.Select(a => new AddressDto
                                                {
                                                    Id = a.Id,
                                                    TenPhuongXa = a.TenPhuongXa,
                                                    TenQuanHuyen = a.TenQuanHuyen,
                                                    TenTinh = a.TenTinh,
                                                    IsPrimary = a.IsPrimary
                                                }).ToList()
                                            })
                                            .ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerById(string Id)
        {
            var customer = await _context.Customer.Include(c => c.Addresses)
                                                   .FirstOrDefaultAsync(c => c.Id == Id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerDto
            {
                Id = customer.Id,
                Ma = customer.Ma,
                Ten = customer.Ten,
                Anh = customer.Anh,
                GioiTinh = customer.GioiTinh,
                NgaySinh = customer.NgaySinh,
                MatKhau = customer.MatKhau,
                SDT = customer.SDT,
                Email = customer.Email,
                TrangThai = customer.TrangThai,
                Address = customer.Addresses.Select(a => new AddressDto
                {
                    Id = a.Id,
                    TenPhuongXa = a.TenPhuongXa,
                    TenQuanHuyen = a.TenQuanHuyen,
                    TenTinh = a.TenTinh,
                    IsPrimary = a.IsPrimary
                }).ToList()
            };
        }

        public async Task<bool> UpdateCustomer(string Id, CustomerDto updatedCustomer)
        {
            var Ecustomer = await _context.Customer.Include(c => c.Addresses)
                                               .FirstOrDefaultAsync(c => c.Id == Id);

            if (Ecustomer == null)
            {
                return false;
            }
            Ecustomer.Ma = updatedCustomer.Ma;
            Ecustomer.Ten = updatedCustomer.Ten;
            Ecustomer.Anh = updatedCustomer.Anh;
            Ecustomer.GioiTinh = updatedCustomer.GioiTinh;
            Ecustomer.NgaySinh = updatedCustomer.NgaySinh;
            Ecustomer.MatKhau = updatedCustomer.MatKhau;
            Ecustomer.SDT = updatedCustomer.SDT;
            Ecustomer.Email = updatedCustomer.Email;
            Ecustomer.TrangThai = updatedCustomer.TrangThai;
            _context.Address.RemoveRange(Ecustomer.Addresses);

            Ecustomer.Addresses = updatedCustomer.Address.Select(a => new Address
            {
                Id = Guid.NewGuid().ToString(),
                TenPhuongXa = a.TenPhuongXa,
                TenQuanHuyen = a.TenQuanHuyen,
                TenTinh = a.TenTinh,
                IsPrimary = a.IsPrimary
            }).ToList();

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
