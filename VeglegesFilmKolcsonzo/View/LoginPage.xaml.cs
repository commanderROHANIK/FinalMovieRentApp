using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Org.BouncyCastle.Crypto.Digests;
using VeglegesFilmKolcsonzo.Helper;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace VeglegesFilmKolcsonzo.View
{
    public sealed partial class LoginPage : Page
    {
        private Frame rootFrame = Window.Current.Content as Frame;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        async void Login(object sender, RoutedEventArgs e)
        {
            var users = DBHelper.getAllUsers();

            try
            {
                App.logedInUser = users.Where(user => user.Name.Equals(Username.Text) && user.Password.Equals(MD5Helper.CreateMD5(Password.Password))).First();
                rootFrame.Navigate(typeof(MainPage));
            } catch(InvalidOperationException)
            {
                var messageDialog = new MessageDialog("Error: User not found, please check if username and password are correct!");

                
                messageDialog.Commands.Add(new UICommand("Close"));

                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 0;

                await messageDialog.ShowAsync();
            }
        }

        void Registration(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Registration));
        }
    }
}

