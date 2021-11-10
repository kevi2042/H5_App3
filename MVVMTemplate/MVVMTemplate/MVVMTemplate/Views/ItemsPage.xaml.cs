using MVVMTemplate.Models;
using MVVMTemplate.ViewModels;
using MVVMTemplate.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMTemplate.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

            // for at der dukker en pop up bliver denne subscribe nød til at ligge i main delen af appen.
            // i dette tilfælde er det her i AppShell
            // Typen af subscribe er den sender der bliver send fra.
            MessagingCenter.Subscribe<ItemDetailViewModel>(new ItemDetailViewModel(),
                "DeleteItem", async (sender) =>
                {
                    var answer = await DisplayAlert("Delete Item", $"The item will be deleted", "OK", "Cancel");
                    MessagingCenter.Send(this, "ConfirmDelete", answer);
                });

            MessagingCenter.Subscribe<NewItemViewModel>(new NewItemViewModel(),
                "NewItem", (sender) =>
                {
                    DisplayAlert("New Item", $"A New Item has been Created", "OK");
                });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}