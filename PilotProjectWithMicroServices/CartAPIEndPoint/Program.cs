using CartBusinessLogicLayer;
using CartBusinessLogicLayer.ExternalServices;
using CartDataAccessLayer.CartRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient("customer", config => config.BaseAddress = new System.Uri("https://localhost:7002"));



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICartRepo, CartRepo>();
builder.Services.AddScoped<IExternalCustomerServices,ExternalCustomerServices>();
builder.Services.AddScoped<ICartServices, CartServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
