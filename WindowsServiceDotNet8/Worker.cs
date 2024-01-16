public class Worker : BackgroundService
{
  private readonly ILogger<Worker> _logger;

  /// <summary>���O�̏o�͐�t�H���_�p�X�B</summary>
  private const string OutputLogFolderPath = @"C:\Temporary\";

  /// <summary>���O�̏o�͐�t�@�C���p�X�B</summary>
  private const string OutputLogFilePath = @$"{OutputLogFolderPath}Test.log";


  public Worker(ILogger<Worker> logger)
  {
    _logger = logger;
  }

  /// <summary>
  /// �T�[�r�X���J�n���ꂽ�Ƃ��ɌĂ΂�܂��B
  /// </summary>
  /// <param name="stoppingToken"></param>
  /// <returns></returns>
  public override async Task StartAsync(CancellationToken stoppingToken)
  {
    if (Directory.Exists(OutputLogFolderPath) == false)
    {
      Directory.CreateDirectory(OutputLogFolderPath);
    }
    File.AppendAllText(OutputLogFilePath, $"StartAsync �T�[�r�X���J�n���܂����B\r\n");

    await base.StartAsync(stoppingToken);
  }

  /// <summary>
  /// �T�[�r�X���I�������Ƃ��ɌĂ΂�܂��B
  /// </summary>
  /// <param name="stoppingToken"></param>
  /// <returns></returns>
  public override async Task StopAsync(CancellationToken stoppingToken)
  {
    File.AppendAllText(OutputLogFilePath, $"StopAsync �T�[�r�X���I�����܂����B\r\n");
    File.AppendAllText(OutputLogFilePath, $"------------------------------\r\n");

    await base.StopAsync(stoppingToken);
  }

  /// <summary>
  /// �T�[�r�X�����s���ꂽ�Ƃ��ɌĂ΂�܂��B
  /// </summary>
  /// <param name="stoppingToken">�T�[�r�X�̔񓯊��L�����Z���g�[�N���B</param>
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

