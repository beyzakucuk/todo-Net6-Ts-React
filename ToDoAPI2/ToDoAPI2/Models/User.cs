
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using toDoApi.DataAccess;

namespace toDoApi.Models
{
    
    public class User
    {
        
        public int UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
      //  [JsonIgnore] public virtual List<Todo> TodosList { get { return new List<Todo>();  } }


    }
}
