using AppProjekt.Repository;
using AppProjekt.Services;
using System;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProjekt
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();
            MonkeyCache.SQLite.Barrel.ApplicationId = "MyApp";
            MainPage = new AppShell();

            var container = TinyIoCContainer.Current;

            container.Register<IMeasurementService, MeasurementService>();

            container.Register<IGenericRepository, GenericRepository>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
