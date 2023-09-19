using DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// creamos inyección de dependencias para inyectar la configuración de la base de datos.
builder.Services.AddDbContext<Bar_dbContext>(options =>
    // agregamos las opciones de conexión agregadas en el archivo appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("BarConnection"))
);

var app = builder.Build();

/*
// Debemos hacer que se cree la Base de Datos al ejecutar la aplicación.
using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<Bar_dbContext>();
    Context.Database.Migrate(); // Migra la BD creada en las clases
}
*/

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
