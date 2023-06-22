using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Specification.Data;
using Specification.Models;
using Specification.Specification;

namespace Specification.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IAsyncRepository<User> _efRepository;

        public WeatherForecastController(DataContext dataContext, IAsyncRepository<User> efRepository)
        {
            _dataContext = dataContext;
            //var user = new User() { Name = "A", Books = new List<Book>() { new Book() { Name = "ABook" }, new Book() { Name = "ABook1" } } };
            //var user2 = new User() { Name = "B", Books = new List<Book>() { new Book() { Name = "BBook" }, new Book() { Name = "BBook1" } } };
            //_dataContext.Users.Add(user);
            //_dataContext.Users.Add(user2);
            //_dataContext.SaveChanges();
            _efRepository = efRepository;
        }

        //[HttpGet(Name = "Get/{userId}")]
        //public IActionResult Get(int userId)
        //{
        //    var user = new UserWithBooksSpecification(userId); 
        //    return Ok(user);
        //}

        [HttpGet(Name = "GetAll")]
        public async Task<IReadOnlyList<User>> GetAll()
        {
            var userSpec = new UserWithBooksSpecification(); 
            var user = await _efRepository.ListAsync(userSpec);
            //var user = await _dataContext.Users.ToListAsync();
            return user;
        }
    }
}