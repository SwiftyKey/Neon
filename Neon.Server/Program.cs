using Neon.Application.Extensions;
using Neon.Infrastructure;
using Neon.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Neon.Server.Extensions;
using Neon.Server.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Neon");
builder.Services.AddDbContext<NeonDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddRepositories();
builder.Services.RegisterMapster();
builder.Services.AddServices();
builder.Services.ConfigureIdentityService();
builder.Services.ApiAuthentication(builder.Configuration);
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddCors(options =>
{
	options.AddPolicy("ClientApp", policy =>
	{
		policy.WithOrigins("http://localhost:4200");
		policy.AllowAnyMethod();
		policy.AllowAnyHeader();
		policy.AllowCredentials();
	});
});
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
app.UseAuthorization();

app.UseCors("ClientApp");

app.MapControllers();

app.Run();