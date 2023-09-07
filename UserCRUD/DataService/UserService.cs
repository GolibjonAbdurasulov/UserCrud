using UserCRUD.Domain;

namespace UserCRUD.DataService;

public class UserService : IService<User,long>
{
    private readonly DataContext _dbContext;

    public UserService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<User>> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public async Task<User> GetById(long id) 
        => _dbContext.Users.Where(user => user.Id == id).FirstOrDefault();
    

    public async Task<User> Creat(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public async Task<User> Put(User user)
    {
        User userData = await GetById(user.Id);
        userData = new User
        {
            Id = user.Id,
            Name = user.Name,
            Syename = user.Syename,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Password = user.Password
        };
        _dbContext.SaveChanges();
        return userData;
    }

    public async Task<User> Patch(long id, string propKey, object? propValue)
    {
        User userData = await GetById(id);

        var propInfo = userData.GetType().GetProperty(propKey);
        if (propInfo is not null)
        {
            propInfo.SetValue(userData,propValue);   
        }
        else
        {
            throw new Exception("Not found property");
        }

        _dbContext.SaveChanges();
        return userData;
    }

    public async Task Delete(long id)
    {
        var user = await GetById(id);
        await Delete(user);
    }

    public async Task Delete(User user)
    {
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
    }
}