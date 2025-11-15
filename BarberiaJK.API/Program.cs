using BarberiaJK.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ? CONFIGURAR LA CONEXIÓN A LA BASE DE DATOS 
builder.Services.AddDbContext<BarberiaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? REGISTRAR LOS REPOSITORIOS 
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();

// Add services to the container. 
builder.Services.AddControllers();

// ? CONFIGURAR SWAGGER / OPENAPI 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ? PROBAR LA CONEXIÓN A LA BASE DE DATOS AL INICIAR 
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BarberiaContext>();
    try
    {
        var canConnect = context.Database.CanConnect();
        if (canConnect)
        {
            Console.WriteLine("? Conexión a la base de datos exitosa!");
            Console.WriteLine($"  Base de datos: {context.Database.GetDbConnection().Database}");
        }
        else
        {
            Console.WriteLine("? No se pudo conectar a la base de datos");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"? Error al conectar a la base de datos: {ex.Message}");
    }
}

// Configure the HTTP request pipeline. 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();