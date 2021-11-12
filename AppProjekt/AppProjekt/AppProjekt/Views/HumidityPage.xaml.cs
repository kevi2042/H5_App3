using AppProjekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HumidityPage : ContentPage
    {
        HumidityViewModel _viewModel;

        public HumidityPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HumidityViewModel();
        }

        protected override void OnAppearing()
        {
            // Så refreshes refreshviewer når den dukker op
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}