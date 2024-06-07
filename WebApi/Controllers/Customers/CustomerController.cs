using Application.Contracts.Customers.Commands;
using Application.Contracts.Customers.Queries;
using AutoMapper;
using Domain.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImageUrl = "https://localhost:7105/CustomerProfiles";

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(CreateCustomerDto customer)
        {
            if (customer.ProfileIcon != null)
            {
                var file = customer.ProfileIcon;
                if (file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + ext;
                    var rootPath = _webHostEnvironment.WebRootPath;
                    var filePath = Path.Combine(rootPath, "CustomerProfiles", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        stream.Close();
                    }
                    customer.ProfileUrl = $"{ImageUrl}/{fileName}";
                }
            }

            try
            {
                var mapData = _mapper.Map<Customer>(customer);
                mapData.Profile = customer.ProfileUrl;
                await _customerRepository.AddAsync(mapData);
                await _customerRepository.SaveChangesAsync();
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest($"Invalid CreatedBy Id ");

            }

        }
        [HttpGet("List")]
        public async Task<ActionResult<List<GetAllCustomersDto>>> Get()
        {
            var data = await _customerRepository.ListAsync();
            var mapData = _mapper.Map<List<GetAllCustomersDto>>(data);
            return Ok(mapData);
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<GetAllCustomersDto>> GetById(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Customer Data did't find on id : {id}");
            }
            return _mapper.Map<GetAllCustomersDto>(data);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(int id, UpdateCustomerDto customer)
        {
            var data = await _customerRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Customer Id : {id}");
            }

            if (customer.ProfileIcon != null)
            {
                var file = customer.ProfileIcon;
                if (file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + ext;
                    var rootPath = _webHostEnvironment.WebRootPath;
                    var filePath = Path.Combine(rootPath, "CustomerProfiles", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        stream.Close();
                    }
                    customer.ProfileUrl = $"{ImageUrl}/{fileName}";
                }
            }
            try
            {
                data.Address = customer.Address;
                data.Mobile = customer.Mobile;
                data.Name = customer.Name;
                data.UpdatedBy = customer.UpdatedBy;
                data.Profile = customer.ProfileUrl;
                data.CustomerType = customer.CustomerType;
                await _customerRepository.UpdateAsync(data);
                await _customerRepository.SaveChangesAsync();
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest($"Invalid UpdatedBy Id");
            }


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _customerRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Ivalid Customer Id : {id}");
            }
            await _customerRepository.DeleteAsync(data);
            await _customerRepository.SaveChangesAsync();
            return Ok("Data deleted successfully!");
        }
    }
}
