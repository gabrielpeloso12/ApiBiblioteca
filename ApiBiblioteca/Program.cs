using Dados.Author;
using Dados.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ORM;
using Services.Author;
using Services.Book;


#region Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Biblioteca", Version = "v1" });

    //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Description = "JWT Authorization header using the Bearer scheme.",
    //    Type = SecuritySchemeType.Http,
    //    Scheme = "bearer"
    //});

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] { }
    //    }
    //});
});
#endregion

#region Injeção de Dependência
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthorServices, AuthorServices>();
builder.Services.AddScoped<IAuthorDados, AuthorDados>();

builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IBookDados, BookDados>();
#endregion

#region App
var app = builder.Build();
#endregion

#region Banco de Dados
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<AppDbContext>();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao configurar o banco de dados: {ex.Message}");
    }
}
#endregion

#region App Settings
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();
app.Run();
#endregion