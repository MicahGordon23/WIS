using WIS_PrototypeAPI.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddTransient<DbIntializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Database initializer
	using var scope = app.Services.CreateScope();

	var services = scope.ServiceProvider;

	var initializer = services.GetRequiredService<DbIntializer>();

	//initializer.Run();
 }



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
