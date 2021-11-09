using MVVMTemplate.ViewModels;
using MVVMTemplate.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MVVMTemplate
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            // for at der dukker en pop up bliver denne subscribe nød til at ligge i main delen af appen.
            // i dette tilfælde er det her i AppShell
            // Typen af subscribe er den sender der bliver send fra.
            MessagingCenter.Subscribe<ItemDetailViewModel>(new ItemDetailViewModel(),
                "DeleteItem", async (sender) =>
                {
                    var answer = await DisplayAlert("Delete Item", $"The item will be deleted", "OK", "Cancel");
                    MessagingCenter.Send(this, "ConfirmDelete", answer);
                });
        }

    }
}
