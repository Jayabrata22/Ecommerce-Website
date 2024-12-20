using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EcommerceContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce.connectionString"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IgenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("https://localhost:4200") // Replace with your Angular app's origin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
//anything up here called the service
var app = builder.Build();
//anything down here are middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5112","https://localhost:7292"));
app.UseCors("AllowSpecificOrigins");
app.MapControllers();

try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<EcommerceContext>();
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch(System.Exception ex)
{
    Console.WriteLine(ex.ToString());
    throw;
}
app.Run();
