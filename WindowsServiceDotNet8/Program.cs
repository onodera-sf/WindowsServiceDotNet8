var builder = Host.CreateApplicationBuilder(args);
// ↓ここから追加
builder.Services.AddWindowsService();
// ↑ここまで追加
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
