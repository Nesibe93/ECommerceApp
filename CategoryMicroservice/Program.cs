using ECommerceApp.CategoryMicroservice.BusinessLayer.Abstract;
using ECommerceApp.CategoryMicroservice.BusinessLayer.Concrete;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Abstract;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.Context;
using ECommerceApp.CategoryMicroservice.DataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//DbContext class
builder.Services.AddDbContext<CategoryDbContext>();
//Services
//'typeof()' is used to obtain a 'System.Type' object for a given type in programming.
//Dependency injection systems like ASP.NET Core, typeof() is used when registering services.
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericDal<>));
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
