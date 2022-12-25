using toDoApi.Models;

namespace toDoApi.DataAccess
{
    
    public interface IDataAccessProvider<T> 
    {
        Response<T> Add(T record);
        Response<T> Update(T record);
        Response<T> Delete(int id);
        Response<T> GetSingle(int id);
        Response<T> GetList();

    }
}