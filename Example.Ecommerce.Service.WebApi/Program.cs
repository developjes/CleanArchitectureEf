using Example.Ecommerce.Application.UseCases;
using Example.Ecommerce.Persistence;
using Example.Ecommerce.Service.WebApi;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Builder

#region Add presentation project

builder.Services.AddPresentationServices(builder.Configuration);

#endregion Add presentation project

#region Add application project

builder.Services.AddApplicationServices();

#endregion Add application project

#region Add persistence project

builder.Services.AddPersistenceServices(builder.Configuration);

#endregion

#endregion Builder

WebApplication app = builder.Build();

#region App

app.AddWebApplicationServices();

app.Run();

#endregion