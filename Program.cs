using StudentManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StudentService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
