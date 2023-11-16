using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace wpfGenericHost;

sealed class TextService : ITextService
{
    private string _text;

    public TextService(IOptions<Settings> options, ILogger<TextService> logger)
    {
        _text = options.Value.Text;

        logger.LogInformation($"Text read from settings: '{options.Value.Text}'");
    }

    public string GetText()
    {
        return _text;
    }
}