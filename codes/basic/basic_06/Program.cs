using ZLogger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(); // �α� �߰�
builder.Services.AddControllers();

// �α� ����
builder.Logging.ClearProviders();
builder.Logging.AddZLoggerConsole();

var app = builder.Build();

app.UseRouting();

// ������ �ùٸ��� ���� �ʾ����Ƿ� �ּ� ó�� �Ѵ�
//app.UseLoadRequestDataMiddlerWare();
//app.UseCheckUserSessionMiddleWare();


app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

IConfiguration configuration = app.Configuration;
DBManager.Init(configuration);

app.Run(configuration["ServerAddress"]);