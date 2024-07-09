using ECommerceApp.ProductMicroService.BusinessLayer.Abstract;
using ECommerceApp.ProductMicroService.BusinessLayer.Concrete;
using ECommerceApp.ProductMicroService.DataAccessLayer.Abstract;
using ECommerceApp.ProductMicroService.DataAccessLayer.Context;
using ECommerceApp.ProductMicroService.DataAccessLayer.EntityFramework;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext class
builder.Services.AddDbContext<ProductDbContext>();
//Services
//'typeof()' is used to obtain a 'System.Type' object for a given type in programming.
//Dependency injection systems like ASP.NET Core, typeof() is used when registering services.
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericDal<>));
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EFProductDal>();

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
