using GastosResidenciais.API.Middlewares;
using GastosResidenciais.Application;
using GastosResidenciais.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Modulos
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// Exceptions
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            //.WithOrigins("http://localhost:5173")
            .WithOrigins("https://gastos-residenciais-api.onrender.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowReactApp");

app.Run();
