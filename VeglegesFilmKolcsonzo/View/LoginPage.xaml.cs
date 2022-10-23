﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Org.BouncyCastle.Crypto.Digests;
using VeglegesFilmKolcsonzo.Helper;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VeglegesFilmKolcsonzo.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private Frame rootFrame = Window.Current.Content as Frame;

        public LoginPage()
        {
            this.InitializeComponent();
        }

        void Login(object sender, RoutedEventArgs e)
        {
            var usrs = DBHelper.getAllUsers();
            var md5 = "";

            foreach (var user in usrs)
            {
                if (user.Name.Equals(Username.Text) && user.Password.Equals(MD5Helper.CreateMD5(Password.Password)))
                {
                    rootFrame.Navigate(typeof(MainPage));
                    break;
                }
            }
        }

        void Registration(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(Registration));
        }
    }
}

