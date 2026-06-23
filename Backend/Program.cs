using Articulos_Backend.Endpoints.Almacen;
using Articulos_Backend.Endpoints.Seguridad;
using Articulos_Backend.Endpoints.Ventas;
using Articulos_Backend.Endpoints;
using Articulos_Backend.JWT;
using Articulos_Backend.Middleware;
using MTNegocios.Repositorios.Almacen;
using MTNegocios.Repositorios.Seguridad;
using MTNegocios.Repositorios.Ventas;
using MTNegocios.Repositorios;
using MTNegocios.MTEndpoints.Seguridad;
using MTNegocios.MTEndpoints.Almacen;
using MTNegocios.MTEndpoints.Ventas;
using MTNegocios.MTEndpoints.BBDD;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using MTCore_AC.Entidades;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log.txt",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 7
    ).CreateLogger();
builder.Host.UseSerilog();
var key = Encoding.UTF8.GetBytes("CLAVE_SECRETA_SECRETOSA_PORFAVOR_FUNCIONA_SOCORRO");
builder.WebHost.UseUrls("http://0.0.0.0:5000");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
string[] roles = new[]
{
    Roles.AdminSeguridad,
    Roles.AdminVentas,
    Roles.AdminAlmacen,
    Roles.AdminPedidos,
    Roles.UserVentas,
    Roles.UserPedidos,
    Roles.UserAlmacen
};
builder.Services.AddAuthorization(options =>
{
    foreach (var rol in roles)
    {
        options.AddPolicy(rol, policy =>
            policy.RequireAssertion(async context =>
            {
                var email = context.User.FindFirst("correo")?.Value;
                if (email == null)
                    return false;

                var httpContext = context.Resource as HttpContext;
                if (httpContext == null)
                    return false;

                var usuarioRolMethods = httpContext.RequestServices.GetRequiredService<UsuarioRolMethods>();

                var rolesUsuario = await usuarioRolMethods.ObtenerRolesPorUsuario(email);

                return rolesUsuario.Any(r => r.Nombre == rol);
            })
        );
    }
    options.AddPolicy(Roles.VentasAdminOUser, policy =>
       policy.RequireAssertion(async context =>
       {
           var email = context.User.FindFirst("correo")?.Value;
           if (email == null)
               return false;

           var httpContext = context.Resource as HttpContext;
           if (httpContext == null)
               return false;

           var usuarioRolMethods = httpContext.RequestServices.GetRequiredService<UsuarioRolMethods>();
           var rolesUsuario = await usuarioRolMethods.ObtenerRolesPorUsuario(email);

           return rolesUsuario.Any(r =>
               r.Nombre == Roles.AdminVentas ||
               r.Nombre == Roles.UserVentas
           );
       }));
    options.AddPolicy(Roles.AlmacenAdminOUser, policy =>
       policy.RequireAssertion(async context =>
       {
           var email = context.User.FindFirst("correo")?.Value;
           if (email == null)
               return false;

           var httpContext = context.Resource as HttpContext;
           if (httpContext == null)
               return false;

           var usuarioRolMethods = httpContext.RequestServices.GetRequiredService<UsuarioRolMethods>();
           var rolesUsuario = await usuarioRolMethods.ObtenerRolesPorUsuario(email);

           return rolesUsuario.Any(r =>
               r.Nombre == Roles.AdminAlmacen ||
               r.Nombre == Roles.UserAlmacen
           );
       }));
    options.AddPolicy(Roles.PedidosAdminOUser, policy =>
       policy.RequireAssertion(async context =>
       {
           var email = context.User.FindFirst("correo")?.Value;
           if (email == null)
               return false;

           var httpContext = context.Resource as HttpContext;
           if (httpContext == null)
               return false;

           var usuarioRolMethods = httpContext.RequestServices.GetRequiredService<UsuarioRolMethods>();
           var rolesUsuario = await usuarioRolMethods.ObtenerRolesPorUsuario(email);

           return rolesUsuario.Any(r =>
               r.Nombre == Roles.AdminPedidos ||
               r.Nombre == Roles.UserPedidos
           );
       }));
});

builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ArticuloRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ConfiguracionRepository>();
builder.Services.AddScoped<RolRepository>();
builder.Services.AddScoped<UsuarioRolRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<ClienteMethods>();
builder.Services.AddScoped<ArticuloMethods>();
builder.Services.AddScoped<UsuarioMethods>();
builder.Services.AddScoped<ConfiguracionMethods>();
builder.Services.AddScoped<PedidoMethods>();
builder.Services.AddScoped<RolMethods>();
builder.Services.AddScoped<UsuarioRolMethods>();
builder.Services.AddScoped<MigrationBBDD>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuditoriaRepository>();
builder.Services.AddScoped<AuditoriaMethods>();
builder.Services.AddSingleton<MigrationBBDD>();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapClienteEndpoints();
app.MapArticuloEndpoints();
app.MapUsuarioEndpoints();
app.MapConfiguracionEndpoints();
app.MapPedidoEndpoints();
app.MapRolEndpoints();
app.MapUsuarioRolEndpoints();
app.MapBBDDEndpoints();
app.Run();