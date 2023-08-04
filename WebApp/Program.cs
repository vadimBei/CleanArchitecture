using ApplicationServices.Implementations;
using ApplicationServices.Interfaces;
using DataAccess.Interfaces;
using DataAccess.MsSQL;
using Delivery.Interfaces;
using Delivery.NovaPoshta;
using DomainServices.Implementations;
using DomainServices.Interfaces;
using Email.Interfaces;
using Email.MailHandler;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.UseCases.Orders.BackgroundJobs;
using WebApi.UseCases.Orders.Queries.GetOrderById;
using WebApi.UseCases.Orders.Utils;
using WebApp.Extensions;
using WebApp.Interfaces;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Domain
builder.Services.AddScoped<IOrderDomainServices, OrderDomainServices>();

// Infrastructure
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IBackgroundJobService, BackgroundJobService>();
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Email
builder.Services.AddScoped<IEmailService, EmailService>();

// Application
builder.Services.AddScoped<ISecurityService, SecurityService>();

//Delivery
builder.Services.AddScoped<IDeliveryService, NovaPoshtaService>();

// Frameworks
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblies(typeof(GetOrderByIdQueryHandler).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Hangfire 
builder.Services.AddHangfire(configuration => 
    configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseErrorHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<UpdateDeliveryStatusJob>("UpdateDeliveryStatusJob", (job) => job.ExecutAsync(), Cron.Minutely);

app.MapControllers();

app.Run();
