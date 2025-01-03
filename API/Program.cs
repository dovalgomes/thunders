using API.Middlewares;
using Aplicacao.Servicos.IoC;
using Infraestrutura.Dados.SqlServer.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.InjecaoAplicacao(builder.Configuration);

// Configura logs
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<ResultFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(conf =>
{
    conf.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Thunders lista de tarefas",
        Version = "v1",
    });

    var arquivoXml = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var caminhoXml = Path.Combine(AppContext.BaseDirectory, arquivoXml);
    conf.IncludeXmlComments(caminhoXml);

    conf.IgnoreObsoleteActions();
    conf.IgnoreObsoleteProperties();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseDeveloperExceptionPage();
//}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
