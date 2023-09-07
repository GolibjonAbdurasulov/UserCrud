using System.Reflection;
using Microsoft.AspNetCore.Components;
using UserCRUD.Controllers;
using UserCRUD.DataService;

namespace UserCRUD;

public class ControllerManager
{
    private UserController _userController;
    private UserService _userService;
    public ControllerManager()
    {
        _userService = new UserService(new DataContext());
        _userController = new UserController(_userService);
    }
    public void RegisterAllActions(WebApplication application)
    {
        var allControllers = typeof(ControllerManager)
            .GetFields().Where(x => x.Name.Contains("Controller"));

        foreach (var controller in allControllers)
        {
            var allMethods = controller.FieldType
                .GetMethods()
                .Where(x => x.GetCustomAttribute<RouteAttribute>() != null);
            foreach (var method in allMethods)
            {
                RouteAttribute attribute = method.GetCustomAttribute<RouteAttribute>();
                Console.WriteLine("{0} - {1} - {2}", attribute.Path, attribute.Method, method.Name);

                switch (attribute.Method)
                {
                    case "GET":
                        application.MapGet(attribute.Path, async (context) =>
                            await Task.FromResult(method.Invoke(controller.GetValue(this), new[] { context })));
                        break;
                    
                    case "POST":
                        application.MapPost(attribute.Path, async (context) => 
                            await Task.FromResult(method.Invoke(controller.GetValue(this), new[] { context })));
                        break;
                }
            }
        }
    }
}