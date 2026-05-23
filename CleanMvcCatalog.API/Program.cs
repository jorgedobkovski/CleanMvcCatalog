using CleanMvcCatalog.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection; // Garante o escopo correto dos métodos de extensão
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// 1. Adiciona os serviços essenciais
builder.Services.AddControllers();
builder.Services.AddInfrastructureAPI(builder.Configuration);

// 2. Configura o Gerador do Swagger (Swashbuckle)
// Removeu-se o builder.Services.AddOpenApi() para evitar o conflito
builder.Services.AddEndpointsApiExplorer(); // Necessário para o Swagger mapear as rotas dos Controllers
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CleanMvcCatalog.API", Version = "v1" });
});

var app = builder.Build();

// 3. Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Ativa o Swagger e a Interface Visual
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("./swagger/v1/swagger.json", "CleanMvcCatalog.API v1");
        // Opcional: faz o Swagger ser a página inicial da API (acessível direto em http://localhost:porta/)
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("DevelopmentCors");

app.UseAuthorization();

app.MapControllers();

app.Run();