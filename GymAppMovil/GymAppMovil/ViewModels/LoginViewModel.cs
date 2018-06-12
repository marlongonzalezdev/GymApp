namespace GymAppMovil.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

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
            this.IsRemember = true;
            this.IsEnabled = true;
        }        
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

            if (this.User != "nestor" || this.Password !="1234")
            {
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario ó Password incorrecto...",
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
