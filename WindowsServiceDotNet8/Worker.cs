public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;

  /// <summary>ログの出力先フォルダパス。</summary>
  private const string OutputLogFolderPath = @"C:\Temporary\";

  /// <summary>ログの出力先ファイルパス。</summary>
  private const string OutputLogFilePath = @$"{OutputLogFolderPath}Test.log";


  public Worker(ILogger<Worker> logger)
  {
    _logger = logger;
  }

  /// <summary>
  /// サービスが開始されたときに呼ばれます。
  /// </summary>
  /// <param name="stoppingToken"></param>
  /// <returns></returns>
  public override async Task StartAsync(CancellationToken stoppingToken)
  {
    if (Directory.Exists(OutputLogFolderPath) == false)
    {
      Directory.CreateDirectory(OutputLogFolderPath);
    }
    File.AppendAllText(OutputLogFilePath, $"StartAsync サービスを開始しました。\r\n");

    await base.StartAsync(stoppingToken);
  }

  /// <summary>
  /// サービスが終了したときに呼ばれます。
  /// </summary>
  /// <param name="stoppingToken"></param>
  /// <returns></returns>
  public override async Task StopAsync(CancellationToken stoppingToken)
  {
    File.AppendAllText(OutputLogFilePath, $"StopAsync サービスを終了しました。\r\n");
    File.AppendAllText(OutputLogFilePath, $"------------------------------\r\n");

    await base.StopAsync(stoppingToken);
  }

  /// <summary>
  /// サービスが実行されたときに呼ばれます。
  /// </summary>
  /// <param name="stoppingToken">サービスの非同期キャンセルトークン。</param>
  /// <returns></returns>
  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    while (!stoppingToken.IsCancellationRequested)
    {
      File.AppendAllText(OutputLogFilePath, $"{DateTime.Now}\r\n");

      if (_logger.IsEnabled(LogLevel.Information))
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      }
      await Task.Delay(1000 * 60, stoppingToken);
    }
  }
}

