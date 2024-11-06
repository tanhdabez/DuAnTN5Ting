using Controller.DTO;
using DemoBanQuanAo.Models;

namespace Controller.Service
{
    public interface ICustomerService
    {
        Task<bool> AddCustomer(CustomerDto customerDto); 
        Task<CustomerDto> GetCustomerById(string Id);     
        Task<List<CustomerDto>> GetAllCustomer();      
        Task<bool> UpdateCustomer(string Id, CustomerDto updatedCustomer);   
        Task<bool> DeleteCustomer(string Id);
    }
}
