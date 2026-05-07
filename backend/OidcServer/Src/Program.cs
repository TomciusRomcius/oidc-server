using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OidcServer.Admin.AdminLogin;
using OidcServer.Admin.Login;
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.Cookie.HttpOnly = true;
        // TODO: https and SecurePolicy.Always
        opts.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        // TODO: setup to strict or lax after setting up reverse proxy
        opts.Cookie.SameSite = SameSiteMode.None;
        
        opts.ExpireTimeSpan = TimeSpan.FromHours(8);
        opts.SlidingExpiration = true;
        
        opts.LoginPath = "/login";
        opts.LogoutPath = "/logout";
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(opts => opts.WithOrigins("http://localhost:4200").AllowCredentials().AllowAnyHeader().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
