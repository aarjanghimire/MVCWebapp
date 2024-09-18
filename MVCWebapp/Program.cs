using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCWebapp.Data;
using MVCWebapp.Repositories.GenericRepositories;
using NuGet.Protocol.Core.Types;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCWebappContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCWebappContext") ?? throw new InvalidOperationException("Connection string 'MVCWebappContext' not found.")));

builder.Services.AddControllers();
// Configure AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IGenericRepositories, GenericRepositories>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
