using MVVMTemplate.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVVMTemplate.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();

        }
    }
}