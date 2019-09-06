using GalaSoft.MvvmLight;

namespace wpfGenericHost
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _text;

        public MainWindowViewModel(ITextService textService)
        {
            _text = textService.GetText();
        }

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }
    }
}
