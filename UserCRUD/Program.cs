using UserCRUD;
using UserCRUD.DataService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserCRUD.Controllers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

HomeController homeController = new HomeController();



app.Run();
