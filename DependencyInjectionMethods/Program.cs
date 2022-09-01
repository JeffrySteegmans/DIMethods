#region " Boilerplate code "
using DependencyInjectionMethods.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

// builder.Services.AddServiceOne();
// builder.Services.AddServiceTwo();
// builder.Services.AddDummyService();

// builder.Services.TryAddServiceOne();
// builder.Services.TryAddServiceTwo();
// builder.Services.TryAddDummyService();

// builder.Services.TryAddEnumerableServiceOne();
// builder.Services.TryAddEnumerableServiceTwo();
// builder.Services.TryAddEnumerableDummyService();

// builder.Services.TryAddServiceOneWitMultipleLifeTimes();

// builder.Services.TryAddEnumerableServiceOneWitMultipleLifeTimes();

// builder.Services.TryAddServiceOneWitMultipleLifeTimesAndTokenInterface();

// builder.Services.AddServiceResolver();

builder.Services.AddPaymentServiceResolver();

builder.Services.AddPaymentServices();

#region " Boilerplate code "
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
