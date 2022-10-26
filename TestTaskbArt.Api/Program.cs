using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TestTaskbArt.Api.Middleware;
using TestTaskbArt.Data;
using TestTaskbArt.Data.Abstracts;
using TestTaskbArt.Data.Repositories;
using TestTaskbArt.Domain.Services;
using TestTaskbArt.Domain.Services.Abstracts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<DataContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("TestTaskbArt.Data")));
    builder.Services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());
    
    var typeAdapterConfig = TypeAdapterConfig.GlobalSettings; 
    typeAdapterConfig.Scan(typeof(ContactService).Assembly);
    var mapperConfig = new Mapper(typeAdapterConfig);
    builder.Services.AddSingleton<IMapper>(mapperConfig);
    
    builder.Services.AddTransient<IContactService, ContactService>();
    builder.Services.AddTransient<IContactRepository, ContactRepository>();
    builder.Services.AddTransient<IAccountService, AccountService>();
    builder.Services.AddTransient<IAccountRepository, AccountRepository>();
    builder.Services.AddTransient<IIncidentService, IncidentService>();
    builder.Services.AddTransient<IIncidentRepository, IncidentRepository>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapControllers();

    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.Run();
}

