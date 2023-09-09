using EntBa_Core.Database;
using EntBa_Core.NationalRegisters.Implementation;
using EntBa_Core.NationalRegisters.Interfaces;
using EntBa_WebBackend.Middleware;
using EntBa_Core.Services.Implementation;
using EntBa_Core.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<EntBaDbContext>();
//services
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IUserService, UserService>();
//registers
builder.Services.AddScoped<ILicensePlateRegister, LicensePlateRegister>();
builder.Services.AddScoped<IOwnershipRegister, OwnershipRegister>();
builder.Services.AddScoped<IPhysicalPersonRegister, PhysicalPersonRegister>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();

app.Run();
