using Application.Contracts.MilkDeliveries.Commands;
using Application.Contracts.MilkDeliveries.Queries;
using AutoMapper;
using Domain.Models.MilkDeliveries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.MilkDeliveries
{
    [Route("api/[controller]")]
    [ApiController]
    public class MilkDeliveryController : ControllerBase
    {
        private readonly IMilkDeliveryRepository _repository;
        private readonly IMapper _mapper;

        public MilkDeliveryController(IMilkDeliveryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(CreateMilkDeliveryDto input)
        {
            try
            {
                var mapData=_mapper.Map<MilkDelivery>(input);
                await _repository.AddAsync(mapData);
                await _repository.SaveChangesAsync();
                return Ok(input);
            }
            catch (Exception)
            {
                return BadRequest("Invalid StoreId");
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<List<GetAllMilkDeliveryDto>>> Get()
        {
            var data = await _repository.ListAsync();
            var mapData=_mapper.Map<List<GetAllMilkDeliveryDto>>(data);
            return Ok(mapData);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var data=await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            var mapData = _mapper.Map<GetAllMilkDeliveryDto>(data);
            return Ok(mapData);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(int id,CreateMilkDeliveryDto input)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            try
            {
                data.MilkRate = input.MilkRate;
                data.Milk = input.Milk;
                data.StoreId = input.StoreId;
                data.DailyDevision = input.DailyDevision;
                await _repository.UpdateAsync(data);
                await _repository.SaveChangesAsync();
                return Ok(input);
            }
            catch(Exception)
            {
                return BadRequest("Invalid StoreId");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            await _repository.DeleteAsync(data);
            await _repository.SaveChangesAsync();
            return Ok("Data deleted successfully!");
        }
    }
    
}
