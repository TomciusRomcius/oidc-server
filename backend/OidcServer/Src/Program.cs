using OidcServer.Admin.AdminLogin;
using OidcServer.Configurations;

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();