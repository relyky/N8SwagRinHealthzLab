var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddRinLogger(); // for Rin ��ť HTTP �ʥ]

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRin(); // for Rin ��ť HTTP �ʥ]

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseRin(); // for Rin ��ť HTTP �ʥ]
  app.UseSwagger(); 
  app.UseSwaggerUI();
  app.UseRinDiagnosticsHandler(); // for Rin ��ť HTTP �ʥ]
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
