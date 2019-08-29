namespace wpfGenericHost
{
    class TextService : ITextService
    {
        private string _text;

        public TextService(Settings settings)
        {
            _text = settings.Text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}