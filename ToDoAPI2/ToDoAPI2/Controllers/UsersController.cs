
using Microsoft.AspNetCore.Mvc;
using toDoApi.DataAccess;
using toDoApi.Models;

namespace toDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider<User> _accessProvider;


        public UsersController(IDataAccessProvider<User> accessProvider)
        {

            _accessProvider = accessProvider;
        }
        [HttpPost]
        public Response<User> Create(User record)
        {

            return _accessProvider.Add(record);
        }
        [HttpGet("{id}")]
        public Response<User> Details(int id)
        {
           return _accessProvider.GetSingle(id);
        }

    }
}
