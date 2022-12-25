using Microsoft.EntityFrameworkCore;
using toDoApi.DataAccess;

namespace toDoApi.Models
{
    public class Response<T>
    {
        public bool Status { get; set; }
        public T Record { get; set; }
        public string Message { get; set; }
        public List<T> List { get; set; }
        public int Count { get; set; }
        
    }
}
