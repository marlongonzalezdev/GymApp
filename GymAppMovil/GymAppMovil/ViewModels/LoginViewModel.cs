namespace GymAppMovil.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;

    public class LoginViewModel : BaseViewModel
    {        

        #region Attributes
        private string user;
        private string password;
        private bool isRemember;
        private bool isEnabled;
        #endregion

        #region Properties
        public string User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRemember
        {
            get { return this.isRemember; }
            set { SetValue(ref this.isRemember, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }        
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.apiService = new ApiService();            
            this.IsRemember = true;
            this.IsEnabled = true;
        }
        
        #endregion

        #region Services
        private ApiService apiService;
        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.User))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un Usuario...",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un Password...",
                    "Aceptar");
                return;
            }

            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }            

            var token = await this.apiService.GetAccess("http://192.168.1.5:45455", this.User, this.Password);

            if (token == null)
            {
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Intentelo nuevamente.",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Aceptar");

                this.Password = string.Empty;

                return;
            }

            this.IsEnabled = true;
            this.User = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Home = new HomeViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        private void Register()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
