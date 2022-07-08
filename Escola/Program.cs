using Escola.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseInMemoryDatabase("Escola"));

// colocar o Bd
//builder.Services.AddDbContext<EscolaContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=escola;User ID=root;Password=341265"));



builder.Services.AddDbContext<EscolaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CodeGirls")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
