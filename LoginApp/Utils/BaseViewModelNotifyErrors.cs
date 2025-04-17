using System.Collections;
using System.ComponentModel;

namespace LoginApp.Utils
{
    public abstract partial class BaseViewModel : INotifyDataErrorInfo
    {
        private string _errorMessage = string.Empty;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        public bool HasErrors => !string.IsNullOrEmpty(_errorMessage);

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return ErrorMessage;
        }
    }
}
