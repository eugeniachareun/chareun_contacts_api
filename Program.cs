var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


// Singleton -> necesitamos usar el servicio acá pero también en controller. 
// Y necesitamos que en ambos lugares se use la misma instancia, para que compartan datos.
// Si es scoped, los contactos que agregue por el endpoint del controller no estarán disponibles en la lista 
// del endpoint minimal
builder.Services.AddSingleton<ContactoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/minimal/contactos", (ContactoService service) =>
{
    return Results.Ok(service.ObtenerTodos());
})
.WithName("Minimal-Obtener-Contactos")
.WithOpenApi();

app.MapControllers();

app.Run();

