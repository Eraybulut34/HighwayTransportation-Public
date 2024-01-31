using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
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
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"))
);

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
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IMapper, MapsterMapper.Mapper>();
builder.Services.AddScoped<DeliveryProvider>();
builder.Services.AddScoped<VehicleProvider>();
builder.Services.AddScoped<AppUserProvider>();
builder.Services.AddScoped<ProjectProvider>();
builder.Services.AddScoped<PaymentProvider>();
builder.Services.AddScoped<CompanyProvider>();
builder.Services.AddScoped<ExpenseProvider>();
builder.Services.AddScoped<EmployeeProvider>();

// Configure authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });

// Configure authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Enable authorization
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
