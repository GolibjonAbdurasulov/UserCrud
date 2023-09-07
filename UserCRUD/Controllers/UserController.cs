using System.Text.Json.Serialization;
using Newtonsoft.Json;
using UserCRUD.DataService;
using UserCRUD.Domain;

namespace UserCRUD.Controllers;

public class UserController
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    [Route(Method = "POST", Path = "/")]
    public async Task CreateUser(HttpContext context)
    {
      var user=await context.Request.ReadFromJsonAsync<User>();
      if (user is not null)
      {
         var res=await _userService.Creat(user);
         if (res is not null)
         {
             string jsonData = JsonConvert.SerializeObject(res);
             context.Response.StatusCode = 200;
             await context.Response.WriteAsJsonAsync(jsonData);
         }
         else
         {
             context.Response.StatusCode = 400;
             await context.Response.WriteAsync("Kiritilgan malumotda xatolik bor");
         }
      }
      
    }
}