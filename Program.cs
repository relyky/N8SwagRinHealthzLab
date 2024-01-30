var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddRinLogger(); // for Rin 監聽 HTTP 封包

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRin(); // for Rin 監聽 HTTP 封包

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseRin(); // for Rin 監聽 HTTP 封包
  app.UseSwagger(); 
  app.UseSwaggerUI();
  app.UseRinDiagnosticsHandler(); // for Rin 監聽 HTTP 封包
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
