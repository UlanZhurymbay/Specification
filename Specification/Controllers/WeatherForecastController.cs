using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Specification.Data;
using Specification.Models;
using Specification.Services;
using Specification.Specification;

namespace Specification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEnumerable<IStrategy> _strategies;

        public WeatherForecastController(
            IEnumerable<IStrategy> strategies
            )
        {
            _strategies = strategies;
        }


        [HttpGet(Name = "GetAll")]
        public async Task<List<int>> GetAll()
        { 
            var list = new List<int>();
            list.Add(_strategies.FirstOrDefault(x => x.Operator == Operator.Add)?.Operation(10, 10) ?? 0);
            list.Add(_strategies.FirstOrDefault(x => x.Operator == Operator.Multiply)?.Operation(10, 10) ?? -1);
            return list;
        }
    }
}