using Microsoft.Extensions.Logging;

namespace wpfGenericHost
{
    class TextService : ITextService
    {
        private string _text;

        public TextService(Settings settings, ILogger<TextService> logger)
        {
            _text = settings.Text;

            logger.LogInformation($"Text read from settings: '{settings.Text}'");
        }

        public string GetText()
        {
            return _text;
        }
    }
}