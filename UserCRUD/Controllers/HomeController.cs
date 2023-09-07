namespace UserCRUD.Controllers;

public class HomeController
{
    [Route(Method = "GET", Path = "/")]
    public async Task Index(HttpContext context)
    {
        await context.Response.WriteAsync("Hello from server!");
    }
}