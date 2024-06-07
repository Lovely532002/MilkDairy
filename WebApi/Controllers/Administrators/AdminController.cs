using Application.Contracts.Administrators.Commands;
using AutoMapper;
using Domain.Models.Administrators;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Administrators
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string ImageUrl = "https://localhost:7105/AdminProfiles";
        public AdminController(IAdminRepository adminRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(CreateAdminDto admin)
        {
            if (admin.ProfileIcon != null)
            {
                var file=admin.ProfileIcon;
                if (file.Length > 0)
                {
                    var ext=Path.GetExtension(file.FileName);
                    var fileName=Guid.NewGuid().ToString()+ext;
                    var rootPath = _webHostEnvironment.WebRootPath;
                    var filePath=Path.Combine(rootPath, "AdminProfiles", fileName);
                    using(var stream=new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        stream.Close();
                    }
                    admin.ProfileUrl = $"{ImageUrl}/{fileName}";
                }
            }
            var mapData =_mapper.Map<Admin>(admin);
            mapData.Profile = admin.ProfileUrl;
            await _adminRepository.AddAsync(mapData);
            await _adminRepository.SaveChangesAsync();
            return Ok(admin);
        }
        [HttpGet("List")]
        public async Task<IActionResult> Get()
        {
            var data=await _adminRepository.ListAsync();
        
            if (data == null)
            {
                return BadRequest("Admin list is Empty!");
            }
            return Ok(data);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var data=await _adminRepository.GetByIdAsync(id);
            if(data == null)
            {
                return BadRequest($"No Admin data exist on id : {id}");
            }
            return Ok(data);    
        }
        [HttpPut("Update")]
        public async Task<IActionResult>Put(int id,CreateAdminDto admin)
        {
            var adminRecored=await _adminRepository.GetByIdAsync(id);
            if(adminRecored == null)
            {
                return BadRequest($"No Admin data exist on id : {id}");
            }
            if (admin.ProfileIcon != null)
            {
                var file = admin.ProfileIcon;
                if (file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString() + ext;
                    var rootPath = _webHostEnvironment.WebRootPath;
                    var filePath = Path.Combine(rootPath, "AdminProfiles", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        stream.Close();
                    }
                    admin.ProfileUrl = $"{ImageUrl}/{fileName}";
                }
            }
            adminRecored.Name = admin.Name;
            adminRecored.Email = admin.Email;
            adminRecored.Profile = admin.ProfileUrl;
            await _adminRepository.UpdateAsync(adminRecored);
            await _adminRepository.SaveChangesAsync();
            return Ok(adminRecored);    
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _adminRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"No Admin data exist on id : {id}");
            }
            try
            {
                await _adminRepository.DeleteAsync(data);
                await _adminRepository.SaveChangesAsync();
                return Ok("Data deleted successfully!");
            }
            catch(Exception)
            {
                return BadRequest("it can't be deleted due to its FK-Reference!");
            }
            
        }
    }
}
