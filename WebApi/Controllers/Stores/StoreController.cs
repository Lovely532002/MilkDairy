using Application.Contracts.Stores.Commands;
using Application.Contracts.Stores.Queries;
using AutoMapper;
using Domain.Models.MilkDeliveries;
using Domain.Models.Stores;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Stores
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(CreateMilkStoreDto input)
        {
            try
            {
                var mapData = _mapper.Map<MilkStore>(input);
                await _storeRepository.AddAsync(mapData);
                await _storeRepository.SaveChangesAsync();
                return Ok(input);
            }
            catch (Exception)
            {
                return BadRequest($"Invalid CreatedBy Id ");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<List<GetAllMilkStoteDto>>> Get()
        {
            var data = await _storeRepository.ListAsync();
            var mapData = _mapper.Map<List<GetAllMilkStoteDto>>(data);
            return Ok(mapData);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _storeRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            var mapData = _mapper.Map<GetAllMilkStoteDto>(data);
            return Ok(mapData);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(int id, UpdateMilkStoreDto input)
        {
            var data = await _storeRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            try
            {
                data.Name = input.Name;
                data.UpdatedBy = input.UpdatedBy;
                data.Address = input.Address;
                await _storeRepository.UpdateAsync(data);
                await _storeRepository.SaveChangesAsync();
                return Ok(input);
            }
            catch (Exception)
            {
                return BadRequest("Invalid UpdatedBy Id");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _storeRepository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            await _storeRepository.DeleteAsync(data);
            await _storeRepository.SaveChangesAsync();
            return Ok("Data deleted successfully!");
        }
    }
}
