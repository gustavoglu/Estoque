using Estoque.Infra.Crosscutting.IoC;
using Estoque.Presentation.Api.Endpoints;
using Estoque.Presentation.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddCors(x => x.AddPolicy("*", pol => pol.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader().Build()));

NativeInjection.InjectServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("*");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.MapProductEndpoints();
app.MapProductTypeEndpoints();
app.MapInventoryMovimentationEndpoints();

app.Run();
