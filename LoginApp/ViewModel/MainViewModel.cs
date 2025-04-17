using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using LoginApp.Model;
using LoginApp.Data.Repositories;
using LoginApp.Utils;
using LoginApp.Utils.Commands;
using LoginApp.Utils.Services.Interfaces;


namespace LoginApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateToLoginViewCommand { get; set; }

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToLoginViewCommand = new RelayCommand(() => NavigationService.NavigateTo<UserLoginViewModel>());
            NavigationService.NavigateTo<UserLoginViewModel>();
        }
    }
}

