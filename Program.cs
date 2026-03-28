var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Scoped -> necesitamos una instancia acá y otra en controller
builder.Services.AddScoped<ContactoService>();

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

app.Run();

