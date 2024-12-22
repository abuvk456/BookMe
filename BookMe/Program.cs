using BookMeService;
using BookMeService.IBookService;
using BookMeRepository.IBookRepository;
using BookMeRepository;
using static BookMe.Controllers.HomeController;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



//Register service and repository

builder.Services.AddTransient<IGridService, GridService>();
builder.Services.AddTransient<IGridRepository, GridRepository>();
builder.Services.AddSingleton<ImasterData,MasterService>();

builder.Configuration["GridDataFilePath"] = Path.Combine(builder.Environment.ContentRootPath, "GridData.json");

var app = builder.Build();

//Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/error-development");
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();




//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<HttpResponseExceptionFilter>();
//});
//builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
//{
//    options.InvalidModelStateResponseFactory = context =>
//        new BadRequestObjectResult(context.ModelState)
//        {
//            ContentTypes =
//            {
//                    // using static System.Net.Mime.MediaTypeNames;
//                    Application.Json,
//                    Application.Xml
//            }
//        };
//}).AddXmlSerializerFormatters();




