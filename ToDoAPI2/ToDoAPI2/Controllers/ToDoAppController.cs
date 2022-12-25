
using Microsoft.AspNetCore.Mvc;
using toDoApi.DataAccess;
using toDoApi.Models;

namespace toDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoAppController : ControllerBase
    {

        private readonly IDataAccessProvider<Todo> _accessProvider;


        public ToDoAppController(IDataAccessProvider<Todo> accessProvider)
        {
            _accessProvider = accessProvider;

        }

        [HttpPost]
        public Response<Todo> Create(Todo record)
        {

            return _accessProvider.Add(record);

        }

        [HttpGet("{id}")]
        public Response<Todo> Details(int id)
        {
            return _accessProvider.GetSingle(id);
        }

        [HttpPut]
        public Response<Todo> Edit(Todo record)
        {
            return _accessProvider.Update(record);
        }

        [HttpDelete("{id}")]
        public Response<Todo> Delete(int id)
        {
           return _accessProvider.Delete(id);
        }

    }
}
