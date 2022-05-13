﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FailToBindToResources
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public bool IsPressed { get; private set; }

        //public ResourceDictionary ButtonRes
        //{
        //    get
        //    {
        //        // Simple bind case
        //        //return IsPressed ? buttonResAccent : buttonResNormal;
        //        // Setter case
        //        //return (IsPressed ? accent.Value : normal.Value) as ResourceDictionary;
        //    }
        //}

        public Uri ButtonResSource
        {
            get
            {
                return new Uri(IsPressed ? "ms-appx:///ButtonResAccent.xaml" : "ms-appx:///ButtonResNormal.xaml");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            IsPressed = !IsPressed;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPressed)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonRes"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonResSource"));
            RequestedTheme = RequestedTheme;
        }
    }
}
