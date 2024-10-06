using Kutubxona.Service;

namespace Kutubxona.View;

public class RegView
{
    private RegService _regService;

    public RegView(RegService regService)
    {
        _regService = regService;
    }

    public RegService GetService() => _regService;
}