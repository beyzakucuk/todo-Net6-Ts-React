
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using toDoApi.DataAccess;

namespace toDoApi.Models
{
    
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
       // [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime Date { get; set; }
        [ForeignKey("UserIdFK")]

        public int UserIdFK { get; set; }

    //    [JsonIgnore] public virtual User UserT { get; set; }


    }
}