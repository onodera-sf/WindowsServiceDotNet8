var builder = Host.CreateApplicationBuilder(args);
// ����������ǉ�
builder.Services.AddWindowsService();
// �������܂Œǉ�
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
