var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddOutputCache(opt =>
{
    opt.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(30); //30 segundo de cache padrão
    opt.AddPolicy("60Segundos", builder => builder.Expire(TimeSpan.FromSeconds(60))); //politica de 60 segundos
}); 



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseOutputCache();  //middleware cache
app.Run();
