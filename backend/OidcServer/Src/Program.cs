using Microsoft.EntityFrameworkCore;
using OidcServer.Admin.AdminLogin;
using OidcServer.Configurations;
using OidcServer.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddOptions<AdminCredentialsConfiguration>()
    .Bind(builder.Configuration.GetSection("AdminCredentials"))
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddOptions<JwtConfiguration>()
    .Bind(builder.Configuration.GetSection("Jwt"))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("Postgres") ??
                          throw new ArgumentException("ConnectionStrings__Postgres not provided");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
