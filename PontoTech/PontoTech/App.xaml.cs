﻿using PontoTech.Mvvm.View;
namespace PontoTech

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePageView());
            
        }
    }
}