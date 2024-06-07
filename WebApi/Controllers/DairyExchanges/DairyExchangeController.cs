using Application.Contracts.DairyExchange.Commands;
using Application.Contracts.DairyExchange.Queries;
using AutoMapper;
using Domain.Models.DairyExchange;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.DairyExchanges
{
    [Route("api/[controller]")]
    [ApiController]
    public class DairyExchangeController : ControllerBase
    {
        private readonly IDairyExchangeRepository _repository;
        private readonly IMapper _mapper;

        public DairyExchangeController(IDairyExchangeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("Post")]
        public async Task<ActionResult> Post(CreateDairyExchangeDto inputs)
        {
            try
            {
                var mapData = _mapper.Map<DairyExchange>(inputs);
                await _repository.AddAsync(mapData);
                await _repository.SaveChangesAsync();
                return Ok(inputs);
        }
            catch(Exception)
            {
                return BadRequest("Invalid CustomerId");
    }

}
        [HttpGet("List")]
        public async Task<ActionResult<List<GetDairyExchangeDto>>> Get()
        {
            var data=await _repository.ListAsync();
            var mapData=_mapper.Map<List<GetDairyExchangeDto>>(data);
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
            var mapdata=_mapper.Map<GetDairyExchangeDto>(data);
            return Ok(mapdata);
        }
        [HttpPut("Update")]
        public async Task<IActionResult>Put(int id,CreateDairyExchangeDto inputs)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            try
            {
                data.Milk = inputs.Milk;
                data.MilkRate = inputs.MilkRate;
                data.CustomerId = inputs.CustomerId;
                data.DailyDevision = inputs.DailyDevision;
                await _repository.UpdateAsync(data);
                await _repository.SaveChangesAsync();
                return Ok(inputs);
            }
            catch (Exception)
            {
                return BadRequest("Invalid CustomerId");
            }
           
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                return BadRequest($"Invalid Id : {id}");
            }
            await _repository.DeleteAsync(data);
            await _repository.SaveChangesAsync();
            return Ok("Data deleted successfylly!");
        }
    }

}
