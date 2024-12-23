using Cibertec.Pokemon.Application.DI;
using Cibertec.Pokemon.Domain.Repositories;
using Cibertec.Pokemon.Infraestructure.Context;
using Cibertec.Pokemon.Infraestructure.DI;
using Cibertec.Pokemon.Infraestructure.Repositories;
using Cibertec.Pokemon.Infraestructure.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddApplicationServices();

builder.Services.AddLogger(builder.Configuration);
builder.Services.AddSqlServer<PokemonDbContext>(builder.Configuration.GetConnectionString("PokemonDbContext"));

builder.Services.AddTransient<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<PokemonService>();



var app = builder.Build();
app.UseCors();

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
