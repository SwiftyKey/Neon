using Neon.Application.Extensions;
using Neon.Infrastructure;
using Neon.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Neon.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Neon");
builder.Services.AddDbContext<NeonDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

var workingDirectory = Environment.CurrentDirectory + "\\images";

builder.Services.AddRepositories();
builder.Services.RegisterMapster();
builder.Services.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

app.Run();
