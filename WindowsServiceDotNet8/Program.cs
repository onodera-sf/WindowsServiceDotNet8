var builder = Host.CreateApplicationBuilder(args);
// «‚±‚±‚©‚ç’Ç‰Á
builder.Services.AddWindowsService();
// ª‚±‚±‚Ü‚Å’Ç‰Á
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
