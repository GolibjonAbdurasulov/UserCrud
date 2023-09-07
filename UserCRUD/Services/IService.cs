using UserCRUD.Domain;

namespace UserCRUD.DataService;

public interface IService<T,TId> where T : BaseModel
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetById(TId id);
    public Task<T> Creat(T context);
    public Task<T> Put(T context);
    public Task<T> Patch(TId id,string propKey,object propValue);
    public Task Delete(TId id);
    public Task Delete(T context);
}