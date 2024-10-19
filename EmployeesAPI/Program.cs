using EmployeesAPI;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureDefaultServices();
builder.ConfigureBusinessLogicServices();

var app = builder.Build();

app.ConfigureMiddlewares();

app.Run();
