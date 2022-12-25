using toDoApi.Models;

namespace toDoApi.DataAccess
{
    public class UserAccessProvider : IDataAccessProvider<User>
    {
        private readonly PostgreContext _context;
        private Response<User> _response=new Response<User>();
        public UserAccessProvider(PostgreContext context)
        {
            _context= context;
        }
        public Response<User> Add(User record)
        {
            
            _response=new Response<User>();
            _context.users.Add(record);
            _context.SaveChanges();
            _response.Record = record;
            _response.Message = record.UserId + " id'li bu kullanıcı listeye eklendi.";
            _response.Status = true;
            _response.List = _context.users.ToList();
            _response.Count = _context.users.ToList().Count;
            return _response;
        }

        public Response<User> Delete(int id)
        {
            var entity = _context.users.FirstOrDefault(t => t.UserId == id);
            _response.Record = entity;
            _response.Message = entity.UserId + " id'li bu kullanıcı listeden silindi.";
            _context.users.Remove(entity);
            _context.SaveChanges();
            _response.Status = true;
            _response.List = _context.users.ToList();
            _response.Count = _context.users.ToList().Count;
            return _response;
        }

        public Response<User> GetList()
        {
             
            if (_context.users.ToList().Count()==0)
            {
                _response.Message = "Liste boş!";
                return _response;
            }
            _context.users.ToList();
            _response.Message = "Kullanıcılar ekrana yazdırıldı.";
            _response.Status = true;
            _response.List = _context.users.ToList();
            _response.Count = _context.users.ToList().Count;
            return _response;
        }

        public Response<User> GetSingle(int id)
        {
            var entity= _context.users.FirstOrDefault(t => t.UserId == id);
           if(entity==null)
            {
                _response.Message = "Böyle bir kullanıcı yoktur.";
                return _response;
            }
            _response.Record = entity;
            _response.Message = entity.UserId + " id'li kullanıcı ekrana yazdırıldı.";
            _response.Status = true;
            _response.List = _context.users.ToList();
            _response.Count = _context.users.ToList().Count;
            return _response;
        }

        public Response<User> Update(User record)
        {
            _context.users.Update(record);
            _context.SaveChanges();
            _response.Record = record;
            _response.Message = record.UserId + " id'li kullanıcı güncellendi.";
            _response.Status = true;
            _response.List = _context.users.ToList();
            _response.Count = _context.users.ToList().Count;
            return _response;
        }
    }
}
