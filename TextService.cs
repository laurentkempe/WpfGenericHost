using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace wpfGenericHost;

internal sealed class TextService : ITextService
{
    private readonly string _text;

    public TextService(IOptions<Settings> options, ILogger<TextService> logger)
    {
        _text = options.Value.Text;

        logger.LogInformation("Text read from settings: \'{ValueText}\'", options.Value.Text);
    }

    public string GetText()
    {
        return _text;
    }
}