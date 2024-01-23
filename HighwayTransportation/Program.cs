using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Domain;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Npgsql;
using HighwayTransportation.Providers;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IGenericService<AppUser>, GenericService<AppUser>>();
builder.Services.AddScoped<IGenericService<AddressItem>, GenericService<AddressItem>>();
builder.Services.AddScoped<IGenericService<Company>, GenericService<Company>>();
builder.Services.AddScoped<IGenericService<CompanyAddress>, GenericService<CompanyAddress>>();
builder.Services.AddScoped<IGenericService<Delivery>, GenericService<Delivery>>();
builder.Services.AddScoped<IGenericService<Employee>, GenericService<Employee>>();
builder.Services.AddScoped<IGenericService<Expense>, GenericService<Expense>>();
builder.Services.AddScoped<IGenericService<Payment>, GenericService<Payment>>();
builder.Services.AddScoped<IGenericService<Project>, GenericService<Project>>();
builder.Services.AddScoped<IGenericService<Role>, GenericService<Role>>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<AppUserService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<DeliveryService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IMapper, MapsterMapper.Mapper>();
builder.Services.AddScoped<DeliveryProvider>();
builder.Services.AddScoped<VehicleProvider>();
builder.Services.AddScoped<AppUserProvider>();
builder.Services.AddScoped<ProjectProvider>();
builder.Services.AddScoped<PaymentProvider>();
builder.Services.AddScoped<CompanyProvider>();
builder.Services.AddScoped<ExpenseProvider>();
builder.Services.AddScoped<EmployeeProvider>();



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
