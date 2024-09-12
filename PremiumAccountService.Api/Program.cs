using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PremiumAccountService.Application.IInsuranceServices;
using PremiumAccountService.Application.IRepository;
using PremiumAccountService.Domain.IInMemoryCacheService;
using PremiumAccountService.Infrastructure.Context;
using PremiumAccountService.Infrastructure.InMemoryCacheService;
using PremiumAccountService.Infrastructure.InsuranceRepository;
using PremiumAccountService.Infrastructure.InsuranceServices;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InsuranceDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddSingleton<IInMemoryCoverageCacheService, MemoryCoverageCacheService>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();
builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
