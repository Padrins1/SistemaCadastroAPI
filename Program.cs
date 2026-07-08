using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using SistemaCadastroAPI.Data;
using SistemaCadastroAPI.Repositories;
using SistemaCadastroAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "Cole aqui só o token JWT"
    });
    c.DocumentFilter<JwtSecurityDocumentFilter>();
});

// JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<FuncionarioRepository>();
builder.Services.AddScoped<FuncionarioService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.UseRequestInterceptor(
            "(req) => {" +
            "  try {" +
            "    var auth = window.ui.authSelectors.authorized().toJS();" +
            "    if (auth && auth.Bearer && auth.Bearer.value) {" +
            "      req.headers['Authorization'] = 'Bearer ' + auth.Bearer.value;" +
            "    }" +
            "  } catch(e) {}" +
            "  return req;" +
            "}"
        );
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Adiciona segurança global no swagger.json (todas as operações herdam)
public class JwtSecurityDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Security ??= new List<OpenApiSecurityRequirement>();
        var req = new OpenApiSecurityRequirement();
        req[new OpenApiSecuritySchemeReference("#/components/securitySchemes/Bearer")] = new List<string>();
        swaggerDoc.Security.Add(req);
    }
}
