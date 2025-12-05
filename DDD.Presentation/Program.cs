using DDD.Infrastructure;
using DDD.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; 
});
builder.Services.AddScoped<DDD.Presentation.Services.EstadoService>();
builder.Services.AddScoped<DDD.Presentation.Services.CidadeService>();
builder.Services.AddScoped<DDD.Presentation.Services.LocalService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("TodasPortas", builder =>
    {
        builder.AllowAnyOrigin()  
               .AllowAnyMethod()   
               .AllowAnyHeader();  
    });
});

builder.Services.AddDbContext<WebLocalizeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true; 
    options.LowercaseQueryStrings = true; 
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WebLocalizeDbContext>();
    DatabaseSeeder.Seed(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TodasPortas"); 
app.UseAuthorization();
app.MapControllers();

app.Run();
