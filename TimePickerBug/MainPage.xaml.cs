namespace TimePickerBug
{
    public partial class MainPage : ContentPage
    {

        private bool _timeSelectedChanging = false;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private TimeSpan _StartTime;

        public TimeSpan StartTime
        {
            get { return _StartTime; }
            set
            {
                if (TimeSpan.Compare(_StartTime, value) != 0)
                {
                    _StartTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private void TimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
        {
            if (_timeSelectedChanging)
            {
                return;
            }
            var timeDifference = e.NewTime - e.OldTime;

            _timeSelectedChanging = true;
            this.StartTime = e.OldTime;
        }
    }

}
