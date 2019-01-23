using System;
using System.Security.Cryptography;
using Xamarin.Forms;

namespace pokemonApp
{
    public class Splash : ContentPage
    {
        Image SplashImage;
        public Splash()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();

            SplashImage = new Image
            {
                Source = ImageSource.FromResource("logo.png"),
                WidthRequest = 256,
                HeightRequest = 256
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(SplashImage);

            this.BackgroundColor = Color.FromHex("#FFFF00");
            this.Content = sub;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SplashImage.ScaleTo(1, 2000);

            await SplashImage.ScaleTo(0.9, 1000, Easing.Linear);

            await SplashImage.ScaleTo(1, 1200, Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new MainPage());
            //{
              //  BarBackgroundColor = Color.Transparent,
              //  BarTextColor = Color.FromHex("#FFFF00")
            //};
        }
    }

}