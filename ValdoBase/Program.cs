using ValdoBase.Database.Repository.Alunos;

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
//IoC.Start(app);

app.Run();