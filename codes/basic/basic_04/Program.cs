var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(); // �α� �߰�
builder.Services.AddControllers();

// �α� ����
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.MapDefaultControllerRoute();

IConfiguration configuration = app.Configuration;
DBManager.Init(configuration);

app.Run(configuration["ServerAddress"]);