using Microsoft.Extensions.Primitives;
using System.Globalization;
using toDoApi.Models;
namespace toDoApi.DataAccess
{
    public class TodoAccessProvider : IDataAccessProvider<Todo>
    {
        private readonly PostgreContext _context;
        private Response<Todo> _response=new Response<Todo>();

        public TodoAccessProvider(PostgreContext context)
        {
            _context = context;
        }
        public Response<Todo> Add(Todo record)
        {
             
            _context.todos.Add(record);
            _context.SaveChanges();
            _response.Record = record;
            _response.Message = record.TodoId+" id'li yapılacak listeye eklendi.";
            _response.Status = true;
            _response.List = _context.todos.ToList();
            _response.Count = _context.todos.ToList().Count;
            return _response;
        }

        public Response<Todo> Delete(int id)
        {
            var entity = _context.todos.FirstOrDefault(t => t.TodoId == id);
            _response.Record = entity;
            _response.Message = entity.TodoId + " id'li bu yapılacak listeden silindi.";
            _context.todos.Remove(entity);
            _context.SaveChanges();
            _response.Status = true;
            _response.List = _context.todos.ToList();
            _response.Count = _context.todos.ToList().Count;
            return _response;
        }

        public Response<Todo> GetList()
        {
            _context.todos.ToList();
            _response.Message = "Yapılacaklar ekrana yazdırıldı.";
            _response.Status = true;
            _response.List = _context.todos.ToList();
            _response.Count = _context.todos.ToList().Count;
            return _response;
        }

        public Response<Todo> GetSingle(int id)
        {
           
           var userTodoList= _context.todos.ToList().Where(a => _context.todos.ToList().Any(b => a.UserIdFK == id));
            _response.Message = id + " id'li kullanıcının yapılacakları ekrana yazdırıldı.";
            _response.Status = true;
            _response.List = userTodoList.ToList();
            _response.Count = _context.todos.ToList().Count;
            return _response;
        }

        public Response<Todo> Update(Todo record)
        {
            Todo tmp = (from x in _context.todos.ToList()
                            where x.TodoId == record.TodoId
                            select x).FirstOrDefault();
            if (tmp == null)
            {
                _response.Message = record.TodoId + " ID'li bir kayıt yoktur.";
                return _response;
            }
            string temp = record.Title.Trim();
            string message="";
            if (record.Title == "string" || record.Title == null || record.Title == String.Empty)
            {
            }
            else
            {
                tmp.Title = record.Title;
                message = " Başlık: " + record.Title;
            }

            if (record.Detail == "string" || record.Detail == null || record.Detail == String.Empty)
            {
            }
            else
            {
                tmp.Detail = record.Detail;
                message = message + " Detay: " + record.Detail.ToString();
            }
            _context.todos.Update(tmp);
            _context.SaveChanges();
            _response.Record = record;
            _response.Message = record.TodoId+ " id'li yapılacak güncellendi.";
            _response.Status = true;
            _response.List = _context.todos.ToList();
            _response.Count = _context.todos.ToList().Count;
            return _response;
        }
    }
}
