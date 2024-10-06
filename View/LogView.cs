using Kutubxona.Service;

namespace Kutubxona.View;

public class LogView
{
    private LogService _logService;

    public LogView(LogService logService)
    {
        _logService = logService;
    }

    
    public LogService GetService() => _logService;
}