using Microsoft.AspNetCore.Localization;
using System.Globalization;
using ValdoBase.Database.Repository.Alunos;
using ValdoBase.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
IoC.Start(app);

app.UseRequestLocalization(new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture("pt-BR") });
CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

app.Run();